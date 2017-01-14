using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace CarProject.DBSEF
{
    public class SingletoonDBS
    {
        private static CarAutomationEntities DBS { get; set; }
        public static CarAutomationEntities GetInstance
        {
            get
            {
                if (DBS == null)
                    DBS = new CarAutomationEntities();

                return DBS;
            }
        }
    }
    public partial class User
    {
        public enum Enum_ActiveORecoveryEnum { Activation = 0, Recovery = 1 };
    }

    public partial class FuelConsumption
    {
        public bool IsNull
        {
            get
            {
                return LphCity == null &&
                    LphRoad == null &&
                    LphMix == null &&
                    Details == null &&
                    ReservedOne == null &&
                    ReservedTwo == null &&
                    ReservedThree == null;
            }
        }
    }

    public partial class Car
    {
        public string[] CarImages
        {
            get
            {
                List<string> res = new List<string>();

                var Server = HttpContext.Current.Server;

                var PicFileUrl = "~/Publics/Gallery/CarImages/" + this.CarsId;
                var finfo = new System.IO.DirectoryInfo(Server.MapPath(PicFileUrl));

                if (finfo.Exists)
                {
                    foreach (var item in finfo.GetFiles())
                    {
                        res.Add(PicFileUrl + "/" + item.Name);
                    }
                }

                return res.ToArray();
            }
        }
    }

    public partial class CarEngine
    {
        public bool IsNull
        {
            get
            {
                return EngineType == null &&
                    EngineCylinderNumber == null &&
                    EnginePowerHpLitr == null &&
                    EnginePowerHpRpm == null &&
                    EnginePowerHpTon == null &&
                    EngineTorque == null &&
                    EngineMaxSpeed == null &&
                    EngineZeroToH == null &&
                    EngineDescription == null &&
                    EngineSize == null &&
                    EngineFuel == null;
            }
        }
    }

    public partial class CarGearBox
    {
        public bool IsNull
        {
            get
            {
                return GearBoxCode == null &&
                    GearBoxType == null &&
                    GearBoxCanBeManual == null &&
                    GearBoxShiftNumber == null &&
                    GearBoxAxel == null &&
                    HasTransferCase == null &&
                    GearBoxDiffrentionalLock == null &&
                    GearBoxWdType == null &&
                    GearBoxDescription == null;
            }
        }
    }

    public partial class BrakeSystem
    {
        public bool IsNull
        {
            get
            {
                return FrontBrakeSystem == null &&
                    RearBrakeSystem == null &&
                    OtherSystem == null &&
                    HandBrakeSystem == null &&
                    Details == null;
                    
            }
        }
    }

    public partial class SecuritySystem
    {
        public bool IsNull
        {
            get
            {
                return this.RemoteControl == null &&
                    BurglarAlarm == null &&
                    Alarm == null &&
                    Emo == null &&
                    KeylessDoor == null &&
                    KeylessStart == null &&
                    Details == null;
            }
        }
    }

    public partial class SteeringSystem
    {
        public bool IsNull
        {
            get
            {
                return SteeringSystemType == null &&
                    SteeringType == null &&
                    SteeringHeightAdjustble == null &&
                    SteeringControlKey == null &&
                    Details == null;
            }
        }
    }

    public partial class AirConditioningSystem
    {
        public bool IsNull
        {
            get
            {
                return AirConditioningType == null && 
                    Details == null;
            }
        }
    }

    public partial class CarAudioSystem
    {
        public bool IsNull
        {
            get
            {
                return AudioSystemType == null &&
                    AudioSystemBrand == null &&
                    HasMonitor == null &&
                    RearSeatsMonitor == null &&
                    RearGearCamera == null &&
                    FrontCamera == null &&
                    RearStereo == null &&
                    FrontStereo == null &&
                    Subwoofer == null &&
                    Amplifire == null &&
                    HasGps == null &&
                    Details == null;
            }
        }
    }

    public partial class CarSeatOption
    {
        public bool IsNull
        {
            get
            {
                return LongitudinalDisplacement == null &&
                    BezelSet == null &&
                    SeatWarmer == null &&
                    SeatMassage == null &&
                    HasMemory == null &&
                    Details == null;
            }
        }
    }

    public partial class GlassAndMirror
    {
        public bool IsNull {
            get
            {
                return FrontWindscreens == null &&
                    RearWindscreens == null &&
                    SunRoof == null &&
                    PanaromaRoof == null &&
                    RearGlassWarmer == null &&
                    WindscreensWarmer == null &&
                    FrontGlassWarmer == null &&
                    SideMirrorSet == null &&
                    SideMirrorSystem == null &&
                    Details == null;
            }
        }
    }

    public partial class CarLightingSystem
    {
        public bool IsNull
        {
            get
            {
                return FrontLights == null &&
                    RearLights == null &&
                    DayLight == null &&
                    SideMirrorLight == null &&
                    FonrAntiFog == null &&
                    RearAntiFog == null &&
                    ReadingLamp == null &&
                    ThirdLightStop == null &&
                    Deailts == null;
            }
        }
    }

    public partial class CarSensorsSystem
    {
        public bool IsNull
        {
            get
            {
                return DayLightSensor == null &&
                    RainSensor == null &&
                    RearGearSensor == null &&
                    ParkSensor == null &&
                    NavigateSensor == null &&
                    CruiseControl == null &&
                    RearGearCamera == null &&
                    Details == null;
            }
        }
    }

    public partial class CarAirbag
    {
        public bool IsNull
        {
            get
            {
                return DriverAirBag == null &&
                    FrontAirBag == null &&
                    AirBag == null &&
                    AirBagEntity == null &&
                    Details == null;
            }
        }
    }

    public partial class CarWheel
    {
        public bool IsNull
        {
            get
            {
                return TireType == null &&
                    RingStandardSize == null &&
                    TireSpec == null &&
                    RingType == null &&
                    RingModel == null &&
                    (AutoInflated == null || AutoInflated == false) &&
                    Details == null;
            }
        }
    }

    public partial class CarsReview
    {
        public bool IsNull
        {
            get
            {
                return Review == null &&
                    CarScore == null &&
                    Beauty == null &&
                    WorthBuying == null &&
                    Quality == null &&
                    Services == null;
            }
        }
    }


    public partial class BasketItem
    {
        private DBSEF.CarAutomationEntities dbs = new CarAutomationEntities();
        private Models.Store.CartUsefull ctus = new Models.Store.CartUsefull();

        public bool Existance
        {
            get
            {
                bool res = false;
                switch ((Models.Store.CartUsefull.Basket_ItemType)this.Type)
                {
                    case CarProject.Models.Store.CartUsefull.Basket_ItemType.Product:
                        {
                            var xcnt = dbs.ProductStores.FirstOrDefault(c => c.ProductId == this.Id);
                            res = (xcnt != null) && (xcnt.ProductEntity >= this.Count);
                        }
                        break;
                    case CarProject.Models.Store.CartUsefull.Basket_ItemType.AutoService:
                        res = true;
                        break;
                    case CarProject.Models.Store.CartUsefull.Basket_ItemType.AutoServicePack:
                        res = true;
                        break;
                    default:
                        break;
                }
                return res;
            }
        }
    }

    public partial class AutoService
    {
        public string[] AutoServiceImages
        {
            get
            {
                List<string> res = new List<string>();
                var Server = HttpContext.Current.Server;
                var PicFileUrl = "~/Publics/Gallery/Services/" + this.AutoServiceId;
                var finfo = new System.IO.DirectoryInfo(Server.MapPath(PicFileUrl));

                if (finfo.Exists)
                {
                    foreach (var item in finfo.GetFiles())
                    {
                        res.Add(PicFileUrl + "/" + item.Name);
                    }
                }

                return res.ToArray();
            }
        }
    }

    public partial class Product
    {
        public string[] ProductImages
        {
            get
            {
                List<string> res = new List<string>();

                var Server = HttpContext.Current.Server;

                var PicFileUrl = "~/Publics/Gallery/ProductImages/" + this.ProductId;
                var finfo = new System.IO.DirectoryInfo(Server.MapPath(PicFileUrl));

                if (finfo.Exists)
                {
                    foreach (var item in finfo.GetFiles())
                    {
                        res.Add(PicFileUrl + "/" + item.Name);
                    }
                }

                return res.ToArray();
            }
        }

        public int CountOfViews
        {
            get
            {
                var x = this.ProductToViews.FirstOrDefault(pv => pv.ProductId == this.ProductId);
                if (x == null)
                    return 0;
                else
                    return x.Viewd.GetValueOrDefault(0);
            }
        }

        public int CountOfFavorite
        {
            get
            {
                var x = this.ProductToViews.FirstOrDefault(pv => pv.ProductId == this.ProductId);
                if (x == null)
                    return 0;
                else
                    return x.Favorite.GetValueOrDefault(0);
            }
        }
    }

    public partial class Content
    {
        public string[] ContentImages
        {
            get
            {
                List<string> res = new List<string>();

                var Server = HttpContext.Current.Server;

                var PicFileUrl = "~/Publics/Gallery/NewsImages/" + this.ContenstId;
                var finfo = new System.IO.DirectoryInfo(Server.MapPath(PicFileUrl));

                if (finfo.Exists)
                {
                    foreach (var item in finfo.GetFiles())
                    {
                        res.Add(PicFileUrl + "/" + item.Name);
                    }
                }

                return res.ToArray();
            }
        }
    }


    public partial class PersonServicesUseRequest
    {
        [Flags]
        public enum StateFlags : byte
        {
            UserSendRequest = 0,
            SendToAgent = 1,
            Completed = 2
        }
    }
}