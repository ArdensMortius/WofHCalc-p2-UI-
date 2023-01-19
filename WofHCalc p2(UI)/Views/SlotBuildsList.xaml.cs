using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WofHCalc_p2_UI_.Control;
using WofHCalc_p2_UI_.Models;
using WofHCalc_p2_UI_.Models.templates;

namespace WofHCalc_p2_UI_.Views
{
    /// <summary>
    /// Логика взаимодействия для SlotBuildsList.xaml
    /// </summary>
    public partial class SlotBuildsList : Window
    {
        public Race race;
        public Town town;
        public byte slot_id;
        public BuildName selected_build { get; set; } //для возврата значения
        public List<BuildName>? AllBuilds { get; set; }
        public SlotBuildsList(Town t, byte s, Race race)
        {
            this.race = race;
            town = t; slot_id = s;
            this.DataContext = this;
            AllBuilds = GetAvailable();
            if (AllBuilds is null || AllBuilds.Count == 0) { MessageBox.Show("Нет доступных строений"); }
            InitializeComponent();
        }
        private List<BuildName> GetAvailable() //работает
        {
            List<BuildName> res = Enum
                .GetValues(typeof(BuildName))
                .Cast<Enum>()
                .Select(x=> (BuildName)x)
                .ToList();
            res.RemoveAt(res.Count - 1); //удаление "none". Если не убрать будет ошибка в data.cs
            //теперь фильтрация
            for (int i = 0; i < res.Count; i++)
            {
                Build b = Data.BuildindsData[(int)(res[i])];
                if (b.Slot != town!.TownBuilds[slot_id].Slot) { res.RemoveAt(i--); continue; } //не подходит в слот+
                if ((b.Race & race) != race) { res.RemoveAt(i--); continue; } //не подходит по расе+
                if (b.Maxcount < town.TownBuilds.Count(x => x.Building == (res[i])))
                { res.RemoveAt(i--); continue; } //достигнуто максимальное количество
                if ((b.Group != 0) && //проверка несовместимых построек+
                    (town.TownBuilds //смотрим имеющиеся клеточки
                        .Where((x, j) => (j != slot_id) && (x.Building != BuildName.none)) //кроме пустых и проверяемой
                        .Where(x => (Data.BuildindsData[(int)x.Building]).Group == b.Group) //ищем совпавшие по группе
                        .Any(x=>x.Building != res[i]))) //но с другим id
                { res.RemoveAt(i--); continue; }
                //проверку terrain не особо нужно делать. Это в основном для чудес, а их и так мало
            }
            //        ((b.Terrain == Terrain.everywhere) || //доступен по типу клетки города
            //            ((b.Terrain == Terrain.hill) && (town!.OnHill)) ||
            //            ((b.Terrain == Terrain.plane) && (!town!.OnHill)) ||
            //            ((b.Terrain == Terrain.plane_no_water) && (!town!.OnHill) && (town!.WaterPlaces == 0)) ||
            //            ((b.Terrain == Terrain.plane_water) && (!town!.OnHill) && (town!.WaterPlaces > 0))) &&            
            return res;
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
