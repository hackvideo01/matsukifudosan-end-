using matsukifudousan.Model;
using matsukifudousan.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace matsukifudousan
{
    /// <summary>
    /// RentalInput.xaml の相互作用ロジック
    /// </summary>
    public partial class RentalInput : UserControl
    {
        class Model
        {
            static public List<string> GetData()
            {
                List<string> data = new List<string>();
                var ListMNGMTCOName = DataProvider.Ins.DB.CustomerDB.Select(c => c.CustomerName);
                foreach (var item in ListMNGMTCOName)
                {
                    data.Add(item);
                }

                return data;
            }
        }
        public RentalInput()
        {
            InitializeComponent();
            DataContext = new RentalInputViewModel();
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

            if (e.Key == Key.Escape)
            {
                autoListPopup.IsOpen = false;
            }
        }

        private void txbHousePost_LostFocus(object sender, RoutedEventArgs e)
        {
            string zipcode = txbHousePost.Text;
            //URL
            string url = "https://zipcloud.ibsnet.co.jp/api/search?zipcode=" + zipcode;
            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    // エンコーディングをUTF-8にしておく（取得してからEncoding変えてもパースできなかった）
                    webClient.Encoding = System.Text.Encoding.UTF8;

                    // JSONのテキストを取得
                    string jsonStr = webClient.DownloadString(url);

                    JObject jsonObj = JObject.Parse(jsonStr);

                    var jsonData = jsonObj["results"].First;
                    //var jsonData1 = jsonObj["results"];
                    //var jsonData2 = jsonObj["results"].FirstOrDefault();

                    var address1 = jsonData["address1"];
                    var address2 = jsonData["address2"];
                    var address3 = jsonData["address3"];

                    //var jsonPollution = jsonCurrent["pollution"];
                    //var json_aqius = jsonPollution["aqius"];
                    //var json_aqicn = jsonPollution["aqicn"];
                    // Dictionaryをシリアライズします。
                    //var jsonstr = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                    //MessageBox.Show(address1.ToString() + address2.ToString() + address3.ToString());

                    txbHouseAddress.Text = address1.ToString() + address2.ToString() + address3.ToString();
                    txbHouseAddress.SelectionStart = txbHouseAddress.Text.Length;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("郵便局番号は恐らく間違っています。もう一度ご確認お願い致します。", "確認", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txbHouseNo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

            //foreach (var ch in e.Text)
            //{
            //    if (!(Char.IsDigit(ch) || ch.Equals(':')))
            //    {
            //        e.Handled = true;
            //        break;
            //    }
            //}
        }

        private void txbHouseNo_KeyUp(object sender, KeyEventArgs e)
        {
            KeyEventArgs ke = e as KeyEventArgs;
            if (ke.Key == Key.Space)
            {
                ke.Handled = true;

                MessageBox.Show("物件番号はスペースバーを入力したいでください！", "確認", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*.?[0-9]+$");
            return regex.IsMatch(pText);
        }

        private void txbHouseNo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txbHouseNo.Text != "" && IsNumber(txbHouseNo.Text))
            {
                int houseno = Int32.Parse(txbHouseNo.Text);
                var checkHouse = DataProvider.Ins.DB.RentalManagementDB.Where(ck => ck.HouseNo == houseno);
                int checkhousenoCount = checkHouse.Count();
                if (checkhousenoCount != 0)
                {
                    MessageBox.Show("その物件番号は使われています。", "物件番号を再入力", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("物件番号（数字のみ）を入力してください。", "物件番号を再入力", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void txbSecurityDeposit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txbKeyMoney_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txbCommonFee_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txbManagementFee_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txbRent_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txbParkingFee_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txbCATVFee_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txbOtherFee_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            bool found = false;
            var border = (resultStack.Parent as ScrollViewer).Parent as Border;
            var data = Model.GetData();

            string query = (sender as TextBox).Text;

            if (query.Length == 0)
            {
                // Clear
                resultStack.Children.Clear();
                border.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                border.Visibility = System.Windows.Visibility.Visible;
            }

            // Clear the list
            resultStack.Children.Clear();

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
                autoListPopup.IsOpen = true;
                TextBlock notfound = new TextBlock();
                notfound.Text = "結果がありません";
                notfound.Foreground = Brushes.White;
                resultStack.Children.Add(notfound);
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
                textBoxCONAME.Text = (sender as TextBlock).Text;
                textBoxCONAME.Focus();
                int ListMNGMTCOName = DataProvider.Ins.DB.CustomerDB.Where(c => c.CustomerName == textBoxCONAME.Text).Count();
                if (ListMNGMTCOName != 0)
                {
                    CompanyAddress.Text = DataProvider.Ins.DB.CustomerDB.Where(c => c.CustomerName == textBoxCONAME.Text).FirstOrDefault().Address;
                    CompanyAddress.Focus();
                    COPhone.Text = DataProvider.Ins.DB.CustomerDB.Where(c => c.CustomerName == textBoxCONAME.Text).FirstOrDefault().TelephoneNumber;
                    COPhone.Focus();
                    COFax.Text = DataProvider.Ins.DB.CustomerDB.Where(c => c.CustomerName == textBoxCONAME.Text).FirstOrDefault().FaxNumber;
                    COFax.Focus();
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
            autoListPopup.IsOpen = true;
            autoListPopup.Visibility = System.Windows.Visibility.Visible;
            resultStack.Children.Add(block);

        }

        private void textBoxCONAME_LostFocus(object sender, RoutedEventArgs e)
        {
            //if (textBoxCONAME.Text != null && textBoxCONAME.Text != "")
            //{
            //    int ListMNGMTCOName = DataProvider.Ins.DB.CustomerDB.Where(c => c.CustomerName == textBoxCONAME.Text).Count();
            //    if (ListMNGMTCOName == 0)
            //    {
            //        MessageBox.Show("「" + textBoxCONAME.Text + "」はありません。", "管理会社名", MessageBoxButton.OK, MessageBoxImage.Error);
            //        textBoxCONAME.Clear();
            //    }
            //}
            int ListMNGMTCOName = DataProvider.Ins.DB.CustomerDB.Where(c => c.CustomerName == textBoxCONAME.Text).Count();
            if (ListMNGMTCOName != 0)
            {
                CompanyAddress.Text = DataProvider.Ins.DB.CustomerDB.Where(c => c.CustomerName == textBoxCONAME.Text).FirstOrDefault().Address;
                CompanyAddress.Focus();
                COPhone.Text = DataProvider.Ins.DB.CustomerDB.Where(c => c.CustomerName == textBoxCONAME.Text).FirstOrDefault().TelephoneNumber;
                COPhone.Focus();
                COFax.Text = DataProvider.Ins.DB.CustomerDB.Where(c => c.CustomerName == textBoxCONAME.Text).FirstOrDefault().FaxNumber;
                COFax.Focus();
            }
        }
    }
}
