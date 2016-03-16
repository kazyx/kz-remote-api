using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kazyx.RemoteApi
{
    /// <summary>
    /// Base of service clients.
    /// </summary>
    public abstract class ApiClient
    {
        private readonly Uri endpoint;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint">Endpoint URL of this service.</param>
        protected ApiClient(Uri endpoint)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException();
            }
            this.endpoint = endpoint;
        }

        /// <summary>
        /// GetMethodTypes v1.0
        /// </summary>
        /// <param name="version">Version of the API set to retrieve. Empty string means all.</param>
        /// <returns></returns>
        public Task<List<MethodType>> GetMethodTypesAsync(string version = "", CancellationTokenSource cancel = null)
        {
            return Single(RequestGenerator.Jsonize("getMethodTypes", version), CustomParser.AsMethodTypes, cancel);
        }

        /// <summary>
        /// GetVersions v1.0
        /// </summary>
        /// <returns></returns>
        public Task<List<string>> GetVersionsAsync(CancellationTokenSource cancel = null)
        {
            return PrimitiveListByMethod<string>("getVersions", ApiVersion.V1_0, cancel);
        }

        /// <summary>
        /// For APIs which have no response parameter.
        /// </summary>
        /// <param name="request">Request JSON body</param>
        /// <returns></returns>
        protected async Task NoValue(string request, CancellationTokenSource cancel = null)
        {
            await Core(request, res =>
            {
                BasicParser.CheckError(res);
                return true;
            }, cancel).ConfigureAwait(false);
        }


        /// <summary>
        /// For APIs which have no response parameter and no request parameter.
        /// </summary>
        /// <param name="method">Name of the API</param>
        /// <param name="version">Version of the API</param>
        /// <returns></returns>
        protected async Task NoValueByMethod(string method, ApiVersion version = ApiVersion.V1_0
            , CancellationTokenSource cancel = null)
        {
            await NoValue(RequestGenerator.Jsonize(method, version), cancel).ConfigureAwait(false);
        }

        /// <summary>
        /// For APIs whose response can be treated as a Capability("result":[current, [candidate0, candidate1, ...]]).
        /// </summary>
        /// <typeparam name="T">Type of the response array members</typeparam>
        /// <param name="request">Request JSON body</param>
        /// <param name="deserializer">Response JSON deserializer</param>
        /// <returns></returns>
        protected Task<Capability<T>> Capability<T>(string request, CapabilityDeserializer<T> deserializer
            , CancellationTokenSource cancel = null)
        {
            return Core(request, res => deserializer(res), cancel);
        }

        /// <summary>
        /// For APIs whose response can be treated as a Capability("result":[current, [candidate0, candidate1, ...]]) and which have no request parameter.
        /// </summary>
        /// <typeparam name="T">Type of the response Capability</typeparam>
        /// <param name="method">Name of the API</param>
        /// <returns></returns>
        protected Task<Capability<T>> CapabilityByMethod<T>(string method
            , CancellationTokenSource cancel = null)
        {
            return Capability(RequestGenerator.Jsonize(method), BasicParser.AsCapability<T>, cancel);
        }

        /// <summary>
        /// For APIs whose response is an array of a single type.
        /// </summary>
        /// <typeparam name="T">Type of the response array members</typeparam>
        /// <param name="request">Request JSON body</param>
        /// <param name="deserializer">Response JSON deserializer</param>
        /// <returns></returns>
        protected Task<List<T>> List<T>(string request, ListDeserializer<T> deserializer
            , CancellationTokenSource cancel = null)
        {
            return Core(request, res => deserializer(res), cancel);
        }

        /// <summary>
        /// For APIs whose response is an array of a single type and which have no request parameter.
        /// </summary>
        /// <typeparam name="T">Type of the response array members</typeparam>
        /// <param name="method">Name of the API</param>
        /// <param name="version">Version of the API</param>
        /// <returns></returns>
        protected Task<List<T>> PrimitiveListByMethod<T>(string method, ApiVersion version = ApiVersion.V1_0
            , CancellationTokenSource cancel = null)
        {
            return List(RequestGenerator.Jsonize(method, version), BasicParser.AsPrimitiveList<T>, cancel);
        }

        /// <summary>
        /// For APIs whose response is a single type of value.
        /// </summary>
        /// <typeparam name="T">Type of the response value</typeparam>
        /// <param name="request">Request JSON body</param>
        /// <param name="deserializer">Response JSON deserializer</param>
        /// <returns></returns>
        protected Task<T> Single<T>(string request, RawDeserializer<T> deserializer
            , CancellationTokenSource cancel = null)
        {
            return Core(request, res => deserializer(res), cancel);
        }

        /// <summary>
        /// For APIs whose response is a primitive value and which have no request parameter.
        /// </summary>
        /// <typeparam name="T">Type of the response value</typeparam>
        /// <param name="method">Name of the API</param>
        /// <param name="version">Version of the API</param>
        /// <returns></returns>
        protected Task<T> PrimitiveByMethod<T>(string method, ApiVersion version = ApiVersion.V1_0
            , CancellationTokenSource cancel = null)
        {
            return Single(RequestGenerator.Jsonize(method, version), BasicParser.AsPrimitive<T>, cancel);
        }

        /// <summary>
        /// For APIs whose response is an object which can be deserialized and which have no request parameter.
        /// </summary>
        /// <typeparam name="T">Type of the response object</typeparam>
        /// <param name="method">Name of the API</param>
        /// <param name="version">Version of the API</param>
        /// <returns></returns>
        protected Task<T> ObjectByMethod<T>(string method, ApiVersion version = ApiVersion.V1_0
            , CancellationTokenSource cancel = null)
        {
            return Single(RequestGenerator.Jsonize(method, version), BasicParser.AsObject<T>, cancel);
        }

        private async Task<T> Core<T>(string request, Func<string, T> function, CancellationTokenSource cancel = null)
        {
            try
            {
                var res = await AsyncPostClient.PostAsync(endpoint, request, cancel).ConfigureAwait(false);
                return function.Invoke(res);
            }
            catch (RemoteApiException e)
            {
                throw e;
            }
            catch (Exception)
            {
                throw new RemoteApiException(StatusCode.IllegalResponse);
            }
        }

        /// <summary>
        /// Deserialize JSON into a List.
        /// </summary>
        /// <typeparam name="T">Type of response</typeparam>
        /// <param name="jString">Input JSON string</param>
        /// <returns></returns>
        protected delegate List<T> ListDeserializer<T>(string jString);

        /// <summary>
        /// Deserialize JSON to a Capability
        /// </summary>
        /// <typeparam name="T">Type of response</typeparam>
        /// <param name="jString">Input JSON string</param>
        /// <returns></returns>
        protected delegate Capability<T> CapabilityDeserializer<T>(string jString);

        /// <summary>
        /// Deserialize JSON to a single value.
        /// </summary>
        /// <typeparam name="T">Type of response</typeparam>
        /// <param name="jString">Input JSON string</param>
        /// <returns></returns>
        protected delegate T RawDeserializer<T>(string jString);
    }
}
