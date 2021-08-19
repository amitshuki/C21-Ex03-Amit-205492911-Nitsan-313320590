using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class IoMenu
    {
        public Ex03.GarageLogic.GarageLogicClass m_LogicMember = new GarageLogicClass();
        public void AddVehicleMenu()
        {
            string vehicleNumber;

            Console.WriteLine("Please enter the vehicle's license number");
            vehicleNumber = Console.ReadLine();
            if (!m_LogicMember.IsVehicleExist(vehicleNumber))
            {
                string customerName, customerPhone, wheelManufacturer;
                float currentAirPressure;
                eVehicleType vehicleType;

                printNewVehicleMenu();
                customerName = getCustomerName();
                System.Console.Clear();
                printNewVehicleMenu();

                customerPhone = getCustomerPhone();
                System.Console.Clear();
                printNewVehicleMenu();

                vehicleType = getVehicleType();
                System.Console.Clear();
                printNewVehicleMenu();
                m_LogicMember.AddToGarage(customerName, customerPhone, vehicleType);

                wheelManufacturer = getWheelManufacturer();
                System.Console.Clear();
                printNewVehicleMenu();

                currentAirPressure = getCurrentAirPressure();
                System.Console.Clear();

                otherDetailsByVehicleType(vehicleNumber, vehicleType, currentAirPressure, wheelManufacturer);
            }
        }

        private void otherDetailsByVehicleType(string i_LicenseNumber, eVehicleType i_VehicleType, float i_CurrentAirPressure, string i_WheelManufacturer)
        {
            if (i_VehicleType == eVehicleType.Motorcycle)
            {
                motorcycleMenu(i_LicenseNumber, i_CurrentAirPressure, i_WheelManufacturer);
            }
            else if (i_VehicleType == eVehicleType.ElectricMotorcycle)
            {
                electricMotorcycleMenu(i_LicenseNumber, i_CurrentAirPressure, i_WheelManufacturer);
            }
            else if (i_VehicleType == eVehicleType.Car)
            {
                carMenu(i_LicenseNumber, i_CurrentAirPressure, i_WheelManufacturer);
            }
            else if (i_VehicleType == eVehicleType.ElectricCar)
            {
                electricCarMenu(i_LicenseNumber, i_CurrentAirPressure, i_WheelManufacturer);
            }
            else if (i_VehicleType == eVehicleType.Truck)
            {
                truckMenu(i_LicenseNumber, i_CurrentAirPressure, i_WheelManufacturer);
            }


        }

        private void truckMenu(string i_LicenseNumber, float i_CurrentAirPressure, string i_WheelManufacturer)
        {
            bool driveDangerousMaterials = false;
            float MaxCarryingWeightStr = 0;

            driveDangerousMaterials = isDrivingDangerousMaterials();
            MaxCarryingWeightStr = getMaxCarryWeight();

            m_LogicMember.AddTruck(i_LicenseNumber, driveDangerousMaterials, MaxCarryingWeightStr, i_CurrentAirPressure, i_WheelManufacturer);
        }

        private bool isDrivingDangerousMaterials()
        {
            bool drivingDangerousMaterials = false;
            Console.WriteLine("Is driving dangerous materials? (Yes/ No) ");
            string dangerousMaterials = Console.ReadLine();
            try
            {
                drivingDangerousMaterials = isValidBool(dangerousMaterials);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter Yes or Not only");
                isDrivingDangerousMaterials();
            }

            return drivingDangerousMaterials;
        }

        private bool isValidBool(string i_DangerousMaterials)
        {
            bool dangerous = false;
            if (string.Equals(i_DangerousMaterials, "Yes") || string.Equals(i_DangerousMaterials, "yes"))
            {
                dangerous = true;
            }
            else if (!string.Equals(i_DangerousMaterials, "No") && !string.Equals(i_DangerousMaterials, "no"))
            {
                throw new FormatException();
            }

            return dangerous;
        }

        private float getMaxCarryWeight()
        {
            string maxCarryingWeightStr;
            float maxCarryingWeight = 0;

            Console.WriteLine("Enter the maximum carrying weight");
            maxCarryingWeightStr = Console.ReadLine();
            try
            {
                maxCarryingWeight = float.Parse(maxCarryingWeightStr);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter digits only");
                getMaxCarryWeight();
            }

            return maxCarryingWeight;
        }

        private void electricCarMenu(string i_LicenseNumber, float i_CurrentAirPressure, string i_WheelManufacturer)
        {
            eCarDoorAmount doorsNumber;
            eCarColor color;
            color = getCarColor();
            doorsNumber = getDoorsNumber();

            m_LogicMember.AddElectricCar(i_LicenseNumber, color, doorsNumber, i_CurrentAirPressure, i_WheelManufacturer);
        }

        private eCarDoorAmount getDoorsNumber()
        {
            string doorsNumberStr = string.Empty;
            int doorsNumber = 0;

            Console.WriteLine("Enter the door number (2, 3, 4, 5) : ");
            doorsNumberStr = Console.ReadLine();

            try
            {
                doorsNumber = int.Parse(doorsNumberStr);
                isDoorsNumberInRange(doorsNumber);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please choose from the list");
                getDoorsNumber();
            }

            return (eCarDoorAmount)doorsNumber;
        }

        private void isDoorsNumberInRange(int i_DoorsNumber)
        {
            if (i_DoorsNumber < 2 || i_DoorsNumber > 5)
            {
                throw new FormatException();
            }
        }

        private eCarColor getCarColor()
        {
            string color;
            int colorToCompare = 0;

            Console.WriteLine("Enter the color of the car : ");
            Console.WriteLine("1 - Red");
            Console.WriteLine("2 - Silver");
            Console.WriteLine("3 - White");
            Console.WriteLine("4 - Black");
            color = Console.ReadLine();

            try
            {
                colorToCompare = int.Parse(color);
                isColorInRange(colorToCompare);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please choose from the list");
                getCarColor();
            }

            return (eCarColor)colorToCompare;
        }

        private void isColorInRange(int i_Color)
        {
            if (i_Color < 1 || i_Color > 4)
            {
                throw new FormatException();
            }
        }

        private void carMenu(string i_LicenseNumber, float i_CurrentAirPressure, string i_WheelManufacturer)
        {
            eCarDoorAmount doorsNumber;
            eCarColor color;
            color = getCarColor();
            doorsNumber = getDoorsNumber();

            m_LogicMember.AddFuelCar(i_LicenseNumber, color, doorsNumber, i_CurrentAirPressure, i_WheelManufacturer);
        }

        private void electricMotorcycleMenu(string i_LicenseNumber, float i_CurrentAirPressure, string i_WheelManufacturer)
        {
            eDriverType licenseType;
            int engineVolume;

            licenseType = getLicenseType();
            engineVolume = getEngineVolume();

            m_LogicMember.AddElectricMotor(i_LicenseNumber, licenseType, engineVolume, i_CurrentAirPressure, i_WheelManufacturer);
        }

        private int getEngineVolume()
        {
            string engineVolumeStr;
            int engineVolume = 0;

            Console.WriteLine("Enter the engine volume : ");
            engineVolumeStr = Console.ReadLine();
            try
            {
                engineVolume = int.Parse(engineVolumeStr);
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter digits only");
                getEngineVolume();
            }

            return engineVolume;
        }

        private eDriverType getLicenseType()
        {
            int licenseType = 0;
            Console.WriteLine("Enter the license type \n1-A \n2-B1 \n3-AA \n4-BB  ");
            string licenseTypeStr = Console.ReadLine();

            try
            {
                licenseType = int.Parse(licenseTypeStr);
                isLicenseTypeValid(licenseType);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please choose from the list");
                getLicenseType();
            }

            return (eDriverType)licenseType;
        }

        private void isLicenseTypeValid(int i_LicenseType)
        {
            if (i_LicenseType > 4 || i_LicenseType < 1)
            {
                throw new FormatException();
            }
        }

        private void motorcycleMenu(string i_LicenseNumber, float i_CurrentAirPressure, string i_WheelManufacturer)
        {
            eDriverType licenseType;
            int engineVolume;

            licenseType = getLicenseType();
            engineVolume = getEngineVolume();

            m_LogicMember.AddFuelMotor(i_LicenseNumber, licenseType, engineVolume, i_CurrentAirPressure, i_WheelManufacturer);
        }

        private void isLegalTypeOfVehicle(int i_VehicleNumber)
        {
            if (i_VehicleNumber < 1 || i_VehicleNumber > 6)
            {
                throw new FormatException();
            }
        }

        private eVehicleType getVehicleType()
        {
            int typeNumber = 0;
            Console.WriteLine("Vehicle type :");
            Console.WriteLine("1- motorcycle \n2- electric motorcycle \n3- car \n4- electric car \n5- truck");
            string vehicleType = Console.ReadLine();

            try
            {
                typeNumber = int.Parse(vehicleType);
                isLegalTypeOfVehicle(typeNumber);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please choose from the list");
                getVehicleType();
            }

            eVehicleType res = (eVehicleType)typeNumber;
            return res;


        }

        private float getCurrentAirPressure()
        {
            float airPressureFloat = 0;
            Console.WriteLine("Current air pressure : ");
            try
            {
                airPressureFloat = float.Parse(Console.ReadLine());


            }
            catch (FormatException)
            {
                Console.WriteLine("Please Enter the correct air pressure");
                getCurrentAirPressure();
            }
            catch (Ex03.GarageLogic.ValueOutOfRangeException)
            {
                Console.WriteLine("Please Enter the correct air pressure");
                getCurrentAirPressure();
            }

            return airPressureFloat;
        }

        private string getWheelManufacturer()
        {
            Console.WriteLine("Wheel manufacturer: ");
            return Console.ReadLine();
        }

        private string getCustomerPhone()
        {
            Console.WriteLine("Customer Phone (digits only!) : ");
            string customerPhone = Console.ReadLine();
            try
            {
                int phoneNumber = int.Parse(customerPhone);

            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter digits only!");
                getCustomerPhone();
            }

            return customerPhone;
        }

        private void printNewVehicleMenu()
        {
            Console.WriteLine("It's a new vehicle :)");
            Console.WriteLine("Please enter the following details:");
        }

        private string getCustomerName()
        {
            Console.WriteLine("Customer Name : ");
            string customerName = Console.ReadLine();

            return customerName;
        }

        private void printVehiclesByStatus(eCarStatus i_VehicleStatus)
        {
            List<string> listToPrint = m_LogicMember.CreateListByStatus(i_VehicleStatus);

            foreach (string licenseNumber in listToPrint)
            {
                Console.WriteLine(licenseNumber);
            }
        }

        public void Menu()
        {
            bool Exit = false;
            while (!Exit)
            {
                string selectedActionStr;
                int selectedAction;
                Console.WriteLine("Hello! Welcome to our Garage");
                Console.WriteLine("Please select the action you want to perform from the menu : ");
                Console.WriteLine("1 - Add vehicle to the Garage");
                Console.WriteLine("2 - View the list of vehicles by status");
                Console.WriteLine("3 - Change vehicle status");
                Console.WriteLine("4 - Inflate the wheels of a vehicle to the maximum");
                Console.WriteLine("5 - Refuel a vehicle that is powered by fuel");
                Console.WriteLine("6 - Charge an electric vehicle");
                Console.WriteLine("7 - View complete vehicle data by license number");
                Console.WriteLine("8 - To Exit");
                selectedActionStr = Console.ReadLine();
                selectedAction = checkUserInput(selectedActionStr);
                if (selectedAction == 8)
                {
                    Exit = !Exit;
                }
                sendByUserSelection(selectedAction);
                System.Console.Clear();
            }
        }

        private void sendByUserSelection(int i_SelectedAction)
        {
            Console.Clear();

            if (i_SelectedAction == 1)
            {
                AddVehicleMenu();
            }
            else if (i_SelectedAction == 2)
            {
                listOfVehicleByStatus();
            }
            else if (i_SelectedAction == 3)
            {
                s_ChangeStatus();
            }
            else if (i_SelectedAction == 4)
            {
                m_LogicMember.UpdateWheelPressuresToMax();
            }
            else if (i_SelectedAction == 5)
            {
                refuelAVehicle();
            }
            else if (i_SelectedAction == 6)
            {
                chargeElectronicVehicle();

            }
            else if (i_SelectedAction == 7)
            {
                getDetailsOfVehicle();
            }
        }

        private void getDetailsOfVehicle()
        {
            string serialNumber;

            serialNumber = askForSerialNumber();
            string msg = m_LogicMember.GetAllDetails(serialNumber);
            System.Console.WriteLine(msg);
            Console.ReadLine();
        }

        private void chargeElectronicVehicle()
        {
            string serialNumber;
            float amountToCharge;

            serialNumber = askForSerialNumber();
            amountToCharge = askForAmountToCharge();
            m_LogicMember.ChargeCar(serialNumber, amountToCharge);
        }

        private float askForAmountToCharge()
        {
            string amountStr;
            float amount = 0;

            Console.WriteLine("Enter the charge amount : ");
            amountStr = Console.ReadLine();
            try
            {
                amount = float.Parse(amountStr);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter digits only");
                askForAmountToCharge();
            }

            return amount;
        }

        private void refuelAVehicle()
        {
            string serialNumber;

            eFuelType fuelType;
            float fuelAmount;

            serialNumber = askForSerialNumber();
            fuelType = askForFuelType();
            fuelAmount = askForFuelAmount();
            m_LogicMember.FuelCar(serialNumber, fuelType, fuelAmount);
        }

        private float askForFuelAmount()
        {
            string fuelAmountStr;
            float fuelAmount = 0;

            Console.WriteLine("Please enter the fuel amount : ");
            fuelAmountStr = Console.ReadLine();
            try
            {
                fuelAmount = float.Parse(fuelAmountStr);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter digits only");
                askForFuelAmount();
            }

            return fuelAmount;
        }

        private eFuelType askForFuelType()
        {
            string fuelType;

            Console.WriteLine("Please choose the fuel type : ");
            Console.WriteLine("1 - Soler");
            Console.WriteLine("2 - Octan95");
            Console.WriteLine("3 - Octan96");
            Console.WriteLine("4 - Octan98");

            fuelType = Console.ReadLine();
            checkFuelType(fuelType);
            int res = int.Parse(fuelType);
            return (eFuelType)res;
        }

        private void checkFuelType(string i_FuelType)
        {
            int fuelType;

            try
            {
                fuelType = int.Parse(i_FuelType);
                isFuelTypeInRange(fuelType);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please choose from the list");
                askForFuelType();
            }
        }

        private void isFuelTypeInRange(int i_FuelType)
        {
            if (i_FuelType < 1 || i_FuelType > 4)
            {
                throw new FormatException();
            }
        }

        private void s_ChangeStatus()
        {
            string serialNumber;
            eCarStatus vehicleStatus;

            serialNumber = askForSerialNumber();
            vehicleStatus = askForStatus();
            m_LogicMember.ChangeStatus(serialNumber, vehicleStatus);
        }

        private string askForSerialNumber()
        {
            string serianNumberStr = string.Empty;
            int serialNumber;

            Console.WriteLine("Please enter the vehicle's serial number : ");
            serianNumberStr = Console.ReadLine();
            try
            {
                serialNumber = int.Parse(serianNumberStr);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter digits only");
                askForSerialNumber();
            }

            return serianNumberStr;
        }


        private eCarStatus askForStatus()
        {
            string vehicleStatus;

            Console.WriteLine("Please choose the new status : ");
            Console.WriteLine("1 - In repair");
            Console.WriteLine("2 - repaired");
            Console.WriteLine("3 - payed");
            vehicleStatus = Console.ReadLine();
            checkStatus(vehicleStatus);
            int res = int.Parse(vehicleStatus);


            return (eCarStatus)res;
        }
        private void listOfVehicleByStatus()
        {
            eCarStatus vehicleStatus;

            vehicleStatus = askForStatus();
            List<string> ListToPrint = m_LogicMember.CreateListByStatus(vehicleStatus);
            if(ListToPrint.Count == 0)
            {
                PrintListIsEmpty();
            }
            else
            {
                foreach (string stringInList in ListToPrint)
                {
                    Console.WriteLine(stringInList);
                }
                Console.ReadLine();

            }
        
        }

        private void checkStatus(string i_VehicleStatus)
        {
            int status = 0;
            try
            {
                status = int.Parse(i_VehicleStatus);
                isStatusInRange(status);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please choose from the list");
                listOfVehicleByStatus();
            }
        }

        private void isStatusInRange(int i_Status)
        {
            if (i_Status < 1 || i_Status > 3)
            {
                throw new FormatException();
            }
        }

        private int checkUserInput(string i_SelectedActionStr)
        {
            int userSelection = 1;
            try
            {
                userSelection = int.Parse(i_SelectedActionStr);
                checkIfTheInputIsInRange(userSelection);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please choose from the list");
                Menu();
            }

            return userSelection;
        }

        private void checkIfTheInputIsInRange(int i_UserSelection)
        {
            if (i_UserSelection < 1 || i_UserSelection > 8)
            {
                throw new FormatException();
            }
        }

        private void PrintNotFound()
        {
            Console.WriteLine("Not Found");
            Console.ReadLine();
        }
        private void PrintListIsEmpty()
        {
            Console.WriteLine("List is empty");
            Console.ReadLine();
        }
        private float currentFuelAmount()
        {
            string fuelAmountStr;
            float fuelAmount = 0;

            Console.WriteLine("Enter the current fuel amount : ");
            fuelAmountStr = Console.ReadLine();

            try
            {
                fuelAmount = float.Parse(fuelAmountStr);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter digits only");
                currentFuelAmount();
            }

            return fuelAmount;
        }

        private float butteryTimeLeft()
        {
            string butteryTimeStr;
            float butteryTime = 0;

            Console.WriteLine("Enter the current fuel amount : ");
            butteryTimeStr = Console.ReadLine();

            try
            {
                butteryTime = float.Parse(butteryTimeStr);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter digits only");
                butteryTimeLeft();
            }

            return butteryTime;
        }
    }
}



