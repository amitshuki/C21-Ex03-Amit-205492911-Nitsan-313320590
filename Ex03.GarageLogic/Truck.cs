using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
   internal class Truck:Vehicle
    {
        
        private bool m_IsCarryDangerousMaterials;
        private float m_MaxCarryLimit;

        internal Truck(string i_LicenseNumber,bool i_IsCarryDangerousMaterials, float i_MaxCarryLimit, float i_AirPressure, string i_WheelManufacturer) : base(i_LicenseNumber,16, 26, eFuelType.Soler, 120, i_AirPressure,i_WheelManufacturer)
        {
            MaxCarryLimit = i_MaxCarryLimit;
            m_IsCarryDangerousMaterials = i_IsCarryDangerousMaterials;
        }
        public float MaxCarryLimit
        {

            get => m_MaxCarryLimit;
            set => m_MaxCarryLimit = value;
        }
        public bool IsCarryDangerousMaterials
        {
            get => m_IsCarryDangerousMaterials;
            set => m_IsCarryDangerousMaterials = value;
        }
        internal override string GetDetailsToString()
        {
            string canOrcant = m_IsCarryDangerousMaterials ? "can" : "can't";
            string enginenName;
            if (m_Engine is FuelEngine)
            {
                enginenName = "Fuel Engine ";
            }
            else
            {
                enginenName = "Electric Engine";
            }
            string msg = ($"{Name} {LicenseNumber} , {PercentageOfEnergyLeft} energy left,{this.GetWheelCount()} Wheels with {this.GetWheelAirPressure()} air pressure \n{enginenName} ")
                +($"\n This Truck Can carry up to {m_MaxCarryLimit} And {canOrcant} Carry Dangerous Materials");
            return msg;
        }
    }
    
}
