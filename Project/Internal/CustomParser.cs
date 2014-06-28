using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace Kazyx.RemoteApi.Internal
{
    internal class CustomParser
    {
        internal static ProgramShiftRange AsProgramShiftRange(string jString)
        {
            var range = BasicParser.AsPrimitiveArray<int>(jString);
            if (range.Length != 2)
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
                Candidates = JsonConvert.DeserializeObject<WhiteBalanceCandidate[]>(json["result"][1].ToString(Formatting.None))
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

        internal static EvCandidate[] AsEvCandidates(string jString)
        {
            var json = BasicParser.Initialize(jString);

            var maxlist = new List<int>();
            foreach (int max in json["result"][0].Values<int>())
            {
                maxlist.Add(max);
            }

            var minlist = new List<int>();
            foreach (int min in json["result"][1].Values<int>())
            {
                minlist.Add(min);
            }

            var deflist = new List<int>();
            foreach (int def in json["result"][2].Values<int>())
            {
                deflist.Add(def);
            }

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

            return tmp.ToArray();
        }

        internal static MethodType[] AsMethodTypes(string jString)
        {
            var json = BasicParser.Initialize(jString);

            var method_types = new List<MethodType>();
            foreach (var token in json["results"])
            {
                var req = new List<string>();
                foreach (var type in token[1].Values<string>())
                {
                    req.Add(type);
                }
                var res = new List<string>();
                foreach (var type in token[2].Values<string>())
                {
                    res.Add(type);
                }
                method_types.Add(new MethodType()
                {
                    Name = token.Value<string>(0),
                    ReqTypes = req.ToArray(),
                    ResTypes = res.ToArray(),
                    Version = token.Value<string>(3)
                });
            }

            return method_types.ToArray();
        }

        internal static Event AsCameraEvent(string jString)
        {
            var json = BasicParser.Initialize(jString);
            Debug.WriteLine(json.ToString());
            var jResult = json["result"] as JArray;

            var jApi = jResult[0];
            string[] apis = null;
            if (jApi.HasValues)
            {
                var apilist = new List<string>();
                foreach (var str in jApi["names"].Values<string>())
                {
                    apilist.Add(str);
                }
                apis = apilist.ToArray();
            }

            var jStatus = jResult[1];
            string status = null;
            if (jStatus.HasValues)
            {
                status = jStatus.Value<string>("cameraStatus");
            }

            var jZoom = jResult[2];
            ZoomInfo zoom = null;
            if (jZoom.HasValues)
            {
                zoom = new ZoomInfo
                {
                    Position = jZoom.Value<int>("zoomPosition"),
                    NumberOfBoxes = jZoom.Value<int>("zoomNumberBox"),
                    CurrentBoxIndex = jZoom.Value<int>("zoomIndexCurrentBox"),
                    PositionInCurrentBox = jZoom.Value<int>("zoomPositionCurrentBox")
                };
            }

            var jLiveview = jResult[3];
            bool liveview_status = false;
            if (jLiveview.HasValues)
            {
                jLiveview.Value<bool>("liveviewStatus");
            }

            var jlvo = jResult[4];
            string lv_orientation = null;
            if (jlvo.HasValues)
            {
                jlvo.Value<string>("liveviewOrientation");
            }

            var jpicurls = jResult[5];
            string[] pic_urls = null;
            if (jpicurls.HasValues)
            {
                var tmp = new List<string>();
                foreach (var obj in jpicurls.Children())
                {
                    foreach (var url in obj["takePictureUrl"].Values<string>())
                    {
                        tmp.Add(url);
                    }
                }
                pic_urls = tmp.ToArray();
            }

            var jStorageInfo = jResult[10];
            StorageInfo[] storage = null;
            if (jStorageInfo.HasValues)
            {
                storage = JsonConvert.DeserializeObject<StorageInfo[]>(jStorageInfo.ToString(Formatting.None));
            }

            var jbeep = jResult[11];
            Capability<string> beep = null;
            if (jbeep.HasValues)
            {
                var bcand = new List<string>();
                foreach (var str in jbeep["beepModeCandidates"].Values<string>())
                {
                    bcand.Add(str);
                }
                beep = new Capability<string>
                {
                    Current = jbeep.Value<string>("currentBeepMode"),
                    Candidates = bcand.ToArray()
                };
            }

            var jMQuality = jResult[13];
            Capability<string> mquality = null;
            if (jMQuality.HasValues)
            {
                Debug.WriteLine(jMQuality.ToString());
                var modecandidates = new List<string>();
                foreach (var str in jMQuality["movieQualityCandidates"].Values<string>())
                {
                    modecandidates.Add(str);
                }
                mquality = new Capability<string>
                {
                    Current = jMQuality.Value<string>("currentMovieQuality"),
                    Candidates = modecandidates.ToArray()
                };
            }

            var jssize = jResult[14];
            StillImageSizeEvent sis = null;
            if (jssize.HasValues)
            {

                sis = new StillImageSizeEvent
                {
                    Current = new StillImageSize
                    {
                        AspectRatio = jssize.Value<string>("currentAspect"),
                        SizeDefinition = jssize.Value<string>("currentSize")
                    },
                    CapabilityChanged = jssize.Value<bool>("checkAvailability")
                };
            }

            var jSteady = jResult[16];
            Capability<string> steady = null;
            if (jSteady.HasValues)
            {
                var modecandidates = new List<string>();
                foreach (var str in jSteady["steadyModeCandidates"].Values<string>())
                {
                    modecandidates.Add(str);
                }
                steady = new Capability<string>
                {
                    Current = jSteady.Value<string>("currentSteadyMode"),
                    Candidates = modecandidates.ToArray()
                };
            }

            var jAngle = jResult[17];
            Capability<int> angle = null;
            if (jAngle.HasValues)
            {
                var modecandidates = new List<int>();
                foreach (var str in jAngle["viewAngleCandidates"].Values<int>())
                {
                    modecandidates.Add(str);
                }
                angle = new Capability<int>
                {
                    Current = jAngle.Value<int>("currentViewAngle"),
                    Candidates = modecandidates.ToArray()
                };
            }

            var jExposureMode = jResult[18];
            Capability<string> exposure = null;
            if (jExposureMode.HasValues)
            {
                var modecandidates = new List<string>();
                foreach (var str in jExposureMode["exposureModeCandidates"].Values<string>())
                {
                    modecandidates.Add(str);
                }
                exposure = new Capability<string>
                {
                    Current = jExposureMode.Value<string>("currentExposureMode"),
                    Candidates = modecandidates.ToArray()
                };
            }

            var jPostView = jResult[19];
            Capability<string> postview = null;
            if (jPostView.HasValues)
            {
                var pvcandidates = new List<string>();
                foreach (var str in jPostView["postviewImageSizeCandidates"].Values<string>())
                {
                    pvcandidates.Add(str);
                }
                postview = new Capability<string>
                {
                    Current = jPostView.Value<string>("currentPostviewImageSize"),
                    Candidates = pvcandidates.ToArray()
                };
            }

            var jSelfTimer = jResult[20];
            Capability<int> selftimer = null;
            if (jSelfTimer.HasValues)
            {
                var stcandidates = new List<int>();
                foreach (var str in jSelfTimer["selfTimerCandidates"].Values<int>())
                {
                    stcandidates.Add(str);
                }
                selftimer = new Capability<int>
                {
                    Current = jSelfTimer.Value<int>("currentSelfTimer"),
                    Candidates = stcandidates.ToArray()
                };
            }

            var jShootMode = jResult[21];
            Capability<string> shootmode = null;
            if (jShootMode.HasValues)
            {
                var smcandidates = new List<string>();
                foreach (var str in jShootMode["shootModeCandidates"].Values<string>())
                {
                    smcandidates.Add(str);
                }
                shootmode = new Capability<string>
                {
                    Current = jShootMode.Value<string>("currentShootMode"),
                    Candidates = smcandidates.ToArray()
                };
            }

            var jEV = jResult[25];
            EvCapability ev = null;
            if (jEV.HasValues)
            {
                ev = new EvCapability
                {
                    CurrentIndex = jEV.Value<int>("currentExposureCompensation"),
                    Candidate = new EvCandidate
                    {
                        MaxIndex = jEV.Value<int>("maxExposureCompensation"),
                        MinIndex = jEV.Value<int>("minExposureCompensation"),
                        IndexStep = EvConverter.GetDefinition(jEV.Value<int>("stepIndexOfExposureCompensation"))
                    }
                };
            }

            var jFlash = jResult[26];
            Capability<string> flash = null;
            if (jFlash.HasValues)
            {
                var flcandidates = new List<string>();
                foreach (var str in jFlash["flashModeCandidates"].Values<string>())
                {
                    flcandidates.Add(str);
                }
                flash = new Capability<string>
                {
                    Current = jFlash.Value<string>("currentFlashMode"),
                    Candidates = flcandidates.ToArray()
                };
            }

            var jFN = jResult[27];
            Capability<string> fn = null;
            if (jFN.HasValues)
            {
                var fncandidates = new List<string>();
                foreach (var str in jFN["fNumberCandidates"].Values<string>())
                {
                    fncandidates.Add(str);
                }
                fn = new Capability<string>
                {
                    Current = jFN.Value<string>("currentFNumber"),
                    Candidates = fncandidates.ToArray()
                };
            }

            var jFM = jResult[28];
            Capability<string> fm = null;
            if (jFM.HasValues)
            {
                var candidates = new List<string>();
                foreach (var str in jFM["focusModeCandidates"].Values<string>())
                {
                    candidates.Add(str);
                }
                fm = new Capability<string>
                {
                    Current = jFM.Value<string>("currentFocusMode"),
                    Candidates = candidates.ToArray()
                };
            }

            var jIso = jResult[29];
            Capability<string> iso = null;
            if (jIso.HasValues)
            {
                var isocandidates = new List<string>();
                foreach (var str in jIso["isoSpeedRateCandidates"].Values<string>())
                {
                    isocandidates.Add(str);
                }
                iso = new Capability<string>
                {
                    Current = jIso.Value<string>("currentIsoSpeedRate"),
                    Candidates = isocandidates.ToArray()
                };
            }

            var jPS = jResult[31];
            bool? ps = null;
            if (jPS.HasValues)
            {
                ps = jPS.Value<bool>("isShifted");
            }

            var jSS = jResult[32];
            Capability<string> ss = null;
            if (jSS.HasValues)
            {
                var sscandidates = new List<string>();
                foreach (var str in jSS["shutterSpeedCandidates"].Values<string>())
                {
                    sscandidates.Add(str);
                }
                ss = new Capability<string>
                {
                    Current = jSS.Value<string>("currentShutterSpeed"),
                    Candidates = sscandidates.ToArray()
                };
            }


            var jwb = jResult[33];
            WhiteBalanceEvent wb = null;
            if (jwb.HasValues)
            {
                wb = new WhiteBalanceEvent
                {
                    Current = new WhiteBalance
                    {
                        Mode = jwb.Value<string>("currentWhiteBalanceMode"),
                        ColorTemperature = jwb.Value<int>("currentColorTemperature")
                    },
                    CapabilityChanged = jwb.Value<bool>("checkAvailability")
                };
            }

            var jtaf = jResult[34];
            TouchFocusStatus tafs = null;
            if (jtaf.HasValues)
            {
                var coordinates = new List<double>();
                foreach (var val in jtaf["currentTouchCoordinates"].Values<double>())
                {
                    coordinates.Add(val);
                }
                tafs = new TouchFocusStatus
                {
                    Focused = jtaf.Value<bool>("currentSet"),
                    Position = coordinates.ToArray()
                };
            }

            string fs = null;
            if (jResult.Count > 35) // GetEvent version 1.1
            {
                var jfs = jResult[35];
                if (jfs != null && jfs.HasValues)
                {
                    fs = jfs.Value<string>("focusStatus");
                }
            }

            return new Event()
            {
                AvailableApis = apis,
                CameraStatus = status,
                ZoomInfo = zoom,
                LiveviewAvailable = liveview_status,
                PostviewSizeInfo = postview,
                SelfTimerInfo = selftimer,
                ShootModeInfo = shootmode,
                FNumber = fn,
                ISOSpeedRate = iso,
                ShutterSpeed = ss,
                EvInfo = ev,
                ExposureMode = exposure,
                ProgramShiftActivated = ps,
                LiveviewOrientation = lv_orientation,
                TouchAFStatus = tafs,
                BeepMode = beep,
                PictureUrls = pic_urls,
                StillImageSize = sis,
                WhiteBalance = wb,
                FocusStatus = fs,
                SteadyMode = steady,
                ViewAngle = angle,
                MovieQuality = mquality,
                StorageInfo = storage,
                FlashMode = flash,
                FocusMode = fm,
            };
        }
    }
}
