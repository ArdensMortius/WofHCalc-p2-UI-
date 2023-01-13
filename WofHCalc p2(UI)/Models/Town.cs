using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WofHCalc_p2_UI_.Models
{
    public class Town
    {
        public string Name { get; set; }
        public Climate Climate { get; set; }
        public DepositName Deposit { get; set; }
        public Town() 
        {
            Name = "new town";
            Climate = Climate.unknown;
        }
    }
}
