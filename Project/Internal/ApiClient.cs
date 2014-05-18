using System;
using System.Threading.Tasks;

namespace Kazyx.RemoteApi.Internal
{
    public abstract class ApiClient
    {
        protected readonly string endpoint;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint">Endpoint URL of this service.</param>
        protected ApiClient(string endpoint)
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
        public async Task<MethodType[]> GetMethodTypesAsync(string version = "")
        {
            return await Single<MethodType[]>(
                RequestGenerator.Jsonize("getMethodTypes", version),
                CustomParser.AsMethodTypes);
        }

        /// <summary>
        /// GetVersions v1.0
        /// </summary>
        /// <returns></returns>
        public async Task<string[]> GetVersionsAsync()
        {
            return await PrimitiveArrayByMethod<string>("getVersions");
        }

        /// <summary>
        /// For APIs which have no response parameter.
        /// </summary>
        /// <param name="request">Request JSON body</param>
        /// <returns></returns>
        protected async Task NoValue(string request)
        {
            await Core<bool>(request, (res) =>
            {
                BasicParser.CheckError(res);
                return true;
            });
        }


        /// <summary>
        /// For APIs which have no response parameter and no request parameter.
        /// </summary>
        /// <param name="method">Name of the API</param>
        /// <param name="version">Version of the API</param>
        /// <returns></returns>
        protected async Task NoValueByMethod(string method, ApiVersion version = ApiVersion.V1_0)
        {
            await NoValue(RequestGenerator.Jsonize(method, version));
        }

        /// <summary>
        /// For APIs whose response can be treated as a Capability("result":[current, [candidate0, candidate1, ...]]).
        /// </summary>
        /// <typeparam name="T">Type of the response array members</typeparam>
        /// <param name="request">Request JSON body</param>
        /// <param name="deserializer">Response JSON deserializer</param>
        /// <returns></returns>
        protected async Task<Capability<T>> Capability<T>(string request, CapabilityDeserializer<T> deserializer)
        {
            return await Core<Capability<T>>(request, (res) => { return deserializer(res); });
        }

        /// <summary>
        /// For APIs whose response can be treated as a Capability("result":[current, [candidate0, candidate1, ...]]) and which have no request parameter.
        /// </summary>
        /// <typeparam name="T">Type of the response Capability</typeparam>
        /// <param name="method">Name of the API</param>
        /// <returns></returns>
        protected async Task<Capability<T>> CapabilityByMethod<T>(string method)
        {
            return await Capability<T>(
                RequestGenerator.Jsonize(method),
                BasicParser.AsCapability<T>);
        }

        /// <summary>
        /// For APIs whose response is an array of a single type.
        /// </summary>
        /// <typeparam name="T">Type of the response array members</typeparam>
        /// <param name="request">Request JSON body</param>
        /// <param name="deserializer">Response JSON deserializer</param>
        /// <returns></returns>
        protected async Task<T[]> Array<T>(string request, ArrayDeserializer<T> deserializer)
        {
            return await Core<T[]>(request, (res) => { return deserializer(res); });
        }

        /// <summary>
        /// For APIs whose response is an array of a single type and which have no request parameter.
        /// </summary>
        /// <typeparam name="T">Type of the response array members</typeparam>
        /// <param name="method">Name of the API</param>
        /// <param name="version">Version of the API</param>
        /// <returns></returns>
        protected async Task<T[]> PrimitiveArrayByMethod<T>(string method, ApiVersion version = ApiVersion.V1_0)
        {
            return await Array<T>(
                RequestGenerator.Jsonize(method, version),
                BasicParser.AsPrimitiveArray<T>);
        }

        /// <summary>
        /// For APIs whose response is a single type of value.
        /// </summary>
        /// <typeparam name="T">Type of the response value</typeparam>
        /// <param name="request">Request JSON body</param>
        /// <param name="deserializer">Response JSON deserializer</param>
        /// <returns></returns>
        protected async Task<T> Single<T>(string request, RawDeserializer<T> deserializer)
        {
            return await Core<T>(request, (res) => { return deserializer(res); });
        }

        /// <summary>
        /// For APIs whose response is a primitive value and which have no request parameter.
        /// </summary>
        /// <typeparam name="T">Type of the response value</typeparam>
        /// <param name="method">Name of the API</param>
        /// <param name="version">Version of the API</param>
        /// <returns></returns>
        protected async Task<T> PrimitiveByMethod<T>(string method, ApiVersion version = ApiVersion.V1_0)
        {
            return await Single<T>(
                RequestGenerator.Jsonize(method, version),
                BasicParser.AsPrimitive<T>);
        }

        /// <summary>
        /// For APIs whose response is an object which can be deserialized and which have no request parameter.
        /// </summary>
        /// <typeparam name="T">Type of the response object</typeparam>
        /// <param name="method">Name of the API</param>
        /// <param name="version">Version of the API</param>
        /// <returns></returns>
        protected async Task<T> ObjectByMethod<T>(string method, ApiVersion version = ApiVersion.V1_0)
        {
            return await Single<T>(
                RequestGenerator.Jsonize(method, version),
                BasicParser.AsObject<T>);
        }

        private async Task<T> Core<T>(string request, Func<string, T> function)
        {
            try
            {
                var res = await AsyncPostClient.Post(endpoint, request);
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
        /// Deserialize JSON to an array.
        /// </summary>
        /// <typeparam name="T">Type of response</typeparam>
        /// <param name="jString">Input JSON string</param>
        /// <returns></returns>
        protected delegate T[] ArrayDeserializer<T>(string jString);

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
