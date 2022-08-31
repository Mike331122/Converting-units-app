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
using System.Windows.Controls.Primitives;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    //public 

    public partial class MainWindow : Window
    {
        public string[] Time = { "Time", "s", "min", "h", "d" };
        public string[] Weight = { "Weight", "g", "dg", "kg", "t" };
        public string[] Length = { "Length", "mm", "cm", "m", "km" };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonAddName_Click(object sender, RoutedEventArgs e)
        {
           /* if (!string.IsNullOrWhiteSpace(txtName.Text) && !ListUnits.Items.Contains(txtName.Text))
            {
                ListUnits.Items.Add(txtName.Text);
                txtName.Clear();
            }*/
        }

        public string[] Choose(string tabName)
        {
            if (tabName == Time[0])
            {
                return Time;
            }
            else if (tabName == Weight[0])
            {
                return Weight;
            }
            else
            {
                return Length;
            }
        }

        public void Adding(string tabName)
        {
            ListUnits.Items.Clear();

            string[] tab = Choose(tabName);
           
            for (int i = 1; i < tab.Length; i++)
            {
                ListUnits.Items.Add(tab[i]);
            }
        }

        public string Deleting(string name)
        { 
            return name.Substring(37);
        }

        private void SelectUnits(object sender, SelectionChangedEventArgs e)
        {
            string curUnit = ListUnits.SelectedItem.ToString();
            //string curType = ListTypes.SelectedItem.ToString();

            ListUnits.Items.RemoveAt(1);
            ListUnits.Items.Refresh();
            

            string number = ListUnits.Items.Count.ToString();
            //int numb = Convert.ToInt32(number);
            Convertnumber.Text = curUnit;
            Convertednumber.Text = number;
        }

        private void SelectType(object sender, SelectionChangedEventArgs e)
        {
            //Adding(ListTypes.);
            string curUnit = ListTypes.SelectedItem.ToString();
            string unit = Deleting(curUnit);
            Adding(unit);
            
            Convertnumber.Text = unit;
        }
    }
}
