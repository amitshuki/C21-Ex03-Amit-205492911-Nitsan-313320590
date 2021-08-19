using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Vehicle
    {
        internal string m_Name;
        internal string m_LicenseNumber;
        internal float m_PercentageOfEnergyLeft;
        internal List<Wheel> m_ListOfWheels;
        internal Engine m_Engine;
        

        public int GetWheelCount()
        {
            return m_ListOfWheels.Count;
        }

        public float GetWheelAirPressure()
        {
            return m_ListOfWheels[0].AirPressure;
        }
        public string Name
        {
            get => m_Name;
            set => m_Name = value;
        }
        public string LicenseNumber
        {
            get => m_LicenseNumber;
            set => m_LicenseNumber = value;
        }
        public float PercentageOfEnergyLeft
        {
            get => m_PercentageOfEnergyLeft;
            set => m_PercentageOfEnergyLeft = value;
        }
        public Engine Engine
        {
            get => m_Engine;
            set => m_Engine = value;
        }


        internal Vehicle(string i_LicenseNumber,int i_NumOfWheels, float i_MaxAirPressure, eFuelType i_FuelType, float i_MaxFuel, float i_AirPressure,string i_WheelManufacturer)
        {
            LicenseNumber = i_LicenseNumber;
            m_ListOfWheels = new List<Wheel>();
            for(int i = 0; i < i_NumOfWheels; i++)
            {
                m_ListOfWheels.Add(new Wheel(i_WheelManufacturer,i_AirPressure,i_MaxAirPressure));
            }

           
            m_Engine = new FuelEngine(i_FuelType,i_MaxFuel);
            
        }

        internal Vehicle(string i_LicenseNumber,int i_NumOfWheels, float i_MaxAirPressure, float i_MaxBatteryTime ,float i_AirPressure, string i_WheelManufacturer)
        {
            LicenseNumber = i_LicenseNumber;
            m_ListOfWheels = new List<Wheel>(i_NumOfWheels);
            foreach (Wheel wheel in m_ListOfWheels)
            {
                wheel.AirPressure = i_AirPressure;
                wheel.MaxAirPressure = i_MaxAirPressure;
                wheel.Manufacturer = i_WheelManufacturer;
            }

            m_Engine = new ElectricEngine(i_MaxBatteryTime);
        }

        internal virtual string GetDetailsToString()
        {
            string msg =
                ($"{m_Name} {m_LicenseNumber} , {m_PercentageOfEnergyLeft} energy left,{m_ListOfWheels.Count} Wheels with {m_ListOfWheels[1].AirPressure}\n {m_Engine} ");
            return msg;
        }
    }
   
}
