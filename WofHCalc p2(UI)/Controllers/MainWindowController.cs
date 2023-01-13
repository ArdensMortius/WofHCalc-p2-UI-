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
        public ObservableCollection<PTDA> PriceTaxDataAdapted 
        {
            set { ptda = value; OnPropertyChanged(nameof(PriceTaxDataAdapted)); }            
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
            //MessageBox.Show("here");
        }
    }
    public class PTDA
    {
        public string? Resource { get; set; }
        public PriceTax? PT { get; set; }
    }
}
