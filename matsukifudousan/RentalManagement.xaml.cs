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
    public partial class RentalManagement : UserControl
    {
        public RentalInputViewModel ViewModel { get; set; }
        public ICommand OpenWindow { get; set; }

        UserControl usc = null;

        public RentalManagement()
        {
            InitializeComponent();

            usc = new RentalInput();
            RentalContain.Children.Add(usc);

            this.DataContext = ViewModel = new RentalInputViewModel();

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

                case "RentalInput":
                    usc = new RentalInput();
                    RentalContain.Children.Add(usc);
                    break;
                
                case "RentalSearch":
                    usc = new RentalSearch();
                    RentalContain.Children.Add(usc);
                    break;

                case "RentalContractSearch":
                    usc = new RentalContractSearch();
                    RentalContain.Children.Add(usc);
                    break;

                case "Prints":
                    usc = new RentalPrints();
                    RentalContain.Children.Add(usc);
                    break;
                case "ContractDetails":
                    usc = new ContractDetailsSearch();
                    RentalContain.Children.Add(usc);
                    break;

                default:
                    break;
            }
        }

    }
}
