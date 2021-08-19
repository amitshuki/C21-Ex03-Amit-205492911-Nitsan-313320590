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
