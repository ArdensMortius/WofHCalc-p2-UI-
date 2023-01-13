using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.ObjectModel;

namespace WofHCalc_p2_UI_.Models
{
    public class PriceTax
    {
        public int Price { get; set; }
        public int Tax { get; set; }
        public PriceTax() { Price = 0; Tax = 0; }
        public PriceTax(int p, int t) { Price = p; Tax = t; }
    }
    public class Account 
    {
        public string Name { get;}        
        public byte World { get;}
        public Race R { get; set; }
        public ObservableCollection<Town> Towns { get; set; }
        public float BasePopulationGrowth { get; set; }
        public float BaseCulture { get; set; }
        public ObservableCollection<int> Science_Bonuses { get; set; }
        public ObservableCollection<PriceTax> Prices { get; set; }
        public Account(string name="unknown", byte world=0)
        {            
            Name = name;
            World = world;
            R = Race.unknown;
            BasePopulationGrowth = 14;
            BaseCulture = 30;
            Science_Bonuses = new ObservableCollection<int> { 100, 100, 100, 100};
            List<PriceTax> tmp = new();
            for (int i = 0; i<23;i++) tmp.Add(new PriceTax(0,i));
            Prices = new ObservableCollection<PriceTax>(tmp);
            Towns = new() {new Town()};
        }
        public string ToJSON() => JsonSerializer.Serialize<Account>(this);

        #region заглушка для тестов
        //public override string ToString()
        //{
        //    return Name + "\n" + World;
        //}
        #endregion

    }
}
