using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using WofHCalc_p2_UI_.Models;

namespace WofHCalc_p2_UI_.VM
{
    internal class AccMngrVM : INotifyPropertyChanged
    {
        public Account? New_acc { get; set; }
        public string Input1 { get; set; }
        public string Input2 { get; set; }
        private readonly string saves_path;
        public ObservableCollection<Account> Accounts { get; set; }
        public Account? Selected_acc { get; set; }
        private RelayCommand? add_command;
        public RelayCommand Add
        {
            get
            {
                return add_command ??= new RelayCommand(obj =>
                    {
                        try
                        {
                            New_acc = new(Input1,byte.Parse(Input2));                            
                            using (StreamWriter writer = new(File.Open(saves_path + "/" + Input1, FileMode.CreateNew)))
                            {                                
                                writer.Write(New_acc.ToString());                                                                                                
                            }
                            Accounts.Add(New_acc);
                            Selected_acc = Accounts.Last();                            
                            OnPropertyChanged(nameof(Accounts));
                        }
                        catch
                        {
                            MessageBox.Show("ошибка при создании аккаунта");
                        }                        
                    });
            }
        }
        private RelayCommand? delete_command;
        public RelayCommand Delete
        {
            get
            {
                return delete_command ??= new RelayCommand(o1 =>
                    {
                        File.Delete(saves_path + "/" + Selected_acc.Name);
                        Accounts.Remove(Selected_acc);
                        OnPropertyChanged(nameof(Accounts));
                    }, 
                    o2 =>{ return (Selected_acc != null); }
                    );
            }
        }
        private RelayCommand open_command;
        public RelayCommand Open
        {
            get
            {
                return open_command ??= new RelayCommand(o1 =>
                    {            
                        //чет делает
                        
                    }, 
                    o2 => { return (Selected_acc != null); }
                    );
            }
        }
        internal AccMngrVM()
        {
            Input1 = "";
            Input2 = "";
            saves_path = "saves";
            Accounts = new ObservableCollection<Account>();                       
            //проверяем наличие папки сохранений
            if (!Directory.Exists(saves_path))
                Directory.CreateDirectory(saves_path);
            else
            {
                //загружаем список файлов
                Directory
                    .GetFiles(saves_path)
                    .ToList()
                    .ForEach(f => {
                        using StreamReader reader = new(f);
                        Accounts.Add(new Account(reader.ReadLine(), byte.Parse(reader.ReadLine())));
                    });
            }            
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //MessageBox.Show("here");
        }
    }
}
