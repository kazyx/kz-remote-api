using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace Kazyx.RemoteApi
{
    internal class AsyncPostClient
    {
        /// <summary>
        /// Asynchronously POST a request to the endpoint.
        /// Response will be returned asynchronously.
        /// </summary>
        /// <param name="endpoint">URL of the endpoint.</param>
        /// <param name="body">Reqeust body.</param>
        /// <returns></returns>
        internal static Task<string> PostAsync(Uri endpoint, string body, CancellationTokenSource cancel = null)
        {
            if (endpoint == null || body == null)
            {
                throw new ArgumentNullException();
            }

            var tcs = new TaskCompletionSource<string>();

            var request = HttpWebRequest.Create(endpoint) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            Debug.WriteLine(body);
            var data = Encoding.UTF8.GetBytes(body);

            var ResponseHandler = new AsyncCallback((res) =>
            {
                try
                {
                    var result = request.EndGetResponse(res) as HttpWebResponse;
                    if (result == null)
                    {
                        tcs.TrySetException(new RemoteApiException(StatusCode.NetworkError));
                        Debug.WriteLine("AsyncPostClient: No result");
                        return;
                    }
                    var code = result.StatusCode;
                    if (code == HttpStatusCode.OK)
                    {
                        using (var reader = new StreamReader(result.GetResponseStream()))
                        {
                            var resbody = reader.ReadToEnd();
                            if (string.IsNullOrEmpty(resbody))
                                tcs.TrySetException(new RemoteApiException(StatusCode.IllegalResponse));
                            else
                                tcs.TrySetResult(resbody);
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Http Status Error: " + code);
                        tcs.TrySetException(new RemoteApiException((int)code));
                    }
                }
                catch (WebException e)
                {
                    var result = e.Response as HttpWebResponse;
                    if (result != null)
                    {
                        Debug.WriteLine("Http Status Error: " + result.StatusCode);
                        tcs.TrySetException(new RemoteApiException((int)result.StatusCode));
                    }
                    else
                    {
                        Debug.WriteLine("WebException: " + e.Status);
                        tcs.TrySetException(new RemoteApiException(StatusCode.NetworkError));
                    }
                };
            });

            request.BeginGetRequestStream((res) =>
            {
                using (var stream = request.EndGetRequestStream(res))
                {
                    stream.Write(data, 0, data.Length);
                }
                request.BeginGetResponse(ResponseHandler, null);
            }, null);

            return tcs.Task;
        }
    }
}
