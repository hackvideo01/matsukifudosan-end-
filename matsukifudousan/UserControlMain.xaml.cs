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
    /// UserControlMain.xaml の相互作用ロジック
    /// </summary>
    public partial class UserControlMain : UserControl
    {
        
        UserControl usc = null;
        public UserControlMain()
        {
            InitializeComponent();
            
        }

        private void RentalManagement_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
            usc = new RentalManagement();
            parentWindow.GridMain.Children.Add(usc);
        }

        private void DetachedHouse_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
            usc = new DetachedHouseManagement();
            parentWindow.GridMain.Children.Add(usc);
        }
        private void Apartment_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
            usc = new ApartmentManagement();
            parentWindow.GridMain.Children.Add(usc);
        }
        private void Land_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
            usc = new LandManagement();
            parentWindow.GridMain.Children.Add(usc);
        }
        private void CompanyDetails_Click(object sender, RoutedEventArgs e)
        {
            CompanyDetails companyDetails = new CompanyDetails();
            companyDetails.Show();
        }
        private void ImageSearch_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
            usc = new ImageSearch();
            parentWindow.GridMain.Children.Add(usc);
        }
        private void RentalContractPaymentSearch_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
            usc = new RentalContractPaymentSearch();
            parentWindow.GridMain.Children.Add(usc);
        }

        private void Customer_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
            usc = new CustomerMGMT();
            parentWindow.GridMain.Children.Add(usc);
        }

        private void DailyReport_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
            usc = new DailyReportMGMT();
            parentWindow.GridMain.Children.Add(usc);
        }

        private void Construction_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
            usc = new ConstructionMGMT();
            parentWindow.GridMain.Children.Add(usc);
        }
    }
}
