
namespace Kazyx.RemoteApi
{
    public class ShootModeParam
    {
        public const string Still = "still";
        public const string Movie = "movie";
        public const string Audio = "audio";
        public const string Interval = "intervalstill";
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
        public const string Silent = "Off";
        public const string On = "On";
        public const string Shutter = "Shutter Only";
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
}
