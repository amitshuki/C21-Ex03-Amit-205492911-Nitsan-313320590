using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricEngine : Engine
    {
        private float m_BatteryTimeLeft;
        private float m_MaxBatteryTime;

        internal ElectricEngine(float i_MaxBatteryTime)
        {
            MaxBatteryTime = i_MaxBatteryTime;
        }
        public float BatteryTimeLeft
        {
            get => m_BatteryTimeLeft;
            set => m_BatteryTimeLeft = value;
        }
        public float MaxBatteryTime
        {
            get => m_MaxBatteryTime;
            set => m_MaxBatteryTime = value;
        }

        internal override void ChargeBattery(float i_HoursToAdd)
        {
          
            if(i_HoursToAdd + m_BatteryTimeLeft <= m_MaxBatteryTime)
            {
                m_BatteryTimeLeft += i_HoursToAdd;
               
            }
            else
            {
                throw new ValueOutOfRangeException(m_MaxBatteryTime,0);
            }

            
        }
    }
}
