using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Kazyx.RemoteApi.Camera
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

    public class ServerAppInfo
    {
        /// <summary>
        /// Name of the server application
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// Version of the server application
        /// </summary>
        public string Version { set; get; }
    }

    public class Event
    {
        public List<string> AvailableApis { set; get; }
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
        public List<string> PictureUrls { set; get; }
        public Capability<string> BeepMode { set; get; }
        public string LiveviewOrientation { set; get; }
        public WhiteBalanceEvent WhiteBalance { set; get; }
        public StillImageSizeEvent StillImageSize { set; get; }
        public Capability<string> SteadyMode { set; get; }
        public Capability<int> ViewAngle { set; get; }
        public Capability<string> MovieQuality { set; get; }
        public List<StorageInfo> StorageInfo { set; get; }
        public Capability<string> FlashMode { set; get; }
        public Capability<string> FocusMode { set; get; }

        // GetEvent v1.1 parameters
        public string FocusStatus { set; get; }

        // GetEvent v1.2 parameters
        public Capability<string> ZoomSetting { set; get; }
        public Capability<string> ImageQuality { set; get; }
        public Capability<string> ContShootingMode { set; get; }
        public Capability<string> ContShootingSpeed { set; get; }
        public List<ContShootingResult> ContShootingResult { set; get; }
        public Capability<string> FlipMode { set; get; }
        public Capability<string> SceneSelection { set; get; }
        public Capability<string> IntervalTime { set; get; }
        public Capability<string> ColorSetting { set; get; }
        public Capability<string> MovieFormat { set; get; }
        public Capability<string> IrRemoteControl { set; get; }
        public Capability<string> TvColorSystem { set; get; }
        public string TrackingFocusStatus { set; get; }
        public Capability<string> TrackingFocusMode { set; get; }
        public List<BatteryInfo> BatteryInfo { set; get; }
        public int RecordingTimeSec { set; get; }
        public int NumberOfShots { set; get; }
        public Capability<int> AutoPowerOff { set; get; }
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
        //[JsonProperty("set")]
        public bool Focused { set; get; }

        //[JsonProperty("touchCoordinates")]
        //public double[] Position { set; get; }

        public FocusPosition Position { set; get; }
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
        public List<WhiteBalanceCandidate> Candidates { set; get; }
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
        public List<int> Candidates { set; get; }
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

    public class AutoPowerOff
    {
        [JsonProperty("autoPowerOff")]
        public int TimeInSeconds { set; get; }
    }

    public class ColorSetting
    {
        [JsonProperty("colorSetting")]
        public string Mode { set; get; }
    }

    public class ContinuousShootSetting
    {
        [JsonProperty("contShootingMode")]
        public string Mode { set; get; }
    }

    public class ContinuousShootSpeedSetting
    {
        [JsonProperty("contShootingSpeed")]
        public string Mode { set; get; }
    }

    public class FlipSetting
    {
        [JsonProperty("flip")]
        public string Mode { set; get; }
    }

    public class IntervalTimeSetting
    {
        [JsonProperty("intervalTimeSec")]
        public string TimeInSeconds { set; get; }
    }

    public class SceneSelectionSetting
    {
        [JsonProperty("scene")]
        public string Mode { set; get; }
    }

    public class ImageQualitySetting
    {
        [JsonProperty("stillQuality")]
        public string Mode { set; get; }
    }

    public class ZoomSetting
    {
        [JsonProperty("zoom")]
        public string Mode { set; get; }
    }

    public class FocusPosition
    {
        /// <summary>
        /// X-axis position by percentage.
        /// </summary>
        [JsonProperty("xPosition")]
        public double X_Axis { set; get; }

        /// <summary>
        /// Y-axis position by percentage.
        /// </summary>
        [JsonProperty("yPosition")]
        public double Y_Axis { set; get; }
    }

    public class TrackingFocusSetting
    {
        [JsonProperty("trackingFocus")]
        public string Mode { set; get; }
    }

    public interface ICandidate<T>
    {
        [JsonProperty("candidate")]
        List<T> CandidateValues { set; get; }
    }

    public class Candidate<T> : ICandidate<T>
    {
        public List<T> CandidateValues { set; get; }
    }

    public abstract class ObjectStyleCapability<T> : Capability<T>, ICandidate<T>
    {
        public virtual T CurrentValue { set; get; }

        public List<T> CandidateValues { set; get; }

        [JsonIgnore]
        public new T Current
        {
            set { CurrentValue = value; }
            get { return CurrentValue; }
        }

        [JsonIgnore]
        public new List<T> Candidates
        {
            set { CandidateValues = value; }
            get { return CandidateValues; }
        }
    }

    public class ApoCapability : ObjectStyleCapability<int>
    {
        [JsonProperty("autoPowerOff")]
        public override int CurrentValue { set; get; }
    }

    public class ColorSettingCapability : ObjectStyleCapability<string>
    {
        [JsonProperty("colorSetting")]
        public override string CurrentValue { set; get; }
    }

    public class ContinuousShootingModeCapability : ObjectStyleCapability<string>
    {
        [JsonProperty("contShootingMode")]
        public override string CurrentValue { set; get; }
    }

    public class ContinuousShootingSpeedCapability : ObjectStyleCapability<string>
    {
        [JsonProperty("contShootingSpeed")]
        public override string CurrentValue { set; get; }
    }

    public class FlipModeCapability : ObjectStyleCapability<string>
    {
        [JsonProperty("flip")]
        public override string CurrentValue { set; get; }
    }

    public class IntervalTimeCapability : ObjectStyleCapability<string>
    {
        [JsonProperty("intervalTimeSec")]
        public override string CurrentValue { set; get; }
    }

    public class SceneSelectionCapability : ObjectStyleCapability<string>
    {
        [JsonProperty("scene")]
        public override string CurrentValue { set; get; }
    }

    public class ImageQualityCapability : ObjectStyleCapability<string>
    {
        [JsonProperty("stillQuality")]
        public override string CurrentValue { set; get; }
    }

    public class ZoomModeCapability : ObjectStyleCapability<string>
    {
        [JsonProperty("zoom")]
        public override string CurrentValue { set; get; }
    }

    public class TrackingFocusModeCapability : ObjectStyleCapability<string>
    {
        [JsonProperty("trackingFocus")]
        public override string CurrentValue { set; get; }
    }

    public class MovieFormatCapability : ObjectStyleCapability<string>
    {
        [JsonProperty("movieFileFormat")]
        public override string CurrentValue { set; get; }
    }

    public class TvColorSystemCapability : ObjectStyleCapability<string>
    {
        [JsonProperty("tvColorSystem")]
        public override string CurrentValue { set; get; }
    }

    public class InfraredRemoteControlCapability : ObjectStyleCapability<string>
    {
        [JsonProperty("infraredRemoteControl")]
        public override string CurrentValue { set; get; }
    }

    public class FrameInfoSetting
    {
        [JsonProperty("frameInfo")]
        public bool TransferFrameInfo { set; get; }
    }

    public class MovieFormat
    {
        [JsonProperty("movieFileFormat")]
        public string Mode { set; get; }
    }

    public class TvColorSystem
    {
        [JsonProperty("tvColorSystem")]
        public string Mode { set; get; }
    }

    public class InfraredRemoteControl
    {
        [JsonProperty("infraredRemoteControl")]
        public string Mode { set; get; }
    }

    public class BatteryInfo
    {
        [JsonProperty("batteryID")]
        public string Id { set; get; }

        [JsonProperty("status")]
        public string Status { set; get; }

        [JsonProperty("additionalStatus")]
        public string AdditionalStatus { set; get; }

        [JsonProperty("levelNumer")]
        public int LevelNumerator { set; get; }

        [JsonProperty("levelDenom")]
        public int LevelDenominator { set; get; }

        [JsonProperty("description")]
        public string Description { set; get; }
    }

    public class ContShootingResult
    {
        [JsonProperty("postviewUrl")]
        public string PostviewUrl { set; get; }

        [JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl { set; get; }
    }
}
