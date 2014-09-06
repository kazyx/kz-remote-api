
namespace Kazyx.RemoteApi.AvContent
{
    public class Scheme
    {
        public const string Storage = "storage";
    }

    public class StreamStatus
    {
        public const string Idle = "idle";
        public const string Paused = "paused";
        public const string Started = "started";
        public const string PausedByEdge = "pausedByEdge";
        public const string Error = "error";
        public const string Invalid = "";
    }

    public class StreamStatusChangeFactor
    {
        public const string StartEdge = "startEdge";
        public const string EndEdge = "endEdge";
        public const string FileError = "fileError";
        public const string MediaError = "mediaError";
        public const string OtherError = "otherError";
        public const string Unknown = "";
    }

    public class RemotePlayMode
    {
        public const string SimpleStreaming = "simpleStreaming";
        public const string Unknown = "";
    }

    public class ContentKind
    {
        public const string StillImage = "still";
        public const string MovieMp4 = "movie_mp4";
        public const string MovieXavcS = "movie_xavcs";
        public const string Directory = "directory";
        public const string Unknown = "";
    }

    public class ContentGroupingMode
    {
        public const string Date = "date";
        public const string Flat = "flat";
    }

    public class SortMode
    {
        public const string Ascending = "ascending";
        public const string Descending = "descending";
        public const string Unspecified = "";
    }

    public class ContentsExpansionParameter
    {
        public const string All = "all";
        public const string Unsupecified = "";
    }

    public class ImageType
    {
        public const string Jpeg = "jpeg";
        public const string Raw = "raw";
        public const string Mpo = "mpo";
        public const string Unknown = "";
    }

    public class TextBoolean
    {
        public const string True = "true";
        public const string False = "false";
        public const string Unknown = "";
    }
}
