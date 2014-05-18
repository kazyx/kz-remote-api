using Kazyx.RemoteApi.Internal;
using System;
using System.Threading.Tasks;

namespace Kazyx.RemoteApi
{
    public class SystemApiClient : ApiClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint">Endpoint URL of system service.</param>
        public SystemApiClient(string endpoint)
            : base(endpoint)
        {
        }

        public async Task SetCurrentTimeAsync(DateTimeOffset time)
        {
            var req = new TimeOffset
            {
                DateTime = time.ToString("yyyy-MM-ddThh:mm:ssZ"),
                TimeZoneOffsetMinute = (int)(time.Offset.TotalMinutes),
                DstOffsetMinute = 0
            };
            await NoValue(RequestGenerator.Serialize("setCurrentTime", ApiVersion.V1_0, req));
        }
    }
}
