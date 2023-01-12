using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WofHCalc_p2_UI_.Models
{
    public class Account 
    {
        public string Name { get;}        
        public byte World { get;}
        public Race R { get; set; }
        public List<Town> Towns { get; set; }
        public Account(string name="unknown", byte world=0)
        {
            Name = name;
            World = world;
            R = Race.unknown;
            Towns = new() {new Town()};
        }


        #region заглушка для тестов
        public override string ToString()
        {
            return Name + "\n" + World;
        }
        #endregion
        #region заглушка2

        #endregion
    }
}
