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
using System.Windows.Shapes;

namespace WofHCalc_p2_UI_.Views
{
    /// <summary>
    /// Логика взаимодействия для Accounts_Manager.xaml
    /// </summary>
    public partial class Accounts_Manager : Window
    {
        public Accounts_Manager()
        {
            InitializeComponent();            
            DataContext = new VM.AccMngrVM();
        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            //this.DialogResult = true;
        }
    }
}
