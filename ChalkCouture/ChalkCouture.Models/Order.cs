using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChalkCouture.Models
{
    public class Order
    {
        public int Id { get; set; }
        //need to change this prop
        public Customer Customer { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderedDate { get; set; }

        public DateTime CompletedDate { get; set; }
        public DateTime PostPhonedDate { get; set; }

        public double TotalAmount { get; set; }

        public PaidThrough PaidThrough { get; set; }
    }
}
