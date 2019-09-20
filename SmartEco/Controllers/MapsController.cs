﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using SmartEco.Models;

namespace SmartEco.Controllers
{
    public class MapsController : Controller
    {
        private readonly IHostingEnvironment _appEnvironment;
        private readonly HttpApiClientController _HttpApiClient;

        public MapsController(IHostingEnvironment appEnvironment, HttpApiClientController HttpApiClient)
        {
            _appEnvironment = appEnvironment;
            _HttpApiClient = HttpApiClient;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Aktau()
        {
            string decimaldelimiter = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            string urlLayers = "api/Layers";
            List<Layer> layers = new List<Layer>();
            HttpResponseMessage responseLayers = await _HttpApiClient.GetAsync(urlLayers);
            layers = await responseLayers.Content.ReadAsAsync<List<Layer>>();
            ViewBag.Layers = layers;

            string urlEcomonMonitoringPoints = "api/EcomonMonitoringPoints";
            List<EcomonMonitoringPoint> ecomons = new List<EcomonMonitoringPoint>();
            HttpResponseMessage responseEcomonMonitoringPoints = await _HttpApiClient.GetAsync(urlEcomonMonitoringPoints);
            ecomons = await responseEcomonMonitoringPoints.Content.ReadAsAsync<List<EcomonMonitoringPoint>>();
            JObject ecomonsObject = JObject.FromObject(new
            {
                type = "FeatureCollection",
                crs = new
                {
                    type = "name",
                    properties = new
                    {
                        name = "urn:ogc:def:crs:EPSG::3857"
                    }
                },
                features = from ecomon in ecomons
                           select new
                           {
                               type = "Feature",
                               properties = new
                               {
                                   Id = ecomon.Id,
                                   Number = ecomon.Number
                               },
                               geometry = new
                               {
                                   type = "Point",
                                   coordinates = new List<decimal>
                            {
                            Convert.ToDecimal(ecomon.EastLongitude.ToString().Replace(".", decimaldelimiter)),
                            Convert.ToDecimal(ecomon.NorthLatitude.ToString().Replace(".", decimaldelimiter))
                            },
                               }
                           }
            });
            ViewBag.EcomonsLayerJson = ecomonsObject.ToString();

            string urlKazHydrometAirPosts = "api/KazHydrometAirPosts";
            List<KazHydrometAirPost> kazHydrometAirPosts = new List<KazHydrometAirPost>();
            HttpResponseMessage responseKazHydrometAirPosts = await _HttpApiClient.GetAsync(urlKazHydrometAirPosts);
            kazHydrometAirPosts = await responseKazHydrometAirPosts.Content.ReadAsAsync<List<KazHydrometAirPost>>();
            JObject objectKazHydrometAirPosts = JObject.FromObject(new
            {
                type = "FeatureCollection",
                crs = new
                {
                    type = "name",
                    properties = new
                    {
                        name = "urn:ogc:def:crs:EPSG::3857"
                    }
                },
                features = from kazHydrometAirPost in kazHydrometAirPosts
                           select new
                           {
                               type = "Feature",
                               properties = new
                               {
                                   Id = kazHydrometAirPost.Id,
                                   Number = kazHydrometAirPost.Number
                               },
                               geometry = new
                               {
                                   type = "Point",
                                   coordinates = new List<decimal>
                            {
                            Convert.ToDecimal(kazHydrometAirPost.EastLongitude.ToString().Replace(".", decimaldelimiter)),
                            Convert.ToDecimal(kazHydrometAirPost.NorthLatitude.ToString().Replace(".", decimaldelimiter))
                            },
                               }
                           }
            });
            ViewBag.KazHydrometAirPostsLayerJson = objectKazHydrometAirPosts.ToString();

            string urlKazHydrometSoilPosts = "api/KazHydrometSoilPosts";
            List<KazHydrometSoilPost> kazHydrometSoilPosts = new List<KazHydrometSoilPost>();
            HttpResponseMessage responseKazHydrometSoilPosts = await _HttpApiClient.GetAsync(urlKazHydrometSoilPosts);
            kazHydrometSoilPosts = await responseKazHydrometSoilPosts.Content.ReadAsAsync<List<KazHydrometSoilPost>>();
            JObject objectKazHydrometSoilPosts = JObject.FromObject(new
            {
                type = "FeatureCollection",
                crs = new
                {
                    type = "name",
                    properties = new
                    {
                        name = "urn:ogc:def:crs:EPSG::3857"
                    }
                },
                features = from kazHydrometSoilPost in kazHydrometSoilPosts
                           select new
                           {
                               type = "Feature",
                               properties = new
                               {
                                   Id = kazHydrometSoilPost.Id,
                                   Number = kazHydrometSoilPost.Number
                               },
                               geometry = new
                               {
                                   type = "Point",
                                   coordinates = new List<decimal>
                            {
                            Convert.ToDecimal(kazHydrometSoilPost.EastLongitude.ToString().Replace(".", decimaldelimiter)),
                            Convert.ToDecimal(kazHydrometSoilPost.NorthLatitude.ToString().Replace(".", decimaldelimiter))
                            },
                               }
                           }
            });
            ViewBag.KazHydrometSoilPostsLayerJson = objectKazHydrometSoilPosts.ToString();

            string urlPollutionSources = "api/PollutionSources";
            List<PollutionSource> pollutionSources = new List<PollutionSource>();
            HttpResponseMessage responsePollutionSources = await _HttpApiClient.GetAsync(urlPollutionSources);
            pollutionSources = await responsePollutionSources.Content.ReadAsAsync<List<PollutionSource>>();
            JObject objectPollutionSources = JObject.FromObject(new
            {
                type = "FeatureCollection",
                crs = new
                {
                    type = "name",
                    properties = new
                    {
                        name = "urn:ogc:def:crs:EPSG::3857"
                    }
                },
                features = from pollutionSource in pollutionSources
                           select new
                           {
                               type = "Feature",
                               properties = new
                               {
                                   Id = pollutionSource.Id,
                                   Name = pollutionSource.Name
                               },
                               geometry = new
                               {
                                   type = "Point",
                                   coordinates = new List<decimal>
                            {
                            Convert.ToDecimal(pollutionSource.EastLongitude.ToString().Replace(".", decimaldelimiter)),
                            Convert.ToDecimal(pollutionSource.NorthLatitude.ToString().Replace(".", decimaldelimiter))
                            },
                               }
                           }
            });
            ViewBag.PollutionSourcesLayerJson = objectPollutionSources.ToString();

            string urlMeasuredDatas = "api/MeasuredDatas";
            List<MeasuredData> measuredDatas = new List<MeasuredData>();
            HttpResponseMessage responseMeasuredDatas = await _HttpApiClient.GetAsync(urlMeasuredDatas);
            measuredDatas = await responseMeasuredDatas.Content.ReadAsAsync<List<MeasuredData>>();
            double temperature = Convert.ToDouble(measuredDatas.Where(m => m.MonitoringPostId == 3).LastOrDefault(t => t.MeasuredParameterId == 4).Value);
            double speedWind = Convert.ToDouble(measuredDatas.Where(m => m.MonitoringPostId == 3).LastOrDefault(t => t.MeasuredParameterId == 5).Value);
            double directionWind = Convert.ToDouble(measuredDatas.Where(m => m.MonitoringPostId == 3).LastOrDefault(t => t.MeasuredParameterId == 6).Value);
            ViewBag.MeasuredData = measuredDatas;
            ViewBag.Temperature = temperature;
            ViewBag.SpeedWind = speedWind;
            ViewBag.DirectionWind = directionWind;

            List<SelectListItem> pollutants = new List<SelectListItem>();
            pollutants.Add(new SelectListItem() { Text = "Азот (II) оксид (Азота оксид) (6)", Value = "12" });
            pollutants.Add(new SelectListItem() { Text = "Азота (IV) диоксид (Азота диоксид) (4)", Value = "13" });
            pollutants.Add(new SelectListItem() { Text = "Сера диоксид (Ангидрид сернистый, Сернистый газ, Сера (IV) оксид) (516)", Value = "16" });
            pollutants.Add(new SelectListItem() { Text = "Углерод оксид (Окись углерода, Угарный газ) (584)", Value = "17" });
            ViewBag.Pollutants = pollutants;

            return View();
        }
        public async Task<IActionResult> KaragandaRegion()
        {
            string role = HttpContext.Session.GetString("Role");
            if (!(role == "admin" || role == "moderator" || role == "KaragandaRegion"))
            {
                return Redirect("/");
            }

            List<MeasuredParameter> measuredParameters = new List<MeasuredParameter>();
            string urlMeasuredParameters = "api/MeasuredParameters",
                routeMeasuredParameters = "";
            HttpResponseMessage responseMeasuredParameters = await _HttpApiClient.GetAsync(urlMeasuredParameters + routeMeasuredParameters);
            if (responseMeasuredParameters.IsSuccessStatusCode)
            {
                measuredParameters = await responseMeasuredParameters.Content.ReadAsAsync<List<MeasuredParameter>>();
            }

            ViewBag.GeoServerWorkspace = Startup.Configuration["GeoServerWorkspace"].ToString();
            ViewBag.GeoServerAddress = Startup.Configuration["GeoServerAddressServer"].ToString();
            if (!Convert.ToBoolean(Startup.Configuration["Server"]))
            {
                ViewBag.GeoServerAddress = Startup.Configuration["GeoServerAddressDebug"].ToString();
            }
            ViewBag.GeoServerPort = Startup.Configuration["GeoServerPort"].ToString();
            //ViewBag.MeasuredParameters = new SelectList(measuredParameters.Where(m => !string.IsNullOrEmpty(m.OceanusCode)).OrderBy(m => m.Name), "Id", "Name");
            ViewBag.MonitoringPostMeasuredParameters = new SelectList(measuredParameters.Where(m => !string.IsNullOrEmpty(m.OceanusCode)).OrderBy(m => m.Name), "Id", "Name");
            ViewBag.Pollutants = new SelectList(measuredParameters.Where(m => !string.IsNullOrEmpty(m.OceanusCode) && m.MPC != null).OrderBy(m => m.Name), "Id", "Name");
            ViewBag.DateFrom = (DateTime.Now).ToString("yyyy-MM-dd");
            ViewBag.TimeFrom = (DateTime.Today).ToString("HH:mm:ss");
            ViewBag.DateTo = (DateTime.Now).ToString("yyyy-MM-dd");
            ViewBag.TimeTo = new DateTime(2000, 1, 1, 23, 59, 00).ToString("HH:mm:ss");

            string decimaldelimiter = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            string urlMonitoringPosts = "api/MonitoringPosts";
            List<MonitoringPost> monitoringPosts = new List<MonitoringPost>();
            HttpResponseMessage responseMonitoringPosts = await _HttpApiClient.GetAsync(urlMonitoringPosts);
            monitoringPosts = await responseMonitoringPosts.Content.ReadAsAsync<List<MonitoringPost>>();

            List<MonitoringPost> kazHydrometAirMonitoringPosts = monitoringPosts
                .Where(m => m.DataProvider.Name == Startup.Configuration["KazhydrometName"].ToString())
                .ToList();
            JObject kazHydrometAirMonitoringPostsObject = JObject.FromObject(new
            {
                type = "FeatureCollection",
                crs = new
                {
                    type = "name",
                    properties = new
                    {
                        name = "urn:ogc:def:crs:EPSG::3857"
                    }
                },
                features = from monitoringPost in kazHydrometAirMonitoringPosts
                           select new
                           {
                               type = "Feature",
                               properties = new
                               {
                                   Id = monitoringPost.Id,
                                   Number = monitoringPost.Number,
                                   Name = monitoringPost.Name,
                                   AdditionalInformation = monitoringPost.AdditionalInformation,
                                   DataProviderName = monitoringPost.DataProvider.Name,
                                   PollutionEnvironmentName = monitoringPost.PollutionEnvironment.Name,
                               },
                               geometry = new
                               {
                                   type = "Point",
                                   coordinates = new List<decimal>
                                    {
                                        Convert.ToDecimal(monitoringPost.EastLongitude.ToString().Replace(".", decimaldelimiter)),
                                        Convert.ToDecimal(monitoringPost.NorthLatitude.ToString().Replace(".", decimaldelimiter))
                                    },
                               }
                           }
            });
            ViewBag.KazHydrometAirMonitoringPostsLayerJson = kazHydrometAirMonitoringPostsObject.ToString();

            List<MonitoringPost> ecoserviceAirMonitoringPosts = monitoringPosts
                .Where(m => m.NorthLatitude >= 46.00M && m.NorthLatitude <= 51.00M
                && m.DataProvider.Name == Startup.Configuration["EcoserviceName"].ToString())
                .ToList();
            JObject ecoserviceAirMonitoringPostsObject = JObject.FromObject(new
            {
                type = "FeatureCollection",
                crs = new
                {
                    type = "name",
                    properties = new
                    {
                        name = "urn:ogc:def:crs:EPSG::3857"
                    }
                },
                features = from monitoringPost in ecoserviceAirMonitoringPosts
                           select new
                           {
                               type = "Feature",
                               properties = new
                               {
                                   Id = monitoringPost.Id,
                                   Number = monitoringPost.Number,
                                   Name = monitoringPost.Name,
                                   AdditionalInformation = monitoringPost.AdditionalInformation,
                                   DataProviderName = monitoringPost.DataProvider.Name,
                                   PollutionEnvironmentName = monitoringPost.PollutionEnvironment.Name,
                               },
                               geometry = new
                               {
                                   type = "Point",
                                   coordinates = new List<decimal>
                                    {
                                        Convert.ToDecimal(monitoringPost.EastLongitude.ToString().Replace(".", decimaldelimiter)),
                                        Convert.ToDecimal(monitoringPost.NorthLatitude.ToString().Replace(".", decimaldelimiter))
                                    },
                               }
                           }
            });
            ViewBag.EcoserviceAirMonitoringPostsLayerJson = ecoserviceAirMonitoringPostsObject.ToString();
            ViewBag.EcoserviceAirMonitoringPosts = ecoserviceAirMonitoringPosts.ToArray();
            return View();
        }

        public async Task<IActionResult> Arys()
        {
            string role = HttpContext.Session.GetString("Role");
            if (!(role == "admin" || role == "moderator" || role == "Arys"))
            {
                return Redirect("/");
            }

            List<MeasuredParameter> measuredParameters = new List<MeasuredParameter>();
            string urlMeasuredParameters = "api/MeasuredParameters",
                routeMeasuredParameters = "";
            HttpResponseMessage responseMeasuredParameters = await _HttpApiClient.GetAsync(urlMeasuredParameters + routeMeasuredParameters);
            if (responseMeasuredParameters.IsSuccessStatusCode)
            {
                measuredParameters = await responseMeasuredParameters.Content.ReadAsAsync<List<MeasuredParameter>>();
            }

            ViewBag.MeasuredParameters = new SelectList(measuredParameters.Where(m => !string.IsNullOrEmpty(m.OceanusCode)).OrderBy(m => m.Name), "Id", "Name");
            ViewBag.DateFrom = (DateTime.Now).ToString("yyyy-MM-dd");
            ViewBag.TimeFrom = (DateTime.Today).ToString("HH:mm:ss");
            ViewBag.DateTo = (DateTime.Now).ToString("yyyy-MM-dd");
            ViewBag.TimeTo = new DateTime(2000, 1, 1, 23, 59, 59).ToString("HH:mm:ss");

            string decimaldelimiter = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            string urlMonitoringPosts = "api/MonitoringPosts";
            List<MonitoringPost> monitoringPosts = new List<MonitoringPost>();
            HttpResponseMessage responseMonitoringPosts = await _HttpApiClient.GetAsync(urlMonitoringPosts);
            monitoringPosts = await responseMonitoringPosts.Content.ReadAsAsync<List<MonitoringPost>>();

            List<MonitoringPost> ecoserviceAirMonitoringPosts = monitoringPosts
                .Where(m => m.NorthLatitude >= 42.32M && m.NorthLatitude <= 42.50M
                    && m.EastLongitude >= 68.6M && m.EastLongitude <= 69.0M)
                .Where(m => m.DataProvider.Name == Startup.Configuration["EcoserviceName"].ToString())
                .ToList();
            JObject ecoserviceAirMonitoringPostsObject = JObject.FromObject(new
            {
                type = "FeatureCollection",
                crs = new
                {
                    type = "name",
                    properties = new
                    {
                        name = "urn:ogc:def:crs:EPSG::3857"
                    }
                },
                features = from monitoringPost in ecoserviceAirMonitoringPosts
                           select new
                           {
                               type = "Feature",
                               properties = new
                               {
                                   Id = monitoringPost.Id,
                                   Number = monitoringPost.Number,
                                   Name = monitoringPost.Name,
                                   AdditionalInformation = monitoringPost.AdditionalInformation,
                                   DataProviderName = monitoringPost.DataProvider.Name,
                                   PollutionEnvironmentName = monitoringPost.PollutionEnvironment.Name,
                               },
                               geometry = new
                               {
                                   type = "Point",
                                   coordinates = new List<decimal>
                                    {
                                        Convert.ToDecimal(monitoringPost.EastLongitude.ToString().Replace(".", decimaldelimiter)),
                                        Convert.ToDecimal(monitoringPost.NorthLatitude.ToString().Replace(".", decimaldelimiter))
                                    },
                               }
                           }
            });
            ViewBag.EcoserviceAirMonitoringPostsLayerJson = ecoserviceAirMonitoringPostsObject.ToString();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CalculateDissipation(float temperature,
            float windSpeed,
            float startSpeed,
            float endSpeed,
            float stepSpeed,
            float windDirection,
            float startDirection,
            float endDirection,
            float stepDirection,
            float uSpeed,
            int pollutants,
            float width,
            float length)
        {
            int code = 0301;
            if (pollutants == 12)
            {
                code = 0301;
            }
            if (pollutants == 13)
            {
                code = 0304;
            }
            if (pollutants == 16)
            {
                code = 0330;
            }
            if (pollutants == 17)
            {
                code = 0337;
            }

            string temperatureString = Convert.ToString(temperature, CultureInfo.InvariantCulture);
            string windSpeedString = Convert.ToString(windSpeed, CultureInfo.InvariantCulture);
            string startSpeedString = Convert.ToString(startSpeed, CultureInfo.InvariantCulture);
            string endSpeedString = Convert.ToString(endSpeed, CultureInfo.InvariantCulture);
            string stepSpeedString = Convert.ToString(stepSpeed, CultureInfo.InvariantCulture);
            string windDirectionString = Convert.ToString(windDirection, CultureInfo.InvariantCulture);
            string startDirectionString = Convert.ToString(startDirection, CultureInfo.InvariantCulture);
            string endDirectionString = Convert.ToString(endDirection, CultureInfo.InvariantCulture);
            string stepDirectionString = Convert.ToString(stepDirection, CultureInfo.InvariantCulture);
            string uSpeedString = Convert.ToString(uSpeed, CultureInfo.InvariantCulture);
            string widthString = Convert.ToString(width, CultureInfo.InvariantCulture);
            string lengthString = Convert.ToString(length, CultureInfo.InvariantCulture);

            string urlMeasuredDatas = "api/MeasuredDatas";
            List<MeasuredData> measuredDatas = new List<MeasuredData>();
            HttpResponseMessage responseMeasuredDatas = await _HttpApiClient.GetAsync(urlMeasuredDatas);
            measuredDatas = await responseMeasuredDatas.Content.ReadAsAsync<List<MeasuredData>>();
            List<double> pollutantsValue = new List<double>();
            pollutantsValue.Add(Convert.ToDouble(measuredDatas.Where(p => p.PollutionSourceId == 3).LastOrDefault(p => p.MeasuredParameterId == pollutants).Value));
            pollutantsValue.Add(Convert.ToDouble(measuredDatas.Where(p => p.PollutionSourceId == 4).LastOrDefault(p => p.MeasuredParameterId == pollutants).Value));
            List<string> pollutantsValueString = new List<string>();
            foreach (double pollutantValue in pollutantsValue)
            {
                pollutantsValueString.Add(Convert.ToString(pollutantValue, CultureInfo.InvariantCulture));
            }

            //List<string> longitude = new List<string> { "76.89392209053041", "76.89093410968779" };
            //List<string> latitude = new List<string> { "43.25245478496336", "43.252024999269906" };
            //List<string> longitude = new List<string> { "77.00667", "76.89093410968779" };
            //List<string> latitude = new List<string> { "43.42417", "43.252024999269906" };

            //List<string> longitude = new List<string> { "8572102.20", "8572696.97" };
            //List<string> latitude = new List<string> { "5376224.66", "5376683.28" };
            List<string> longitude = new List<string> { "8572410", "8572371" };
            List<string> latitude = new List<string> { "5376722", "5376650" };

            List<string> height = new List<string> { "20", "4" };
            List<string> diameter = new List<string> { "0.5", "0.25" };
            List<string> flow_temperature = new List<string> { "24", "20" };
            List<string> flow_speed = new List<string> { "1", "8.5" };

            string content = "";
            string airPollutionSources = "air_pollution_sources\": [ ";

            for (int i = 0; i < pollutantsValueString.Count; i++)
            {
                airPollutionSources += "{ \"id\": " + i + ", \"is_organized\": true, \"methodical\": 1, \"background_relation\": 3, " +
                    "\"configuration\": { \"type\": 1, \"height\": " + height[i] + ", \"diameter\": " + diameter[i] + ", \"flow_temperature\": " + flow_temperature[i] + ", \"flow_speed\": " + flow_speed[i] + ", " +
                    "\"point_1\": { \"x\": " + longitude[i] + ", \"y\": " + latitude[i] + ", \"z\": 0 }, \"relief_coefficient\": 1 }, \"emissions\": [";
                airPollutionSources += "{ \"pollutant_code\": " + code + ", \"power\": " + pollutantsValueString[i] + ", \"coefficient\": 2 }";
                airPollutionSources += " ] }";
                if (i < pollutantsValueString.Count - 1)
                {
                    airPollutionSources += ", ";
                }
            }
            airPollutionSources += " ], ";

            content = "{ \"threshold_pdk\": 0, \"locality\": { \"square\": 682, \"relief_coefficient\": 1, \"stratification_coefficient\": 200 }, \"meteo\": " +
                "{ \"temperature\": " + temperatureString + ", \"wind_speed_settings\": { \"mode\": 1, \"speed\": " + windSpeedString + ", \"start_speed\": " + startSpeedString + ", \"end_speed\": " + endSpeedString + ", \"step_speed\": " + stepSpeedString + " }, " +
                "\"wind_direction_settings\": { \"mode\": 1, \"direction\": " + windDirectionString + ", \"start_direction\": " + startDirectionString + ", \"end_direction\": " + endDirectionString + ", \"step_direction\": " + stepDirectionString + " }, \"rose_of_wind\": { \"north\": 1.2, \"northeast\": 1.7, \"northwest\": 1.4, \"south\": 2.6, \"southeast\": 1.5, \"southwest\": 1.55, \"west\": 1.75, \"east\": 1.0 }, \"u_speed\": " + uSpeedString + " }" +
                ", \"background\": { \"mode\": 0 }, \"method\": 1, \"contributor_count\": " + pollutantsValueString.Count + ", \"use_summation_groups\": false, \"";
            content += airPollutionSources;
            //content += "\"calculated_area\": { \"rectangles\": [{ \"id\": 0, \"center_point\": { \"y\": 43.42417, \"x\": 77.00667, \"z\": 0 }, \"width\": 10, \"length\": 10, \"height\": 1, \"step_by_width\": 1, \"step_by_length\": 1 }], \"points\": [], \"lines\": [] }}";
            content += "\"calculated_area\": { \"rectangles\": [{ \"id\": 0, \"center_point\": { \"y\": 5376759.33, \"x\": 8572343.29, \"z\": 0 }, \"width\": " + widthString + ", \"length\": " + lengthString + ", \"height\": 1, \"step_by_width\": 100, \"step_by_length\": 100 }], \"points\": [], \"lines\": [] }}";

            bool server = Convert.ToBoolean(Startup.Configuration["Server"]);
            string URPZAUrl = server ? Startup.Configuration["URPZAUrlServer"] : Startup.Configuration["URPZAUrlDebug"];

            //string calculate = "-X POST \"http://185.125.44.116:50006/calculation/create\" -H \"accept: application/json\" -H \"Content-Type: application/json\" -d \"" + content + "\"";
            string calculate = "-X POST \"" + URPZAUrl + "calculation/create\" -H \"accept: application/json\" -H \"Content-Type: application/json\" -d \"" + content + "\"";
            Process process = CurlExecute(calculate);
            string answer = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            var jObject = JObject.Parse(answer);
            int id = (int)jObject["id"];

            //string statusQuery = "-X GET \"http://185.125.44.116:50006/calculation/status?id=" + id + "\" -H \"accept: application/json\"";
            string statusQuery = "-X GET \"" + URPZAUrl + "calculation/status?id=" + id + "\" -H \"accept: application/json\"";
            process = CurlExecute(statusQuery);
            answer = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            jObject = JObject.Parse(answer);
            string status = (string)jObject["status"];

            while (status != "ready")
            {
                process = CurlExecute(statusQuery);
                answer = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                jObject = JObject.Parse(answer);
                status = (string)jObject["status"];
            }
            //string resultEmissions = "-X GET \"http://185.125.44.116:50006/result-emissions?jobId=" + id + "&containerType=rectangle&containerId=0&pollutantCode=" + code + "\" -H \"accept: application/json\"";
            string resultEmissions = "-X GET \"" + URPZAUrl + "result-emissions?jobId=" + id + "&containerType=rectangle&containerId=0&pollutantCode=" + code + "\" -H \"accept: application/json\"";
            process = CurlExecute(resultEmissions);
            answer = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            return Json(new
            {
                answer
            });
        }

        private Process CurlExecute(string Arguments)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.FileName = Startup.Configuration["CurlFullPath"];
                process.StartInfo.Arguments = Arguments;
                process.Start();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString(), exception.InnerException);
            }
            return process;
        }

        [HttpPost]
        public async Task<IActionResult> GetTodayTimes20()
        {
            List<DateTime> times20l = new List<DateTime>();
            for (DateTime i = DateTime.Today; i <= DateTime.Now; i = i.AddMinutes(20))
            {
                times20l.Add(i);
            }
            DateTime[] times20 = times20l.ToArray();
            return Json(new
            {
                times20
            });
        }

        [HttpPost]
        public async Task<IActionResult> GetLayersCount(
            string LayerBaseName)
        {
            string GSUser = Startup.Configuration["GeoServerUser"].ToString(),
                GSPassword = Startup.Configuration["GeoServerPassword"].ToString(),
                GSAddress = Startup.Configuration["GeoServerAddressDebug"].ToString(),
                GSPort = Startup.Configuration["GeoServerPort"].ToString(),
                GSWorkspace = Startup.Configuration["GeoServerWorkspace"].ToString();
            //if (!Convert.ToBoolean(Startup.Configuration["Server"]))
            //{
            //    GSAddress = Startup.Configuration["GeoServerAddressDebug"].ToString();
            //}
            int count = 0;
            while (true)
            {
                string Layer = LayerBaseName + "_" + (count + 1).ToString();
                Process process = CurlExecute($" -u " +
                    $"{GSUser}:" +
                    $"{GSPassword}" +
                    $" -XGET" +
                    $" http://{GSAddress}:" +
                    $"{GSPort}/geoserver/rest/layers/{GSWorkspace}:{Layer}.json");
                string json = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                if (json.Contains("No such layer"))
                {
                    break;
                }
                else
                {
                    count++;
                }
            }
            return Json(new
            {
                count
            });
        }

        public async Task<IActionResult> GetMeasuredParameters(int MonitoringPostId)
        {
            List<MonitoringPostMeasuredParameters> monitoringPostMeasuredParameters = new List<MonitoringPostMeasuredParameters>();
            string urlMonitoringPostMeasuredParameters = "api/MonitoringPosts/getMonitoringPostMeasuredParametersForMap";
            string routeMonitoringPostMeasuredParameters = "";
            routeMonitoringPostMeasuredParameters += string.IsNullOrEmpty(routeMonitoringPostMeasuredParameters) ? "?" : "&";
            routeMonitoringPostMeasuredParameters += $"MonitoringPostId={MonitoringPostId.ToString()}";
            HttpResponseMessage responseMPMP = await _HttpApiClient.PostAsync(urlMonitoringPostMeasuredParameters + routeMonitoringPostMeasuredParameters, null);
            if (responseMPMP.IsSuccessStatusCode)
            {
                monitoringPostMeasuredParameters = await responseMPMP.Content.ReadAsAsync<List<MonitoringPostMeasuredParameters>>();
            }
            var result = monitoringPostMeasuredParameters.OrderBy(m => m.MeasuredParameter.Name);

            return Json(
                result
            );
        }
    }
}