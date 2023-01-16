using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WofHCalc_p2_UI_.Models;
using WofHCalc_p2_UI_.Models.templates;

namespace WofHCalc_p2_UI_.Control
{   
    class MainWindowController :INotifyPropertyChanged
    {
        //поля и свойста
        private Account? active_acc;
        public Account? ActiveAccount 
        {
            get => active_acc;
            set 
            {
                active_acc = value;
                OnPropertyChanged(nameof(ActiveAccount));
                SelectedTown ??= ActiveAccount!.Towns.FirstOrDefault();                
            }
        }
        private Town? selected_town;
        public Town? SelectedTown 
        {
            get => selected_town;
            set 
            { 
                selected_town = value;
                OnPropertyChanged(nameof(SelectedTown));
            }
        }

        //всякие штуки
        

        //команды
        private RelayCommand? add_town_command;
        public RelayCommand AddTown
        {
            get
            {
                return add_town_command ??= new RelayCommand(o1 =>
                {
                    try
                    {
                        ActiveAccount!.Towns.Add(new Town());
                        SelectedTown = ActiveAccount.Towns.Last();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка добавления города");
                    }
                }, 
                o2 => { return (ActiveAccount is not null); }
                );
            }
        }
        private RelayCommand? del_town_command;
        public RelayCommand DelTown
        {
            get
            {
                return del_town_command ??= new RelayCommand(o1 =>
                {
                    try
                    {
                        ActiveAccount!.Towns.Remove(SelectedTown);
                        SelectedTown = ActiveAccount.Towns.FirstOrDefault();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка удаления города");
                    }
                },
                o2 => { return (SelectedTown is not null); }
                );
            }
        }
        //костыли
        private ObservableCollection<PTDA>? ptda;
        public ObservableCollection<PTDA> PriceTaxDataAdapter 
        {
            set { ptda = value; OnPropertyChanged(nameof(PriceTaxDataAdapter)); }            
            get
            {
                if (ptda != null) return ptda;
                else
                {
                    ptda = new ObservableCollection<PTDA>();
                    for (int i=0; i<23; i++) 
                    {
                        ptda.Add(new PTDA
                        {
                            ImgPath = $"/img/icons/res/res{i}.png",
                            Resource = ((ResName)i).ToString(),
                            PT = ActiveAccount!.Prices[i]
                        });
                    }
                }
                return ptda;
            }
        }                           
        //интерфейсы
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));            
        }
    }
    //преобразование данных из json в другой вид, чтоб удобно пользоваться было
    public class PTDA 
    {
        public string? ImgPath { get; set; }
        public string? Resource { get; set; }
        public PriceTax? PT { get; set; }
    }
    public class BDA
    {
        public string? Name { get; set; }
        public int ID { get; set; }
        //public BuildName bName { get; set; } //может и так сойдёт. Сразу и ID и название доступны. Надо проверять
        public Build? Building { get; set; }
    }
}
