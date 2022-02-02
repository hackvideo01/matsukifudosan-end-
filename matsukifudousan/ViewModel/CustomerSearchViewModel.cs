using matsukifudousan.Model;
using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;

namespace matsukifudousan.ViewModel
{
    public class CustomerSearchViewModel : BaseViewModel
    {
        private ObservableCollection<CustomerDB> _List;
        public ObservableCollection<CustomerDB> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private string _Search;
        public string Search { get => _Search; set { _Search = value; OnPropertyChanged(); } }

        private int _CustomerNumbers;
        public int CustomerNumbers { get => _CustomerNumbers; set { _CustomerNumbers = value; OnPropertyChanged(); } }

        private ObservableCollection<ImageDB> _autoImageDelete;
        public ObservableCollection<ImageDB> autoImageDelete { get => _autoImageDelete; set { _autoImageDelete = value; OnPropertyChanged(); } }

        public ICommand SearchButton { get; set; }

        public ICommand PrintsButton { get; set; }

        //public ICommand CustomerDetailsView { get; set; }

        public ICommand CustomerFix { get; set; }

        public ICommand CustomerDelete { get; set; }

        public ICommand CustomerDetailsView { get; set; }

        public ICommand TotalSearch { get; set; }

        private CustomerDB _SelectedItem;
        public CustomerDB SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    CustomerNo = (int)SelectedItem.CustomerNo;
                }
            }
        }

        private Nullable<int> _CustomerNo;
        public Nullable<int> CustomerNo { get => _CustomerNo; set { _CustomerNo = value; OnPropertyChanged(); } }

        public CustomerSearchViewModel()
        {
            string Result = null;
            List = new ObservableCollection<CustomerDB>(DataProvider.Ins.DB.CustomerDB.Where(t => t.CustomerNo.ToString().Contains(Result) || t.CustomerName.Contains(Result) || t.Address.Contains(Result)));
            #region SearchButton
            SearchButton = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CustomerSearch selectCustomerNo = new CustomerSearch();
                //selectCustomerNo.CustomerNo.Text = null;
                Result = Search;
                if (!String.IsNullOrWhiteSpace(Result) && Result != null && Result != "")
                {
                    List = new ObservableCollection<CustomerDB>(DataProvider.Ins.DB.CustomerDB.Where(t => t.CustomerNo.ToString().Contains(Result) || t.CustomerName.Contains(Result) || t.Address.Contains(Result)));
                    CustomerNumbers = List.Count;
                    if (List.Count == 0)
                    {
                        MessageBox.Show("検索の結果がなかったです。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("入力してください。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
            #endregion
            TotalSearch = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                List = new ObservableCollection<CustomerDB>(DataProvider.Ins.DB.CustomerDB.ToList());
                CustomerNumbers = List.Count;
            });
            //PrintsButton = new RelayCommand<object>((p) => { return true; }, (p) => { printsButton(); });
            CustomerDetailsView = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CustomerSearch selectCustomer = new CustomerSearch();

                if (selectCustomer.CustomerNo.Text != "")
                {
                    CustomerDetailView openLand = new CustomerDetailView(); openLand.ShowDialog();
                }
                else
                {
                    MessageBox.Show("物件を選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
            CustomerFix = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CustomerSearch selectCustomer = new CustomerSearch();

                if (selectCustomer.CustomerNo.Text != "")
                {
                    customerFixOpenWithWindow();
                }
                else
                {
                    MessageBox.Show("物件を選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
            CustomerDelete = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CustomerSearch selectCustomer = new CustomerSearch();
                if (selectCustomer.CustomerNo.Text != "")
                {
                    customerDelete();
                    selectCustomer.CustomerNo.Text = null;
                    List = new ObservableCollection<CustomerDB>(DataProvider.Ins.DB.CustomerDB.Where(t => t.CustomerNo.ToString().Contains(Result) || t.CustomerName.Contains(Result) || t.Address.Contains(Result)));
                }
                else
                {
                    MessageBox.Show("物件を選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }
        //private void printsButton()
        //{
        //    if (List.Count != 0) // if List.Count = 0 then Search Result not had 
        //    {
        //        ExcelPackage.LicenseContext = LicenseContext.Commercial;
        //        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        //        string filePath = "";
        //        SaveFileDialog dialog = new SaveFileDialog();
        //        dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";
        //        if (dialog.ShowDialog() == true)
        //        {
        //            filePath = dialog.FileName;
        //        }

        //        if (string.IsNullOrEmpty(filePath))
        //        {
        //            MessageBox.Show("回線（パス）には正しくないです。", "回線とパス", MessageBoxButton.OK, MessageBoxImage.Warning);
        //            return;
        //        }
        //        try
        //        {
        //            using (ExcelPackage pa = new ExcelPackage())
        //            {
        //                pa.Workbook.Properties.Author = "マツキ不動産賃貸管理";
        //                pa.Workbook.Properties.Title = "賃貸物件詳細";
        //                ExcelWorksheet ws = pa.Workbook.Worksheets.Add("賃貸一覧");
        //                ws.Name = "賃貸物件詳細";
        //                ws.Cells.Style.Font.Size = 11;
        //                ws.Cells.Style.Font.Name = "Calibri";
        //                string[] arrColumnHeader = {
        //                                                "物件番号",
        //                                                "物件名",
        //                                                "所在地"
        //                                                };
        //                var countColHeader = arrColumnHeader.Count();
        //                ws.Cells[1, 1].Value = "賃貸管理の一覧表示";
        //                ws.Cells[1, 1, 1, countColHeader].Merge = true;
        //                ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
        //                ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

        //                int colIndex = 1;
        //                int rowIndex = 2;

        //                foreach (var item in arrColumnHeader)
        //                {
        //                    var cell = ws.Cells[rowIndex, colIndex];
        //                    var fill = cell.Style.Fill;
        //                    fill.PatternType = ExcelFillStyle.Solid;
        //                    fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

        //                    var border = cell.Style.Border;
        //                    border.Bottom.Style =
        //                    border.Top.Style =
        //                    border.Left.Style =
        //                    border.Right.Style = ExcelBorderStyle.Thin;
        //                    cell.Value = item;
        //                    colIndex++;
        //                }

        //                foreach (var item in List)
        //                {
        //                    colIndex = 1;
        //                    rowIndex++;
        //                    ws.Cells[rowIndex, colIndex++].Value = item.CustomerNo;
        //                    ws.Cells[rowIndex, colIndex++].Value = item.CustomerName;
        //                    ws.Cells[rowIndex, colIndex++].Value = item.Address;
        //                }
        //                Byte[] bin = pa.GetAsByteArray();
        //                File.WriteAllBytes(filePath, bin);
        //            }
        //            MessageBox.Show("一覧表示からリスト印刷出来ました❣", "成功", MessageBoxButton.OK, MessageBoxImage.Information);
        //        }
        //        catch (Exception EE)
        //        {
        //            MessageBox.Show("エラーがありました❕" + EE, "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("一覧表示がなかったです。検索のは検索してください❕", "検索しなかった", MessageBoxButton.OK, MessageBoxImage.Hand);
        //    }
        //}

        private void customerFixOpenWithWindow()
        {
            CustomerSearch customerSearch = new CustomerSearch();
            var customerSearchNo = customerSearch.CustomerNo.Text;
            if (customerSearchNo != "")
            {
                Window window = new Window
                {
                    Title = "顧客情報",
                    Width = 835,
                    Height = 450,
                    Content = new CustomerFixs(),
                    ResizeMode = ResizeMode.NoResize,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen,
                    WindowStyle = WindowStyle.None
                };
                window.ShowDialog();
                List = new ObservableCollection<CustomerDB>(DataProvider.Ins.DB.CustomerDB.Where(t => t.CustomerNo.ToString().Contains(Search) || t.CustomerName.Contains(Search) || t.Address.Contains(Search)));
            }
            else
            {
                MessageBox.Show("物件を選択してください！", "Warring", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void customerDelete()
        {
            CustomerSearch customerSearch = new CustomerSearch();
            int customerSearchNo = Int32.Parse(customerSearch.CustomerNo.Text);
            var resultButtonDeleteHouse = MessageBox.Show("本当にこの物件（物件番号：" + customerSearchNo + "）を削除しますか？", "警告", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultButtonDeleteHouse == MessageBoxResult.Yes)
            {
                autoImageDelete = new ObservableCollection<ImageDB>(DataProvider.Ins.DB.ImageDB.Where(img => img.CustomerNo == customerSearchNo));
                foreach (var imagePathDB in autoImageDelete)
                {
                    string imagePath = imagePathDB.ImagePath;
                    string imageName = imagePathDB.ImageName;
                    DeleteImage(imageName);
                }

                var imageDeleteDB = DataProvider.Ins.DB.ImageDB.Where(imgDelete => imgDelete.CustomerNo == customerSearchNo);
                DataProvider.Ins.DB.ImageDB.RemoveRange(imageDeleteDB);
                DataProvider.Ins.DB.SaveChanges();

                var customerDeleteDB = DataProvider.Ins.DB.CustomerDB.Where(dtDelete => dtDelete.CustomerNo == customerSearchNo);
                DataProvider.Ins.DB.CustomerDB.RemoveRange(customerDeleteDB);
                DataProvider.Ins.DB.SaveChanges();

                MessageBox.Show("削除しました！");
            }
            else
            {
                MessageBox.Show("削除しなかったです。");
            }
        }

        private void DeleteImage(string nameImage)
        {
            // Get current working directory (..\bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // GEt the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            // Create specific path file
            string SavePath = string.Format(@"{0}\\matsuki\matsuki\images\Customer\", projectDirectory);
            string path = SavePath + nameImage;
            try
            {
                if (File.Exists(path))
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    GC.Collect();
                    System.IO.File.Delete(path);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
