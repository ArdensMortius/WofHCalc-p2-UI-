using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace WofHCalc_p2_UI_.Models.templates
{
    public class Resource
    {
        public float consumption { get; set; }
        public float effect { get; set; }
        public int prodtype { get; set; }
        public int type { get; set; }
    }
}
