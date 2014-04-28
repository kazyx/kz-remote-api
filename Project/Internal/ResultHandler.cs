using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Kazyx.RemoteApi
{
    /// <summary>
    /// This class provides function to parse response JSON string and invoke proper callback.
    /// </summary>
    /// <remarks>
    /// Error callback include error code as an argument.
    /// <see cref="WPPMM.RemoteApi.StatusCode"/>
    /// </remarks>
    ///
    internal class ResultHandler
    {
        internal static void HandleWBCapability(string jString, Action<StatusCode> error, Action<WhiteBalanceCapability> result)
        {
            var json = JObject.Parse(jString);
            if (BasicResultHandler.HandleError(json, error))
            {
                return;
            }

            result.Invoke(new WhiteBalanceCapability
            {
                current = JsonConvert.DeserializeObject<WhiteBalance>(json["result"][0].ToString()),
                candidates = JsonConvert.DeserializeObject<WhiteBalanceCandidate[]>(json["result"][1].ToString())
            }
            );
        }

        internal static void HandleGetCurrentTime(string jString, Action<StatusCode> error, Action<DateTimeOffset> result)
        {
            var json = JObject.Parse(jString);
            if (BasicResultHandler.HandleError(json, error))
            {
                return;
            }

            DateTime dt = DateTime.Parse(json["result"][0].Value<string>("dateTime"));
            int timezone = json["result"][1].Value<int>("timeZoneOffsetMinute");
            int dst = json["result"][2].Value<int>("dstOffsetMinute");
            DateTimeOffset dto = new DateTimeOffset(dt, TimeSpan.FromMinutes(timezone + dst));
            result.Invoke(dto);
        }

        internal static void HandleGetSupportedEv(string jString, Action<StatusCode> error, Action<EvCandidate[]> result)
        {
            var json = JObject.Parse(jString);
            if (BasicResultHandler.HandleError(json, error))
            {
                return;
            }

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
                error.Invoke(StatusCode.IllegalResponse);
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
            result.Invoke(tmp.ToArray());
        }

        internal static void HandleGetApplicationInfo(string jString, Action<StatusCode> error, Action<ServerAppInfo> result)
        {
            BasicResultHandler.HandleParallelValues<string>(jString, 2, error,
                (array) => { result.Invoke(new ServerAppInfo { name = array[0], version = array[1] }); });
        }

        internal static void HandleGetMethodTypes(string jString, Action<StatusCode> error, Action<MethodType[]> result)
        {
            var json = JObject.Parse(jString);
            if (BasicResultHandler.HandleError(json, error))
            {
                return;
            }

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
                    name = token.Value<string>(0),
                    reqtypes = req.ToArray(),
                    restypes = res.ToArray(),
                    version = token.Value<string>(3)
                });
            }
            result.Invoke(method_types.ToArray());
        }

        internal static void HandleGetEvent(string jString, Action<StatusCode> error, Action<Event> result)
        {
            var json = JObject.Parse(jString);
            if (BasicResultHandler.HandleError(json, error))
            {
                return;
            }

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
                    position = jZoom.Value<int>("zoomPosition"),
                    number_of_boxes = jZoom.Value<int>("zoomNumberBox"),
                    current_box_index = jZoom.Value<int>("zoomIndexCurrentBox"),
                    position_in_current_box = jZoom.Value<int>("zoomPositionCurrentBox")
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
                    current = jbeep.Value<string>("currentBeepMode"),
                    candidates = bcand.ToArray()
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
                    current = jExposureMode.Value<string>("currentExposureMode"),
                    candidates = modecandidates.ToArray()
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
                    current = jPostView.Value<string>("currentPostviewImageSize"),
                    candidates = pvcandidates.ToArray()
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
                    current = jSelfTimer.Value<int>("currentSelfTimer"),
                    candidates = stcandidates.ToArray()
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
                    current = jShootMode.Value<string>("currentShootMode"),
                    candidates = smcandidates.ToArray()
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
                    current = jFN.Value<string>("currentFNumber"),
                    candidates = fncandidates.ToArray()
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
                    current = jFM.Value<string>("currentFocusMode"),
                    candidates = candidates.ToArray()
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
                    current = jIso.Value<string>("currentIsoSpeedRate"),
                    candidates = isocandidates.ToArray()
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
                    current = jSS.Value<string>("currentShutterSpeed"),
                    candidates = sscandidates.ToArray()
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
                tafs = new TouchFocusStatus
                {
                    Focused = jtaf.Value<bool>("currentSet")
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


            result.Invoke(new Event()
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
                FocusStatus = fs
            });
        }
    }
}
