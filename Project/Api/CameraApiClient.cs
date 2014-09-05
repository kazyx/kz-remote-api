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
                CustomParser.AsCameraEvent);
        }

        public async Task<ServerAppInfo> GetApplicationInfoAsync()
        {
            return await Single<ServerAppInfo>(
                RequestGenerator.Jsonize("getApplicationInfo"),
                CustomParser.AsServerAppInfo);
        }

        public async Task<List<string>> GetAvailableApiListAsync()
        {
            return await PrimitiveListByMethod<string>("getAvailableApiList");
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

        public async Task<string> StartLiveviewWithSizeAsync(string size)
        {
            return await Single<string>(
                RequestGenerator.Jsonize("startLiveviewWithSize", size),
                BasicParser.AsPrimitive<string>);
        }

        public async Task<List<string>> GetSupportedLiveviewSize()
        {
            return await PrimitiveListByMethod<string>("getSupportedLiveviewSize");
        }

        public async Task StopLiveviewAsync()
        {
            await NoValueByMethod("stopLiveview");
        }

        public async Task SetLiveviewFrameInfo(FrameInfoSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setLiveviewFrameInfo", ApiVersion.V1_0, setting));
        }

        public async Task<FrameInfoSetting> GetLiveviewFrameInfo()
        {
            return await ObjectByMethod<FrameInfoSetting>("getLiveviewFrameInfo");
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

        public async Task<List<string>> ActTakePictureAsync()
        {
            return await PrimitiveListByMethod<string>("actTakePicture");
        }

        public async Task<List<string>> AwaitTakePictureAsync()
        {
            return await PrimitiveListByMethod<string>("awaitTakePicture");
        }

        public async Task SetSelfTimerAsync(int timer)
        {
            await NoValue(RequestGenerator.Jsonize("setSelfTimer", timer));
        }

        public async Task<int> GetSelfTimerAsync()
        {
            return await PrimitiveByMethod<int>("getSelfTimer");
        }

        public async Task<List<int>> GetSupportedSelfTimerAsync()
        {
            return await PrimitiveListByMethod<int>("getSupportedSelfTimer");
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

        public async Task<List<string>> GetSupportedPostviewImageSizeAsync()
        {
            return await PrimitiveListByMethod<string>("getSupportedPostviewImageSize");
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

        public async Task<List<string>> GetSupportedShootModeAsync()
        {
            return await PrimitiveListByMethod<string>("getSupportedShootMode");
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

        public async Task<List<string>> GetSupportedExposureModeAsync()
        {
            return await PrimitiveListByMethod<string>("getSupportedExposureMode");
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

        public async Task<List<string>> GetSupportedFocusModeAsync()
        {
            return await PrimitiveListByMethod<string>("getSupportedFocusMode");
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

        public async Task<List<EvCandidate>> GetSupportedEvAsync()
        {
            return await Single<List<EvCandidate>>(
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

        public async Task<List<string>> GetSupportedFNumberAsync()
        {
            return await PrimitiveListByMethod<string>("getSupportedFNumber");
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

        public async Task<List<string>> GetSupportedShutterSpeedAsync()
        {
            return await PrimitiveListByMethod<string>("getSupportedShutterSpeed");
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

        public async Task<List<string>> GetSupportedIsoSpeedAsync()
        {
            return await PrimitiveListByMethod<string>("getSupportedIsoSpeedRate");
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

        public async Task SetWhiteBalanceAsync(WhiteBalance wb)
        {
            await NoValue(RequestGenerator.Jsonize("setWhiteBalance", wb.Mode, wb.ColorTemperature != WhiteBalance.InvalidColorTemperture, wb.ColorTemperature));
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

        public async Task<List<string>> GetSupportedBeepModeAsync()
        {
            return await PrimitiveListByMethod<string>("getSupportedBeepMode");
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

        public async Task<List<int>> GetSupportedViewAngleAsync()
        {
            return await PrimitiveListByMethod<int>("getSupportedViewAngle");
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

        public async Task<List<string>> GetSupportedSteadyModeAsync()
        {
            return await PrimitiveListByMethod<string>("getSupportedSteadyMode");
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

        public async Task<List<string>> GetSupportedMovieQualityAsync()
        {
            return await PrimitiveListByMethod<string>("getSupportedMovieQuality");
        }

        public async Task<Capability<string>> GetAvailableMovieQualityAsync()
        {
            return await CapabilityByMethod<string>("getAvailableMovieQuality");
        }

        public async Task SetFlashModeAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setFlashMode", mode));
        }

        public async Task<string> GetFlashModeAsync()
        {
            return await PrimitiveByMethod<string>("getFlashMode");
        }

        public async Task<List<string>> GetSupportedFlashModeAsync()
        {
            return await PrimitiveListByMethod<string>("getSupportedFlashMode");
        }

        public async Task<Capability<string>> GetAvailableFlashModeAsync()
        {
            return await CapabilityByMethod<string>("getAvailableFlashMode");
        }

        public async Task SetProgramShiftAsync(int amount)
        {
            await NoValue(RequestGenerator.Jsonize("setProgramShift", amount));
        }

        public async Task<ProgramShiftRange> GetSupportedProgramShiftAsync()
        {
            return await Single<ProgramShiftRange>(
                RequestGenerator.Jsonize("getSupportedProgramShift"),
                CustomParser.AsProgramShiftRange);
        }

        public async Task<AutoPowerOff> GetAutoPowerOffAsync()
        {
            return await ObjectByMethod<AutoPowerOff>("getAutoPowerOff");
        }

        public async Task SetAutoPowerOffAsync(AutoPowerOff param)
        {
            await NoValue(RequestGenerator.Serialize("setAutoPowerOff", ApiVersion.V1_0, param));
        }

        public async Task<Candidate<int>> GetSupportedAutoPowerOffAsync()
        {
            return await ObjectByMethod<Candidate<int>>("getSupportedAutoPowerOff");
        }

        public async Task<Capability<int>> GetAvailableAutoPowerOffAsync()
        {
            return await ObjectByMethod<ApoCapability>("getAvailableAutoPowerOff");
        }

        public async Task<string> GetCameraFunctionAsync()
        {
            return await PrimitiveByMethod<string>("getCameraFunction");
        }

        public async Task SetCameraFunctionAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setCameraFunction", mode));
        }

        public async Task<List<string>> GetSupportedCameraFunctionAsync()
        {
            return await PrimitiveListByMethod<string>("getSupportedCameraFunction");
        }

        public async Task<Capability<string>> GetAvailableCameraFunctionAsync()
        {
            return await CapabilityByMethod<string>("getAvailableCameraFunction");
        }

        public async Task<ColorSetting> GetColorSettingAsync()
        {
            return await ObjectByMethod<ColorSetting>("getColorSetting");
        }

        public async Task SetColorSettingAsync(ColorSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setColorSetting", ApiVersion.V1_0, setting));
        }

        public async Task<Candidate<string>> GetSupportedColorSettingAsync()
        {
            return await ObjectByMethod<Candidate<string>>("getSupportedColorSetting");
        }

        public async Task<Capability<string>> GetAvailableColorSettingAsync()
        {
            return await ObjectByMethod<ColorSettingCapability>("getAvailableColorSetting");
        }

        public async Task<ContinuousShootSetting> GetContShootingModeAsync()
        {
            return await ObjectByMethod<ContinuousShootSetting>("getContShootingMode");
        }

        public async Task SetContShootingModeAsync(ContinuousShootSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setContShootingMode", ApiVersion.V1_0, setting));
        }

        public async Task<Candidate<string>> GetSupportedContShootingModeAsync()
        {
            return await ObjectByMethod<Candidate<string>>("getSupportedContShootingMode");
        }

        public async Task<Capability<string>> GetAvailableContShootingModeAsync()
        {
            return await ObjectByMethod<ContinuousShootingModeCapability>("getAvailableContShootingMode");
        }

        public async Task<ContinuousShootSpeedSetting> GetContShootingSpeedAsync()
        {
            return await ObjectByMethod<ContinuousShootSpeedSetting>("getContShootingSpeed");
        }

        public async Task SetContShootingSpeedAsync(ContinuousShootSpeedSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setContShootingSpeed", ApiVersion.V1_0, setting));
        }

        public async Task<Candidate<string>> GetSupportedContShootingSpeedAsync()
        {
            return await ObjectByMethod<Candidate<string>>("getSupportedContShootingSpeed");
        }

        public async Task<Capability<string>> GetAvailableContShootingSpeedAsync()
        {
            return await ObjectByMethod<ContinuousShootingSpeedCapability>("getAvailableContShootingSpeed");
        }

        public async Task<FlipSetting> GetFlipSettingAsync()
        {
            return await ObjectByMethod<FlipSetting>("getFlipSetting");
        }

        public async Task SetFlipSettingAsync(FlipSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setFlipSetting", ApiVersion.V1_0, setting));
        }

        public async Task<Candidate<string>> GetSupportedFlipSettingAsync()
        {
            return await ObjectByMethod<Candidate<string>>("getSupportedFlipSetting");
        }

        public async Task<Capability<string>> GetAvailableFlipSettingAsync()
        {
            return await ObjectByMethod<FlipModeCapability>("getAvailableFlipSetting");
        }

        public async Task<StorageInfo> GetStorageInformationAsync()
        {
            return await ObjectByMethod<StorageInfo>("getStorageInformation");
        }

        public async Task<IntervalTimeSetting> GetIntervalTimeAsync()
        {
            return await ObjectByMethod<IntervalTimeSetting>("getIntervalTime");
        }

        public async Task SetIntervalTimeAsync(IntervalTimeSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setIntervalTime", ApiVersion.V1_0, setting));
        }

        public async Task<Candidate<string>> GetSupportedIntervalTime()
        {
            return await ObjectByMethod<Candidate<string>>("getSupportedIntervalTime");
        }

        public async Task<Capability<string>> GetAvailableIntervalTimeAsync()
        {
            return await ObjectByMethod<IntervalTimeCapability>("getAvailableIntervalTime");
        }

        public async Task<SceneSelectionSetting> GetSceneSelectionAsync()
        {
            return await ObjectByMethod<SceneSelectionSetting>("getSceneSelection");
        }

        public async Task SetSceneSelectionAsync(SceneSelectionSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setSceneSelection", ApiVersion.V1_0, setting));
        }

        public async Task<Candidate<string>> GetSupportedSceneSelectionAsync()
        {
            return await ObjectByMethod<Candidate<string>>("getSupportedSceneSelection");
        }

        public async Task<Capability<string>> GetAvailableSceneSelectionAsync()
        {
            return await ObjectByMethod<SceneSelectionCapability>("getAvailableSceneSelection");
        }

        public async Task<ImageQualitySetting> GetStillQualityAsync()
        {
            return await ObjectByMethod<ImageQualitySetting>("getStillQuality");
        }

        public async Task SetStillQualityAsync(ImageQualitySetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setStillQuality", ApiVersion.V1_0, setting));
        }

        public async Task<Candidate<string>> GetSupportedStillQualityAsync()
        {
            return await ObjectByMethod<Candidate<string>>("getSupportedStillQuality");
        }

        public async Task<Capability<string>> GetAvailableStillQualityAsync()
        {
            return await ObjectByMethod<ImageQualityCapability>("getAvailableStillQuality");
        }

        public async Task ActTrackingFocusAsync(FocusPosition position)
        {
            await NoValue(RequestGenerator.Serialize("actTrackingFocus", ApiVersion.V1_0, position));
        }

        public async Task CancelTrackingFocusAsync()
        {
            await NoValueByMethod("cancelTrackingFocus");
        }

        public async Task SetTrackingFocusAsync(TrackingFocusSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setTrackingFocus", ApiVersion.V1_0, setting));
        }

        public async Task<TrackingFocusSetting> GetTrackingFocusAsync()
        {
            return await ObjectByMethod<TrackingFocusSetting>("getTrackingFocus");
        }

        public async Task<Candidate<string>> GetSupportedTrackingFocus()
        {
            return await ObjectByMethod<Candidate<string>>("getSupportedTrackingFocus");
        }

        public async Task<Capability<string>> GetAvailableTrackingFocusAsync()
        {
            return await ObjectByMethod<TrackingFocusModeCapability>("getAvailableTrackingFocus");
        }

        public async Task<ZoomSetting> GetZoomSettingAsync()
        {
            return await ObjectByMethod<ZoomSetting>("getZoomSetting");
        }

        public async Task SetZoomSettingAsync(ZoomSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setZoomSetting", ApiVersion.V1_0, setting));
        }

        public async Task<Candidate<string>> GetSupportedZoomSettingAsync()
        {
            return await ObjectByMethod<Candidate<string>>("getSupportedZoomSetting");
        }

        public async Task<Capability<string>> GetAvailableZoomSettingAsync()
        {
            return await ObjectByMethod<ZoomModeCapability>("getAvailableZoomSetting");
        }

        public async Task StartContShootingAsync()
        {
            await NoValueByMethod("startContShooting");
        }

        public async Task StopContShootingAsync()
        {
            await NoValueByMethod("stopContShootingAsync");
        }

        public async Task<MovieFormat> GetMovieFileFormat()
        {
            return await ObjectByMethod<MovieFormat>("getMovieFileFormat");
        }

        public async Task SetMovieFileFormatAsync(MovieFormat setting)
        {
            await NoValue(RequestGenerator.Serialize("setMovieFileFormat", ApiVersion.V1_0, setting));
        }

        public async Task<Candidate<string>> GetSupportedMovieFileFormatAsync()
        {
            return await ObjectByMethod<Candidate<string>>("getSupportedMovieFileFormat");
        }

        public async Task<Capability<string>> GetAvailableMovieFileFormatAsync()
        {
            return await ObjectByMethod<MovieFormatCapability>("getAvailableMovieFileFormat");
        }

        public async Task<TvColorSystem> GetTvColorSystem()
        {
            return await ObjectByMethod<TvColorSystem>("getTvColorSystem");
        }

        public async Task SetTvColorSystemAsync(TvColorSystem setting)
        {
            await NoValue(RequestGenerator.Serialize("setTvColorSystem", ApiVersion.V1_0, setting));
        }

        public async Task<Candidate<string>> GetSupportedTvColorSystemAsync()
        {
            return await ObjectByMethod<Candidate<string>>("getSupportedTvColorSystem");
        }

        public async Task<Capability<string>> GetAvailableTvColorSystemAsync()
        {
            return await ObjectByMethod<TvColorSystemCapability>("getAvailableTvColorSystem");
        }

        public async Task<InfraredRemoteControl> GetInfraredRemoteControl()
        {
            return await ObjectByMethod<InfraredRemoteControl>("getInfraredRemoteControl");
        }

        public async Task SetInfraredRemoteControlAsync(InfraredRemoteControl setting)
        {
            await NoValue(RequestGenerator.Serialize("setInfraredRemoteControl", ApiVersion.V1_0, setting));
        }

        public async Task<Candidate<string>> GetSupportedInfraredRemoteControlAsync()
        {
            return await ObjectByMethod<Candidate<string>>("getSupportedInfraredRemoteControl");
        }

        public async Task<Capability<string>> GetAvailableInfraredRemoteControlAsync()
        {
            return await ObjectByMethod<InfraredRemoteControlCapability>("getAvailableInfraredRemoteControl");
        }
    }
}
