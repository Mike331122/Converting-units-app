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
        // 3 tables that the program will use to show units
        public string[] Time = { "Time", "s", "min", "h", "d" };
        public string[] Weight = { "Weight", "g", "dg", "kg", "t" };
        public string[] Length = { "Length", "mm", "cm", "m", "km" };
        public string actualTypeName;

        public MainWindow()
        {
            InitializeComponent();

            Replacement("Time");
        }
        /// <summary>
        /// Function that is choosing which Type of data the user wants to look at
        /// </summary>
        /// <param name="tabName">Name of the table user wants to be shown</param>
        /// <returns>Table that will be showing units</returns>
        public string[] Choose(string tabName)
        {
            actualTypeName = tabName;
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

        /// <summary>
        /// Function that based on the user choosing, will list every unit available for converting
        /// </summary>
        /// <param name="tabName">Name of the table user wants to be shown</param>
        public void Replacement(string tabName,int numb = 1)
        {
            

            string[] tab = Choose(tabName);

            switch (numb)
            {
                case 1:

                    ListUnits.Items.Clear();
                    ListUnitsWithoutOne.Items.Clear();

                    for (int i = 1; i < tab.Length; i++)
                    {
                        ListUnits.Items.Add(tab[i]);
                        ListUnitsWithoutOne.Items.Add(tab[i]);
                    }
                    break;

                case 2:

                    ListUnitsWithoutOne.Items.Clear();

                    for (int i = 1; i < tab.Length; i++)
                    {
                        
                        ListUnitsWithoutOne.Items.Add(tab[i]);
                    }
                    break;
            }
        }

        public void Sasd()
        {
            ListUnitsWithoutOne.Items.RemoveAt(ListUnits.Items.IndexOf(ListUnits.SelectedItem));

            
        }

        /// <summary>
        /// Reduces name and it won't show System... anymore
        /// </summary>
        /// <param name="name">String that need to be shorted</param>
        /// <returns>New string with the name f the table that user wanna look at</returns>
        public string Deleting(string name)
        { 
            return name.Substring(37);
        }

        private void SelectType(object sender, SelectionChangedEventArgs e)
        {
            Replacement(actualTypeName, 2);

            string unit = Deleting(ListTypes.SelectedItem.ToString());
            Replacement(unit);

            Convertnumber.IsEnabled = false;
            ListTypes.UnselectAll();
        }

        private void SelectUnits(object sender, SelectionChangedEventArgs e)
        {
            
            Replacement(actualTypeName, 2);

            Convertnumber.IsEnabled = true;

            Sasd();
            ListUnits.UnselectAll();
        }

        private void Convert(object sender, TextChangedEventArgs e)
        {
            string napis = "klaa";
            Convertednumber.Text = napis;
            //MessageBox.Show("Zmieniasz coś");
        }
    }
}
