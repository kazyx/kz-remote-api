using System;
using System.Threading.Tasks;

namespace Kazyx.RemoteApi.System
{
    public class SystemApiClient : ApiClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint">Endpoint URL of system service.</param>
        public SystemApiClient(Uri endpoint)
            : base(endpoint)
        {
        }

        public async Task SetCurrentTimeAsync(DateTimeOffset UtcTime, int OffsetInMinute)
        {
            var req = new TimeOffset
            {
                DateTime = UtcTime.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                TimeZoneOffsetMinute = OffsetInMinute,
                DstOffsetMinute = 0
            };
            await NoValue(RequestGenerator.Serialize("setCurrentTime", ApiVersion.V1_0, req));
        }
    }
}
