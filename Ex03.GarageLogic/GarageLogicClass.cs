using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageLogicClass
    {
        private List<VehicleInGarage> m_CarInGarages = new List<VehicleInGarage>();
        private VehicleInGarage m_CurrentVehicleInGarage = null;
        public void AddToGarage(string i_Name, string i_Phone, eVehicleType i_VehicleType)
        {
            m_CurrentVehicleInGarage = new VehicleInGarage(i_Name, i_Phone, i_VehicleType);
            m_CarInGarages.Add(m_CurrentVehicleInGarage);
        }

        public void AddFuelCar(string i_LicenseNumber, eCarColor i_CarColor, eCarDoorAmount i_CarDoor, float i_CurrentAirPressure, string i_WheelManufacturer, float i_CurrentFuel)
        {
            m_CurrentVehicleInGarage.m_Vehicle = new Car(i_LicenseNumber, i_CarColor, i_CarDoor, i_CurrentAirPressure, i_WheelManufacturer);
            m_CurrentVehicleInGarage.m_Vehicle.Name = m_CurrentVehicleInGarage.OwnerName;
            m_CurrentVehicleInGarage.m_Vehicle.m_PercentageOfEnergyLeft = i_CurrentFuel;

        }
        public void AddElectricCar(string i_LicenseNumber, eCarColor i_CarColor, eCarDoorAmount i_CarDoor, float i_CurrentAirPressure, string i_WheelManufacturer, float i_CurrentTimeLeft)
        {
            m_CurrentVehicleInGarage.m_Vehicle = new Car(i_LicenseNumber, eEngineType.Electric, i_CarColor, i_CarDoor, i_CurrentAirPressure, i_WheelManufacturer);
            m_CurrentVehicleInGarage.m_Vehicle.Name = m_CurrentVehicleInGarage.OwnerName;
            m_CurrentVehicleInGarage.m_Vehicle.m_PercentageOfEnergyLeft = i_CurrentTimeLeft;
        }
        public void AddFuelMotor(string i_LicenseNumber, eDriverType i_DriverType, int i_EngineVolume, float i_AirPressure, string i_WheelManufacturer, float i_CurrentFuel)
        {
            m_CurrentVehicleInGarage.m_Vehicle = new MotorCycle(i_LicenseNumber, i_DriverType, i_EngineVolume, i_AirPressure, i_WheelManufacturer);
            m_CurrentVehicleInGarage.m_Vehicle.Name = m_CurrentVehicleInGarage.OwnerName;
            m_CurrentVehicleInGarage.m_Vehicle.m_PercentageOfEnergyLeft = i_CurrentFuel;


        }
        public void AddElectricMotor(string i_LicenseNumber, eDriverType i_DriverType, int i_EngineVolume, float i_AirPressure, string i_WheelManufacturer, float i_CurrentTimeLeft)
        {
            m_CurrentVehicleInGarage.m_Vehicle = new MotorCycle(i_LicenseNumber, eEngineType.Electric, i_DriverType, i_EngineVolume, i_AirPressure, i_WheelManufacturer);
            m_CurrentVehicleInGarage.m_Vehicle.Name = m_CurrentVehicleInGarage.OwnerName;
            m_CurrentVehicleInGarage.m_Vehicle.m_PercentageOfEnergyLeft = i_CurrentTimeLeft;
        }

        public void AddTruck(string i_LicenseNumber, bool i_IsCarryDangerousMaterials, float i_MaxCarryLimit, float i_AirPressure, string i_WheelManufacturer, float i_CurrentFuel)
        {
            m_CurrentVehicleInGarage.m_Vehicle = new Truck(i_LicenseNumber, i_IsCarryDangerousMaterials, i_MaxCarryLimit, i_AirPressure, i_WheelManufacturer);
            m_CurrentVehicleInGarage.m_Vehicle.Name = m_CurrentVehicleInGarage.OwnerName;
            m_CurrentVehicleInGarage.m_Vehicle.m_PercentageOfEnergyLeft = i_CurrentFuel;
        }

        public bool IsVehicleExist(String i_CarNumber)
        {

            return m_CarInGarages.Exists((i => i.Vehicle.LicenseNumber == i_CarNumber));
        }

        public void UpdateWheelPressures(float i_PressuresUpdate)
        {
            foreach (Wheel wheel in m_CurrentVehicleInGarage.Vehicle.m_ListOfWheels)
            {
                wheel.WheelInflation(i_PressuresUpdate);
            }
        }

        public void UpdateWheelPressuresToMax()
        {
            foreach (Wheel wheel in m_CurrentVehicleInGarage.Vehicle.m_ListOfWheels)
            {
                wheel.WheelInflation(wheel.MaxAirPressure - wheel.AirPressure);
            }
        }

        public void FuelCar(string i_CarNumber, eFuelType i_FuelType, float i_AmountToFuel)
        {
            if (IsVehicleExist(i_CarNumber))
            {
                m_CurrentVehicleInGarage =
                    m_CarInGarages.Find(vehicle => vehicle.Vehicle.LicenseNumber == (i_CarNumber));
                if (m_CurrentVehicleInGarage.Vehicle.m_Engine is FuelEngine)
                {
                    m_CurrentVehicleInGarage.Vehicle.m_Engine.FuelTheEngine(i_FuelType, i_AmountToFuel);
                }

            }

        }

        public void ChargeCar(string i_CarNumber, float i_AmountToCharge)
        {
            if (IsVehicleExist(i_CarNumber))
            {
                m_CurrentVehicleInGarage =
                    m_CarInGarages.Find(vehicle => vehicle.Vehicle.LicenseNumber == (i_CarNumber));
                if (m_CurrentVehicleInGarage.Vehicle.m_Engine is ElectricEngine)
                {
                    m_CurrentVehicleInGarage.Vehicle.m_Engine.ChargeBattery(i_AmountToCharge / 60);
                }

            }

        }

        public void ChangeStatus(string i_CarNumber, eCarStatus i_CarStatus)
        {
            if (IsVehicleExist(i_CarNumber))
            {
                m_CurrentVehicleInGarage =
                    m_CarInGarages.Find(vehicle => vehicle.Vehicle.LicenseNumber == (i_CarNumber));
                m_CurrentVehicleInGarage.CarStatus = i_CarStatus;
            }

        }

        public List<string> CreateListByStatus(eCarStatus i_CarStatus)
        {
            List<string> res = new List<string>();
            foreach (VehicleInGarage veCarInGarage in m_CarInGarages)
            {
                if (veCarInGarage.CarStatus == i_CarStatus)
                {

                    res.Add(($"{veCarInGarage.Vehicle.LicenseNumber}"));
                }
            }

            return res;
        }

        public string GetAllDetails(string i_CarNumber)
        {
            string msg = string.Empty;
            if (IsVehicleExist(i_CarNumber))
            {
                m_CurrentVehicleInGarage =
                    m_CarInGarages.Find(vehicle => vehicle.Vehicle.LicenseNumber == (i_CarNumber));
                msg = m_CurrentVehicleInGarage.m_Vehicle.GetDetailsToString();
            }

            return msg;
        }
    }
}
