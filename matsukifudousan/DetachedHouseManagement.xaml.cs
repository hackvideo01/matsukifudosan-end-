using matsukifudousan.Model;
using matsukifudousan.ViewModel;
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
    /// RentalManagement.xaml の相互作用ロジック
    /// </summary>
    public partial class DetachedHouseManagement : UserControl
    {
        public DetachedHouseInput ViewModel { get; set; }
        public ICommand OpenWindow { get; set; }

        UserControl usc = null;

        public DetachedHouseManagement()
        {
            InitializeComponent();

            usc = new DetachedHouseInput();
            DetachedContain.Children.Add(usc);

            this.DataContext = ViewModel = new DetachedHouseInput();

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

                case "DetachedInput":
                    usc = new DetachedHouseInput();
                    DetachedContain.Children.Add(usc);
                    break;

                case "DetachedSearch":
                    usc = new DetachedSearch();
                    DetachedContain.Children.Add(usc);
                    break;

                case "Prints":
                    usc = new DetachedPrints();
                    DetachedContain.Children.Add(usc);
                    break;

                default:
                    break;
            }
        }

    }
}
