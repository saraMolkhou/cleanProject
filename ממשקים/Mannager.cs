using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Mannager:Employee, ISalary, IComparable
    {
        public int Bonus { get; set; }
        public string MGroup { get; set; }

        public Mannager(int bonus, string mGroup, int salaryHour, DateTime startWorking, int countHours, string n, string tel, DateTime bd)
            :base( salaryHour,  startWorking,  countHours,  n,  tel,  bd)
        {
            Bonus = bonus;
            MGroup = mGroup;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendFormat($"ypur bonus is:{Bonus} , your group is {MGroup}");

            return stringBuilder.ToString();
        }

        public override double GetSalary()
        {
            return base.GetSalary()+Bonus;
        }

        public int CompareTo(object obj)
        {
            if(obj is Mannager)
            {
                if (this.salaryHour == (obj as Mannager).salaryHour)
                    return 0;
                if (this.salaryHour > (obj as Mannager).salaryHour)
                    return 1;  
                return -1;
            }
            return -2;

        }
    }
}
