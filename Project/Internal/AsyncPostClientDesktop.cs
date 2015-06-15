using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kazyx.RemoteApi
{
    internal class AsyncPostClient
    {
        private static readonly HttpClient mClient = new HttpClient();

        /// <summary>
        /// Asynchronously POST a request to the endpoint.
        /// Response will be returned asynchronously.
        /// </summary>
        /// <param name="endpoint">URL of the endpoint.</param>
        /// <param name="body">Reqeust body.</param>
        /// <returns></returns>
        internal static async Task<string> PostAsync(Uri endpoint, string body, CancellationTokenSource cancel = null)
        {
            if (endpoint == null || body == null)
            {
                throw new ArgumentNullException();
            }

            var content = new StringContent(body);
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            try
            {
                Task<HttpResponseMessage> task;
                if (cancel != null)
                {
                    task = mClient.PostAsync(endpoint, content, cancel.Token);
                }
                else
                {
                    task = mClient.PostAsync(endpoint, content);
                }

                var response = await task;
                if (response.IsSuccessStatusCode)
                {
                    // ReadAsString fails in case of charset=utf-8
                    return Encoding.UTF8.GetString(await response.Content.ReadAsByteArrayAsync());
                }
                else
                {
                    Debug.WriteLine("Http Status Error: " + response.StatusCode);
                    throw new RemoteApiException((int)response.StatusCode);
                }
            }
            catch (RemoteApiException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                if (e is TaskCanceledException || e is OperationCanceledException)
                {
                    Debug.WriteLine("Request cancelled: " + e.StackTrace);
                    throw new RemoteApiException(StatusCode.Cancelled);
                }
                else
                {
                    Debug.WriteLine("HttpPost Exception: " + e.StackTrace);
                    throw new RemoteApiException(StatusCode.NetworkError);
                }
            }
        }
    }
}
