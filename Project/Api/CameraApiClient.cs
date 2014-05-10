using System;
using System.Threading.Tasks;

namespace Kazyx.RemoteApi
{
    public class CameraApiClient
    {
        private readonly string endpoint;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint">Endpoint URL of camera service.</param>
        public CameraApiClient(string endpoint)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException();
            }
            this.endpoint = endpoint;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="longpolling">Set true for event notification, false for immediate response.</param>
        /// <returns></returns>
        public async Task<Event> GetEventAsync(bool longpolling, ApiVersion version = ApiVersion.V1_0)
        {
            Event result = null;
            ResultHandler.HandleGetEvent(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getEvent", version, longpolling)),
                code => { throw new RemoteApiException(code); },
                @event => result = @event);
            return result;
        }

        public async Task<MethodType[]> GetMethodTypesAsync(string version = "")
        {
            MethodType[] result = null;
            ResultHandler.HandleGetMethodTypes(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getMethodTypes", version)),
                code => { throw new RemoteApiException(code); },
                types => result = types);
            return result;
        }

        public async Task<string[]> GetVersionsAsync()
        {
            string[] result = null;
            BasicResultHandler.HandleArray<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getVersions")),
                code => { throw new RemoteApiException(code); },
                versions => result = versions);
            return result;
        }

        public async Task<ServerAppInfo> GetApplicationInfoAsync()
        {
            ServerAppInfo result = null;
            ResultHandler.HandleGetApplicationInfo(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getApplicationInfo")),
                code => { throw new RemoteApiException(code); },
                info => result = info);
            return result;
        }

        public async Task<string[]> GetAvailableApiListAsync()
        {
            string[] result = null;
            BasicResultHandler.HandleArray<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getAvailableApiList")),
                code => { throw new RemoteApiException(code); },
                list => result = list);
            return result;
        }

        public async Task StartRecModeAsync()
        {
            BasicResultHandler.HandleNoValue(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("startRecMode")),
                code => { throw new RemoteApiException(code); },
                () => { });
        }

        public async Task StopRecModeAsync()
        {
            BasicResultHandler.HandleNoValue(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("stopRecMode")),
                code => { throw new RemoteApiException(code); },
                () => { });
        }

        public async Task ActZoomAsync(string direction, string movement)
        {
            BasicResultHandler.HandleNoValue(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("actZoom", direction, movement)),
                code => { throw new RemoteApiException(code); },
                () => { });
        }

        public async Task<string> StartLiveviewAsync()
        {
            string result = null;
            BasicResultHandler.HandleSingleValue<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("startLiveview")),
                code => { throw new RemoteApiException(code); },
                url => result = url);
            return result;
        }

        public async Task StopLiveviewAsync()
        {
            BasicResultHandler.HandleNoValue(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("stopLiveview")),
                code => { throw new RemoteApiException(code); },
                () => { });
        }

        public async Task StartAudioRecAsync()
        {
            BasicResultHandler.HandleNoValue(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("startAudioRec")),
                code => { throw new RemoteApiException(code); },
                () => { });
        }

        public async Task StopAudioRecAsync()
        {
            BasicResultHandler.HandleNoValue(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("stopAudioRec")),
                code => { throw new RemoteApiException(code); },
                () => { });
        }

        public async Task StartMovieRecAsync()
        {
            BasicResultHandler.HandleNoValue(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("startMovieRec")),
                code => { throw new RemoteApiException(code); },
                () => { });
        }

        public async Task<string> StopMovieRecAsync()
        {
            string result = null;
            BasicResultHandler.HandleSingleValue<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("stopMovieRec")),
                code => { throw new RemoteApiException(code); },
                url => result = url);
            return result;
        }

        public async Task<string[]> ActTakePictureAsync()
        {
            string[] result = null;
            BasicResultHandler.HandleArray<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("actTakePicture")),
                code => { throw new RemoteApiException(code); },
                url => result = url);
            return result;
        }

        public async Task<string[]> AwaitTakePictureAsync()
        {
            string[] result = null;
            BasicResultHandler.HandleArray<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("awaitTakePicture")),
                code => { throw new RemoteApiException(code); },
                url => result = url);
            return result;
        }

        public async Task SetSelfTimerAsync(int timer)
        {
            BasicResultHandler.HandleNoValue(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("setSelfTimer", timer)),
                code => { throw new RemoteApiException(code); },
                () => { });
        }

        public async Task<int> GetSelfTimerAsync()
        {
            int result = 0;
            BasicResultHandler.HandleSingleValue<int>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getSelfTimer")),
                code => { throw new RemoteApiException(code); },
                timer => result = timer);
            return result;
        }

        public async Task<int[]> GetSupportedSelfTimerAsync()
        {
            int[] result = null;
            BasicResultHandler.HandleArray<int>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getSupportedSelfTimer")),
                code => { throw new RemoteApiException(code); },
                timer => result = timer);
            return result;
        }

        public async Task<Capability<int>> GetAvailableSelfTimerAsync()
        {
            Capability<int> result = null;
            BasicResultHandler.HandleCapability<int>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getAvailableSelfTimer")),
                code => { throw new RemoteApiException(code); },
                info => result = info);
            return result;
        }

        public async Task SetPostviewImageSizeAsync(string size)
        {
            BasicResultHandler.HandleNoValue(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("setPostviewImageSize", size)),
                code => { throw new RemoteApiException(code); },
                () => { });
        }

        public async Task<string> GetPostviewImageSizeAsync()
        {
            string result = null;
            BasicResultHandler.HandleSingleValue<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getPostviewImageSize")),
                code => { throw new RemoteApiException(code); },
                size => result = size);
            return result;
        }

        public async Task<string[]> GetSupportedPostviewImageSizeAsync()
        {
            string[] result = null;
            BasicResultHandler.HandleArray<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getSupportedPostviewImageSize")),
                code => { throw new RemoteApiException(code); },
                size => result = size);
            return result;
        }

        public async Task<Capability<string>> GetAvailablePostviewImageSizeAsync()
        {
            Capability<string> result = null;
            BasicResultHandler.HandleCapability<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getAvailablePostviewImageSize")),
                code => { throw new RemoteApiException(code); },
                info => result = info);
            return result;
        }

        public async Task SetShootModeAsync(string mode)
        {
            BasicResultHandler.HandleNoValue(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("setShootMode", mode)),
                code => { throw new RemoteApiException(code); },
                () => { });
        }

        public async Task<string> GetShootModeAsync()
        {
            string result = null;
            BasicResultHandler.HandleSingleValue<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getShootMode")),
                code => { throw new RemoteApiException(code); },
                mode => result = mode);
            return result;
        }

        public async Task<string[]> GetSupportedShootModeAsync()
        {
            string[] result = null;
            BasicResultHandler.HandleArray<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getSupportedShootMode")),
                code => { throw new RemoteApiException(code); },
                mode => result = mode);
            return result;
        }

        public async Task<Capability<string>> GetAvailableShootModeAsync()
        {
            Capability<string> result = null;
            BasicResultHandler.HandleCapability<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getAvailableShootMode")),
                code => { throw new RemoteApiException(code); },
                info => result = info);
            return result;
        }

        public async Task ActHalfPressShutterAsync()
        {
            BasicResultHandler.HandleNoValue(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("actHalfPressShutter")),
                code => { throw new RemoteApiException(code); },
                () => { });
        }

        public async Task CancelHalfPressShutterAsync()
        {
            BasicResultHandler.HandleNoValue(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("cancelHalfPressShutter")),
                code => { throw new RemoteApiException(code); },
                () => { });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="x">Percentage of the position to focus in x-axis.</param>
        /// <param name="y">Percentage of the position to focus in y-axis</param>
        /// <returns></returns>
        public async Task<SetFocusResult> SetAFPositionAsync(double x, double y)
        {
            SetFocusResult result = null;
            BasicResultHandler.HandleObject<SetFocusResult>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("setTouchAFPosition", x, y)),
                code => { throw new RemoteApiException(code); },
                res => result = res,
                1); // ignore 0th parameter
            return result;
        }

        public async Task<TouchFocusStatus> GetTouchAFStatusAsync()
        {
            TouchFocusStatus result = null;
            BasicResultHandler.HandleObject<TouchFocusStatus>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getTouchAFPosition")),
                code => { throw new RemoteApiException(code); },
                res => result = res);
            return result;
        }

        public async Task CancelTouchAFAsync()
        {
            BasicResultHandler.HandleNoValue(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("cancelTouchAFPosition")),
                code => { throw new RemoteApiException(code); },
                () => { });
        }

        public async Task SetExposureModeAsync(string mode)
        {
            BasicResultHandler.HandleNoValue(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("setExposureMode", mode)),
                code => { throw new RemoteApiException(code); },
                () => { });
        }

        public async Task<string> GetExposureModeAsync()
        {
            string result = null;
            BasicResultHandler.HandleSingleValue<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getExposureMode")),
                code => { throw new RemoteApiException(code); },
                mode => result = mode);
            return result;
        }

        public async Task<string[]> GetSupportedExposureModeAsync()
        {
            string[] result = null;
            BasicResultHandler.HandleArray<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getSupportedExposureMode")),
                code => { throw new RemoteApiException(code); },
                mode => result = mode);
            return result;
        }

        public async Task<Capability<string>> GetAvailableExposureModeAsync()
        {
            Capability<string> result = null;
            BasicResultHandler.HandleCapability<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getAvailableExposureMode")),
                code => { throw new RemoteApiException(code); },
                info => result = info);
            return result;
        }

        public async Task SetFocusModeAsync(string mode)
        {
            BasicResultHandler.HandleNoValue(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("setFocusMode", mode)),
                code => { throw new RemoteApiException(code); },
                () => { });
        }

        public async Task<string> GetFocusModeAsync()
        {
            string result = null;
            BasicResultHandler.HandleSingleValue<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getFocusMode")),
                code => { throw new RemoteApiException(code); },
                mode => result = mode);
            return result;
        }

        public async Task<string[]> GetSupportedFocusModeAsync()
        {
            string[] result = null;
            BasicResultHandler.HandleArray<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getSupportedFocusMode")),
                code => { throw new RemoteApiException(code); },
                mode => result = mode);
            return result;
        }

        public async Task<Capability<string>> GetAvailableFocusModeAsync()
        {
            Capability<string> result = null;
            BasicResultHandler.HandleCapability<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getAvailableFocusMode")),
                code => { throw new RemoteApiException(code); },
                info => result = info);
            return result;
        }

        public async Task SetEvIndexAsync(int index)
        {
            BasicResultHandler.HandleNoValue(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("setExposureCompensation", index)),
                code => { throw new RemoteApiException(code); },
                () => { });
        }

        public async Task<int> GetEvIndexAsync()
        {
            int result = -1;
            BasicResultHandler.HandleSingleValue<int>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getExposureCompensation")),
                code => { throw new RemoteApiException(code); },
                mode => result = mode);
            return result;
        }

        public async Task<EvCandidate[]> GetSupportedEvAsync()
        {
            EvCandidate[] result = null;
            ResultHandler.HandleGetSupportedEv(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getSupportedExposureCompensation")),
                code => { throw new RemoteApiException(code); },
                info => result = info);
            return result;
        }

        public async Task<EvCapability> GetAvailableEvAsync()
        {
            EvCapability result = null;
            BasicResultHandler.HandleParallelValues<int>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getAvailableExposureCompensation")),
                4,
                code => { throw new RemoteApiException(code); },
                info => result = new EvCapability
                {
                    Candidate = new EvCandidate
                    {
                        IndexStep = EvConverter.GetDefinition(info[3]),
                        MaxIndex = info[1],
                        MinIndex = info[2]
                    },
                    CurrentIndex = info[0]
                });
            return result;
        }

        public async Task SetFNumberAsync(string f)
        {
            BasicResultHandler.HandleNoValue(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("setFNumber", f)),
                code => { throw new RemoteApiException(code); },
                () => { });
        }

        public async Task<string> GetFNumberAsync()
        {
            string result = null;
            BasicResultHandler.HandleSingleValue<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getFNumber")),
                code => { throw new RemoteApiException(code); },
                res => result = res);
            return result;
        }

        public async Task<string[]> GetSupportedFNumberAsync()
        {
            string[] result = null;
            BasicResultHandler.HandleArray<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getSupportedFNumber")),
                code => { throw new RemoteApiException(code); },
                res => result = res);
            return result;
        }

        public async Task<Capability<string>> GetAvailableFNumberAsync()
        {
            Capability<string> result = null;
            BasicResultHandler.HandleCapability<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getAvailableFNumber")),
                code => { throw new RemoteApiException(code); },
                res => result = res);
            return result;
        }

        public async Task SetShutterSpeedAsync(string ss)
        {
            BasicResultHandler.HandleNoValue(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("setShutterSpeed", ss)),
                code => { throw new RemoteApiException(code); },
                () => { });
        }

        public async Task<string> GetShutterSpeedAsync()
        {
            string result = null;
            BasicResultHandler.HandleSingleValue<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getShutterSpeed")),
                code => { throw new RemoteApiException(code); },
                res => result = res);
            return result;
        }

        public async Task<string[]> GetSupportedShutterSpeedAsync()
        {
            string[] result = null;
            BasicResultHandler.HandleArray<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getSupportedShutterSpeed")),
                code => { throw new RemoteApiException(code); },
                res => result = res);
            return result;
        }

        public async Task<Capability<string>> GetAvailableShutterSpeedAsync()
        {
            Capability<string> result = null;
            BasicResultHandler.HandleCapability<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getAvailableShutterSpeed")),
                code => { throw new RemoteApiException(code); },
                res => result = res);
            return result;
        }

        public async Task SetISOSpeedAsync(string iso)
        {
            BasicResultHandler.HandleNoValue(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("setIsoSpeedRate", iso)),
                code => { throw new RemoteApiException(code); },
                () => { });
        }

        public async Task<string> GetIsoSpeedAsync()
        {
            string result = null;
            BasicResultHandler.HandleSingleValue<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getIsoSpeedRate")),
                code => { throw new RemoteApiException(code); },
                res => result = res);
            return result;
        }

        public async Task<string[]> GetSupportedIsoSpeedAsync()
        {
            string[] result = null;
            BasicResultHandler.HandleArray<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getSupportedIsoSpeedRate")),
                code => { throw new RemoteApiException(code); },
                res => result = res);
            return result;
        }

        public async Task<Capability<string>> GetAvailableIsoSpeedAsync()
        {
            Capability<string> result = null;
            BasicResultHandler.HandleCapability<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getAvailableIsoSpeedRate")),
                code => { throw new RemoteApiException(code); },
                res => result = res);
            return result;
        }

        public async Task SetStillImageSizeAsync(StillImageSize size)
        {
            BasicResultHandler.HandleNoValue(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("setStillSize", size.AspectRatio, size.SizeDefinition)),
                code => { throw new RemoteApiException(code); },
                () => { });
        }

        public async Task<StillImageSize> GetStillSizeAsync()
        {
            StillImageSize result = null;
            BasicResultHandler.HandleObject<StillImageSize>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getStillSize")),
                code => { throw new RemoteApiException(code); },
                res => result = res);
            return result;
        }

        public async Task<StillImageSize[]> GetSupportedStillSizeAsync()
        {
            StillImageSize[] result = null;
            BasicResultHandler.HandleObject<StillImageSize[]>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getSupportedStillSize")),
                code => { throw new RemoteApiException(code); },
                res => result = res);
            return result;
        }

        public async Task<Capability<StillImageSize>> GetAvailableStillSizeAsync()
        {
            Capability<StillImageSize> result = null;
            BasicResultHandler.HandleCapabilityObject<StillImageSize>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getAvailableStillSize")),
                code => { throw new RemoteApiException(code); },
                res => result = res);
            return result;
        }

        public async Task SetWhiteBalanceAsync(WhiteBalance wb, bool enableColorTemperature)
        {
            BasicResultHandler.HandleNoValue(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("setWhiteBalance", wb.Mode, enableColorTemperature, wb.ColorTemperature)),
                code => { throw new RemoteApiException(code); },
                () => { });
        }

        public async Task<WhiteBalance> GetWhiteBalanceAsync()
        {
            WhiteBalance result = null;
            BasicResultHandler.HandleObject<WhiteBalance>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getWhiteBalance")),
                code => { throw new RemoteApiException(code); },
                res => result = res);
            return result;
        }

        public async Task<WhiteBalanceCandidate[]> GetSupportedWhiteBalanceAsync()
        {
            WhiteBalanceCandidate[] result = null;
            BasicResultHandler.HandleObject<WhiteBalanceCandidate[]>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getSupportedWhiteBalance")),
                code => { throw new RemoteApiException(code); },
                res => result = res);
            return result;
        }

        public async Task<WhiteBalanceCapability> GetAvailableWhiteBalanceAsync()
        {
            WhiteBalanceCapability result = null;
            ResultHandler.HandleWBCapability(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getAvailableWhiteBalance")),
                code => { throw new RemoteApiException(code); },
                res => result = res);
            return result;
        }

        public async Task SetBeepModeAsync(string mode)
        {
            BasicResultHandler.HandleNoValue(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("setBeepMode", mode)),
                code => { throw new RemoteApiException(code); },
                () => { });
        }

        public async Task<string> GetBeepModeAsync()
        {
            string result = null;
            BasicResultHandler.HandleSingleValue<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getBeepMode")),
                code => { throw new RemoteApiException(code); },
                mode => result = mode);
            return result;
        }

        public async Task<string[]> GetSupportedBeepModeAsync()
        {
            string[] result = null;
            BasicResultHandler.HandleArray<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getSupportedBeepMode")),
                code => { throw new RemoteApiException(code); },
                mode => result = mode);
            return result;
        }

        public async Task<Capability<string>> GetAvailableBeepModeAsync()
        {
            Capability<string> result = null;
            BasicResultHandler.HandleCapability<string>(
                await AsyncPostClient.Post(endpoint, RequestGenerator.Jsonize("getAvailableBeepMode")),
                code => { throw new RemoteApiException(code); },
                info => result = info);
            return result;
        }
    }
}
