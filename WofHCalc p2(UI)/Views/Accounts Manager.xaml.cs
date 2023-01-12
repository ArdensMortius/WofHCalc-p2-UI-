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
using WofHCalc_p2_UI_.Control;
using WofHCalc_p2_UI_.Models;

namespace WofHCalc_p2_UI_.Views
{
    /// <summary>
    /// Логика взаимодействия для Accounts_Manager.xaml
    /// </summary>
    public partial class Accounts_Manager : Window
    {
        public Account? open_acc { get; private set; }
        AccMngrController ds;
        public Accounts_Manager()
        {
            InitializeComponent();            
            ds = new AccMngrController();
            DataContext = ds;
        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            this.open_acc = ds.Selected_acc;
            this.DialogResult = true;
        }
    }
}
