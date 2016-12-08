using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarProject.DBSEF
{
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
}