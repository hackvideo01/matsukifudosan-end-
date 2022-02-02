using matsukifudousan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// DailyReportInput.xaml の相互作用ロジック
    /// </summary>
    public partial class DailyReportInput : UserControl
    {
        class Model
        {
            static public List<string> GetData()
            {
                List<string> dataHouseNo = new List<string>();
                var ListHouseNo = DataProvider.Ins.DB.RentalManagementDB.Select(c => c.HouseNo);
                foreach (int item in ListHouseNo)
                {
                    dataHouseNo.Add(""+item);
                }

                return dataHouseNo;
            }
        }
        public DailyReportInput()
        {
            InitializeComponent();
        }

        private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var uie = e.OriginalSource as UIElement;

            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                uie.MoveFocus(
                new TraversalRequest(
                FocusNavigationDirection.Next));
            }
        }

        private void txbHouseNo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txbCustomerNo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txbHouseNo_KeyUp(object sender, KeyEventArgs e)
        {
            bool found = false;
            var border = (resultStackHouseNo.Parent as ScrollViewer).Parent as Border;
            var data = Model.GetData();

            string query = (sender as TextBox).Text;

            if (query.Length == 0)
            {
                // Clear
                resultStackHouseNo.Children.Clear();
                border.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                border.Visibility = System.Windows.Visibility.Visible;
            }

            // Clear the list
            resultStackHouseNo.Children.Clear();

            // Add the result
            foreach (var obj in data)
            {
                if (obj != null)
                {
                    if (obj.ToLower().Contains(query.ToLower()))
                    {
                        // The word starts with this... Autocomplete must work
                        addItem(obj);
                        found = true;
                    }
                }
            }

            if (!found)
            {
                autoListPopupHouseNo.IsOpen = true;
                TextBlock notfound = new TextBlock();
                notfound.Text = "結果がありません";
                notfound.Foreground = Brushes.White;
                resultStackHouseNo.Children.Add(notfound);
            }
        }

        private void addItem(string text)
        {
            TextBlock block = new TextBlock();

            // Add the text
            block.Text = text;
            block.Foreground = Brushes.White;

            // A little style...
            block.Margin = new Thickness(2, 3, 2, 3);
            block.Cursor = Cursors.Hand;

            // Mouse events
            block.MouseLeftButtonUp += (sender, e) =>
            {
                txbHouseNo.Text = (sender as TextBlock).Text;
                txbHouseNo.Focus();
                int ListMNGMTCOName = DataProvider.Ins.DB.RentalManagementDB.Where(c => c.HouseNo.ToString() == txbHouseNo.Text).Count();
                if (ListMNGMTCOName != 0)
                {
                    txbHouseName.Text = DataProvider.Ins.DB.RentalManagementDB.Where(c => c.HouseNo.ToString() == txbHouseNo.Text).FirstOrDefault().Address;
                    txbHouseName.Focus();
                }
            };

            block.MouseEnter += (sender, e) =>
            {
                TextBlock b = sender as TextBlock;
                b.Background = Brushes.Blue;
            };

            block.MouseLeave += (sender, e) =>
            {
                TextBlock b = sender as TextBlock;
                b.Background = Brushes.Transparent;

            };

            // Add to the panel
            autoListPopupHouseNo.IsOpen = true;
            autoListPopupHouseNo.Visibility = System.Windows.Visibility.Visible;
            resultStackHouseNo.Children.Add(block);

        }
    }
}
