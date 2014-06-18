using Newtonsoft.Json;

namespace Kazyx.RemoteApi
{
    public class ZoomInfo
    {
        public int position { set; get; }
        public int number_of_boxes { set; get; }
        public int current_box_index { set; get; }
        public int position_in_current_box { set; get; }
    }

    /// <summary>
    /// Set of current value and its candidates.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Capability<T>
    {
        public T current { set; get; }
        public T[] candidates { set; get; }
    }

    public class MethodType
    {
        public string name { set; get; }
        public string[] reqtypes { set; get; }
        public string[] restypes { set; get; }
        public string version { set; get; }
    }

    public class ServerAppInfo
    {
        public string name { set; get; }
        public string version { set; get; }
    }

    public class Event
    {
        public string[] AvailableApis { internal set; get; }
        public string CameraStatus { internal set; get; }
        public ZoomInfo ZoomInfo { internal set; get; }
        public bool LiveviewAvailable { internal set; get; }
        public Capability<string> PostviewSizeInfo { internal set; get; }
        public Capability<int> SelfTimerInfo { internal set; get; }
        public Capability<string> ShootModeInfo { internal set; get; }
        public Capability<string> ExposureMode { internal set; get; }
        public Capability<string> ShutterSpeed { internal set; get; }
        public Capability<string> ISOSpeedRate { internal set; get; }
        public Capability<string> FNumber { internal set; get; }
        public EvCapability EvInfo { internal set; get; }
        public bool? ProgramShiftActivated { internal set; get; }
        public TouchFocusStatus TouchAFStatus { internal set; get; }
        public string[] PictureUrls { internal set; get; }
        public Capability<string> BeepMode { internal set; get; }
        public string LiveviewOrientation { internal set; get; }
        public WhiteBalanceEvent WhiteBalance { internal set; get; }
        public StillImageSizeEvent StillImageSize { internal set; get; }
        public string FocusStatus { internal set; get; }
        public Capability<string> SteadyMode { internal set; get; }
        public Capability<int> ViewAngle { internal set; get; }
        public Capability<string> MovieQuality { internal set; get; }
        public StorageInfo[] StorageInfo { internal set; get; }
    }

    public class EvCapability
    {
        public int CurrentIndex { set; get; }
        public EvCandidate Candidate { internal set; get; }
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
        public bool Focused { internal set; get; }
    }

    public class EvCandidate
    {
        public EvStepDefinition IndexStep { internal set; get; }
        public int MaxIndex { internal set; get; }
        public int MinIndex { internal set; get; }
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
        public bool CapabilityChanged { internal set; get; }
        public StillImageSize Current { internal set; get; }
    }

    public class WhiteBalanceCapability
    {
        public WhiteBalance current { internal set; get; }
        public WhiteBalanceCandidate[] candidates { internal set; get; }
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
        public bool CapabilityChanged { internal set; get; }
        public WhiteBalance Current { internal set; get; }
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
}
