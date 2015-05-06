
namespace Kazyx.RemoteApi.Camera
{
    public class ShootModeParam
    {
        public const string Still = "still";
        public const string Movie = "movie";
        public const string Audio = "audio";
        public const string Interval = "intervalstill";
        public const string Loop = "looprec";
    }

    public class ZoomParam
    {
        public const string DirectionIn = "in";
        public const string DirectionOut = "out";
        public const string ActionStart = "start";
        public const string ActionStop = "stop";
        public const string Action1Shot = "1shot";
    }

    public class PostviewSizeParam
    {
        public const string Original = "Original";
        public const string Px2M = "2M";
    }

    public class SelfTimerParam
    {
        public const int Off = 0;
        public const int TwoSec = 2;
        public const int TenSec = 10;
    }

    public class EventParam
    {
        public const string Error = "Error";
        public const string NotReady = "NotReady";
        public const string Idle = "IDLE";
        public const string StCapturing = "StillCapturing";
        public const string StSaving = "StillSaving";
        public const string MvWaitRecStart = "MovieWaitRecStart";
        public const string MvRecording = "MovieRecording";
        public const string MvWaitRecStop = "MovieWaitRecStop";
        public const string MvSaving = "MovieSaving";
        public const string AuWaitRecStart = "AudioWaitRecStart";
        public const string AuRecording = "AudioRecording";
        public const string AuWaitRecStop = "AudioWaitRecStop";
        public const string AuSaving = "AudioSaving";
        public const string ItvWaitRecStart = "IntervalWaitRecStart";
        public const string ItvRecording = "IntervalRecording";
        public const string ItvWaitRecStop = "IntervalWaitRecStop";
        public const string LoopWaitRecStart = "LoopWaitRecStart";
        public const string LoopRecording = "LoopRecording";
        public const string LoopWaitRecStop = "LoopWaitRecStop";
        public const string LoopSaving = "LoopSaving";
        public const string WBCapturing = "WhiteBalanceOnePushCapturing";
        public const string ContentsTransfer = "ContentsTransfer";
        public const string StreamingMovie = "Streaming";
        public const string DeletingContents = "Deleting";
    }

    public class FocusArea
    {
        public const string Touch = "Touch";
        public const string Wide = "Wide";
    }

    public class ExposureMode
    {
        public const string Program = "Program Auto";
        public const string Aperture = "Aperture";
        public const string SS = "Shutter";
        public const string Manual = "Manual";
        public const string Intelligent = "Intelligent Auto";
        public const string Superior = "Superior Auto";
    }

    public class FocusMode
    {
        public const string Single = "AF-S";
        public const string Continuous = "AF-C";
        public const string Manual = "MF";
        public const string DirectManual = "DMF";
    }

    public class AspectRatio
    {
        public const string W16_H9 = "16:9";
        public const string W4_H3 = "4:3";
        public const string W3_H2 = "3:2";
        public const string W1_H1 = "1:1";
    }

    public class WhiteBalanceMode
    {
        public const string Auto = "Auto WB";
        public const string DayLight = "Daylight";
        public const string Shade = "Shade";
        public const string Cloudy = "Cloudy";
        public const string Incandescent = "Incandescent";
        public const string Fluorescent_WarmWhite = "Fluorescent: Warm White (-1)";
        public const string Fluorescent_CoolWhite = "Fluorescent: Cool White (0)";
        public const string Fluorescent_DayWhite = "Fluorescent: Day White (+1)";
        public const string Fluorescent_DayLight = "Fluorescent: Daylight (+2)";
        public const string Manual = "Color Temperature";
        public const string Flash = "Flash";
        public const string Custom = "Custom";
        public const string Custom_1 = "Custom 1";
        public const string Custom_2 = "Custom 2";
        public const string Custom_3 = "Custom 3";
    }

    public class ImageSize
    {
        public const string Pix20M = "20M";
        public const string Pix18M = "18M";
        public const string Pix17M = "17M";
        public const string Pix13M = "13M";
        public const string Pix7_5M = "7.5M";
        public const string Pix5M = "5M";
        public const string Pix4_2M = "4.2M";
        public const string Pix3_7M = "3.7M";
    }

    public class BeepMode
    {
        public const string Off = "Off";
        public const string On = "On";
        public const string Shutter = "Shutter Only";
        public const string Silent = "Silent";
    }

    public class Orientation
    {
        public const string Straight = "0";
        public const string Right = "90";
        public const string Left = "270";
        public const string Opposite = "180";
    }

    public class FocusState
    {
        public const string Released = "Not Focusing";
        public const string InProgress = "Focusing";
        public const string Focused = "Focused";
        public const string Failed = "Failed";
    }

    public class WindNoiseReductionMode
    {
        public const string On = "on";
        public const string Off = "off";
    }

    public class AudioRecordingMode
    {
        public const string On = "on";
        public const string Off = "off";
    }

    public class SteadyMode
    {
        public const string On = "on";
        public const string Off = "off";
    }

    public class ViewAngle
    {
        public const int Deg120 = 120;
        public const int Deg170 = 170;
        public const int Invalid = -1;
    }

    public class MovieQuality
    {
        public const string MP4_FHD_60P = "PS";
        public const string MP4_FHD_30P = "HQ";
        public const string MP4_HD_30P = "STD";
        public const string MP4_VGA_30P = "VGA";
        public const string MP4_HD_30P_DOUBLE = "SLOW";
        public const string MP4_HD_30P_QUADRABLE = "SSLOW";
        public const string MP4_HD_120P = "HS120";
        public const string MP4_HD_100P = "HS100";
        public const string MP4_VGA_240P = "HS240";
        public const string MP4_VGA_200P = "HS200";
        public const string XAVC_S_FHD_60P = "50M 60p";
        public const string XAVC_S_FHD_50P = "50M 50p";
        public const string XAVC_S_FHD_30P = "50M 30p";
        public const string XAVC_S_FHD_25P = "50M 25p";
        public const string XAVC_S_FHD_24P = "50M 24p";
        public const string XAVC_S_FHD_120P_100M = "100M 120P";
        public const string XAVC_S_FHD_100P_100M = "100M 100P";
        public const string XAVC_S_FHD_120P_60M = "60M 120P";
        public const string XAVC_S_FHD_100P_60M = "60M 100P";
        public const string XAVC_S_HD_240P_100M = "100M 240P";
        public const string XAVC_S_HD_200P_100M = "100M 200P";
        public const string XAVC_S_HD_240P_60M = "60M 240P";
        public const string XAVC_S_HD_200P_60M = "60M 200P";
        public const string XAVC_S_4K_30P_100M = "100M 30p";
        public const string XAVC_S_4K_25P_100M = "100M 25p";
        public const string XAVC_S_4K_24P_100M = "100M 24p";
        public const string XAVC_S_4K_30P_60M = "60M 30p";
        public const string XAVC_S_4K_25P_60M = "60M 25p";
        public const string XAVC_S_4K_24P_60M = "60M 24p";
    }

    public class FlashMode
    {
        public const string Off = "off";
        public const string Auto = "auto";
        public const string On = "on";
        public const string SlowSync = "slowSync";
        public const string RearSync = "rearSync";
        public const string Wireless = "wireless";
    }

    public class LiveviewSize
    {
        public const string XGA = "L";
        public const string VGA = "M";
    }

    public class ColorMode
    {
        public const string Neutral = "Neutral";
        public const string Vivid = "Vivid";
    }

    public class ContinuousShootMode
    {
        public const string Single = "Single";
        public const string Cont = "Continuous";
        public const string SpeedPriority = "Spd Priority Cont.";
        public const string Burst = "Burst";
        public const string MotionShot = "MotionShot";
    }

    public class ContinuousShootSpeed
    {
        public const string High = "Hi";
        public const string Low = "Low";
        public const string FixedFrames_10_In_1_25Sec = "8fps 1sec";
        public const string FixedFrames_10_In_2Sec = "5fps 2sec";
        public const string FixedFrames_10_In_5Sec = "2fps 5sec";
        public const string FixedFrames_10_In_1Sec = "10fps 1sec";
    }

    public class LoopTime
    {
        public const string MIN_5 = "5";
        public const string MIN_20 = "20";
        public const string MIN_60 = "60";
        public const string MIN_120 = "120";
        public const string UNLIMITED = "unlimited";
    }

    public class FlipMode
    {
        public const string On = "On";
        public const string Off = "Off";
    }

    public class IrRemoteSetting
    {
        public const string On = "On";
        public const string Off = "Off";
    }

    public class TvColorSystemMode
    {
        public const string NTSC = "NTSC";
        public const string PAL = "PAL";
    }

    public class CameraFunction
    {
        public const string RemoteShooting = "Remote Shooting";
        public const string ContentTransfer = "Contents Transfer";
    }

    public class Scene
    {
        public const string Normal = "Normal";
        public const string UnderWater = "Under Water";
    }

    public class ImageQuality
    {
        public const string RawAndJpeg = "RAW+JPEG";
        public const string Fine = "Fine";
        public const string Standard = "Standard";
    }

    public class ZoomMode
    {
        public const string Optical = "Optical Zoom Only";
        public const string ClearImageDigital = "On:Clear Image Zoom";
    }

    public class TrackingFocusMode
    {
        public const string Off = "Off";
        public const string On = "On";
    }

    public class TrackingFocusStatus
    {
        public const string Tracking = "Tracking";
        public const string NotTracking = "Not Tracking";
    }

    public class MovieFormatMode
    {
        public const string MP4 = "MP4";
        public const string XAVCS = "XAVC S";
        public const string XAVCS_4K = "XAVC S 4K";
    }

    public class StorageId
    {
        public const string Card_No1 = "Memory Card 1";
        public const string NoMedia = "No Media";
    }

    public class BatteryId
    {
        public const string External_No1 = "externalBattery1";
        public const string NoBattery = "noBattery";
    }

    public class BatteryStatus
    {
        public const string Active = "active";
        public const string Inactive = "inactive";
        public const string Unknown = "unknown";
        public const string NearEnd = "batteryNearEnd";
        public const string Charging = "charging";
        public const string NoInfo = "";
    }
}
