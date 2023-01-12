using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WofHCalc_p2_UI_.Models;

namespace WofHCalc_p2_UI_.VM
{
    internal static class Wofhfunk
    {
        static double main(double A, double B, double C, double D, int n)
        {
            double k = (n==0)? A : 0;
            return (k+B+C*(Math.Pow(n,D)));
        }
        static double great_citizens(int n) =>        
            main(0,1,0.04d,0.75d,n);
        static double terrain_improvement(int users)
        {
            double u = (double)users;
            return (u+1)/(2*u);
        }
        static bool available_check(Race acc, Race build) =>        
            ((build & acc) == acc);        
    }
}
