using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Windows.Web.Http;

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

            var content = new HttpStringContent(body);
            content.Headers["Content-Type"] = "application/json";

            CancellationTokenRegistration cancelReg;

            try
            {
                var task = mClient.PostAsync(endpoint, content);
                if (cancel != null)
                {
                    cancelReg = cancel.Token.Register(() =>
                    {
                        try
                        {
                            task.Cancel();
                        }
                        catch { Debug.WriteLine("Failed to cancel request: " + body); }
                    });
                }
                var response = await task;
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
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
            finally
            {
                if (cancel != null)
                {
                    cancelReg.Dispose();
                }
            }
        }
    }
}
