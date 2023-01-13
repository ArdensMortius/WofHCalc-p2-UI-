using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WofHCalc_p2_UI_.Models;
using WofHCalc_p2_UI_.Views;
using WofHCalc_p2_UI_.Control;
using System.IO;

namespace WofHCalc_p2_UI_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Dictionary<string, int> race_kostyl;
        //string[] rrr = new string[5];
        MainWindowController dc;            
        public MainWindow()
        {
            dc = new MainWindowController();
            DataContext = dc;            
            if (dc.ActiveAccount== null) 
            {
                Accounts_Manager AM = new();
                if (AM.ShowDialog()==true)
                {
                    dc.ActiveAccount = AM.open_acc;
                }
                else this.Close();
            }            
            InitializeComponent();            
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)//пока просто сохранение без диалогового окна
        {
            if (dc.ActiveAccount != null)
            {
                string path = "saves/" + dc.ActiveAccount!.Name;
                using StreamWriter writer = new(File.Open(path, FileMode.Create));
                writer.Write(dc.ActiveAccount.ToJSON());
            }
            else MessageBox.Show("Nothing to save");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Towns.Height = (int)(Towns.ActualHeight / Towns.Items.Count) * (Towns.Items.Count + 1);
        }
    }
}
