using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChalkCouture.Models
{
    public class Item
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public Category Category { get; set; }

        public int Count { get; set; }

        public bool IsSelected { get; set; }
    }
}
