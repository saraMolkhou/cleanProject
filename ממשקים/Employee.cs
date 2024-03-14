using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Employee:Person, ISalary 
    {
        public int salaryHour { get; set; }
        public DateTime startWorking { get; set; }
        public int countHours { get; set; }

        public Employee(int salaryHour, DateTime startWorking, int countHours, string n, string tel, DateTime bd)
            :base(n, tel, bd)
        {
            this.salaryHour = salaryHour;
            this.startWorking = startWorking;
            this.countHours = countHours;   
        }


        public virtual double GetSalary()
        {
            return salaryHour * countHours;
        }

        public override string ToString()
        { 
        

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendFormat($"salary for hour:{salaryHour} , start working at {startWorking}");

            return stringBuilder.ToString();
        }

        
    }

}
