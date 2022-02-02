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

namespace matsukifudousan
{
    /// <summary>
    /// DailyReportMGMT.xaml の相互作用ロジック
    /// </summary>
    public partial class ConstructionMGMT : UserControl
    {
        //public DetachedHouseInput ViewModel { get; set; }
        public ICommand OpenWindow { get; set; }

        UserControl usc = null;

        public ConstructionMGMT()
        {
            InitializeComponent();

            usc = new ConstructionInput();
            CustomerContain.Children.Add(usc);

            //this.DataContext = ViewModel = new DetachedHouseInput();

        }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "Menu":
                    MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
                    usc = new UserControlMain();
                    parentWindow.GridMain.Children.Add(usc);
                    break;

                case "ConstructionInput":
                    usc = new ConstructionInput();
                    CustomerContain.Children.Add(usc);
                    break;

                case "ConstructionSearch":
                    usc = new ConstructionSearch();
                    CustomerContain.Children.Add(usc);
                    break;

                default:
                    break;
            }
        }
    }
}
