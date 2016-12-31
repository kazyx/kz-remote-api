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

        [ApiMeta("getSchemeList")]
        public Task<List<UriScheme>> GetSchemeListAsync()
        {
            return ObjectByMethod<List<UriScheme>>("getSchemeList");
        }

        [ApiMeta("setSourceList")]
        public Task<List<DataSource>> GetSourceListAsync(UriScheme scheme)
        {
            return Single(
                RequestGenerator.Serialize("getSourceList", ApiVersion.V1_0, scheme),
                BasicParser.AsObject<List<DataSource>>);
        }

        [ApiMeta("pauseStreaming")]
        public async Task PauseStreamingAsync()
        {
            await NoValueByMethod("pauseStreaming").ConfigureAwait(false);
        }

        [ApiMeta("requestToNotifyStreamingStatus")]
        public Task<StreamingStatus> RequestToNotifyStreamingStatusAsync(LongPollingFlag flag
            , CancellationTokenSource cancel = null)
        {
            return Single(
                RequestGenerator.Serialize("requestToNotifyStreamingStatus", ApiVersion.V1_0, flag),
                BasicParser.AsObject<StreamingStatus>, cancel);
        }

        [ApiMeta("seekStreamingPosition")]
        public async Task SeekStreamingPositionAsync(PlaybackPosition position)
        {
            await NoValue(RequestGenerator.Serialize("seekStreamingPosition", ApiVersion.V1_0, position)).ConfigureAwait(false);
        }

        [ApiMeta("setStreamingContent")]
        public Task<PlaybackContentLocation> SetStreamingContentAsync(PlaybackContent content)
        {
            return Single(
                RequestGenerator.Serialize("setStreamingContent", ApiVersion.V1_0, content),
                BasicParser.AsObject<PlaybackContentLocation>);
        }

        [ApiMeta("startStreaming")]
        public async Task StartStreamingAsync()
        {
            await NoValueByMethod("startStreaming").ConfigureAwait(false);
        }

        [ApiMeta("stopStreaming")]
        public async Task StopStreamingAsync()
        {
            await NoValueByMethod("stopStreaming").ConfigureAwait(false);
        }

        [ApiMeta("deleteContent")]
        public async Task DeleteContentAsync(TargetContents contents)
        {
            await NoValue(RequestGenerator.Serialize("deleteContent", ApiVersion.V1_1, contents)).ConfigureAwait(false);
        }

        [ApiMeta("getContentCount")]
        public Task<ContentCount> GetContentCountAsync(CountingTarget target)
        {
            return Single(
                RequestGenerator.Serialize("getContentCount", ApiVersion.V1_2, target),
                BasicParser.AsObject<ContentCount>);
        }

        [ApiMeta("getContentList")]
        public Task<List<Content>> GetContentListAsync(ContentListTarget target)
        {
            return Single(
                RequestGenerator.Serialize("getContentList", ApiVersion.V1_3, target),
                BasicParser.AsObject<List<Content>>);
        }
    }
}
