using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WofHCalc_p2_UI_.Models;

namespace WofHCalc_p2_UI_.VM
{
    class MainWindowVM
    {
        public Account? ActiveAccount { get; set; }
        public Town? SelectedTown { get; set; }
    }
}
