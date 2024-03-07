using clean.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.core.DTOs
{
    public class orderDTO
    {
        public int orderNum { get; set; }
        public string Status { get; set; }
        public int orderSum { get; set; }
        public DateTime orderDate { get; set; }
        public int customerId { get; set; }
        public customer customer { get; set; }

    }
}
