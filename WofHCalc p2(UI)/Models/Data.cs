﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WofHCalc_p2_UI_.Models.templates;

namespace WofHCalc_p2_UI_.Models
{
    public static class Data
    {
        public static Resource[] ResData { get; }
        public static Deposit[] DepositsData { get; }
        public static float RaceEffect_Consumption(Race race)
        {
            if (race == Race.indians) return 0.85f;
            else return 1;
        }
        public static float RaceEffect_Culture(Race race)
        {
            if (race == Race.europeans) return 1.05f;
            else return 1;
        }
        public static float RaceEffect_PopulationGrowth(Race race)
        {
            if (race == Race.asians) return 1.1f;
            else return 1;
        }
        public static float RaceEffect_Upkeep(Race race)
        {
            if (race == Race.africans) return 0.9f;
            else return 1;
        }
        public static float RaceEffect_ProdMod(Race race, ResName res)
        {
            if ((int)res < 11 || (int)res > 14) return 1;
            if (race == Race.asians && res == ResName.rice) return 1.3f;
            if (race == Race.europeans && res == ResName.grain) return 1.3f;
            if (race == Race.indians && res == ResName.corn) return 1.3f;
            if (race == Race.africans && res == ResName.fruit) return 1.08f;
            return 0;
        }
        public static float ClimateEffect(Climate climate, ResProdType rpt)
        {
            //                наука деньги  с/х     пром
            float[,] ans = {{ 0,    0,      0,      0 },
                            { 1,    1,      1.3f,   1 },
                            { 1,    1.15f,  1.1f,   1.1f},
                            { 1.1f, 1.05f,  0.85f,  1},
                            { 1,    0.9f,   0.85f,  1.3f} };
            return ans[(int)climate-1,(int)rpt];
        }        
        static Data()
        {

            //+
            ResData = new Resource[23];
            string data = File.ReadAllText("resourses.json");
            ResData = System.Text.Json.JsonSerializer.Deserialize<Resource[]>(data)!;
            //+
            DepositsData = new Deposit[53];
            data = File.ReadAllText("deposits.json");
            DepositsData = System.Text.Json.JsonSerializer.Deserialize<Deposit[]>(data)!;


        }
        
    }
}
