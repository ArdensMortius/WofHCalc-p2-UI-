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

namespace WofHCalc_p2_UI_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Dictionary<string, int> race_kostyl;
        //string[] rrr = new string[5];
        public MainWindow()
        {
            Account acc = new();//
            DataContext = acc;
            InitializeComponent();       
        }
    }
}
