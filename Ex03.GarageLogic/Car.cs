using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eCarColor
    {
        Red=1, Silver=2, White=3, Black=5
    }

    public enum eCarDoorAmount
    {
        Two = 2, Three = 3, Four = 4, Five = 5
    }

    internal class Car : Vehicle
    {
        

       
        private eCarColor m_CarColor;
        private eCarDoorAmount m_CarDoorAmount;

        private eEngineType m_CarType;
        public eCarColor CarColor
        {
            get => m_CarColor;
            set => m_CarColor = value;
        }
        public eCarDoorAmount CarDoorAmount
        {
            get => m_CarDoorAmount;
            set => m_CarDoorAmount = value;
        }

        internal Car(string i_LicenseNumber,eCarColor i_CarColor, eCarDoorAmount i_CarDoor, float i_AirPressure, string i_WheelManufacturer)
            : base(i_LicenseNumber,4, 32, eFuelType.Octan95, 45, i_AirPressure, i_WheelManufacturer)
        {
            m_CarType = eEngineType.Fuel;
            m_CarColor = i_CarColor;
            m_CarDoorAmount = i_CarDoor;
        }
        internal Car(string i_LicenseNumber,eEngineType i_CarType, eCarColor i_CarColor, eCarDoorAmount i_CarDoor, float i_AirPressure, string i_WheelManufacturer)
            : base(i_LicenseNumber,4, 32, 3.2f, i_AirPressure, i_WheelManufacturer)
        {
            m_CarType = eEngineType.Electric;
            m_CarColor = i_CarColor;
            m_CarDoorAmount = i_CarDoor;
        }
        internal override string GetDetailsToString()
        {
            string enginenName;
            if (m_Engine is FuelEngine)
            {
                enginenName = "Fuel Engine ";
            }
            else
            {
                enginenName = "Electric Engine";
            }
            string msg = ($"{Name} {LicenseNumber} , {PercentageOfEnergyLeft} energy left,{this.GetWheelCount()} Wheels with {this.GetWheelAirPressure()} air pressure \n{enginenName} ")+($"\n This car work On {m_CarType}, is color is {m_CarColor} and have {m_CarDoorAmount} doors\n ");
            return msg;
        }

    }
}

