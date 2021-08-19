using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eEngineType
    {
        Electric, Fuel
    }
    abstract class Engine
    {
        
        internal virtual void FuelTheEngine(eFuelType i_FuelType, float i_MaxFuel)
        {

        }

        internal virtual void ChargeBattery(float i_HoursToAdd)
        {

        }
    }
}
