using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums
{
    [Flags]
     public  enum WeekDay : byte 
    {
        Sunday=1,
        Monday=2,
        Tuesday=4,
        Wednesday=8,
        Thursday=16,
        Friday=32,
        Saturday=64 
            //--------
    //00000001
    //00000011
    //00001011
    
    
    }
    
}
