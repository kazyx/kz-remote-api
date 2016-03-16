using Newtonsoft.Json;
using System.Collections.Generic;

namespace Kazyx.RemoteApi.AvContent
{
    public class UriScheme
    {
        [JsonProperty("scheme")]
        public string Scheme { set; get; }
    }

    public class DataSource
    {
        [JsonProperty("source")]
        public string Source { set; get; }
    }

    public class LongPollingFlag
    {
        [JsonProperty("polling")]
        public bool ForLongPolling { set; get; }
    }

    public class StreamingStatus
    {
        /// <summary>
        /// Refer to <seealso cref="StreamStatus"/> for defined parameters.
        /// </summary>
        [JsonProperty("status")]
        public string Status { set; get; }

        /// <summary>
        /// Refer to <seealso cref="StreamStatusChangeFactor"/> for defined parameters.
        /// </summary>
        [JsonProperty("factor")]
        public string Factor { set; get; }
    }

    public class PlaybackPosition
    {
        [JsonProperty("positionMsec")]
        public int PositionMSec { set; get; }
    }

    public class PlaybackContent
    {
        [JsonProperty("uri")]
        public string Uri { set; get; }

        /// <summary>
        /// Refer to <seealso cref="RemotePlayMode"/> for defined parameters.
        /// </summary>
        [JsonProperty("remotePlayType")]
        public string RemotePlayType { set; get; }
    }

    public class PlaybackContentLocation
    {
        [JsonProperty("playbackUrl")]
        public string Url { set; get; }
    }

    public class TargetContents
    {
        /// <summary>
        /// Maximum list size is 100.
        /// </summary>
        [JsonProperty("uri")]
        public List<string> ContentUris { set; get; }
    }

    public class CountingTarget
    {
        [JsonProperty("uri")]
        public string Uri { set; get; }

        /// <summary>
        /// Refer to <seealso cref="ContentKind"/> for defined parameters.
        /// null means "Not specified"
        /// </summary>
        [JsonProperty("type")]
        public List<string> Types { set; get; }

        /// <summary>
        /// Refer to <seealso cref="ContentsExpansionParameter"/> for defined parameters.
        /// </summary>
        [JsonProperty("target")]
        public string Target { set; get; }

        /// <summary>
        /// Refer to <seealso cref="ContentGroupingMode"/> for defined parameters.
        /// </summary>
        [JsonProperty("view")]
        public string Grouping { set; get; }
    }

    public class ContentCount
    {
        [JsonProperty("count")]
        public int NumOfContents { set; get; }
    }

    public class ContentListTarget
    {
        [JsonProperty("uri")]
        public string Uri { set; get; }

        [JsonProperty("stIdx")]
        public int StartIndex { set; get; }

        /// <summary>
        /// Should be same or less than 100.
        /// </summary>
        [JsonProperty("cnt")]
        public int MaxContents { set; get; }

        /// <summary>
        /// Refer to <seealso cref="ContentKind"/> for defined parameters.
        /// </summary>
        [JsonProperty("type")]
        public List<string> Types { set; get; }

        /// <summary>
        /// Refer to <seealso cref="ContentGroupingMode"/> for defined parameters.
        /// </summary>
        [JsonProperty("view")]
        public string Grouping { set; get; }

        /// <summary>
        /// Refer to <seealso cref="SortMode"/> for defined parameters.
        /// </summary>
        [JsonProperty("sort")]
        public string Sorting { set; get; }
    }

    public class Content
    {
        [JsonProperty("uri")]
        public string Uri { set; get; }

        [JsonProperty("title")]
        public string Title { set; get; }

        [JsonProperty("content")]
        public ImageContent ImageContent { set; get; }

        /// <summary>
        /// ISO8601
        /// </summary>
        [JsonProperty("createdTime")]
        public string CreatedTime { set; get; }

        /// <summary>
        /// Refer to <seealso cref="AvContent.ContentKind"/> for defined parameters.
        /// </summary>
        [JsonProperty("contentKind")]
        public string ContentKind { set; get; }

        [JsonProperty("folderNo")]
        public string FolderNumber { set; get; }

        [JsonProperty("fileNo")]
        public string FileNumber { set; get; }

        /// <summary>
        /// Refer to <seealso cref="TextBoolean"/> for defined parameters.
        /// </summary>
        [JsonProperty("isPlayable")]
        public string IsPlayableOnCamera { set; get; }

        /// <summary>
        /// Refer to <seealso cref="TextBoolean"/> for defined parameters.
        /// </summary>
        [JsonProperty("isBrowsable")]
        public string IsFolder { set; get; }

        /// <summary>
        /// Refer to <seealso cref="TextBoolean"/> for defined parameters.
        /// </summary>
        [JsonProperty("isProtected")]
        public string IsProtected { set; get; }

        /// <summary>
        /// Refer to <seealso cref="RemotePlayMode"/> for defined parameters.
        /// </summary>
        [JsonProperty("remotePlayType")]
        public List<string> RemotePlayTypes { set; get; }
    }

    public class ImageContent
    {
        [JsonProperty("original")]
        public List<OriginaContent> OriginalContents { set; get; }

        [JsonProperty("largeUrl")]
        public string LargeImageUrl { set; get; }

        [JsonProperty("smallUrl")]
        public string SmallImageUrl { set; get; }

        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl { set; get; }
    }

    public class OriginaContent
    {
        [JsonProperty("url")]
        public string Url { set; get; }

        [JsonProperty("fileName")]
        public string FileName { set; get; }

        /// <summary>
        /// Refer to <seealso cref="ImageType"/> for defined parameters.
        /// </summary>
        [JsonProperty("stillObject")]
        public string Type { set; get; }
    }
}
