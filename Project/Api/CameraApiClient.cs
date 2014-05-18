using Kazyx.RemoteApi.Internal;
using System.Threading.Tasks;

namespace Kazyx.RemoteApi
{
    public class CameraApiClient : ApiClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint">Endpoint URL of camera service.</param>
        public CameraApiClient(string endpoint)
            : base(endpoint)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="longpolling">Set true for event notification, false for immediate response.</param>
        /// <returns></returns>
        public async Task<Event> GetEventAsync(bool longpolling, ApiVersion version = ApiVersion.V1_0)
        {
            return await Single<Event>(
                RequestGenerator.Jsonize("getEvent", version, longpolling),
                CustomParser.AsCameraEvent);
        }

        public async Task<ServerAppInfo> GetApplicationInfoAsync()
        {
            return await Single<ServerAppInfo>(
                RequestGenerator.Jsonize("getApplicationInfo"),
                CustomParser.AsServerAppInfo);
        }

        public async Task<string[]> GetAvailableApiListAsync()
        {
            return await PrimitiveArrayByMethod<string>("getAvailableApiList");
        }

        public async Task StartRecModeAsync()
        {
            await NoValueByMethod("startRecMode");
        }

        public async Task StopRecModeAsync()
        {
            await NoValueByMethod("stopRecMode");
        }

        public async Task ActZoomAsync(string direction, string movement)
        {
            await NoValue(RequestGenerator.Jsonize("actZoom", direction, movement));
        }

        public async Task<string> StartLiveviewAsync()
        {
            return await PrimitiveByMethod<string>("startLiveview");
        }

        public async Task StopLiveviewAsync()
        {
            await NoValueByMethod("stopLiveview");
        }

        public async Task StartAudioRecAsync()
        {
            await NoValueByMethod("startAudioRec");
        }

        public async Task StopAudioRecAsync()
        {
            await NoValueByMethod("stopAudioRec");
        }

        public async Task StartMovieRecAsync()
        {
            await NoValueByMethod("startMovieRec");
        }

        public async Task<string> StopMovieRecAsync()
        {
            return await PrimitiveByMethod<string>("stopMovieRec");
        }

        public async Task<string[]> ActTakePictureAsync()
        {
            return await PrimitiveArrayByMethod<string>("actTakePicture");
        }

        public async Task<string[]> AwaitTakePictureAsync()
        {
            return await PrimitiveArrayByMethod<string>("awaitTakePicture");
        }

        public async Task SetSelfTimerAsync(int timer)
        {
            await NoValue(RequestGenerator.Jsonize("setSelfTimer", timer));
        }

        public async Task<int> GetSelfTimerAsync()
        {
            return await PrimitiveByMethod<int>("getSelfTimer");
        }

        public async Task<int[]> GetSupportedSelfTimerAsync()
        {
            return await PrimitiveArrayByMethod<int>("getSupportedSelfTimer");
        }

        public async Task<Capability<int>> GetAvailableSelfTimerAsync()
        {
            return await CapabilityByMethod<int>("getAvailableSelfTimer");
        }

        public async Task SetPostviewImageSizeAsync(string size)
        {
            await NoValue(RequestGenerator.Jsonize("setPostviewImageSize", size));
        }

        public async Task<string> GetPostviewImageSizeAsync()
        {
            return await PrimitiveByMethod<string>("getPostviewImageSize");
        }

        public async Task<string[]> GetSupportedPostviewImageSizeAsync()
        {
            return await PrimitiveArrayByMethod<string>("getSupportedPostviewImageSize");
        }

        public async Task<Capability<string>> GetAvailablePostviewImageSizeAsync()
        {
            return await CapabilityByMethod<string>("getAvailablePostviewImageSize");
        }

        public async Task SetShootModeAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setShootMode", mode));
        }

        public async Task<string> GetShootModeAsync()
        {
            return await PrimitiveByMethod<string>("getShootMode");
        }

        public async Task<string[]> GetSupportedShootModeAsync()
        {
            return await PrimitiveArrayByMethod<string>("getSupportedShootMode");
        }

        public async Task<Capability<string>> GetAvailableShootModeAsync()
        {
            return await CapabilityByMethod<string>("getAvailableShootMode");
        }

        public async Task ActHalfPressShutterAsync()
        {
            await NoValueByMethod("actHalfPressShutter");
        }

        public async Task CancelHalfPressShutterAsync()
        {
            await NoValueByMethod("cancelHalfPressShutter");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="x">Percentage of the position to focus in x-axis.</param>
        /// <param name="y">Percentage of the position to focus in y-axis</param>
        /// <returns></returns>
        public async Task<SetFocusResult> SetAFPositionAsync(double x, double y)
        {
            return await Single<SetFocusResult>(
                RequestGenerator.Jsonize("setTouchAFPosition", x, y),
                CustomParser.AsSetFocusResult);
        }

        public async Task<TouchFocusStatus> GetTouchAFStatusAsync()
        {
            return await ObjectByMethod<TouchFocusStatus>("getTouchAFPosition");
        }

        public async Task CancelTouchAFAsync()
        {
            await NoValueByMethod("cancelTouchAFPosition");
        }

        public async Task SetExposureModeAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setExposureMode", mode));
        }

        public async Task<string> GetExposureModeAsync()
        {
            return await PrimitiveByMethod<string>("getExposureMode");
        }

        public async Task<string[]> GetSupportedExposureModeAsync()
        {
            return await PrimitiveArrayByMethod<string>("getSupportedExposureMode");
        }

        public async Task<Capability<string>> GetAvailableExposureModeAsync()
        {
            return await CapabilityByMethod<string>("getAvailableExposureMode");
        }

        public async Task SetFocusModeAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setFocusMode", mode));
        }

        public async Task<string> GetFocusModeAsync()
        {
            return await PrimitiveByMethod<string>("getFocusMode");
        }

        public async Task<string[]> GetSupportedFocusModeAsync()
        {
            return await PrimitiveArrayByMethod<string>("getSupportedFocusMode");
        }

        public async Task<Capability<string>> GetAvailableFocusModeAsync()
        {
            return await CapabilityByMethod<string>("getAvailableFocusMode");
        }

        public async Task SetEvIndexAsync(int index)
        {
            await NoValue(RequestGenerator.Jsonize("setExposureCompensation", index));
        }

        public async Task<int> GetEvIndexAsync()
        {
            return await PrimitiveByMethod<int>("getExposureCompensation");
        }

        public async Task<EvCandidate[]> GetSupportedEvAsync()
        {
            return await Single<EvCandidate[]>(
                 RequestGenerator.Jsonize("getSupportedExposureCompensation"),
                 CustomParser.AsEvCandidates);
        }

        public async Task<EvCapability> GetAvailableEvAsync()
        {
            return await Single<EvCapability>(
                RequestGenerator.Jsonize("getAvailableExposureCompensation"),
                CustomParser.AsEvCapability);
        }

        public async Task SetFNumberAsync(string f)
        {
            await NoValue(RequestGenerator.Jsonize("setFNumber", f));
        }

        public async Task<string> GetFNumberAsync()
        {
            return await PrimitiveByMethod<string>("getFNumber");
        }

        public async Task<string[]> GetSupportedFNumberAsync()
        {
            return await PrimitiveArrayByMethod<string>("getSupportedFNumber");
        }

        public async Task<Capability<string>> GetAvailableFNumberAsync()
        {
            return await CapabilityByMethod<string>("getAvailableFNumber");
        }

        public async Task SetShutterSpeedAsync(string ss)
        {
            await NoValue(RequestGenerator.Jsonize("setShutterSpeed", ss));
        }

        public async Task<string> GetShutterSpeedAsync()
        {
            return await PrimitiveByMethod<string>("getShutterSpeed");
        }

        public async Task<string[]> GetSupportedShutterSpeedAsync()
        {
            return await PrimitiveArrayByMethod<string>("getSupportedShutterSpeed");
        }

        public async Task<Capability<string>> GetAvailableShutterSpeedAsync()
        {
            return await CapabilityByMethod<string>("getAvailableShutterSpeed");
        }

        public async Task SetISOSpeedAsync(string iso)
        {
            await NoValue(RequestGenerator.Jsonize("setIsoSpeedRate", iso));
        }

        public async Task<string> GetIsoSpeedAsync()
        {
            return await PrimitiveByMethod<string>("getIsoSpeedRate");
        }

        public async Task<string[]> GetSupportedIsoSpeedAsync()
        {
            return await PrimitiveArrayByMethod<string>("getSupportedIsoSpeedRate");
        }

        public async Task<Capability<string>> GetAvailableIsoSpeedAsync()
        {
            return await CapabilityByMethod<string>("getAvailableIsoSpeedRate");
        }

        public async Task SetStillImageSizeAsync(StillImageSize size)
        {
            await NoValue(RequestGenerator.Jsonize("setStillSize", size.AspectRatio, size.SizeDefinition));
        }

        public async Task<StillImageSize> GetStillSizeAsync()
        {
            return await ObjectByMethod<StillImageSize>(RequestGenerator.Jsonize("getStillSize"));
        }

        public async Task<StillImageSize[]> GetSupportedStillSizeAsync()
        {
            return await ObjectByMethod<StillImageSize[]>("getSupportedStillSize");
        }

        public async Task<Capability<StillImageSize>> GetAvailableStillSizeAsync()
        {
            return await Capability<StillImageSize>(
                RequestGenerator.Jsonize("getAvailableStillSize"),
                BasicParser.AsCapabilityObject<StillImageSize>);
        }

        public async Task SetWhiteBalanceAsync(WhiteBalance wb, bool enableColorTemperature)
        {
            await NoValue(RequestGenerator.Jsonize("setWhiteBalance", wb.Mode, enableColorTemperature, wb.ColorTemperature));
        }

        public async Task<WhiteBalance> GetWhiteBalanceAsync()
        {
            return await ObjectByMethod<WhiteBalance>("getWhiteBalance");
        }

        public async Task<WhiteBalanceCandidate[]> GetSupportedWhiteBalanceAsync()
        {
            return await ObjectByMethod<WhiteBalanceCandidate[]>("getSupportedWhiteBalance");
        }

        public async Task<WhiteBalanceCapability> GetAvailableWhiteBalanceAsync()
        {
            return await Single<WhiteBalanceCapability>(
                RequestGenerator.Jsonize("getAvailableWhiteBalance"),
                CustomParser.AsWhiteBalanceCapability);
        }

        public async Task SetBeepModeAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setBeepMode", mode));
        }

        public async Task<string> GetBeepModeAsync()
        {
            return await PrimitiveByMethod<string>("getBeepMode");
        }

        public async Task<string[]> GetSupportedBeepModeAsync()
        {
            return await PrimitiveArrayByMethod<string>("getSupportedBeepMode");
        }

        public async Task<Capability<string>> GetAvailableBeepModeAsync()
        {
            return await CapabilityByMethod<string>("getAvailableBeepMode");
        }

        public async Task StartIntervalStillRecAsync()
        {
            await NoValueByMethod("startIntervalStillRec");
        }

        public async Task StopIntervalStillRecAsync()
        {
            await NoValueByMethod("stopIntervalStillRec");
        }

        public async Task SetViewAngleAsync(int angle)
        {
            await NoValue(RequestGenerator.Jsonize("setViewAngle", angle));
        }

        public async Task<int> GetViewAngleAsync()
        {
            return await PrimitiveByMethod<int>("getViewAngle");
        }

        public async Task<int[]> GetSupportedViewAngleAsync()
        {
            return await PrimitiveArrayByMethod<int>("getSupportedViewAngle");
        }

        public async Task<Capability<int>> GetAvailableViewAngleAsync()
        {
            return await CapabilityByMethod<int>("getAvailableViewAngle");
        }

        public async Task SetSteadyModeAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setSteadyMode", mode));
        }

        public async Task<string> GetSteadyModeAsync()
        {
            return await PrimitiveByMethod<string>("getSteadyMode");
        }

        public async Task<string[]> GetSupportedSteadyModeAsync()
        {
            return await PrimitiveArrayByMethod<string>("getSupportedSteadyMode");
        }

        public async Task<Capability<string>> GetAvailableSteadyModeAsync()
        {
            return await CapabilityByMethod<string>("getAvailableSteadyMode");
        }

        public async Task SetMovieQualityAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setMovieQuality", mode));
        }

        public async Task<string> GetMovieQualityAsync()
        {
            return await PrimitiveByMethod<string>("getMovieQuality");
        }

        public async Task<string[]> GetSupportedMovieQualityAsync()
        {
            return await PrimitiveArrayByMethod<string>("getSupportedMovieQuality");
        }

        public async Task<Capability<string>> GetAvailableMovieQualityAsync()
        {
            return await CapabilityByMethod<string>("getAvailableMovieQuality");
        }
    }
}
