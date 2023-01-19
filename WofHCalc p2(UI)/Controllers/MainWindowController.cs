using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using WofHCalc_p2_UI_.Models;
using WofHCalc_p2_UI_.Models.templates;
using WofHCalc_p2_UI_.Views;

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

        //функции для вычислений разного




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
        private ObservableCollection<TBDA>? tbda;
        public ObservableCollection<TBDA> TownBuildsDataAdapter
        {
            set { tbda = value; OnPropertyChanged(nameof(TownBuildsDataAdapter)); }
            get
            {
                if (tbda != null) return tbda;
                tbda = new ObservableCollection<TBDA>();
                for (int i = 0; i < selected_town!.TownBuilds.Count; i++)
                {
                    tbda.Add(new TBDA() 
                    { 
                        DisplayName = selected_town.TownBuilds[i].Building.Description(),
                        ImgPath = $"/img/builds/{(int)(BuildName)selected_town.TownBuilds[i].Building}_1.png",
                        BuildSlot = selected_town.TownBuilds[i]
                    });
                }                
                return tbda;
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
    public class TBDA //для привязки картиночков к слотам
    {
        public string? ImgPath { set; get; }
        public string? DisplayName { get; set; }        
        public BuildSlot? BuildSlot { get; set; }   
    }
    public class BuildToImgConverter : IValueConverter // работает
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //source->target
            if (value is BuildName)
            {                
                return $"/img/builds/{(int)value}_1.png";
            }
            else return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {   //target->source
            return null;
            //return (BuildName)(int.Parse(((string)value).Substring(12, ((string)value).Length - 18)));            
        }
    }
    public class EnumDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!value.GetType().IsEnum) throw new Exception("error enum to description");
            else
            {
                Type t = value.GetType();
                return EnumHelper.Description((Enum)value);

                //return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null; 
            //throw new NotImplementedException();
        }
    }
}
