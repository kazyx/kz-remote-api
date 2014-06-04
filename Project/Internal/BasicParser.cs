using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Kazyx.RemoteApi.Internal
{
    internal class BasicParser
    {
        internal static JObject Initialize(string response)
        {
            var json = JObject.Parse(response);
            if (json == null)
            {
                throw new RemoteApiException(StatusCode.IllegalResponse);
            }
            if (json["error"] != null)
            {
                throw new RemoteApiException((StatusCode)json["error"].Value<int>(0));
            }
            return json;
        }

        /// <summary>
        /// For response which has no value or no effective value.
        /// </summary>
        /// <param name="jString"></param>
        internal static void CheckError(string jString)
        {
            Initialize(jString);
        }

        /// <summary>
        /// For response which has a single value.
        /// </summary>
        /// <typeparam name="T">Type of the value</typeparam>
        /// <param name="jString"></param>
        internal static T AsPrimitive<T>(string jString)
        {
            var json = Initialize(jString);

            return json["result"].Value<T>(0);
        }

        /// <summary>
        /// For response which has a single Array consists of a single type.
        /// </summary>
        /// <typeparam name="T">Type of the value</typeparam>
        /// <param name="jString"></param>
        internal static T[] AsPrimitiveArray<T>(string jString)
        {
            var json = Initialize(jString);

            var array = new List<T>();
            foreach (var token in json["result"][0].Values<T>())
            {
                array.Add(token);
            }

            return array.ToArray();
        }

        /// <summary>
        /// For response which has multiple same type values in parallel.
        /// </summary>
        /// <typeparam name="T">Type of the values</typeparam>
        /// <param name="jString"></param>
        /// <param name="num">Number of the values contained</param>
        internal static T[] AsParallelPrimitives<T>(string jString, int num)
        {
            var json = Initialize(jString);

            var results = json["result"];
            var array = new T[num];
            for (int i = 0; i < num; i++)
            {
                array[i] = results.Value<T>(i);
            }

            return array;
        }

        /// <summary>
        /// For response which has a single value and a single array.
        /// </summary>
        /// <typeparam name="T">Type of the values</typeparam>
        /// <param name="jString"></param>
        internal static Capability<T> AsCapability<T>(string jString)
        {
            var json = Initialize(jString);

            var _candidates = new List<T>();
            foreach (var token in json["result"][1].Values<T>())
            {
                _candidates.Add(token);
            }

            return new Capability<T>
            {
                current = json["result"].Value<T>(0),
                candidates = _candidates.ToArray()
            };
        }

        internal static T AsObject<T>(string jString)
        {
            var json = Initialize(jString);

            return JsonConvert.DeserializeObject<T>(json["result"][0].ToString(Formatting.None));
        }

        internal static Capability<T> AsCapabilityObject<T>(string jString)
        {
            var json = Initialize(jString);

            var _candidates = new List<T>();
            var array = json["result"][1] as JArray;
            foreach (var token in array.Values<JObject>())
            {
                _candidates.Add(JsonConvert.DeserializeObject<T>(token.ToString(Formatting.None)));
            }

            return new Capability<T>
            {
                current = JsonConvert.DeserializeObject<T>(json["result"][0].ToString(Formatting.None)),
                candidates = _candidates.ToArray()
            };
        }
    }
}
