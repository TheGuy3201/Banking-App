using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    internal struct DayTime
    {
        //Data Members
        private long Minutes;
        //Constructor
        public DayTime(long minutes)
        {
            Minutes = minutes; 
        }
        //Methods
        public override string ToString()
        {
            return "";
        }
    }
}
