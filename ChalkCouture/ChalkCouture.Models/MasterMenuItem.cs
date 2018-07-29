using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChalkCouture.Models
{
    public class MasterMenuItem
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public MainMenu MenuItem { get; set; }

        public string Icon { get; set; }
    }
}
