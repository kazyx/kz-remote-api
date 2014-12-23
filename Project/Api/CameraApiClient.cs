using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kazyx.RemoteApi.Camera
{
    public class CameraApiClient : ApiClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint">Endpoint URL of camera service.</param>
        public CameraApiClient(Uri endpoint)
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
                CustomParser.AsCameraEvent).ConfigureAwait(false);
        }

        public async Task<ServerAppInfo> GetApplicationInfoAsync()
        {
            return await Single<ServerAppInfo>(
                RequestGenerator.Jsonize("getApplicationInfo"),
                CustomParser.AsServerAppInfo).ConfigureAwait(false);
        }

        public async Task<List<string>> GetAvailableApiListAsync()
        {
            return await PrimitiveListByMethod<string>("getAvailableApiList").ConfigureAwait(false);
        }

        public async Task StartRecModeAsync()
        {
            await NoValueByMethod("startRecMode").ConfigureAwait(false);
        }

        public async Task StopRecModeAsync()
        {
            await NoValueByMethod("stopRecMode").ConfigureAwait(false);
        }

        public async Task ActZoomAsync(string direction, string movement)
        {
            await NoValue(RequestGenerator.Jsonize("actZoom", direction, movement)).ConfigureAwait(false);
        }

        public async Task<string> StartLiveviewAsync()
        {
            return await PrimitiveByMethod<string>("startLiveview").ConfigureAwait(false);
        }

        public async Task<string> StartLiveviewWithSizeAsync(string size)
        {
            return await Single<string>(
                RequestGenerator.Jsonize("startLiveviewWithSize", size),
                BasicParser.AsPrimitive<string>).ConfigureAwait(false);
        }

        public async Task<List<string>> GetSupportedLiveviewSize()
        {
            return await PrimitiveListByMethod<string>("getSupportedLiveviewSize").ConfigureAwait(false);
        }

        public async Task StopLiveviewAsync()
        {
            await NoValueByMethod("stopLiveview").ConfigureAwait(false);
        }

        public async Task SetLiveviewFrameInfo(FrameInfoSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setLiveviewFrameInfo", ApiVersion.V1_0, setting)).ConfigureAwait(false);
        }

        public async Task<FrameInfoSetting> GetLiveviewFrameInfo()
        {
            return await ObjectByMethod<FrameInfoSetting>("getLiveviewFrameInfo").ConfigureAwait(false);
        }

        public async Task StartAudioRecAsync()
        {
            await NoValueByMethod("startAudioRec").ConfigureAwait(false);
        }

        public async Task StopAudioRecAsync()
        {
            await NoValueByMethod("stopAudioRec").ConfigureAwait(false);
        }

        public async Task StartMovieRecAsync()
        {
            await NoValueByMethod("startMovieRec").ConfigureAwait(false);
        }

        public async Task<string> StopMovieRecAsync()
        {
            return await PrimitiveByMethod<string>("stopMovieRec").ConfigureAwait(false);
        }

        public async Task<List<string>> ActTakePictureAsync()
        {
            return await PrimitiveListByMethod<string>("actTakePicture").ConfigureAwait(false);
        }

        public async Task<List<string>> AwaitTakePictureAsync()
        {
            return await PrimitiveListByMethod<string>("awaitTakePicture").ConfigureAwait(false);
        }

        public async Task SetSelfTimerAsync(int timer)
        {
            await NoValue(RequestGenerator.Jsonize("setSelfTimer", timer)).ConfigureAwait(false);
        }

        public async Task<int> GetSelfTimerAsync()
        {
            return await PrimitiveByMethod<int>("getSelfTimer").ConfigureAwait(false);
        }

        public async Task<List<int>> GetSupportedSelfTimerAsync()
        {
            return await PrimitiveListByMethod<int>("getSupportedSelfTimer").ConfigureAwait(false);
        }

        public async Task<Capability<int>> GetAvailableSelfTimerAsync()
        {
            return await CapabilityByMethod<int>("getAvailableSelfTimer").ConfigureAwait(false);
        }

        public async Task SetPostviewImageSizeAsync(string size)
        {
            await NoValue(RequestGenerator.Jsonize("setPostviewImageSize", size)).ConfigureAwait(false);
        }

        public async Task<string> GetPostviewImageSizeAsync()
        {
            return await PrimitiveByMethod<string>("getPostviewImageSize").ConfigureAwait(false);
        }

        public async Task<List<string>> GetSupportedPostviewImageSizeAsync()
        {
            return await PrimitiveListByMethod<string>("getSupportedPostviewImageSize").ConfigureAwait(false);
        }

        public async Task<Capability<string>> GetAvailablePostviewImageSizeAsync()
        {
            return await CapabilityByMethod<string>("getAvailablePostviewImageSize").ConfigureAwait(false);
        }

        public async Task SetShootModeAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setShootMode", mode)).ConfigureAwait(false);
        }

        public async Task<string> GetShootModeAsync()
        {
            return await PrimitiveByMethod<string>("getShootMode").ConfigureAwait(false);
        }

        public async Task<List<string>> GetSupportedShootModeAsync()
        {
            return await PrimitiveListByMethod<string>("getSupportedShootMode").ConfigureAwait(false);
        }

        public async Task<Capability<string>> GetAvailableShootModeAsync()
        {
            return await CapabilityByMethod<string>("getAvailableShootMode").ConfigureAwait(false);
        }

        public async Task ActHalfPressShutterAsync()
        {
            await NoValueByMethod("actHalfPressShutter").ConfigureAwait(false);
        }

        public async Task CancelHalfPressShutterAsync()
        {
            await NoValueByMethod("cancelHalfPressShutter").ConfigureAwait(false);
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
                CustomParser.AsSetFocusResult).ConfigureAwait(false);
        }

        public async Task<TouchFocusStatus> GetTouchAFStatusAsync()
        {
            return await ObjectByMethod<TouchFocusStatus>("getTouchAFPosition").ConfigureAwait(false);
        }

        public async Task CancelTouchAFAsync()
        {
            await NoValueByMethod("cancelTouchAFPosition").ConfigureAwait(false);
        }

        public async Task SetExposureModeAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setExposureMode", mode)).ConfigureAwait(false);
        }

        public async Task<string> GetExposureModeAsync()
        {
            return await PrimitiveByMethod<string>("getExposureMode").ConfigureAwait(false);
        }

        public async Task<List<string>> GetSupportedExposureModeAsync()
        {
            return await PrimitiveListByMethod<string>("getSupportedExposureMode").ConfigureAwait(false);
        }

        public async Task<Capability<string>> GetAvailableExposureModeAsync()
        {
            return await CapabilityByMethod<string>("getAvailableExposureMode").ConfigureAwait(false);
        }

        public async Task SetFocusModeAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setFocusMode", mode)).ConfigureAwait(false);
        }

        public async Task<string> GetFocusModeAsync()
        {
            return await PrimitiveByMethod<string>("getFocusMode").ConfigureAwait(false);
        }

        public async Task<List<string>> GetSupportedFocusModeAsync()
        {
            return await PrimitiveListByMethod<string>("getSupportedFocusMode").ConfigureAwait(false);
        }

        public async Task<Capability<string>> GetAvailableFocusModeAsync()
        {
            return await CapabilityByMethod<string>("getAvailableFocusMode").ConfigureAwait(false);
        }

        public async Task SetEvIndexAsync(int index)
        {
            await NoValue(RequestGenerator.Jsonize("setExposureCompensation", index)).ConfigureAwait(false);
        }

        public async Task<int> GetEvIndexAsync()
        {
            return await PrimitiveByMethod<int>("getExposureCompensation").ConfigureAwait(false);
        }

        public async Task<List<EvCandidate>> GetSupportedEvAsync()
        {
            return await Single<List<EvCandidate>>(
                 RequestGenerator.Jsonize("getSupportedExposureCompensation"),
                 CustomParser.AsEvCandidates).ConfigureAwait(false);
        }

        public async Task<EvCapability> GetAvailableEvAsync()
        {
            return await Single<EvCapability>(
                RequestGenerator.Jsonize("getAvailableExposureCompensation"),
                CustomParser.AsEvCapability).ConfigureAwait(false);
        }

        public async Task SetFNumberAsync(string f)
        {
            await NoValue(RequestGenerator.Jsonize("setFNumber", f)).ConfigureAwait(false);
        }

        public async Task<string> GetFNumberAsync()
        {
            return await PrimitiveByMethod<string>("getFNumber").ConfigureAwait(false);
        }

        public async Task<List<string>> GetSupportedFNumberAsync()
        {
            return await PrimitiveListByMethod<string>("getSupportedFNumber").ConfigureAwait(false);
        }

        public async Task<Capability<string>> GetAvailableFNumberAsync()
        {
            return await CapabilityByMethod<string>("getAvailableFNumber").ConfigureAwait(false);
        }

        public async Task SetShutterSpeedAsync(string ss)
        {
            await NoValue(RequestGenerator.Jsonize("setShutterSpeed", ss)).ConfigureAwait(false);
        }

        public async Task<string> GetShutterSpeedAsync()
        {
            return await PrimitiveByMethod<string>("getShutterSpeed").ConfigureAwait(false);
        }

        public async Task<List<string>> GetSupportedShutterSpeedAsync()
        {
            return await PrimitiveListByMethod<string>("getSupportedShutterSpeed").ConfigureAwait(false);
        }

        public async Task<Capability<string>> GetAvailableShutterSpeedAsync()
        {
            return await CapabilityByMethod<string>("getAvailableShutterSpeed").ConfigureAwait(false);
        }

        public async Task SetISOSpeedAsync(string iso)
        {
            await NoValue(RequestGenerator.Jsonize("setIsoSpeedRate", iso)).ConfigureAwait(false);
        }

        public async Task<string> GetIsoSpeedAsync()
        {
            return await PrimitiveByMethod<string>("getIsoSpeedRate").ConfigureAwait(false);
        }

        public async Task<List<string>> GetSupportedIsoSpeedAsync()
        {
            return await PrimitiveListByMethod<string>("getSupportedIsoSpeedRate").ConfigureAwait(false);
        }

        public async Task<Capability<string>> GetAvailableIsoSpeedAsync()
        {
            return await CapabilityByMethod<string>("getAvailableIsoSpeedRate").ConfigureAwait(false);
        }

        public async Task SetStillImageSizeAsync(StillImageSize size)
        {
            await NoValue(RequestGenerator.Jsonize("setStillSize", size.AspectRatio, size.SizeDefinition)).ConfigureAwait(false);
        }

        public async Task<StillImageSize> GetStillSizeAsync()
        {
            return await ObjectByMethod<StillImageSize>(RequestGenerator.Jsonize("getStillSize")).ConfigureAwait(false);
        }

        public async Task<StillImageSize[]> GetSupportedStillSizeAsync()
        {
            return await ObjectByMethod<StillImageSize[]>("getSupportedStillSize").ConfigureAwait(false);
        }

        public async Task<Capability<StillImageSize>> GetAvailableStillSizeAsync()
        {
            return await Capability<StillImageSize>(
                RequestGenerator.Jsonize("getAvailableStillSize"),
                BasicParser.AsCapabilityObject<StillImageSize>).ConfigureAwait(false);
        }

        public async Task SetWhiteBalanceAsync(WhiteBalance wb)
        {
            await NoValue(RequestGenerator.Jsonize("setWhiteBalance", wb.Mode, wb.ColorTemperature != WhiteBalance.InvalidColorTemperture, wb.ColorTemperature)).ConfigureAwait(false);
        }

        public async Task<WhiteBalance> GetWhiteBalanceAsync()
        {
            return await ObjectByMethod<WhiteBalance>("getWhiteBalance").ConfigureAwait(false);
        }

        public async Task<WhiteBalanceCandidate[]> GetSupportedWhiteBalanceAsync()
        {
            return await ObjectByMethod<WhiteBalanceCandidate[]>("getSupportedWhiteBalance").ConfigureAwait(false);
        }

        public async Task<WhiteBalanceCapability> GetAvailableWhiteBalanceAsync()
        {
            return await Single<WhiteBalanceCapability>(
                RequestGenerator.Jsonize("getAvailableWhiteBalance"),
                CustomParser.AsWhiteBalanceCapability).ConfigureAwait(false);
        }

        public async Task SetBeepModeAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setBeepMode", mode)).ConfigureAwait(false);
        }

        public async Task<string> GetBeepModeAsync()
        {
            return await PrimitiveByMethod<string>("getBeepMode").ConfigureAwait(false);
        }

        public async Task<List<string>> GetSupportedBeepModeAsync()
        {
            return await PrimitiveListByMethod<string>("getSupportedBeepMode").ConfigureAwait(false);
        }

        public async Task<Capability<string>> GetAvailableBeepModeAsync()
        {
            return await CapabilityByMethod<string>("getAvailableBeepMode").ConfigureAwait(false);
        }

        public async Task StartIntervalStillRecAsync()
        {
            await NoValueByMethod("startIntervalStillRec").ConfigureAwait(false);
        }

        public async Task StopIntervalStillRecAsync()
        {
            await NoValueByMethod("stopIntervalStillRec").ConfigureAwait(false);
        }

        public async Task SetViewAngleAsync(int angle)
        {
            await NoValue(RequestGenerator.Jsonize("setViewAngle", angle)).ConfigureAwait(false);
        }

        public async Task<int> GetViewAngleAsync()
        {
            return await PrimitiveByMethod<int>("getViewAngle").ConfigureAwait(false);
        }

        public async Task<List<int>> GetSupportedViewAngleAsync()
        {
            return await PrimitiveListByMethod<int>("getSupportedViewAngle").ConfigureAwait(false);
        }

        public async Task<Capability<int>> GetAvailableViewAngleAsync()
        {
            return await CapabilityByMethod<int>("getAvailableViewAngle").ConfigureAwait(false);
        }

        public async Task SetSteadyModeAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setSteadyMode", mode)).ConfigureAwait(false);
        }

        public async Task<string> GetSteadyModeAsync()
        {
            return await PrimitiveByMethod<string>("getSteadyMode").ConfigureAwait(false);
        }

        public async Task<List<string>> GetSupportedSteadyModeAsync()
        {
            return await PrimitiveListByMethod<string>("getSupportedSteadyMode").ConfigureAwait(false);
        }

        public async Task<Capability<string>> GetAvailableSteadyModeAsync()
        {
            return await CapabilityByMethod<string>("getAvailableSteadyMode").ConfigureAwait(false);
        }

        public async Task SetMovieQualityAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setMovieQuality", mode)).ConfigureAwait(false);
        }

        public async Task<string> GetMovieQualityAsync()
        {
            return await PrimitiveByMethod<string>("getMovieQuality").ConfigureAwait(false);
        }

        public async Task<List<string>> GetSupportedMovieQualityAsync()
        {
            return await PrimitiveListByMethod<string>("getSupportedMovieQuality").ConfigureAwait(false);
        }

        public async Task<Capability<string>> GetAvailableMovieQualityAsync()
        {
            return await CapabilityByMethod<string>("getAvailableMovieQuality").ConfigureAwait(false);
        }

        public async Task SetFlashModeAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setFlashMode", mode)).ConfigureAwait(false);
        }

        public async Task<string> GetFlashModeAsync()
        {
            return await PrimitiveByMethod<string>("getFlashMode").ConfigureAwait(false);
        }

        public async Task<List<string>> GetSupportedFlashModeAsync()
        {
            return await PrimitiveListByMethod<string>("getSupportedFlashMode").ConfigureAwait(false);
        }

        public async Task<Capability<string>> GetAvailableFlashModeAsync()
        {
            return await CapabilityByMethod<string>("getAvailableFlashMode").ConfigureAwait(false);
        }

        public async Task SetProgramShiftAsync(int amount)
        {
            await NoValue(RequestGenerator.Jsonize("setProgramShift", amount)).ConfigureAwait(false);
        }

        public async Task<ProgramShiftRange> GetSupportedProgramShiftAsync()
        {
            return await Single<ProgramShiftRange>(
                RequestGenerator.Jsonize("getSupportedProgramShift"),
                CustomParser.AsProgramShiftRange).ConfigureAwait(false);
        }

        public async Task<AutoPowerOff> GetAutoPowerOffAsync()
        {
            return await ObjectByMethod<AutoPowerOff>("getAutoPowerOff").ConfigureAwait(false);
        }

        public async Task SetAutoPowerOffAsync(AutoPowerOff param)
        {
            await NoValue(RequestGenerator.Serialize("setAutoPowerOff", ApiVersion.V1_0, param)).ConfigureAwait(false);
        }

        public async Task<Candidate<int>> GetSupportedAutoPowerOffAsync()
        {
            return await ObjectByMethod<Candidate<int>>("getSupportedAutoPowerOff").ConfigureAwait(false);
        }

        public async Task<Capability<int>> GetAvailableAutoPowerOffAsync()
        {
            return await ObjectByMethod<ApoCapability>("getAvailableAutoPowerOff").ConfigureAwait(false);
        }

        public async Task<string> GetCameraFunctionAsync()
        {
            return await PrimitiveByMethod<string>("getCameraFunction").ConfigureAwait(false);
        }

        public async Task SetCameraFunctionAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setCameraFunction", mode)).ConfigureAwait(false);
        }

        public async Task<List<string>> GetSupportedCameraFunctionAsync()
        {
            return await PrimitiveListByMethod<string>("getSupportedCameraFunction").ConfigureAwait(false);
        }

        public async Task<Capability<string>> GetAvailableCameraFunctionAsync()
        {
            return await CapabilityByMethod<string>("getAvailableCameraFunction").ConfigureAwait(false);
        }

        public async Task<ColorSetting> GetColorSettingAsync()
        {
            return await ObjectByMethod<ColorSetting>("getColorSetting").ConfigureAwait(false);
        }

        public async Task SetColorSettingAsync(ColorSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setColorSetting", ApiVersion.V1_0, setting)).ConfigureAwait(false);
        }

        public async Task<Candidate<string>> GetSupportedColorSettingAsync()
        {
            return await ObjectByMethod<Candidate<string>>("getSupportedColorSetting").ConfigureAwait(false);
        }

        public async Task<Capability<string>> GetAvailableColorSettingAsync()
        {
            return await ObjectByMethod<ColorSettingCapability>("getAvailableColorSetting").ConfigureAwait(false);
        }

        public async Task<ContinuousShootSetting> GetContShootingModeAsync()
        {
            return await ObjectByMethod<ContinuousShootSetting>("getContShootingMode").ConfigureAwait(false);
        }

        public async Task SetContShootingModeAsync(ContinuousShootSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setContShootingMode", ApiVersion.V1_0, setting)).ConfigureAwait(false);
        }

        public async Task<Candidate<string>> GetSupportedContShootingModeAsync()
        {
            return await ObjectByMethod<Candidate<string>>("getSupportedContShootingMode").ConfigureAwait(false);
        }

        public async Task<Capability<string>> GetAvailableContShootingModeAsync()
        {
            return await ObjectByMethod<ContinuousShootingModeCapability>("getAvailableContShootingMode").ConfigureAwait(false);
        }

        public async Task<ContinuousShootSpeedSetting> GetContShootingSpeedAsync()
        {
            return await ObjectByMethod<ContinuousShootSpeedSetting>("getContShootingSpeed").ConfigureAwait(false);
        }

        public async Task SetContShootingSpeedAsync(ContinuousShootSpeedSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setContShootingSpeed", ApiVersion.V1_0, setting)).ConfigureAwait(false);
        }

        public async Task<Candidate<string>> GetSupportedContShootingSpeedAsync()
        {
            return await ObjectByMethod<Candidate<string>>("getSupportedContShootingSpeed").ConfigureAwait(false);
        }

        public async Task<Capability<string>> GetAvailableContShootingSpeedAsync()
        {
            return await ObjectByMethod<ContinuousShootingSpeedCapability>("getAvailableContShootingSpeed").ConfigureAwait(false);
        }

        public async Task<FlipSetting> GetFlipSettingAsync()
        {
            return await ObjectByMethod<FlipSetting>("getFlipSetting").ConfigureAwait(false);
        }

        public async Task SetFlipSettingAsync(FlipSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setFlipSetting", ApiVersion.V1_0, setting)).ConfigureAwait(false);
        }

        public async Task<Candidate<string>> GetSupportedFlipSettingAsync()
        {
            return await ObjectByMethod<Candidate<string>>("getSupportedFlipSetting").ConfigureAwait(false);
        }

        public async Task<Capability<string>> GetAvailableFlipSettingAsync()
        {
            return await ObjectByMethod<FlipModeCapability>("getAvailableFlipSetting").ConfigureAwait(false);
        }

        public async Task<StorageInfo> GetStorageInformationAsync()
        {
            return await ObjectByMethod<StorageInfo>("getStorageInformation").ConfigureAwait(false);
        }

        public async Task<IntervalTimeSetting> GetIntervalTimeAsync()
        {
            return await ObjectByMethod<IntervalTimeSetting>("getIntervalTime").ConfigureAwait(false);
        }

        public async Task SetIntervalTimeAsync(IntervalTimeSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setIntervalTime", ApiVersion.V1_0, setting)).ConfigureAwait(false);
        }

        public async Task<Candidate<string>> GetSupportedIntervalTime()
        {
            return await ObjectByMethod<Candidate<string>>("getSupportedIntervalTime").ConfigureAwait(false);
        }

        public async Task<Capability<string>> GetAvailableIntervalTimeAsync()
        {
            return await ObjectByMethod<IntervalTimeCapability>("getAvailableIntervalTime").ConfigureAwait(false);
        }

        public async Task<SceneSelectionSetting> GetSceneSelectionAsync()
        {
            return await ObjectByMethod<SceneSelectionSetting>("getSceneSelection").ConfigureAwait(false);
        }

        public async Task SetSceneSelectionAsync(SceneSelectionSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setSceneSelection", ApiVersion.V1_0, setting)).ConfigureAwait(false);
        }

        public async Task<Candidate<string>> GetSupportedSceneSelectionAsync()
        {
            return await ObjectByMethod<Candidate<string>>("getSupportedSceneSelection").ConfigureAwait(false);
        }

        public async Task<Capability<string>> GetAvailableSceneSelectionAsync()
        {
            return await ObjectByMethod<SceneSelectionCapability>("getAvailableSceneSelection").ConfigureAwait(false);
        }

        public async Task<ImageQualitySetting> GetStillQualityAsync()
        {
            return await ObjectByMethod<ImageQualitySetting>("getStillQuality").ConfigureAwait(false);
        }

        public async Task SetStillQualityAsync(ImageQualitySetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setStillQuality", ApiVersion.V1_0, setting)).ConfigureAwait(false);
        }

        public async Task<Candidate<string>> GetSupportedStillQualityAsync()
        {
            return await ObjectByMethod<Candidate<string>>("getSupportedStillQuality").ConfigureAwait(false);
        }

        public async Task<Capability<string>> GetAvailableStillQualityAsync()
        {
            return await ObjectByMethod<ImageQualityCapability>("getAvailableStillQuality").ConfigureAwait(false);
        }

        public async Task ActTrackingFocusAsync(FocusPosition position)
        {
            await NoValue(RequestGenerator.Serialize("actTrackingFocus", ApiVersion.V1_0, position)).ConfigureAwait(false);
        }

        public async Task CancelTrackingFocusAsync()
        {
            await NoValueByMethod("cancelTrackingFocus").ConfigureAwait(false);
        }

        public async Task SetTrackingFocusAsync(TrackingFocusSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setTrackingFocus", ApiVersion.V1_0, setting)).ConfigureAwait(false);
        }

        public async Task<TrackingFocusSetting> GetTrackingFocusAsync()
        {
            return await ObjectByMethod<TrackingFocusSetting>("getTrackingFocus").ConfigureAwait(false);
        }

        public async Task<Candidate<string>> GetSupportedTrackingFocus()
        {
            return await ObjectByMethod<Candidate<string>>("getSupportedTrackingFocus").ConfigureAwait(false);
        }

        public async Task<Capability<string>> GetAvailableTrackingFocusAsync()
        {
            return await ObjectByMethod<TrackingFocusModeCapability>("getAvailableTrackingFocus").ConfigureAwait(false);
        }

        public async Task<ZoomSetting> GetZoomSettingAsync()
        {
            return await ObjectByMethod<ZoomSetting>("getZoomSetting").ConfigureAwait(false);
        }

        public async Task SetZoomSettingAsync(ZoomSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setZoomSetting", ApiVersion.V1_0, setting)).ConfigureAwait(false);
        }

        public async Task<Candidate<string>> GetSupportedZoomSettingAsync()
        {
            return await ObjectByMethod<Candidate<string>>("getSupportedZoomSetting").ConfigureAwait(false);
        }

        public async Task<Capability<string>> GetAvailableZoomSettingAsync()
        {
            return await ObjectByMethod<ZoomModeCapability>("getAvailableZoomSetting").ConfigureAwait(false);
        }

        public async Task StartContShootingAsync()
        {
            await NoValueByMethod("startContShooting").ConfigureAwait(false);
        }

        public async Task StopContShootingAsync()
        {
            await NoValueByMethod("stopContShooting").ConfigureAwait(false);
        }

        public async Task<MovieFormat> GetMovieFileFormat()
        {
            return await ObjectByMethod<MovieFormat>("getMovieFileFormat").ConfigureAwait(false);
        }

        public async Task SetMovieFileFormatAsync(MovieFormat setting)
        {
            await NoValue(RequestGenerator.Serialize("setMovieFileFormat", ApiVersion.V1_0, setting)).ConfigureAwait(false);
        }

        public async Task<Candidate<string>> GetSupportedMovieFileFormatAsync()
        {
            return await ObjectByMethod<Candidate<string>>("getSupportedMovieFileFormat").ConfigureAwait(false);
        }

        public async Task<Capability<string>> GetAvailableMovieFileFormatAsync()
        {
            return await ObjectByMethod<MovieFormatCapability>("getAvailableMovieFileFormat").ConfigureAwait(false);
        }

        public async Task<TvColorSystem> GetTvColorSystem()
        {
            return await ObjectByMethod<TvColorSystem>("getTvColorSystem").ConfigureAwait(false);
        }

        public async Task SetTvColorSystemAsync(TvColorSystem setting)
        {
            await NoValue(RequestGenerator.Serialize("setTvColorSystem", ApiVersion.V1_0, setting)).ConfigureAwait(false);
        }

        public async Task<Candidate<string>> GetSupportedTvColorSystemAsync()
        {
            return await ObjectByMethod<Candidate<string>>("getSupportedTvColorSystem").ConfigureAwait(false);
        }

        public async Task<Capability<string>> GetAvailableTvColorSystemAsync()
        {
            return await ObjectByMethod<TvColorSystemCapability>("getAvailableTvColorSystem").ConfigureAwait(false);
        }

        public async Task<InfraredRemoteControl> GetInfraredRemoteControl()
        {
            return await ObjectByMethod<InfraredRemoteControl>("getInfraredRemoteControl").ConfigureAwait(false);
        }

        public async Task SetInfraredRemoteControlAsync(InfraredRemoteControl setting)
        {
            await NoValue(RequestGenerator.Serialize("setInfraredRemoteControl", ApiVersion.V1_0, setting)).ConfigureAwait(false);
        }

        public async Task<Candidate<string>> GetSupportedInfraredRemoteControlAsync()
        {
            return await ObjectByMethod<Candidate<string>>("getSupportedInfraredRemoteControl").ConfigureAwait(false);
        }

        public async Task<Capability<string>> GetAvailableInfraredRemoteControlAsync()
        {
            return await ObjectByMethod<InfraredRemoteControlCapability>("getAvailableInfraredRemoteControl").ConfigureAwait(false);
        }
    }
}
