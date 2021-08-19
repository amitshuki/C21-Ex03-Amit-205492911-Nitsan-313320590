using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public enum eFuelType
    {
        Soler=1, Octan95=2, Octan96=3, Octan98=4
    }
    internal class FuelEngine:Engine
    {
       

        private eFuelType m_FuelType;
        private float m_AmountOfFuel;
        private float m_MaxAmountOfFuel;

        internal bool FuelTheVehicle(float i_FuelToInsert, eFuelType i_FuelType)
        {
            bool res = false;
            if(i_FuelToInsert + m_AmountOfFuel <= m_MaxAmountOfFuel && i_FuelType==m_FuelType)
            {
                res = !res;
                m_AmountOfFuel += i_FuelToInsert;

            }

            return res;
        }

        internal float AmountOfFuel
        {
            get => m_AmountOfFuel;
            set => m_AmountOfFuel = value;
        }
        internal float MaxAmountOfFuel
        {
            get => m_MaxAmountOfFuel;
            set => m_MaxAmountOfFuel = value;
        }
        internal eFuelType FuelType
        {
            get => m_FuelType;
            set => m_FuelType = value;
        }

        internal FuelEngine(eFuelType i_FuelType, float i_MaxFuel)
        {
            FuelType = i_FuelType;
            MaxAmountOfFuel = i_MaxFuel;
        }
        internal override void FuelTheEngine(eFuelType i_FuelType, float i_FuelToAdd)
        {
          if(m_AmountOfFuel+i_FuelToAdd  <= m_MaxAmountOfFuel)
          {
              m_AmountOfFuel = +i_FuelToAdd;
          }
          else
          {
              throw new ValueOutOfRangeException();

          }
        }

    }
}
