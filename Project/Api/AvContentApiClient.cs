using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kazyx.RemoteApi.AvContent
{
    public class AvContentApiClient : ApiClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint">Endpoint URL of avContent service.</param>
        public AvContentApiClient(Uri endpoint)
            : base(endpoint)
        {
        }

        public async Task<List<UriScheme>> GetSchemeListAsync()
        {
            return await ObjectByMethod<List<UriScheme>>("getSchemeList").ConfigureAwait(false);
        }

        public async Task<List<DataSource>> GetSourceListAsync(UriScheme scheme)
        {
            return await Single(
                RequestGenerator.Serialize("getSourceList", ApiVersion.V1_0, scheme),
                BasicParser.AsObject<List<DataSource>>).ConfigureAwait(false);
        }

        public async Task PauseStreamingAsync()
        {
            await NoValueByMethod("pauseStreaming").ConfigureAwait(false);
        }

        public async Task<StreamingStatus> RequestToNotifyStreamingStatusAsync(LongPollingFlag flag
            , CancellationTokenSource cancel = null)
        {
            return await Single(
                RequestGenerator.Serialize("requestToNotifyStreamingStatus", ApiVersion.V1_0, flag),
                BasicParser.AsObject<StreamingStatus>, cancel).ConfigureAwait(false);
        }

        public async Task SeekStreamingPositionAsync(PlaybackPosition position)
        {
            await NoValue(RequestGenerator.Serialize("seekStreamingPosition", ApiVersion.V1_0, position)).ConfigureAwait(false);
        }

        public async Task<PlaybackContentLocation> SetStreamingContentAsync(PlaybackContent content)
        {
            return await Single(
                RequestGenerator.Serialize("setStreamingContent", ApiVersion.V1_0, content),
                BasicParser.AsObject<PlaybackContentLocation>).ConfigureAwait(false);
        }

        public async Task StartStreamingAsync()
        {
            await NoValueByMethod("startStreaming").ConfigureAwait(false);
        }

        public async Task StopStreamingAsync()
        {
            await NoValueByMethod("stopStreaming").ConfigureAwait(false);
        }

        public async Task DeleteContentAsync(TargetContents contents)
        {
            await NoValue(RequestGenerator.Serialize("deleteContent", ApiVersion.V1_1, contents)).ConfigureAwait(false);
        }

        public async Task<ContentCount> GetContentCountAsync(CountingTarget target)
        {
            return await Single(
                RequestGenerator.Serialize("getContentCount", ApiVersion.V1_2, target),
                BasicParser.AsObject<ContentCount>).ConfigureAwait(false);
        }

        public async Task<List<Content>> GetContentListAsync(ContentListTarget target)
        {
            return await Single(
                RequestGenerator.Serialize("getContentList", ApiVersion.V1_3, target),
                BasicParser.AsObject<List<Content>>).ConfigureAwait(false);
        }
    }
}
