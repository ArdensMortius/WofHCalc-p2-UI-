using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WofHCalc_p2_UI_.Models.templates;

namespace WofHCalc_p2_UI_.Models
{
    public class BuildSlot
    {
        public Slot Slot { get; set; }
        public BuildName? Building { get; set; }
        public byte? Level { get; set; }
        public bool Available { get; set; }
        public BuildSlot()
        {
            Slot = Slot.plain; Building= null; Level = null; Available = true;
        }
        public BuildSlot(Slot slot = Slot.plain, bool available = true)
        {
            Slot = slot;
            Building = null;
            Level = null;
            this.Available = available;
        }
    }

    public class Town : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public Climate Climate { get; set; }
        public DepositName Deposit { get; set; }
        private byte water_places;
        public byte WaterPlaces 
        {
            get => water_places;
            set
            {
                water_places = value;
                for (int i = 10; i < 14; i++)
                    if (water_places + 10 > i) TownBuilds[i].Slot = Slot.water;
                    else TownBuilds[i].Slot = Slot.plain;                
            }
        }
        private bool on_hill;
        public bool OnHill 
        {
            get => on_hill;          
            set
            {
                on_hill = value;
                if (OnHill)
                {
                    TownBuilds[16].Slot = Slot.hill;
                    TownBuilds[17].Slot = Slot.hill;
                }
                else
                {
                    TownBuilds[16].Slot = Slot.plain;
                    TownBuilds[17].Slot = Slot.plain;
                }
            }
        }
        public ObservableCollection<BuildSlot> TownBuilds { get; set; }
        public Town() 
        {
            Name = "new town";
            Climate = Climate.unknown;
            water_places = 0;
            on_hill = false;
            TownBuilds = new ObservableCollection<BuildSlot>
            {
                new BuildSlot(Slot.wounder), //0 чудо
                new BuildSlot(Slot.fort), //1 защита
                new BuildSlot(Slot.center), //2 центр
                new BuildSlot(), //3
                new BuildSlot(), //4
                new BuildSlot(), //5
                new BuildSlot(), //6
                new BuildSlot(), //7
                new BuildSlot(), //8
                new BuildSlot(), //9
                new BuildSlot(), //10 равнина или вода
                new BuildSlot(available: false), //11 равнина или вода
                new BuildSlot(), //12 равнина или вода
                new BuildSlot(), //13 равнина или вода
                new BuildSlot(available: false), //14
                new BuildSlot(available: false), //15
                new BuildSlot(available: false), //16 холм или равнина
                new BuildSlot(), //17 холм или равнина
                new BuildSlot(Slot.hill) //18
            };
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
