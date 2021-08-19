using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eDriverType
    {
        A=1,
        B1=2,
        AA=3,
        BB=4
    }
    class MotorCycle : Vehicle
    {
        
     

        private eDriverType m_DriverType;
        private int m_EngineVolume;
        
        public eDriverType DriverType
        {
            get => m_DriverType;
            set => m_DriverType = value;
        }
        public int EngineVolume
        {
            get => m_EngineVolume;
            set => m_EngineVolume = value;
        }


        internal MotorCycle(string i_LicenseNumber,eDriverType i_DriverType, int i_EngineVolume, float i_AirPressure, string i_WheelManufacturer)
            : base(i_LicenseNumber,2, 30, eFuelType.Octan98, 6, i_AirPressure,i_WheelManufacturer)
        {
            m_EngineVolume = i_EngineVolume;
            DriverType = i_DriverType;
           

        }

        internal MotorCycle(string i_LicenseNumber,eEngineType i_MotorType, eDriverType i_DriverType, int i_EngineVolume, float i_AirPressure, string i_WheelManufacturer)
            : base(i_LicenseNumber,2, 30, 1.8f, i_AirPressure,  i_WheelManufacturer)
        {
            m_EngineVolume = i_EngineVolume;
            DriverType = i_DriverType;
        }
        internal override string GetDetailsToString()
        {
            string enginenName;
            if(m_Engine is FuelEngine)
            {
                enginenName = "Fuel Engine ";
            }
            else
            {
                enginenName = "Electric Engine";
            }
            string msg = ($"{Name} {LicenseNumber} , {PercentageOfEnergyLeft} energy left,{this.GetWheelCount()} Wheels with {this.GetWheelAirPressure()} air pressure \n {enginenName} ")
                         + $"\nThis motorcycle Driver is {m_DriverType},The Engine size is {m_EngineVolume}";
            return msg;
        }

    }
}
