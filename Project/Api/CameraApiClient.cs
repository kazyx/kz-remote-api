using System;
using System.Collections.Generic;
using System.Threading;
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
        public Task<Event> GetEventAsync(bool longpolling, ApiVersion version = ApiVersion.V1_0
            , CancellationTokenSource cancel = null)
        {
            return Single(
                RequestGenerator.Jsonize("getEvent", version, longpolling),
                CustomParser.AsCameraEvent, cancel);
        }

        public Task<ServerAppInfo> GetApplicationInfoAsync()
        {
            return Single(
                RequestGenerator.Jsonize("getApplicationInfo"),
                CustomParser.AsServerAppInfo);
        }

        public Task<List<string>> GetAvailableApiListAsync()
        {
            return PrimitiveListByMethod<string>("getAvailableApiList");
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

        public Task<string> StartLiveviewAsync()
        {
            return PrimitiveByMethod<string>("startLiveview");
        }

        public Task<string> StartLiveviewWithSizeAsync(string size)
        {
            return Single(
                RequestGenerator.Jsonize("startLiveviewWithSize", size),
                BasicParser.AsPrimitive<string>);
        }

        public Task<List<string>> GetSupportedLiveviewSizeAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedLiveviewSize");
        }

        public async Task StopLiveviewAsync()
        {
            await NoValueByMethod("stopLiveview");
        }

        public async Task SetLiveviewFrameInfoAsync(FrameInfoSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setLiveviewFrameInfo", ApiVersion.V1_0, setting));
        }

        public Task<FrameInfoSetting> GetLiveviewFrameInfoAsync()
        {
            return ObjectByMethod<FrameInfoSetting>("getLiveviewFrameInfo");
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

        public Task<string> StopMovieRecAsync()
        {
            return PrimitiveByMethod<string>("stopMovieRec");
        }

        public Task<List<string>> ActTakePictureAsync(CancellationTokenSource cancel = null)
        {
            return PrimitiveListByMethod<string>("actTakePicture", ApiVersion.V1_0, cancel);
        }

        public Task<List<string>> AwaitTakePictureAsync(CancellationTokenSource cancel = null)
        {
            return PrimitiveListByMethod<string>("awaitTakePicture", ApiVersion.V1_0, cancel);
        }

        public async Task SetSelfTimerAsync(int timer)
        {
            await NoValue(RequestGenerator.Jsonize("setSelfTimer", timer));
        }

        public Task<int> GetSelfTimerAsync()
        {
            return PrimitiveByMethod<int>("getSelfTimer");
        }

        public Task<List<int>> GetSupportedSelfTimerAsync()
        {
            return PrimitiveListByMethod<int>("getSupportedSelfTimer");
        }

        public Task<Capability<int>> GetAvailableSelfTimerAsync()
        {
            return CapabilityByMethod<int>("getAvailableSelfTimer");
        }

        public async Task SetPostviewImageSizeAsync(string size)
        {
            await NoValue(RequestGenerator.Jsonize("setPostviewImageSize", size));
        }

        public Task<string> GetPostviewImageSizeAsync()
        {
            return PrimitiveByMethod<string>("getPostviewImageSize");
        }

        public Task<List<string>> GetSupportedPostviewImageSizeAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedPostviewImageSize");
        }

        public Task<Capability<string>> GetAvailablePostviewImageSizeAsync()
        {
            return CapabilityByMethod<string>("getAvailablePostviewImageSize");
        }

        public async Task SetShootModeAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setShootMode", mode));
        }

        public Task<string> GetShootModeAsync()
        {
            return PrimitiveByMethod<string>("getShootMode");
        }

        public Task<List<string>> GetSupportedShootModeAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedShootMode");
        }

        public Task<Capability<string>> GetAvailableShootModeAsync()
        {
            return CapabilityByMethod<string>("getAvailableShootMode");
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
        public Task<SetFocusResult> SetAFPositionAsync(double x, double y)
        {
            return Single(
                RequestGenerator.Jsonize("setTouchAFPosition", x, y),
                CustomParser.AsSetFocusResult);
        }

        public Task<TouchFocusStatus> GetTouchAFStatusAsync()
        {
            return ObjectByMethod<TouchFocusStatus>("getTouchAFPosition");
        }

        public async Task CancelTouchAFAsync()
        {
            await NoValueByMethod("cancelTouchAFPosition");
        }

        public async Task SetExposureModeAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setExposureMode", mode));
        }

        public Task<string> GetExposureModeAsync()
        {
            return PrimitiveByMethod<string>("getExposureMode");
        }

        public Task<List<string>> GetSupportedExposureModeAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedExposureMode");
        }

        public Task<Capability<string>> GetAvailableExposureModeAsync()
        {
            return CapabilityByMethod<string>("getAvailableExposureMode");
        }

        public async Task SetFocusModeAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setFocusMode", mode));
        }

        public Task<string> GetFocusModeAsync()
        {
            return PrimitiveByMethod<string>("getFocusMode");
        }

        public Task<List<string>> GetSupportedFocusModeAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedFocusMode");
        }

        public Task<Capability<string>> GetAvailableFocusModeAsync()
        {
            return CapabilityByMethod<string>("getAvailableFocusMode");
        }

        public async Task SetEvIndexAsync(int index)
        {
            await NoValue(RequestGenerator.Jsonize("setExposureCompensation", index));
        }

        public Task<int> GetEvIndexAsync()
        {
            return PrimitiveByMethod<int>("getExposureCompensation");
        }

        public Task<List<EvCandidate>> GetSupportedEvAsync()
        {
            return Single(
                 RequestGenerator.Jsonize("getSupportedExposureCompensation"),
                 CustomParser.AsEvCandidates);
        }

        public Task<EvCapability> GetAvailableEvAsync()
        {
            return Single(
                RequestGenerator.Jsonize("getAvailableExposureCompensation"),
                CustomParser.AsEvCapability);
        }

        public async Task SetFNumberAsync(string f)
        {
            await NoValue(RequestGenerator.Jsonize("setFNumber", f));
        }

        public Task<string> GetFNumberAsync()
        {
            return PrimitiveByMethod<string>("getFNumber");
        }

        public Task<List<string>> GetSupportedFNumberAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedFNumber");
        }

        public Task<Capability<string>> GetAvailableFNumberAsync()
        {
            return CapabilityByMethod<string>("getAvailableFNumber");
        }

        public async Task SetShutterSpeedAsync(string ss)
        {
            await NoValue(RequestGenerator.Jsonize("setShutterSpeed", ss));
        }

        public Task<string> GetShutterSpeedAsync()
        {
            return PrimitiveByMethod<string>("getShutterSpeed");
        }

        public Task<List<string>> GetSupportedShutterSpeedAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedShutterSpeed");
        }

        public Task<Capability<string>> GetAvailableShutterSpeedAsync()
        {
            return CapabilityByMethod<string>("getAvailableShutterSpeed");
        }

        public async Task SetISOSpeedAsync(string iso)
        {
            await NoValue(RequestGenerator.Jsonize("setIsoSpeedRate", iso));
        }

        public Task<string> GetIsoSpeedAsync()
        {
            return PrimitiveByMethod<string>("getIsoSpeedRate");
        }

        public Task<List<string>> GetSupportedIsoSpeedAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedIsoSpeedRate");
        }

        public Task<Capability<string>> GetAvailableIsoSpeedAsync()
        {
            return CapabilityByMethod<string>("getAvailableIsoSpeedRate");
        }

        public async Task SetStillImageSizeAsync(StillImageSize size)
        {
            await NoValue(RequestGenerator.Jsonize("setStillSize", size.AspectRatio, size.SizeDefinition));
        }

        public Task<StillImageSize> GetStillSizeAsync()
        {
            return ObjectByMethod<StillImageSize>(RequestGenerator.Jsonize("getStillSize"));
        }

        public Task<StillImageSize[]> GetSupportedStillSizeAsync()
        {
            return ObjectByMethod<StillImageSize[]>("getSupportedStillSize");
        }

        public Task<Capability<StillImageSize>> GetAvailableStillSizeAsync()
        {
            return Capability(
                RequestGenerator.Jsonize("getAvailableStillSize"),
                BasicParser.AsCapabilityObject<StillImageSize>);
        }

        public async Task SetWhiteBalanceAsync(WhiteBalance wb)
        {
            await NoValue(RequestGenerator.Jsonize("setWhiteBalance", wb.Mode, wb.ColorTemperature != WhiteBalance.InvalidColorTemperture, wb.ColorTemperature));
        }

        public Task<WhiteBalance> GetWhiteBalanceAsync()
        {
            return ObjectByMethod<WhiteBalance>("getWhiteBalance");
        }

        public Task<WhiteBalanceCandidate[]> GetSupportedWhiteBalanceAsync()
        {
            return ObjectByMethod<WhiteBalanceCandidate[]>("getSupportedWhiteBalance");
        }

        public Task<WhiteBalanceCapability> GetAvailableWhiteBalanceAsync()
        {
            return Single(
                RequestGenerator.Jsonize("getAvailableWhiteBalance"),
                CustomParser.AsWhiteBalanceCapability);
        }

        public Task<CaptureBasedWhiteBalance> ActWhiteBalanceOnePushCustomAsync()
        {
            return ObjectByMethod<CaptureBasedWhiteBalance>("actWhiteBalanceOnePushCustom");
        }

        public async Task SetBeepModeAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setBeepMode", mode));
        }

        public Task<string> GetBeepModeAsync()
        {
            return PrimitiveByMethod<string>("getBeepMode");
        }

        public Task<List<string>> GetSupportedBeepModeAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedBeepMode");
        }

        public Task<Capability<string>> GetAvailableBeepModeAsync()
        {
            return CapabilityByMethod<string>("getAvailableBeepMode");
        }

        public async Task StartIntervalStillRecAsync()
        {
            await NoValueByMethod("startIntervalStillRec");
        }

        public async Task StopIntervalStillRecAsync()
        {
            await NoValueByMethod("stopIntervalStillRec");
        }

        public async Task StartLoopRecAsync()
        {
            await NoValueByMethod("startLoopRec");
        }

        public async Task StopLoopRecAsync()
        {
            await NoValueByMethod("stopLoopRec");
        }

        public async Task SetViewAngleAsync(int angle)
        {
            await NoValue(RequestGenerator.Jsonize("setViewAngle", angle));
        }

        public Task<int> GetViewAngleAsync()
        {
            return PrimitiveByMethod<int>("getViewAngle");
        }

        public Task<List<int>> GetSupportedViewAngleAsync()
        {
            return PrimitiveListByMethod<int>("getSupportedViewAngle");
        }

        public Task<Capability<int>> GetAvailableViewAngleAsync()
        {
            return CapabilityByMethod<int>("getAvailableViewAngle");
        }

        public async Task SetSteadyModeAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setSteadyMode", mode));
        }

        public Task<string> GetSteadyModeAsync()
        {
            return PrimitiveByMethod<string>("getSteadyMode");
        }

        public Task<List<string>> GetSupportedSteadyModeAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedSteadyMode");
        }

        public Task<Capability<string>> GetAvailableSteadyModeAsync()
        {
            return CapabilityByMethod<string>("getAvailableSteadyMode");
        }

        public async Task SetMovieQualityAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setMovieQuality", mode));
        }

        public Task<string> GetMovieQualityAsync()
        {
            return PrimitiveByMethod<string>("getMovieQuality");
        }

        public Task<List<string>> GetSupportedMovieQualityAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedMovieQuality");
        }

        public Task<Capability<string>> GetAvailableMovieQualityAsync()
        {
            return CapabilityByMethod<string>("getAvailableMovieQuality");
        }

        public async Task SetFlashModeAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setFlashMode", mode));
        }

        public Task<string> GetFlashModeAsync()
        {
            return PrimitiveByMethod<string>("getFlashMode");
        }

        public Task<List<string>> GetSupportedFlashModeAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedFlashMode");
        }

        public Task<Capability<string>> GetAvailableFlashModeAsync()
        {
            return CapabilityByMethod<string>("getAvailableFlashMode");
        }

        public async Task SetProgramShiftAsync(int amount)
        {
            await NoValue(RequestGenerator.Jsonize("setProgramShift", amount));
        }

        public Task<ProgramShiftRange> GetSupportedProgramShiftAsync()
        {
            return Single(
                RequestGenerator.Jsonize("getSupportedProgramShift"),
                CustomParser.AsProgramShiftRange);
        }

        public Task<AutoPowerOff> GetAutoPowerOffAsync()
        {
            return ObjectByMethod<AutoPowerOff>("getAutoPowerOff");
        }

        public async Task SetAutoPowerOffAsync(AutoPowerOff param)
        {
            await NoValue(RequestGenerator.Serialize("setAutoPowerOff", ApiVersion.V1_0, param));
        }

        public Task<Candidate<int>> GetSupportedAutoPowerOffAsync()
        {
            return ObjectByMethod<Candidate<int>>("getSupportedAutoPowerOff");
        }

        public async Task<Capability<int>> GetAvailableAutoPowerOffAsync()
        {
            return await ObjectByMethod<ApoCapability>("getAvailableAutoPowerOff").ConfigureAwait(false);
        }

        public Task<string> GetCameraFunctionAsync()
        {
            return PrimitiveByMethod<string>("getCameraFunction");
        }

        public async Task SetCameraFunctionAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setCameraFunction", mode));
        }

        public Task<List<string>> GetSupportedCameraFunctionAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedCameraFunction");
        }

        public Task<Capability<string>> GetAvailableCameraFunctionAsync()
        {
            return CapabilityByMethod<string>("getAvailableCameraFunction");
        }

        public Task<ColorSetting> GetColorSettingAsync()
        {
            return ObjectByMethod<ColorSetting>("getColorSetting");
        }

        public async Task SetColorSettingAsync(ColorSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setColorSetting", ApiVersion.V1_0, setting));
        }

        public Task<Candidate<string>> GetSupportedColorSettingAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedColorSetting");
        }

        public async Task<Capability<string>> GetAvailableColorSettingAsync()
        {
            return await ObjectByMethod<ColorSettingCapability>("getAvailableColorSetting").ConfigureAwait(false);
        }

        public Task<ContinuousShootSetting> GetContShootingModeAsync()
        {
            return ObjectByMethod<ContinuousShootSetting>("getContShootingMode");
        }

        public async Task SetContShootingModeAsync(ContinuousShootSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setContShootingMode", ApiVersion.V1_0, setting));
        }

        public Task<Candidate<string>> GetSupportedContShootingModeAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedContShootingMode");
        }

        public async Task<Capability<string>> GetAvailableContShootingModeAsync()
        {
            return await ObjectByMethod<ContinuousShootingModeCapability>("getAvailableContShootingMode").ConfigureAwait(false);
        }

        public Task<ContinuousShootSpeedSetting> GetContShootingSpeedAsync()
        {
            return ObjectByMethod<ContinuousShootSpeedSetting>("getContShootingSpeed");
        }

        public async Task SetContShootingSpeedAsync(ContinuousShootSpeedSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setContShootingSpeed", ApiVersion.V1_0, setting));
        }

        public Task<Candidate<string>> GetSupportedContShootingSpeedAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedContShootingSpeed");
        }

        public async Task<Capability<string>> GetAvailableContShootingSpeedAsync()
        {
            return await ObjectByMethod<ContinuousShootingSpeedCapability>("getAvailableContShootingSpeed").ConfigureAwait(false);
        }

        public Task<FlipSetting> GetFlipSettingAsync()
        {
            return ObjectByMethod<FlipSetting>("getFlipSetting");
        }

        public async Task SetFlipSettingAsync(FlipSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setFlipSetting", ApiVersion.V1_0, setting));
        }

        public Task<Candidate<string>> GetSupportedFlipSettingAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedFlipSetting");
        }

        public async Task<Capability<string>> GetAvailableFlipSettingAsync()
        {
            return await ObjectByMethod<FlipModeCapability>("getAvailableFlipSetting").ConfigureAwait(false);
        }

        public Task<StorageInfo> GetStorageInformationAsync()
        {
            return ObjectByMethod<StorageInfo>("getStorageInformation");
        }

        public Task<IntervalTimeSetting> GetIntervalTimeAsync()
        {
            return ObjectByMethod<IntervalTimeSetting>("getIntervalTime");
        }

        public async Task SetIntervalTimeAsync(IntervalTimeSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setIntervalTime", ApiVersion.V1_0, setting));
        }

        public Task<Candidate<string>> GetSupportedIntervalTimeAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedIntervalTime");
        }

        public async Task<Capability<string>> GetAvailableIntervalTimeAsync()
        {
            return await ObjectByMethod<IntervalTimeCapability>("getAvailableIntervalTime").ConfigureAwait(false);
        }

        public Task<LoopRecTimeSetting> GetLoopRecTimeAsync()
        {
            return ObjectByMethod<LoopRecTimeSetting>("getLoopRecTime");
        }

        public async Task SetLoopRecTimeAsync(LoopRecTimeSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setLoopRecTime", ApiVersion.V1_0, setting));
        }

        public Task<Candidate<string>> GetSupportedLoopRecTimeAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedLoopRecTime");
        }

        public async Task<Capability<string>> GetAvailableLoopRecTimeAsync()
        {
            return await ObjectByMethod<LoopRecTimeCapability>("getAvailableLoopRecTime").ConfigureAwait(false);
        }

        public Task<WindNoiseReductionSetting> GetWindNoiseReductionAsync()
        {
            return ObjectByMethod<WindNoiseReductionSetting>("getWindNoiseReduction");
        }

        public async Task SetWindNoiseReductionAsync(WindNoiseReductionSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setWindNoiseReduction", ApiVersion.V1_0, setting));
        }

        public Task<Candidate<string>> GetSupportedWindNoiseReductionAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedWindNoiseReduction");
        }

        public async Task<Capability<string>> GetAvailableWindNoiseReductionAsync()
        {
            return await ObjectByMethod<WindNoiseReductionCapability>("getAvailableWindNoiseReduction").ConfigureAwait(false);
        }

        public Task<AudioRecordingSetting> GetAudioRecordingAsync()
        {
            return ObjectByMethod<AudioRecordingSetting>("getAudioRecording");
        }

        public async Task SetAudioRecordingAsync(AudioRecordingSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setAudioRecording", ApiVersion.V1_0, setting));
        }

        public Task<Candidate<string>> GetSupportedAudioRecordingAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedAudioRecording");
        }

        public async Task<Capability<string>> GetAvailableAudioRecordingAsync()
        {
            return await ObjectByMethod<AudioRecordingCapability>("getAvailableAudioRecording").ConfigureAwait(false);
        }

        public Task<SceneSelectionSetting> GetSceneSelectionAsync()
        {
            return ObjectByMethod<SceneSelectionSetting>("getSceneSelection");
        }

        public async Task SetSceneSelectionAsync(SceneSelectionSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setSceneSelection", ApiVersion.V1_0, setting));
        }

        public Task<Candidate<string>> GetSupportedSceneSelectionAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedSceneSelection");
        }

        public async Task<Capability<string>> GetAvailableSceneSelectionAsync()
        {
            return await ObjectByMethod<SceneSelectionCapability>("getAvailableSceneSelection").ConfigureAwait(false);
        }

        public Task<ImageQualitySetting> GetStillQualityAsync()
        {
            return ObjectByMethod<ImageQualitySetting>("getStillQuality");
        }

        public async Task SetStillQualityAsync(ImageQualitySetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setStillQuality", ApiVersion.V1_0, setting));
        }

        public Task<Candidate<string>> GetSupportedStillQualityAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedStillQuality");
        }

        public async Task<Capability<string>> GetAvailableStillQualityAsync()
        {
            return await ObjectByMethod<ImageQualityCapability>("getAvailableStillQuality").ConfigureAwait(false);
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

        public Task<TrackingFocusSetting> GetTrackingFocusAsync()
        {
            return ObjectByMethod<TrackingFocusSetting>("getTrackingFocus");
        }

        public Task<Candidate<string>> GetSupportedTrackingFocusAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedTrackingFocus");
        }

        public async Task<Capability<string>> GetAvailableTrackingFocusAsync()
        {
            return await ObjectByMethod<TrackingFocusModeCapability>("getAvailableTrackingFocus").ConfigureAwait(false);
        }

        public Task<ZoomSetting> GetZoomSettingAsync()
        {
            return ObjectByMethod<ZoomSetting>("getZoomSetting");
        }

        public async Task SetZoomSettingAsync(ZoomSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setZoomSetting", ApiVersion.V1_0, setting));
        }

        public Task<Candidate<string>> GetSupportedZoomSettingAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedZoomSetting");
        }

        public async Task<Capability<string>> GetAvailableZoomSettingAsync()
        {
            return await ObjectByMethod<ZoomModeCapability>("getAvailableZoomSetting").ConfigureAwait(false);
        }

        public async Task StartContShootingAsync()
        {
            await NoValueByMethod("startContShooting");
        }

        public async Task StopContShootingAsync()
        {
            await NoValueByMethod("stopContShooting");
        }

        public Task<MovieFormat> GetMovieFileFormat()
        {
            return ObjectByMethod<MovieFormat>("getMovieFileFormat");
        }

        public async Task SetMovieFileFormatAsync(MovieFormat setting)
        {
            await NoValue(RequestGenerator.Serialize("setMovieFileFormat", ApiVersion.V1_0, setting));
        }

        public Task<Candidate<string>> GetSupportedMovieFileFormatAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedMovieFileFormat");
        }

        public async Task<Capability<string>> GetAvailableMovieFileFormatAsync()
        {
            return await ObjectByMethod<MovieFormatCapability>("getAvailableMovieFileFormat").ConfigureAwait(false);
        }

        public Task<TvColorSystem> GetTvColorSystemAsync()
        {
            return ObjectByMethod<TvColorSystem>("getTvColorSystem");
        }

        public async Task SetTvColorSystemAsync(TvColorSystem setting)
        {
            await NoValue(RequestGenerator.Serialize("setTvColorSystem", ApiVersion.V1_0, setting));
        }

        public Task<Candidate<string>> GetSupportedTvColorSystemAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedTvColorSystem");
        }

        public async Task<Capability<string>> GetAvailableTvColorSystemAsync()
        {
            return await ObjectByMethod<TvColorSystemCapability>("getAvailableTvColorSystem").ConfigureAwait(false);
        }

        public Task<InfraredRemoteControl> GetInfraredRemoteControlAsync()
        {
            return ObjectByMethod<InfraredRemoteControl>("getInfraredRemoteControl");
        }

        public async Task SetInfraredRemoteControlAsync(InfraredRemoteControl setting)
        {
            await NoValue(RequestGenerator.Serialize("setInfraredRemoteControl", ApiVersion.V1_0, setting));
        }

        public Task<Candidate<string>> GetSupportedInfraredRemoteControlAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedInfraredRemoteControl");
        }

        public async Task<Capability<string>> GetAvailableInfraredRemoteControlAsync()
        {
            return await ObjectByMethod<InfraredRemoteControlCapability>("getAvailableInfraredRemoteControl").ConfigureAwait(false);
        }
    }
}
