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

namespace matsukifudousan.ViewModel
{
    public class ContractDetailsSearchViewModel : BaseViewModel
    {
        public static bool AddItem = false; //This must be public and static so that it can be called from your second Window

        //private List<RentalManagementDB> _List;
        //public List<RentalManagementDB> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<ContractDetailsDB> _ListContractDetails;
        public ObservableCollection<ContractDetailsDB> ListContractDetails { get => _ListContractDetails; set { _ListContractDetails = value; OnPropertyChanged(); } }

        private string _Search;
        public string Search { get => _Search; set { _Search = value; OnPropertyChanged(); } }

        public ICommand SearchButton { get; set; }

        public ICommand PrintsButton { get; set; }

        public ICommand ContractDetailsView { get; set; }

        public ICommand ContractDetailsFix { get; set; }

        public ICommand ContractDetailsDelete { get; set; }

        //public ICommand RentalDetailsInput { get; set; }

        public ICommand ContractDetailsCommandWD { get; set; }

        private ContractDetailsDB _SelectedItem;
        public ContractDetailsDB SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    HouseNo = (int)SelectedItem.HouseNo;
                }
            }
        }

        private Nullable<int> _HouseNo;
        public Nullable<int> HouseNo { get => _HouseNo; set { _HouseNo = value; OnPropertyChanged(); } }

        public ContractDetailsSearchViewModel()
        {
            string Result = "";
            //ListContractDetails = new ObservableCollection<ContractDetailsDB>(DataProvider.Ins.DB.ContractDetailsDB.Where(t => t.HouseNo.ToString().Contains(Result) || t.ContractType.Contains(Result) || t.PickupMode.Contains(Result)));
            #region SearchButton

            SearchButton = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ContractDetailsSearch selectContractNo = new ContractDetailsSearch();
                selectContractNo.HouseSelect.Text = null;
                Result = Search;
                if (!String.IsNullOrWhiteSpace(Result) && Result != null && Result != "")
                {
                    ListContractDetails = new ObservableCollection<ContractDetailsDB>(DataProvider.Ins.DB.ContractDetailsDB.Where(t => t.HouseNo.ToString().Contains(Result) || t.ContractType.Contains(Result) || t.PickupMode.Contains(Result)));

                    if (ListContractDetails.Count == 0)
                    {
                        MessageBox.Show("検索の結果がなかったです。", "警告", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("入力してください。", "警告", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
            #endregion

            PrintsButton = new RelayCommand<object>((p) => { return true; }, (p) => { printsButton(); });
            ContractDetailsView = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ContractDetailsSearch selectContractNo = new ContractDetailsSearch();

                if (selectContractNo.HouseSelect.Text != "")
                {
                    ContractDetailsView openWindowDetails = new ContractDetailsView(); openWindowDetails.ShowDialog();
                }
                else
                {
                    MessageBox.Show("物件を選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            });
            ContractDetailsFix = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ContractDetailsSearch selectContractNo = new ContractDetailsSearch();
                string HouseNoSelect = selectContractNo.HouseSelect.Text;
                if (HouseNoSelect != "")
                {
                    contractDetailsFixOpenWithWindow();
                }
                else
                {
                    MessageBox.Show("物件を選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            });
            ContractDetailsDelete = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ContractDetailsSearch selectContractNo = new ContractDetailsSearch();

                if (selectContractNo.HouseSelect.Text != "")
                {
                    contractDetailsDelete();
                }
                else
                {
                    MessageBox.Show("物件を選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            });

            ContractDetailsCommandWD = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ContractDetailsSearch selectContractNo = new ContractDetailsSearch();

                if (selectContractNo.HouseSelect.Text != "")
                {
                    ContractDetails wd = new ContractDetails(); wd.ShowDialog();
                }
                else
                {
                    MessageBox.Show("物件を選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            });
        }
        private void printsButton()
        {
            if (ListContractDetails.Count != 0) // if List.Count = 0 then Search Result not had 
            {
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                string filePath = "";
                SaveFileDialog dialog = new SaveFileDialog();

                dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";

                if (dialog.ShowDialog() == true)
                {
                    filePath = dialog.FileName;
                }

                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("回線（パス）には正しくないです。", "回線とパス", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                try
                {
                    using (ExcelPackage pa = new ExcelPackage())
                    {
                        pa.Workbook.Properties.Author = "マツキ不動産賃貸管理";
                        pa.Workbook.Properties.Title = "契約詳細";
                        ExcelWorksheet ws = pa.Workbook.Worksheets.Add("契約一覧");
                        ws.Name = "契約詳細";
                        ws.Cells.Style.Font.Size = 11;
                        ws.Cells.Style.Font.Name = "Calibri";

                        string[] arrColumnHeader = {
                                                        "物件番号",
                                                        "契約の種類",
                                                        "取引態様"
                                                        };
                        var countColHeader = arrColumnHeader.Count();

                        ws.Cells[1, 1].Value = "契約管理の一覧表示";
                        ws.Cells[1, 1, 1, countColHeader].Merge = true;
                        ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                        ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        int colIndex = 1;
                        int rowIndex = 2;

                        foreach (var item in arrColumnHeader)
                        {
                            var cell = ws.Cells[rowIndex, colIndex];
                            var fill = cell.Style.Fill;
                            fill.PatternType = ExcelFillStyle.Solid;
                            fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                            var border = cell.Style.Border;
                            border.Bottom.Style =
                            border.Top.Style =
                            border.Left.Style =
                            border.Right.Style = ExcelBorderStyle.Thin;

                            cell.Value = item;
                            colIndex++;
                        }

                        foreach (var item in ListContractDetails)
                        {
                            colIndex = 1;
                            rowIndex++;
                            ws.Cells[rowIndex, colIndex++].Value = item.HouseNo;
                            ws.Cells[rowIndex, colIndex++].Value = item.ContractType;
                            ws.Cells[rowIndex, colIndex++].Value = item.PickupMode;
                        }

                        Byte[] bin = pa.GetAsByteArray();
                        File.WriteAllBytes(filePath, bin);
                    }
                    MessageBox.Show("一覧表示からリスト印刷出来ました❣", "成功", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception EE)
                {
                    MessageBox.Show("ファイルが開いているために閉じて保存してください！　", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("一覧表示がなかったです。検索のは検索してください❕", "検索しなかった", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        private void contractDetailsFixOpenWithWindow()
        {
            ContractDetailsSearch contractSearch = new ContractDetailsSearch();
            var contractSearchHouseNo = contractSearch.HouseSelect.Text;

            if (contractSearchHouseNo != "")
            {
                //Window window = new Window
                //{
                //    Title = "賃貸修正",
                //    Width = 835,
                //    Height = 450,
                //    Content = new RentalFixs(),
                //    ResizeMode = ResizeMode.NoResize,
                //    WindowStartupLocation = WindowStartupLocation.CenterScreen,
                //    WindowStyle = WindowStyle.None
                //};
                //window.ShowDialog();

                ContractDetailsFix openWindowDetails = new ContractDetailsFix(); openWindowDetails.ShowDialog();
            }
            else
            {
                MessageBox.Show("物件を選択してください！", "Warring", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void contractDetailsDelete()
        {
            ContractDetailsSearch contractSearch = new ContractDetailsSearch();
            var contractHouseDelete = Int32.Parse(contractSearch.HouseSelect.Text);
            var resultButtonDeleteHouse = MessageBox.Show("本当にこの物件（物件番号：" + contractHouseDelete + "）を削除しますか？", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (resultButtonDeleteHouse == MessageBoxResult.OK)
            {
                string Result = null;
                Result = Search;
                var HouseDeleteDB = DataProvider.Ins.DB.ContractDetailsDB.Where(houseDelete => houseDelete.HouseNo == contractHouseDelete);
                DataProvider.Ins.DB.ContractDetailsDB.RemoveRange(HouseDeleteDB);
                DataProvider.Ins.DB.SaveChanges();

                MessageBox.Show("削除しました！");
                ListContractDetails = new ObservableCollection<ContractDetailsDB>(DataProvider.Ins.DB.ContractDetailsDB.Where(t => t.HouseNo.ToString().Contains(Result) || t.ContractType.Contains(Result) || t.PickupMode.Contains(Result)));
            }
            else
            {
                MessageBox.Show("削除しなかったです。");
            }
        }
    }
}
