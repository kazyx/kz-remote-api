using Kazyx.RemoteApi.Camera;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Kazyx.RemoteApi
{
    internal class CustomParser
    {
        internal static TouchFocusStatus AsTouchFocusStatus(string jString)
        {
            var json = BasicParser.Initialize(jString);

            var position = json["result"][0].Values<double>("touchCoordinates").ToArray();

            return new TouchFocusStatus
            {
                Focused = json["result"][0].Value<bool>("set"),
                Position = new FocusPosition { X_Axis = position[0], Y_Axis = position[1] }
            };
        }

        internal static ProgramShiftRange AsProgramShiftRange(string jString)
        {
            var range = BasicParser.AsPrimitiveList<int>(jString);
            if (range.Count != 2)
            {
                throw new RemoteApiException(StatusCode.IllegalResponse);
            }

            return new ProgramShiftRange
            {
                Max = range[0],
                Min = range[1]
            };
        }

        internal static WhiteBalanceCapability AsWhiteBalanceCapability(string jString)
        {
            var json = BasicParser.Initialize(jString);

            return new WhiteBalanceCapability
            {
                Current = JsonConvert.DeserializeObject<WhiteBalance>(json["result"][0].ToString(Formatting.None)),
                Candidates = JsonConvert.DeserializeObject<List<WhiteBalanceCandidate>>(json["result"][1].ToString(Formatting.None))
            };
        }

        internal static EvCapability AsEvCapability(string jString)
        {
            var info = BasicParser.AsParallelPrimitives<int>(jString, 4);

            return new EvCapability
               {
                   Candidate = new EvCandidate
                   {
                       IndexStep = EvConverter.GetDefinition(info[3]),
                       MaxIndex = info[1],
                       MinIndex = info[2]
                   },
                   CurrentIndex = info[0]
               };
        }

        internal static ServerAppInfo AsServerAppInfo(string jString)
        {
            var res = BasicParser.AsParallelPrimitives<string>(jString, 2);

            return new ServerAppInfo { Name = res[0], Version = res[1] };
        }

        internal static SetFocusResult AsSetFocusResult(string jString)
        {
            var json = BasicParser.Initialize(jString);

            return JsonConvert.DeserializeObject<SetFocusResult>(json["result"][1].ToString(Formatting.None)); // ignore 0th parameter
        }

        internal static List<EvCandidate> AsEvCandidates(string jString)
        {
            var json = BasicParser.Initialize(jString);

            var maxlist = json["result"][0].Values<int>().ToList();
            var minlist = json["result"][1].Values<int>().ToList();
            var deflist = json["result"][2].Values<int>().ToList();

            if (maxlist.Count != minlist.Count || minlist.Count != deflist.Count)
            {
                throw new RemoteApiException(StatusCode.IllegalResponse);
            }
            var tmp = new List<EvCandidate>();
            for (int i = 0; i < maxlist.Count; i++)
            {
                tmp.Add(new EvCandidate
                {
                    IndexStep = EvConverter.GetDefinition(deflist[i]),
                    MaxIndex = maxlist[i],
                    MinIndex = minlist[i]
                });
            }

            return tmp;
        }

        internal static List<MethodType> AsMethodTypes(string jString)
        {
            var json = BasicParser.Initialize(jString);

            var method_types = new List<MethodType>();
            foreach (var token in json["results"])
            {
                method_types.Add(new MethodType()
                {
                    Name = token.Value<string>(0),
                    ReqTypes = token[1].Values<string>().ToList(),
                    ResTypes = token[2].Values<string>().ToList(),
                    Version = token.Value<string>(3)
                });
            }

            return method_types;
        }

        internal static Event AsCameraEvent(string jString)
        {
            var json = BasicParser.Initialize(jString);
            Debug.WriteLine(json.ToString(Formatting.None));

            var jResult = json["result"] as JArray;

            var res = new Event();

            var elem = jResult[0];
            res.AvailableApis = elem.HasValues ? elem["names"].Values<string>().ToList() : null;

            elem = jResult[1];
            res.CameraStatus = elem.HasValues ? elem.Value<string>("cameraStatus") : null;

            elem = jResult[2];
            res.ZoomInfo = elem.HasValues ? JsonConvert.DeserializeObject<ZoomInfo>(elem.ToString(Formatting.None)) : null;

            elem = jResult[3];
            res.LiveviewAvailable = elem.HasValues ? elem.Value<bool>("liveviewStatus") : false;

            elem = jResult[4];
            res.LiveviewOrientation = elem.HasValues ? elem.Value<string>("liveviewOrientation") : null;

            elem = jResult[5];
            if (elem.HasValues)
            {
                var tmp = new List<string>();
                foreach (var obj in elem.Children())
                {
                    foreach (var url in obj["takePictureUrl"].Values<string>())
                    {
                        tmp.Add(url);
                    }
                }
                res.PictureUrls = tmp;
            }

            elem = jResult[10];
            res.StorageInfo = elem.HasValues ? JsonConvert.DeserializeObject<List<StorageInfo>>(elem.ToString(Formatting.None)) : null;

            elem = jResult[11];
            res.BeepMode = elem.HasValues ? new Capability<string>
                {
                    Current = elem.Value<string>("currentBeepMode"),
                    Candidates = elem["beepModeCandidates"].Values<string>().ToList()
                } : null;

            elem = jResult[12];
            res.Function = elem.HasValues ? new Capability<string>
                {
                    Current = elem.Value<string>("currentCameraFunction"),
                    Candidates = elem["cameraFunctionCandidates"].Values<string>().ToList()
                } : null;

            elem = jResult[13];
            res.MovieQuality = elem.HasValues ? new Capability<string>
                {
                    Current = elem.Value<string>("currentMovieQuality"),
                    Candidates = elem["movieQualityCandidates"].Values<string>().ToList()
                } : null;

            elem = jResult[14];
            res.StillImageSize = elem.HasValues ? new StillImageSizeEvent
                {
                    Current = new StillImageSize
                    {
                        AspectRatio = elem.Value<string>("currentAspect"),
                        SizeDefinition = elem.Value<string>("currentSize")
                    },
                    CapabilityChanged = elem.Value<bool>("checkAvailability")
                } : null;

            elem = jResult[15];
            res.FunctionChangeResult = elem.HasValues ? elem.Value<string>("cameraFunctionResult") : null;

            elem = jResult[16];
            res.SteadyMode = elem.HasValues ? new Capability<string>
                {
                    Current = elem.Value<string>("currentSteadyMode"),
                    Candidates = elem["steadyModeCandidates"].Values<string>().ToList()
                } : null;

            elem = jResult[17];
            res.ViewAngle = elem.HasValues ? new Capability<int>
                {
                    Current = elem.Value<int>("currentViewAngle"),
                    Candidates = elem["viewAngleCandidates"].Values<int>().ToList()
                } : null;

            elem = jResult[18];
            res.ExposureMode = elem.HasValues ? new Capability<string>
                {
                    Current = elem.Value<string>("currentExposureMode"),
                    Candidates = elem["exposureModeCandidates"].Values<string>().ToList()
                } : null;

            elem = jResult[19];
            res.PostviewSizeInfo = elem.HasValues ? new Capability<string>
                {
                    Current = elem.Value<string>("currentPostviewImageSize"),
                    Candidates = elem["postviewImageSizeCandidates"].Values<string>().ToList()
                } : null;

            elem = jResult[20];
            res.SelfTimerInfo = elem.HasValues ? new Capability<int>
                {
                    Current = elem.Value<int>("currentSelfTimer"),
                    Candidates = elem["selfTimerCandidates"].Values<int>().ToList()
                } : null;

            elem = jResult[21];
            res.ShootModeInfo = elem.HasValues ? new Capability<string>
                {
                    Current = elem.Value<string>("currentShootMode"),
                    Candidates = elem["shootModeCandidates"].Values<string>().ToList()
                } : null;

            elem = jResult[25];
            res.EvInfo = elem.HasValues ? new EvCapability
                {
                    CurrentIndex = elem.Value<int>("currentExposureCompensation"),
                    Candidate = new EvCandidate
                    {
                        MaxIndex = elem.Value<int>("maxExposureCompensation"),
                        MinIndex = elem.Value<int>("minExposureCompensation"),
                        IndexStep = EvConverter.GetDefinition(elem.Value<int>("stepIndexOfExposureCompensation"))
                    }
                } : null;

            elem = jResult[26];
            res.FlashMode = elem.HasValues ? new Capability<string>
                {
                    Current = elem.Value<string>("currentFlashMode"),
                    Candidates = elem["flashModeCandidates"].Values<string>().ToList()
                } : null;

            elem = jResult[27];
            res.FNumber = elem.HasValues ? new Capability<string>
                {
                    Current = elem.Value<string>("currentFNumber"),
                    Candidates = elem["fNumberCandidates"].Values<string>().ToList()
                } : null;

            elem = jResult[28];
            res.FocusMode = elem.HasValues ? new Capability<string>
                {
                    Current = elem.Value<string>("currentFocusMode"),
                    Candidates = elem["focusModeCandidates"].Values<string>().ToList()
                } : null;

            elem = jResult[29];
            res.ISOSpeedRate = elem.HasValues ? new Capability<string>
                {
                    Current = elem.Value<string>("currentIsoSpeedRate"),
                    Candidates = elem["isoSpeedRateCandidates"].Values<string>().ToList()
                } : null;

            elem = jResult[31];
            if (elem.HasValues)
            {
                res.ProgramShiftActivated = elem.Value<bool>("isShifted");
            }

            elem = jResult[32];
            res.ShutterSpeed = elem.HasValues ? new Capability<string>
                {
                    Current = elem.Value<string>("currentShutterSpeed"),
                    Candidates = elem["shutterSpeedCandidates"].Values<string>().ToList()
                } : null;

            elem = jResult[33];
            res.WhiteBalance = elem.HasValues ? new WhiteBalanceEvent
                {
                    Current = new WhiteBalance
                    {
                        Mode = elem.Value<string>("currentWhiteBalanceMode"),
                        ColorTemperature = elem.Value<int>("currentColorTemperature")
                    },
                    CapabilityChanged = elem.Value<bool>("checkAvailability")
                } : null;

            elem = jResult[34];
            if (elem.HasValues)
            {
                var coordinates = elem["currentTouchCoordinates"].Values<double>().ToArray();
                res.TouchAFStatus = new TouchFocusStatus
                {
                    Focused = elem.Value<bool>("currentSet"),
                    Position = coordinates.Length == 2 ? new FocusPosition
                    {
                        X_Axis = coordinates[0],
                        Y_Axis = coordinates[1]
                    } : null
                };
            }

            if (jResult.Count > 35) // GetEvent version 1.1
            {
                elem = jResult[35];
                res.FocusStatus = elem.HasValues ? elem.Value<string>("focusStatus") : null;
            }

            if (jResult.Count > 36) // GetEvent version 1.2
            {
                elem = jResult[36];
                res.ZoomSetting = elem.HasValues ? JsonConvert.DeserializeObject<ZoomModeCapability>(elem.ToString(Formatting.None)) : null;

                elem = jResult[37];
                res.ImageQuality = elem.HasValues ? JsonConvert.DeserializeObject<ImageQualityCapability>(elem.ToString(Formatting.None)) : null;

                elem = jResult[38];
                res.ContShootingMode = elem.HasValues ? JsonConvert.DeserializeObject<ContinuousShootingModeCapability>(elem.ToString(Formatting.None)) : null;

                elem = jResult[39];
                res.ContShootingSpeed = elem.HasValues ? JsonConvert.DeserializeObject<ContinuousShootingSpeedCapability>(elem.ToString(Formatting.None)) : null;

                elem = jResult[40];
                if (elem.HasValues)
                {
                    var list = new List<ContShootingResult>();
                    var ja = elem["contShootingUrl"] as JArray;
                    foreach (var token in ja.Values<JObject>())
                    {
                        list.Add(JsonConvert.DeserializeObject<ContShootingResult>(token.ToString(Formatting.None)));
                    }
                    res.ContShootingResult = list;
                }

                elem = jResult[41];
                res.FlipMode = elem.HasValues ? JsonConvert.DeserializeObject<FlipModeCapability>(elem.ToString(Formatting.None)) : null;

                elem = jResult[42];
                res.SceneSelection = elem.HasValues ? JsonConvert.DeserializeObject<SceneSelectionCapability>(elem.ToString(Formatting.None)) : null;

                elem = jResult[43];
                res.IntervalTime = elem.HasValues ? JsonConvert.DeserializeObject<IntervalTimeCapability>(elem.ToString(Formatting.None)) : null;

                elem = jResult[44];
                res.ColorSetting = elem.HasValues ? JsonConvert.DeserializeObject<ColorSettingCapability>(elem.ToString(Formatting.None)) : null;

                elem = jResult[45];
                res.MovieFormat = elem.HasValues ? JsonConvert.DeserializeObject<MovieFormatCapability>(elem.ToString(Formatting.None)) : null;

                elem = jResult[52];
                res.IrRemoteControl = elem.HasValues ? JsonConvert.DeserializeObject<InfraredRemoteControlCapability>(elem.ToString(Formatting.None)) : null;

                elem = jResult[53];
                res.TvColorSystem = elem.HasValues ? JsonConvert.DeserializeObject<TvColorSystemCapability>(elem.ToString(Formatting.None)) : null;

                elem = jResult[54];
                res.TrackingFocusStatus = elem.HasValues ? elem.Value<string>("trackingFocusStatus") : null;

                elem = jResult[55];
                res.TrackingFocusMode = elem.HasValues ? JsonConvert.DeserializeObject<TrackingFocusModeCapability>(elem.ToString(Formatting.None)) : null;

                elem = jResult[56];
                if (elem.HasValues)
                {
                    var list = new List<BatteryInfo>();
                    var ja = elem["batteryInfo"] as JArray;
                    foreach (var token in ja.Values<JObject>())
                    {
                        list.Add(JsonConvert.DeserializeObject<BatteryInfo>(token.ToString(Formatting.None)));
                    }
                    res.BatteryInfo = list;
                }

                elem = jResult[57];
                res.RecordingTimeSec = elem.HasValues ? elem.Value<int>("recordingTime") : -1;

                elem = jResult[58];
                res.NumberOfShots = elem.HasValues ? elem.Value<int>("numberOfShots") : -1;

                elem = jResult[59];
                res.AutoPowerOff = elem.HasValues ? JsonConvert.DeserializeObject<ApoCapability>(elem.ToString(Formatting.None)) : null;
            }

            if (jResult.Count > 60) // GetEvent version 1.3
            {
                elem = jResult[60];
                res.LoopRecTime = elem.HasValues ? JsonConvert.DeserializeObject<LoopRecTimeCapability>(elem.ToString(Formatting.None)) : null;

                elem = jResult[61];
                res.AudioRecording = elem.HasValues ? JsonConvert.DeserializeObject<AudioRecordingCapability>(elem.ToString(Formatting.None)) : null;

                elem = jResult[62];
                res.WindNoiseReduction = elem.HasValues ? JsonConvert.DeserializeObject<WindNoiseReductionCapability>(elem.ToString(Formatting.None)) : null;
            }

            return res;
        }
    }
}
