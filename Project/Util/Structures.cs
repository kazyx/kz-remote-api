using Newtonsoft.Json;

namespace Kazyx.RemoteApi
{
    public class ZoomInfo
    {
        [JsonProperty("zoomPosition")]
        public int Position { set; get; }

        [JsonProperty("zoomNumberBox")]
        public int NumberOfBoxes { set; get; }

        [JsonProperty("zoomIndexCurrentBox")]
        public int CurrentBoxIndex { set; get; }

        [JsonProperty("zoomPositionCurrentBox")]
        public int PositionInCurrentBox { set; get; }
    }

    /// <summary>
    /// Set of current value and its candidates.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Capability<T>
    {
        public T Current { set; get; }
        public T[] Candidates { set; get; }
    }

    public class MethodType
    {
        public string Name { set; get; }
        public string[] ReqTypes { set; get; }
        public string[] ResTypes { set; get; }
        public string Version { set; get; }
    }

    public class ServerAppInfo
    {
        public string Name { set; get; }
        public string Version { set; get; }
    }

    public class Event
    {
        public string[] AvailableApis { set; get; }
        public string CameraStatus { set; get; }
        public ZoomInfo ZoomInfo { set; get; }
        public bool LiveviewAvailable { set; get; }
        public Capability<string> PostviewSizeInfo { set; get; }
        public Capability<int> SelfTimerInfo { set; get; }
        public Capability<string> ShootModeInfo { set; get; }
        public Capability<string> ExposureMode { set; get; }
        public Capability<string> ShutterSpeed { set; get; }
        public Capability<string> ISOSpeedRate { set; get; }
        public Capability<string> FNumber { set; get; }
        public EvCapability EvInfo { set; get; }
        public bool? ProgramShiftActivated { set; get; }
        public TouchFocusStatus TouchAFStatus { set; get; }
        public string[] PictureUrls { set; get; }
        public Capability<string> BeepMode { set; get; }
        public string LiveviewOrientation { set; get; }
        public WhiteBalanceEvent WhiteBalance { set; get; }
        public StillImageSizeEvent StillImageSize { set; get; }
        public string FocusStatus { set; get; }
        public Capability<string> SteadyMode { set; get; }
        public Capability<int> ViewAngle { set; get; }
        public Capability<string> MovieQuality { set; get; }
        public StorageInfo[] StorageInfo { set; get; }
        public Capability<string> FlashMode { set; get; }
        public Capability<string> FocusMode { set; get; }
    }

    public class EvCapability
    {
        public int CurrentIndex { set; get; }
        public EvCandidate Candidate { set; get; }
    }

    public class SetFocusResult
    {
        [JsonProperty("AFResult")]
        public bool Focused { set; get; }

        [JsonProperty("AFType")]
        public string Mode { set; get; }
    }

    public class TouchFocusStatus
    {
        [JsonProperty("set")]
        public bool Focused { set; get; }

        [JsonProperty("touchCoordinates")]
        public double[] Position { set; get; }
    }

    public class EvCandidate
    {
        public EvStepDefinition IndexStep { set; get; }
        public int MaxIndex { set; get; }
        public int MinIndex { set; get; }
    }

    public class StillImageSize
    {
        [JsonProperty("aspect")]
        public string AspectRatio { set; get; }

        [JsonProperty("size")]
        public string SizeDefinition { set; get; }
    }

    public class StillImageSizeEvent
    {
        public bool CapabilityChanged { set; get; }
        public StillImageSize Current { set; get; }
    }

    public class WhiteBalanceCapability
    {
        public WhiteBalance Current { set; get; }
        public WhiteBalanceCandidate[] Candidates { set; get; }
    }

    public class WhiteBalance
    {
        [JsonIgnore]
        public const int InvalidColorTemperture = -1;

        [JsonProperty("whiteBalanceMode")]
        public string Mode { set; get; }

        private int _ColorTemperature = InvalidColorTemperture;

        [JsonProperty("colorTemperature")]
        public int ColorTemperature
        {
            set { _ColorTemperature = value; }
            get { return _ColorTemperature; }
        }
    }

    public class WhiteBalanceEvent
    {
        public bool CapabilityChanged { set; get; }
        public WhiteBalance Current { set; get; }
    }

    public class WhiteBalanceCandidate
    {
        [JsonProperty("whiteBalanceMode")]
        public string WhiteBalanceMode { set; get; }

        [JsonProperty("colorTemperatureRange")]
        public int[] Candidates { set; get; }
    }

    public class TimeOffset
    {
        [JsonProperty("dateTime")]
        public string DateTime { set; get; }

        [JsonProperty("timeZoneOffsetMinute")]
        public int TimeZoneOffsetMinute { set; get; }

        [JsonProperty("dstOffsetMinute")]
        public int DstOffsetMinute { set; get; }
    }

    public class StorageInfo
    {
        [JsonProperty("numberOfRecordableImages")]
        public int RecordableImages { set; get; }

        [JsonProperty("recordTarget")]
        public bool RecordTarget { set; get; }

        [JsonProperty("recordableTime")]
        public int RecordableMovieLength { set; get; }

        [JsonProperty("storageDescription")]
        public string Description { set; get; }

        [JsonProperty("storageID")]
        public string StorageID { set; get; }
    }

    public class ProgramShiftRange
    {
        public int Max { set; get; }
        public int Min { set; get; }
    }
}
