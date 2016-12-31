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
        [ApiMeta("getEvent")]
        public Task<Event> GetEventAsync(bool longpolling, ApiVersion version = ApiVersion.V1_0
            , CancellationTokenSource cancel = null)
        {
            return Single(
                RequestGenerator.Jsonize("getEvent", version, longpolling),
                CustomParser.AsCameraEvent, cancel);
        }

        [ApiMeta("getApplicationInfo")]
        public Task<ServerAppInfo> GetApplicationInfoAsync()
        {
            return Single(
                RequestGenerator.Jsonize("getApplicationInfo"),
                CustomParser.AsServerAppInfo);
        }

        [ApiMeta("getAvailableApiList")]
        public Task<List<string>> GetAvailableApiListAsync()
        {
            return PrimitiveListByMethod<string>("getAvailableApiList");
        }

        [ApiMeta("startRecMode")]
        public async Task StartRecModeAsync()
        {
            await NoValueByMethod("startRecMode");
        }

        [ApiMeta("stopRecMode")]
        public async Task StopRecModeAsync()
        {
            await NoValueByMethod("stopRecMode");
        }

        [ApiMeta("actZoom")]
        public async Task ActZoomAsync(string direction, string movement)
        {
            await NoValue(RequestGenerator.Jsonize("actZoom", direction, movement));
        }

        [ApiMeta("startLiveview")]
        public Task<string> StartLiveviewAsync()
        {
            return PrimitiveByMethod<string>("startLiveview");
        }

        [ApiMeta("startLiveviewWithSize")]
        public Task<string> StartLiveviewWithSizeAsync(string size)
        {
            return Single(
                RequestGenerator.Jsonize("startLiveviewWithSize", size),
                BasicParser.AsPrimitive<string>);
        }

        [ApiMeta("getSupportedLiveviewSize")]
        public Task<List<string>> GetSupportedLiveviewSizeAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedLiveviewSize");
        }

        [ApiMeta("stopLiveview")]
        public async Task StopLiveviewAsync()
        {
            await NoValueByMethod("stopLiveview");
        }

        [ApiMeta("setLiveviewFrameInfo")]
        public async Task SetLiveviewFrameInfoAsync(FrameInfoSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setLiveviewFrameInfo", ApiVersion.V1_0, setting));
        }

        [ApiMeta("getLiveviewFrameInfo")]
        public Task<FrameInfoSetting> GetLiveviewFrameInfoAsync()
        {
            return ObjectByMethod<FrameInfoSetting>("getLiveviewFrameInfo");
        }

        [ApiMeta("startAudioRec")]
        public async Task StartAudioRecAsync()
        {
            await NoValueByMethod("startAudioRec");
        }

        [ApiMeta("stopAudioRec")]
        public async Task StopAudioRecAsync()
        {
            await NoValueByMethod("stopAudioRec");
        }

        [ApiMeta("startMovieRec")]
        public async Task StartMovieRecAsync()
        {
            await NoValueByMethod("startMovieRec");
        }

        [ApiMeta("stopMovieRec")]
        public Task<string> StopMovieRecAsync()
        {
            return PrimitiveByMethod<string>("stopMovieRec");
        }

        [ApiMeta("actTakePicture")]
        public Task<List<string>> ActTakePictureAsync(CancellationTokenSource cancel = null)
        {
            return PrimitiveListByMethod<string>("actTakePicture", ApiVersion.V1_0, cancel);
        }

        [ApiMeta("awaitTakePicture")]
        public Task<List<string>> AwaitTakePictureAsync(CancellationTokenSource cancel = null)
        {
            return PrimitiveListByMethod<string>("awaitTakePicture", ApiVersion.V1_0, cancel);
        }

        [ApiMeta("setSelfTimer")]
        public async Task SetSelfTimerAsync(int timer)
        {
            await NoValue(RequestGenerator.Jsonize("setSelfTimer", timer));
        }

        [ApiMeta("getSelfTimer")]
        public Task<int> GetSelfTimerAsync()
        {
            return PrimitiveByMethod<int>("getSelfTimer");
        }

        [ApiMeta("getSupportedSelfTimer")]
        public Task<List<int>> GetSupportedSelfTimerAsync()
        {
            return PrimitiveListByMethod<int>("getSupportedSelfTimer");
        }

        [ApiMeta("getAvailableSelfTimer")]
        public Task<Capability<int>> GetAvailableSelfTimerAsync()
        {
            return CapabilityByMethod<int>("getAvailableSelfTimer");
        }

        [ApiMeta("setPostviewImageSize")]
        public async Task SetPostviewImageSizeAsync(string size)
        {
            await NoValue(RequestGenerator.Jsonize("setPostviewImageSize", size));
        }

        [ApiMeta("getPostviewImageSize")]
        public Task<string> GetPostviewImageSizeAsync()
        {
            return PrimitiveByMethod<string>("getPostviewImageSize");
        }

        [ApiMeta("getSupportedPostviewImageSize")]
        public Task<List<string>> GetSupportedPostviewImageSizeAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedPostviewImageSize");
        }

        [ApiMeta("getAvailablePostviewImageSize")]
        public Task<Capability<string>> GetAvailablePostviewImageSizeAsync()
        {
            return CapabilityByMethod<string>("getAvailablePostviewImageSize");
        }

        [ApiMeta("setShootMode")]
        public async Task SetShootModeAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setShootMode", mode));
        }

        [ApiMeta("getShootMode")]
        public Task<string> GetShootModeAsync()
        {
            return PrimitiveByMethod<string>("getShootMode");
        }

        [ApiMeta("getSupportedShootMode")]
        public Task<List<string>> GetSupportedShootModeAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedShootMode");
        }

        [ApiMeta("getAvailableShootMode")]
        public Task<Capability<string>> GetAvailableShootModeAsync()
        {
            return CapabilityByMethod<string>("getAvailableShootMode");
        }

        [ApiMeta("actHalfPressShutter")]
        public async Task ActHalfPressShutterAsync()
        {
            await NoValueByMethod("actHalfPressShutter");
        }

        [ApiMeta("cancelHalfPressShutter")]
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
        [ApiMeta("setTouchAFPosition")]
        public Task<SetFocusResult> SetAFPositionAsync(double x, double y)
        {
            return Single(
                RequestGenerator.Jsonize("setTouchAFPosition", x, y),
                CustomParser.AsSetFocusResult);
        }

        [ApiMeta("getTouchAFPosition")]
        public Task<TouchFocusStatus> GetTouchAFStatusAsync()
        {
            return ObjectByMethod<TouchFocusStatus>("getTouchAFPosition");
        }

        [ApiMeta("cancelTouchAFPosition")]
        public async Task CancelTouchAFAsync()
        {
            await NoValueByMethod("cancelTouchAFPosition");
        }

        [ApiMeta("setExposureMode")]
        public async Task SetExposureModeAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setExposureMode", mode));
        }

        [ApiMeta("getExposureMode")]
        public Task<string> GetExposureModeAsync()
        {
            return PrimitiveByMethod<string>("getExposureMode");
        }

        [ApiMeta("getSupportedExposureMode")]
        public Task<List<string>> GetSupportedExposureModeAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedExposureMode");
        }

        [ApiMeta("getAvailableExposureMode")]
        public Task<Capability<string>> GetAvailableExposureModeAsync()
        {
            return CapabilityByMethod<string>("getAvailableExposureMode");
        }

        [ApiMeta("setFocusMode")]
        public async Task SetFocusModeAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setFocusMode", mode));
        }

        [ApiMeta("getFocusMode")]
        public Task<string> GetFocusModeAsync()
        {
            return PrimitiveByMethod<string>("getFocusMode");
        }

        [ApiMeta("getSupportedFocusMode")]
        public Task<List<string>> GetSupportedFocusModeAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedFocusMode");
        }

        [ApiMeta("getAvailableFocusMode")]
        public Task<Capability<string>> GetAvailableFocusModeAsync()
        {
            return CapabilityByMethod<string>("getAvailableFocusMode");
        }

        [ApiMeta("setExposureCompensation")]
        public async Task SetEvIndexAsync(int index)
        {
            await NoValue(RequestGenerator.Jsonize("setExposureCompensation", index));
        }

        [ApiMeta("getExposureCompensation")]
        public Task<int> GetEvIndexAsync()
        {
            return PrimitiveByMethod<int>("getExposureCompensation");
        }

        [ApiMeta("getSupportedExposureCompensation")]
        public Task<List<EvCandidate>> GetSupportedEvAsync()
        {
            return Single(
                 RequestGenerator.Jsonize("getSupportedExposureCompensation"),
                 CustomParser.AsEvCandidates);
        }

        [ApiMeta("getAvailableExposureCompensation")]
        public Task<EvCapability> GetAvailableEvAsync()
        {
            return Single(
                RequestGenerator.Jsonize("getAvailableExposureCompensation"),
                CustomParser.AsEvCapability);
        }

        [ApiMeta("setFNumber")]
        public async Task SetFNumberAsync(string f)
        {
            await NoValue(RequestGenerator.Jsonize("setFNumber", f));
        }

        [ApiMeta("getFNumber")]
        public Task<string> GetFNumberAsync()
        {
            return PrimitiveByMethod<string>("getFNumber");
        }

        [ApiMeta("getSupportedFNumber")]
        public Task<List<string>> GetSupportedFNumberAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedFNumber");
        }

        [ApiMeta("getAvailableFNumber")]
        public Task<Capability<string>> GetAvailableFNumberAsync()
        {
            return CapabilityByMethod<string>("getAvailableFNumber");
        }

        [ApiMeta("setShutterSpeed")]
        public async Task SetShutterSpeedAsync(string ss)
        {
            await NoValue(RequestGenerator.Jsonize("setShutterSpeed", ss));
        }

        [ApiMeta("getShutterSpeed")]
        public Task<string> GetShutterSpeedAsync()
        {
            return PrimitiveByMethod<string>("getShutterSpeed");
        }

        [ApiMeta("getSupportedShutterSpeed")]
        public Task<List<string>> GetSupportedShutterSpeedAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedShutterSpeed");
        }

        [ApiMeta("getAvailableShutterSpeed")]
        public Task<Capability<string>> GetAvailableShutterSpeedAsync()
        {
            return CapabilityByMethod<string>("getAvailableShutterSpeed");
        }

        [ApiMeta("setIsoSpeedRate")]
        public async Task SetISOSpeedAsync(string iso)
        {
            await NoValue(RequestGenerator.Jsonize("setIsoSpeedRate", iso));
        }

        [ApiMeta("getIsoSpeedRate")]
        public Task<string> GetIsoSpeedAsync()
        {
            return PrimitiveByMethod<string>("getIsoSpeedRate");
        }

        [ApiMeta("getSupportedIsoSpeedRate")]
        public Task<List<string>> GetSupportedIsoSpeedAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedIsoSpeedRate");
        }

        [ApiMeta("getAvailableIsoSpeedRate")]
        public Task<Capability<string>> GetAvailableIsoSpeedAsync()
        {
            return CapabilityByMethod<string>("getAvailableIsoSpeedRate");
        }

        [ApiMeta("setStillSize")]
        public async Task SetStillImageSizeAsync(StillImageSize size)
        {
            await NoValue(RequestGenerator.Jsonize("setStillSize", size.AspectRatio, size.SizeDefinition));
        }

        [ApiMeta("getStillSize")]
        public Task<StillImageSize> GetStillSizeAsync()
        {
            return ObjectByMethod<StillImageSize>(RequestGenerator.Jsonize("getStillSize"));
        }

        [ApiMeta("getSupportedStillSize")]
        public Task<StillImageSize[]> GetSupportedStillSizeAsync()
        {
            return ObjectByMethod<StillImageSize[]>("getSupportedStillSize");
        }

        [ApiMeta("getAvailableStillSize")]
        public Task<Capability<StillImageSize>> GetAvailableStillSizeAsync()
        {
            return Capability(
                RequestGenerator.Jsonize("getAvailableStillSize"),
                BasicParser.AsCapabilityObject<StillImageSize>);
        }

        [ApiMeta("setWhiteBalance")]
        public async Task SetWhiteBalanceAsync(WhiteBalance wb)
        {
            await NoValue(RequestGenerator.Jsonize("setWhiteBalance", wb.Mode, wb.ColorTemperature != WhiteBalance.InvalidColorTemperture, wb.ColorTemperature));
        }

        [ApiMeta("getWhiteBalance")]
        public Task<WhiteBalance> GetWhiteBalanceAsync()
        {
            return ObjectByMethod<WhiteBalance>("getWhiteBalance");
        }

        [ApiMeta("getSupportedWhiteBalance")]
        public Task<WhiteBalanceCandidate[]> GetSupportedWhiteBalanceAsync()
        {
            return ObjectByMethod<WhiteBalanceCandidate[]>("getSupportedWhiteBalance");
        }

        [ApiMeta("getAvailableWhiteBalance")]
        public Task<WhiteBalanceCapability> GetAvailableWhiteBalanceAsync()
        {
            return Single(
                RequestGenerator.Jsonize("getAvailableWhiteBalance"),
                CustomParser.AsWhiteBalanceCapability);
        }

        [ApiMeta("actWhiteBalanceOnePushCustom")]
        public Task<CaptureBasedWhiteBalance> ActWhiteBalanceOnePushCustomAsync()
        {
            return ObjectByMethod<CaptureBasedWhiteBalance>("actWhiteBalanceOnePushCustom");
        }

        [ApiMeta("setBeepMode")]
        public async Task SetBeepModeAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setBeepMode", mode));
        }

        [ApiMeta("getBeepMode")]
        public Task<string> GetBeepModeAsync()
        {
            return PrimitiveByMethod<string>("getBeepMode");
        }

        [ApiMeta("getSupportedBeepMode")]
        public Task<List<string>> GetSupportedBeepModeAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedBeepMode");
        }

        [ApiMeta("getAvailableBeepMode")]
        public Task<Capability<string>> GetAvailableBeepModeAsync()
        {
            return CapabilityByMethod<string>("getAvailableBeepMode");
        }

        [ApiMeta("startIntervalStillRec")]
        public async Task StartIntervalStillRecAsync()
        {
            await NoValueByMethod("startIntervalStillRec");
        }

        [ApiMeta("stopIntervalStillRec")]
        public async Task StopIntervalStillRecAsync()
        {
            await NoValueByMethod("stopIntervalStillRec");
        }

        [ApiMeta("startLoopRec")]
        public async Task StartLoopRecAsync()
        {
            await NoValueByMethod("startLoopRec");
        }

        [ApiMeta("stopLoopRec")]
        public async Task StopLoopRecAsync()
        {
            await NoValueByMethod("stopLoopRec");
        }

        [ApiMeta("setViewAngle")]
        public async Task SetViewAngleAsync(int angle)
        {
            await NoValue(RequestGenerator.Jsonize("setViewAngle", angle));
        }

        [ApiMeta("getViewAngle")]
        public Task<int> GetViewAngleAsync()
        {
            return PrimitiveByMethod<int>("getViewAngle");
        }

        [ApiMeta("getSupportedViewAngle")]
        public Task<List<int>> GetSupportedViewAngleAsync()
        {
            return PrimitiveListByMethod<int>("getSupportedViewAngle");
        }

        [ApiMeta("getAvailableViewAngle")]
        public Task<Capability<int>> GetAvailableViewAngleAsync()
        {
            return CapabilityByMethod<int>("getAvailableViewAngle");
        }

        [ApiMeta("setSteadyMode")]
        public async Task SetSteadyModeAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setSteadyMode", mode));
        }

        [ApiMeta("getSteadyMode")]
        public Task<string> GetSteadyModeAsync()
        {
            return PrimitiveByMethod<string>("getSteadyMode");
        }

        [ApiMeta("getSupportedSteadyMode")]
        public Task<List<string>> GetSupportedSteadyModeAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedSteadyMode");
        }

        [ApiMeta("getAvailableSteadyMode")]
        public Task<Capability<string>> GetAvailableSteadyModeAsync()
        {
            return CapabilityByMethod<string>("getAvailableSteadyMode");
        }

        [ApiMeta("setMovieQuality")]
        public async Task SetMovieQualityAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setMovieQuality", mode));
        }

        [ApiMeta("getMovieQuality")]
        public Task<string> GetMovieQualityAsync()
        {
            return PrimitiveByMethod<string>("getMovieQuality");
        }

        [ApiMeta("getSupportedMovieQuality")]
        public Task<List<string>> GetSupportedMovieQualityAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedMovieQuality");
        }

        [ApiMeta("getAvailableMovieQuality")]
        public Task<Capability<string>> GetAvailableMovieQualityAsync()
        {
            return CapabilityByMethod<string>("getAvailableMovieQuality");
        }

        [ApiMeta("setFlashMode")]
        public async Task SetFlashModeAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setFlashMode", mode));
        }

        [ApiMeta("getFlashMode")]
        public Task<string> GetFlashModeAsync()
        {
            return PrimitiveByMethod<string>("getFlashMode");
        }

        [ApiMeta("getSupportedFlashMode")]
        public Task<List<string>> GetSupportedFlashModeAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedFlashMode");
        }

        [ApiMeta("getAvailableFlashMode")]
        public Task<Capability<string>> GetAvailableFlashModeAsync()
        {
            return CapabilityByMethod<string>("getAvailableFlashMode");
        }

        [ApiMeta("setProgramShift")]
        public async Task SetProgramShiftAsync(int amount)
        {
            await NoValue(RequestGenerator.Jsonize("setProgramShift", amount));
        }

        [ApiMeta("getSupportedProgramShift")]
        public Task<ProgramShiftRange> GetSupportedProgramShiftAsync()
        {
            return Single(
                RequestGenerator.Jsonize("getSupportedProgramShift"),
                CustomParser.AsProgramShiftRange);
        }

        [ApiMeta("getAutoPowerOff")]
        public Task<AutoPowerOff> GetAutoPowerOffAsync()
        {
            return ObjectByMethod<AutoPowerOff>("getAutoPowerOff");
        }

        [ApiMeta("setAutoPowerOff")]
        public async Task SetAutoPowerOffAsync(AutoPowerOff param)
        {
            await NoValue(RequestGenerator.Serialize("setAutoPowerOff", ApiVersion.V1_0, param));
        }

        [ApiMeta("getSupportedAutoPowerOff")]
        public Task<Candidate<int>> GetSupportedAutoPowerOffAsync()
        {
            return ObjectByMethod<Candidate<int>>("getSupportedAutoPowerOff");
        }

        [ApiMeta("getAvailableAutoPowerOff")]
        public async Task<Capability<int>> GetAvailableAutoPowerOffAsync()
        {
            return await ObjectByMethod<ApoCapability>("getAvailableAutoPowerOff").ConfigureAwait(false);
        }

        [ApiMeta("getCameraFunction")]
        public Task<string> GetCameraFunctionAsync()
        {
            return PrimitiveByMethod<string>("getCameraFunction");
        }

        [ApiMeta("setCameraFunction")]
        public async Task SetCameraFunctionAsync(string mode)
        {
            await NoValue(RequestGenerator.Jsonize("setCameraFunction", mode));
        }

        [ApiMeta("getSupportedCameraFunction")]
        public Task<List<string>> GetSupportedCameraFunctionAsync()
        {
            return PrimitiveListByMethod<string>("getSupportedCameraFunction");
        }

        [ApiMeta("getAvailableCameraFunction")]
        public Task<Capability<string>> GetAvailableCameraFunctionAsync()
        {
            return CapabilityByMethod<string>("getAvailableCameraFunction");
        }

        [ApiMeta("getColorSetting")]
        public Task<ColorSetting> GetColorSettingAsync()
        {
            return ObjectByMethod<ColorSetting>("getColorSetting");
        }

        [ApiMeta("setColorSetting")]
        public async Task SetColorSettingAsync(ColorSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setColorSetting", ApiVersion.V1_0, setting));
        }

        [ApiMeta("getSupportedColorSetting")]
        public Task<Candidate<string>> GetSupportedColorSettingAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedColorSetting");
        }

        [ApiMeta("getAvailableColorSetting")]
        public async Task<Capability<string>> GetAvailableColorSettingAsync()
        {
            return await ObjectByMethod<ColorSettingCapability>("getAvailableColorSetting").ConfigureAwait(false);
        }

        [ApiMeta("getContShootingMode")]
        public Task<ContinuousShootSetting> GetContShootingModeAsync()
        {
            return ObjectByMethod<ContinuousShootSetting>("getContShootingMode");
        }

        [ApiMeta("setContShootingMode")]
        public async Task SetContShootingModeAsync(ContinuousShootSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setContShootingMode", ApiVersion.V1_0, setting));
        }

        [ApiMeta("getSupportedContShootingMode")]
        public Task<Candidate<string>> GetSupportedContShootingModeAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedContShootingMode");
        }

        [ApiMeta("getAvailableContShootingMode")]
        public async Task<Capability<string>> GetAvailableContShootingModeAsync()
        {
            return await ObjectByMethod<ContinuousShootingModeCapability>("getAvailableContShootingMode").ConfigureAwait(false);
        }

        [ApiMeta("getContShootingSpeed")]
        public Task<ContinuousShootSpeedSetting> GetContShootingSpeedAsync()
        {
            return ObjectByMethod<ContinuousShootSpeedSetting>("getContShootingSpeed");
        }

        [ApiMeta("setContShootingSpeed")]
        public async Task SetContShootingSpeedAsync(ContinuousShootSpeedSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setContShootingSpeed", ApiVersion.V1_0, setting));
        }

        [ApiMeta("getSupportedContShootingSpeed")]
        public Task<Candidate<string>> GetSupportedContShootingSpeedAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedContShootingSpeed");
        }

        [ApiMeta("getAvailableContShootingSpeed")]
        public async Task<Capability<string>> GetAvailableContShootingSpeedAsync()
        {
            return await ObjectByMethod<ContinuousShootingSpeedCapability>("getAvailableContShootingSpeed").ConfigureAwait(false);
        }

        [ApiMeta("getFlipSetting")]
        public Task<FlipSetting> GetFlipSettingAsync()
        {
            return ObjectByMethod<FlipSetting>("getFlipSetting");
        }

        [ApiMeta("setFlipSetting")]
        public async Task SetFlipSettingAsync(FlipSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setFlipSetting", ApiVersion.V1_0, setting));
        }

        [ApiMeta("getSupportedFlipSetting")]
        public Task<Candidate<string>> GetSupportedFlipSettingAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedFlipSetting");
        }

        [ApiMeta("getAvailableFlipSetting")]
        public async Task<Capability<string>> GetAvailableFlipSettingAsync()
        {
            return await ObjectByMethod<FlipModeCapability>("getAvailableFlipSetting").ConfigureAwait(false);
        }

        [ApiMeta("getStorageInformation")]
        public Task<StorageInfo> GetStorageInformationAsync()
        {
            return ObjectByMethod<StorageInfo>("getStorageInformation");
        }

        [ApiMeta("getIntervalTime")]
        public Task<IntervalTimeSetting> GetIntervalTimeAsync()
        {
            return ObjectByMethod<IntervalTimeSetting>("getIntervalTime");
        }

        [ApiMeta("setIntervalTime")]
        public async Task SetIntervalTimeAsync(IntervalTimeSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setIntervalTime", ApiVersion.V1_0, setting));
        }

        [ApiMeta("getSupportedIntervalTime")]
        public Task<Candidate<string>> GetSupportedIntervalTimeAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedIntervalTime");
        }

        [ApiMeta("getAvailableIntervalTime")]
        public async Task<Capability<string>> GetAvailableIntervalTimeAsync()
        {
            return await ObjectByMethod<IntervalTimeCapability>("getAvailableIntervalTime").ConfigureAwait(false);
        }

        [ApiMeta("getLoopRecTime")]
        public Task<LoopRecTimeSetting> GetLoopRecTimeAsync()
        {
            return ObjectByMethod<LoopRecTimeSetting>("getLoopRecTime");
        }

        [ApiMeta("setLoopRecTime")]
        public async Task SetLoopRecTimeAsync(LoopRecTimeSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setLoopRecTime", ApiVersion.V1_0, setting));
        }

        [ApiMeta("getSupportedLoopRecTime")]
        public Task<Candidate<string>> GetSupportedLoopRecTimeAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedLoopRecTime");
        }

        [ApiMeta("getAvailableLoopRecTime")]
        public async Task<Capability<string>> GetAvailableLoopRecTimeAsync()
        {
            return await ObjectByMethod<LoopRecTimeCapability>("getAvailableLoopRecTime").ConfigureAwait(false);
        }

        [ApiMeta("getWindNoiseReduction")]
        public Task<WindNoiseReductionSetting> GetWindNoiseReductionAsync()
        {
            return ObjectByMethod<WindNoiseReductionSetting>("getWindNoiseReduction");
        }

        [ApiMeta("setWindNoiseReduction")]
        public async Task SetWindNoiseReductionAsync(WindNoiseReductionSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setWindNoiseReduction", ApiVersion.V1_0, setting));
        }

        [ApiMeta("getSupportedWindNoiseReduction")]
        public Task<Candidate<string>> GetSupportedWindNoiseReductionAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedWindNoiseReduction");
        }

        [ApiMeta("getAvailableWindNoiseReduction")]
        public async Task<Capability<string>> GetAvailableWindNoiseReductionAsync()
        {
            return await ObjectByMethod<WindNoiseReductionCapability>("getAvailableWindNoiseReduction").ConfigureAwait(false);
        }

        [ApiMeta("getAudioRecording")]
        public Task<AudioRecordingSetting> GetAudioRecordingAsync()
        {
            return ObjectByMethod<AudioRecordingSetting>("getAudioRecording");
        }

        [ApiMeta("setAudioRecording")]
        public async Task SetAudioRecordingAsync(AudioRecordingSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setAudioRecording", ApiVersion.V1_0, setting));
        }

        [ApiMeta("getSupportedAudioRecording")]
        public Task<Candidate<string>> GetSupportedAudioRecordingAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedAudioRecording");
        }

        [ApiMeta("getAvailableAudioRecording")]
        public async Task<Capability<string>> GetAvailableAudioRecordingAsync()
        {
            return await ObjectByMethod<AudioRecordingCapability>("getAvailableAudioRecording").ConfigureAwait(false);
        }

        [ApiMeta("getSceneSelection")]
        public Task<SceneSelectionSetting> GetSceneSelectionAsync()
        {
            return ObjectByMethod<SceneSelectionSetting>("getSceneSelection");
        }

        [ApiMeta("setSceneSelection")]
        public async Task SetSceneSelectionAsync(SceneSelectionSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setSceneSelection", ApiVersion.V1_0, setting));
        }

        [ApiMeta("getSupportedSceneSelection")]
        public Task<Candidate<string>> GetSupportedSceneSelectionAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedSceneSelection");
        }

        [ApiMeta("getAvailableSceneSelection")]
        public async Task<Capability<string>> GetAvailableSceneSelectionAsync()
        {
            return await ObjectByMethod<SceneSelectionCapability>("getAvailableSceneSelection").ConfigureAwait(false);
        }

        [ApiMeta("getStillQuality")]
        public Task<ImageQualitySetting> GetStillQualityAsync()
        {
            return ObjectByMethod<ImageQualitySetting>("getStillQuality");
        }

        [ApiMeta("setStillQuality")]
        public async Task SetStillQualityAsync(ImageQualitySetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setStillQuality", ApiVersion.V1_0, setting));
        }

        [ApiMeta("getSupportedStillQuality")]
        public Task<Candidate<string>> GetSupportedStillQualityAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedStillQuality");
        }

        [ApiMeta("getAvailableStillQuality")]
        public async Task<Capability<string>> GetAvailableStillQualityAsync()
        {
            return await ObjectByMethod<ImageQualityCapability>("getAvailableStillQuality").ConfigureAwait(false);
        }

        [ApiMeta("actTrackingFocus")]
        public async Task ActTrackingFocusAsync(FocusPosition position)
        {
            await NoValue(RequestGenerator.Serialize("actTrackingFocus", ApiVersion.V1_0, position));
        }

        [ApiMeta("cancelTrackingFocus")]
        public async Task CancelTrackingFocusAsync()
        {
            await NoValueByMethod("cancelTrackingFocus");
        }

        [ApiMeta("setTrackingFocus")]
        public async Task SetTrackingFocusAsync(TrackingFocusSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setTrackingFocus", ApiVersion.V1_0, setting));
        }

        [ApiMeta("getTrackingFocus")]
        public Task<TrackingFocusSetting> GetTrackingFocusAsync()
        {
            return ObjectByMethod<TrackingFocusSetting>("getTrackingFocus");
        }

        [ApiMeta("getSupportedTrackingFocus")]
        public Task<Candidate<string>> GetSupportedTrackingFocusAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedTrackingFocus");
        }

        [ApiMeta("getAvailableTrackingFocus")]
        public async Task<Capability<string>> GetAvailableTrackingFocusAsync()
        {
            return await ObjectByMethod<TrackingFocusModeCapability>("getAvailableTrackingFocus").ConfigureAwait(false);
        }

        [ApiMeta("getZoomSetting")]
        public Task<ZoomSetting> GetZoomSettingAsync()
        {
            return ObjectByMethod<ZoomSetting>("getZoomSetting");
        }

        [ApiMeta("setZoomSetting")]
        public async Task SetZoomSettingAsync(ZoomSetting setting)
        {
            await NoValue(RequestGenerator.Serialize("setZoomSetting", ApiVersion.V1_0, setting));
        }

        [ApiMeta("getSupportedZoomSetting")]
        public Task<Candidate<string>> GetSupportedZoomSettingAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedZoomSetting");
        }

        [ApiMeta("getAvailableZoomSetting")]
        public async Task<Capability<string>> GetAvailableZoomSettingAsync()
        {
            return await ObjectByMethod<ZoomModeCapability>("getAvailableZoomSetting").ConfigureAwait(false);
        }

        [ApiMeta("startContShooting")]
        public async Task StartContShootingAsync()
        {
            await NoValueByMethod("startContShooting");
        }

        [ApiMeta("stopContShooting")]
        public async Task StopContShootingAsync()
        {
            await NoValueByMethod("stopContShooting");
        }

        [ApiMeta("getMovieFileFormat")]
        public Task<MovieFormat> GetMovieFileFormat()
        {
            return ObjectByMethod<MovieFormat>("getMovieFileFormat");
        }

        [ApiMeta("setMovieFileFormat")]
        public async Task SetMovieFileFormatAsync(MovieFormat setting)
        {
            await NoValue(RequestGenerator.Serialize("setMovieFileFormat", ApiVersion.V1_0, setting));
        }

        [ApiMeta("getSupportedMovieFileFormat")]
        public Task<Candidate<string>> GetSupportedMovieFileFormatAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedMovieFileFormat");
        }

        [ApiMeta("getAvailableMovieFileFormat")]
        public async Task<Capability<string>> GetAvailableMovieFileFormatAsync()
        {
            return await ObjectByMethod<MovieFormatCapability>("getAvailableMovieFileFormat").ConfigureAwait(false);
        }

        [ApiMeta("getTvColorSystem")]
        public Task<TvColorSystem> GetTvColorSystemAsync()
        {
            return ObjectByMethod<TvColorSystem>("getTvColorSystem");
        }

        [ApiMeta("setTvColorSystem")]
        public async Task SetTvColorSystemAsync(TvColorSystem setting)
        {
            await NoValue(RequestGenerator.Serialize("setTvColorSystem", ApiVersion.V1_0, setting));
        }

        [ApiMeta("getSupportedTvColorSystem")]
        public Task<Candidate<string>> GetSupportedTvColorSystemAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedTvColorSystem");
        }

        [ApiMeta("getAvailableTvColorSystem")]
        public async Task<Capability<string>> GetAvailableTvColorSystemAsync()
        {
            return await ObjectByMethod<TvColorSystemCapability>("getAvailableTvColorSystem").ConfigureAwait(false);
        }

        [ApiMeta("getInfraredRemoteControl")]
        public Task<InfraredRemoteControl> GetInfraredRemoteControlAsync()
        {
            return ObjectByMethod<InfraredRemoteControl>("getInfraredRemoteControl");
        }

        [ApiMeta("setInfraredRemoteControl")]
        public async Task SetInfraredRemoteControlAsync(InfraredRemoteControl setting)
        {
            await NoValue(RequestGenerator.Serialize("setInfraredRemoteControl", ApiVersion.V1_0, setting));
        }

        [ApiMeta("getSupportedInfraredRemoteControl")]
        public Task<Candidate<string>> GetSupportedInfraredRemoteControlAsync()
        {
            return ObjectByMethod<Candidate<string>>("getSupportedInfraredRemoteControl");
        }

        [ApiMeta("getAvailableInfraredRemoteControl")]
        public async Task<Capability<string>> GetAvailableInfraredRemoteControlAsync()
        {
            return await ObjectByMethod<InfraredRemoteControlCapability>("getAvailableInfraredRemoteControl").ConfigureAwait(false);
        }
    }
}
