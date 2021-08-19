using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        private string m_Manufacturer;
        private float m_AirPressure;
        private float m_MaxAirPressure;


        internal bool WheelInflation(float i_AirToInsert)
        {
            bool res = false;
            if(i_AirToInsert + m_AirPressure  <= m_MaxAirPressure)
            {
                m_AirPressure = +i_AirToInsert;
                res = true;
            }

            return res;
        }

       internal Wheel(string i_Manufacturer, float i_AirPressure, float i_MaxAirPressure)
        {
            m_AirPressure = i_AirPressure;
            m_Manufacturer = i_Manufacturer;
            m_MaxAirPressure = i_MaxAirPressure;
        }
      
        public float AirPressure
        {
            get => m_AirPressure;
            set => m_AirPressure = value;
        }
        public float MaxAirPressure
        {
            get => m_MaxAirPressure;
            set => m_MaxAirPressure = value;
        }
        public string Manufacturer
        {
            get => m_Manufacturer;
            set => m_Manufacturer = value;
        }
    }
}
