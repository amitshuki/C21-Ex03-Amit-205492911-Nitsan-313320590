using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
   public  class ValueOutOfRangeException:Exception
   {
       public float m_MaxValue;
       public float m_MinValue;

       public ValueOutOfRangeException(float i_MaxValue, float i_MinValue)
       {
            Console.WriteLine($"value is out of Range The max value is {i_MaxValue} and you already have {i_MinValue}");
       }
       public float MaxValue
       {
           get => m_MaxValue;
           set => m_MaxValue = value;
       }
       public float MinValue
       {
           get => m_MinValue;
           set => m_MinValue = value;
       }
    }

}
