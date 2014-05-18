using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace Kazyx.RemoteApi.Internal
{
    /// <summary>
    /// This class provide function to generate JSON string to set as a body of API request.
    /// You just have to set required argument for the APIs.
    /// </summary>
    internal class RequestGenerator
    {
        private static int request_id = 0;

        private static int GetID()
        {
            var id = Interlocked.Increment(ref request_id);
            if (request_id > 1000000000)
            {
                request_id = 0;
            }
            return id;
        }

        private static string CreateJson(string name, string version, params object[] prms)
        {
            var param = new JArray();
            foreach (var p in prms)
            {
                param.Add(p);
            }

            var json = new JObject(
                new JProperty("method", name),
                new JProperty("version", version),
                new JProperty("id", GetID()),
                new JProperty("params", param));

            return json.ToString(Formatting.None);
        }

        /// <summary>
        /// Automatically insert "version":"1.0"
        /// </summary>
        /// <param name="name"></param>
        /// <param name="prms"></param>
        /// <returns></returns>
        internal static string Jsonize(string name, params object[] prms)
        {
            return Jsonize(name, ApiVersion.V1_0, prms);
        }

        internal static string Jsonize(string name, ApiVersion version, params object[] prms)
        {
            return CreateJson(name, ToString(version), prms);
        }

        internal static string Serialize(string name, ApiVersion version = ApiVersion.V1_0, object prm = null)
        {
            return CreateJson(name, ToString(version), JObject.FromObject(prm));
        }

        private static string ToString(ApiVersion version)
        {
            switch (version)
            {
                case ApiVersion.V1_0:
                    return "1.0";
                case ApiVersion.V1_1:
                    return "1.1";
                default:
                    throw new System.InvalidOperationException("Version " + version + " is not supported.");
            }
        }
    }
}
