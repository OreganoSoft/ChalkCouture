using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChalkCouture.Models
{
    public class OrderedItem
    {
        public List<Item> Items { get; set; }

        public int Count { get; set; }
    }
}
