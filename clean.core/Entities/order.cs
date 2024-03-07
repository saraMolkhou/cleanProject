using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean.core.Entities
{
    public class order
    {
        [Key]
        public int orderNum { get; set; }
        public string Status { get; set; }
        public int orderSum { get; set; }
        public DateTime orderDate { get; set; }
        public int customerId { get; set; }
        public customer customer { get; set; }
        //many to many
        public List<product> products {  get; set; }
    }
}
