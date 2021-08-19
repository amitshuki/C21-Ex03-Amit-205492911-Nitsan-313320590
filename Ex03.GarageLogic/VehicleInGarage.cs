using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eVehicleType
    {
        Motorcycle=1, ElectricMotorcycle=2, Car=3, ElectricCar=4, Truck=5
    }
    public enum eCarStatus
    {
        InRepair=1, Repaired=2, Paid=3
    }
    internal class VehicleInGarage
    {
      


        private string m_OwnerName;
        private string m_OwnerPhone;
        private eCarStatus m_CarStatus = eCarStatus.InRepair;
        public eVehicleType m_VehicleType;
        public Vehicle m_Vehicle=null;

        public VehicleInGarage(string i_OwnerName, string i_OwnerPhone, eVehicleType i_VehicleType)
        {
            OwnerName = i_OwnerName;
            OwnerPhone = i_OwnerPhone;
            m_VehicleType = i_VehicleType;

        }
      

        public string OwnerName
        {
            get => m_OwnerName;
            set => m_OwnerName = value;
        }
        public string OwnerPhone
        {
            get => m_OwnerPhone;
            set => m_OwnerPhone = value;
        }
        public eCarStatus CarStatus
        {
            get => m_CarStatus;
            set => m_CarStatus = value;
        }
        public Vehicle Vehicle
        {
            get => m_Vehicle;
            set => m_Vehicle = value;
        }
    }
}
