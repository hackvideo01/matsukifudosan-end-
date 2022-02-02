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
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using MaterialDesignThemes.Wpf;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing.Printing;
using System.Configuration;

namespace matsukifudousan.ViewModel
{
    public class CustomerPrintsViewModel : BaseViewModel
    {
        private ObservableCollection<CustomerDB> _List;
        public ObservableCollection<CustomerDB> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private string _Search;
        public string Search { get => _Search; set { _Search = value; OnPropertyChanged(); } }

        private int _CustomerNumbers;
        public int CustomerNumbers { get => _CustomerNumbers; set { _CustomerNumbers = value; OnPropertyChanged(); } }

        private ObservableCollection<ImageDB> _autoImageDelete;
        public ObservableCollection<ImageDB> autoImageDelete { get => _autoImageDelete; set { _autoImageDelete = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _GetHouseNo = new ObservableCollection<Object>();
        public ObservableCollection<Object> GetHouseNo { get => _GetHouseNo; set { _GetHouseNo = value; OnPropertyChanged(); } }

        public ICommand SearchButton { get; set; }

        public ICommand CustomerPrints { get; set; }

        public ICommand TotalSearch { get; set; }

        private bool isNewXlsFile = false;
        private Microsoft.Office.Interop.Excel.Application xls = null;
        private Microsoft.Office.Interop.Excel.Workbook book = null;
        private Microsoft.Office.Interop.Excel.Worksheet sheet = null;

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

        public CustomerPrintsViewModel()
        {
            string PathRoot = ConfigurationManager.AppSettings["Path"];


            // Get current working directory (..\bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // GEt the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            // Create specific path file
            string savePathFile = string.Format(@"{0}" + PathRoot + "files", projectDirectory);
            // Create specific path image
            string savePathImage = string.Format(@"{0}" + PathRoot + "images", projectDirectory);

            string Result = null;
            List = new ObservableCollection<CustomerDB>(DataProvider.Ins.DB.CustomerDB.Where(t => t.CustomerNo.ToString().Contains(Result) || t.CustomerName.Contains(Result) || t.Address.Contains(Result)));
            #region SearchButton
            SearchButton = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CustomerPrints selectCustomerNo = new CustomerPrints();
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

            CustomerPrints = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CustomerPrints selectCustomerPrint = new CustomerPrints();
                if (selectCustomerPrint.CustomerPrintText.Text == "管理報告書" && CustomerNo != null && CustomerNo.ToString() != "")
                {
                    try
                    {
                        this.xls = new Excel.Application();
                        ExcelVisibleToggle(xls, false);
                        if (this.isNewXlsFile)
                        {
                            this.book = xls.Workbooks.Add();
                        }
                        else
                        {

                            
                            // Open a File
                            try
                            {
                                this.book = xls.Workbooks.Open(savePathFile + "/管理報告書.xlsx");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("パースがないです。");
                            }

                            int count = 12;
                            var countHouse = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.CustomerNo == CustomerNo).ToList();
                            //家賃・月額 Money
                            string MNMGTName = DataProvider.Ins.DB.CustomerDB.Where(r => r.CustomerNo == CustomerNo).FirstOrDefault().CustomerName;
                            this.xls.Cells[4, "A"] = MNMGTName;
                            foreach (var item in countHouse)
                            {
                                int getHouseNo = item.HouseNo;
                                //家賃・月額 Money
                                string rentMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == getHouseNo).FirstOrDefault().Rent;
                                this.xls.Cells[count, "A"] = getHouseNo + "号";
                                this.xls.Cells[count, "C"] = "当月分家賃　" + rentMoney;
                                count++;
                            }


                        }
                        //this.sheet =
                        //(Microsoft.Office.Interop.Excel.Worksheet)this.book.Sheets[sheetName];
                        ExcelVisibleToggle(xls, true);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("もう一度印刷してください。");
                    }
                }
            });
        }

        public void ExcelVisibleToggle(Microsoft.Office.Interop.Excel.Application xls, bool setting)
        {
            if (xls.Visible == !setting)
            {
                xls.Visible = setting;
            }
        }

    }
}
