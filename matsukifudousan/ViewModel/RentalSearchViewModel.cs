using matsukifudousan.Model;
using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace matsukifudousan.ViewModel
{
    public class RentalSearchViewModel : BaseViewModel
    {
        public static bool AddItem = false; //This must be public and static so that it can be called from your second Window

        //private List<RentalManagementDB> _List;
        //public List<RentalManagementDB> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<RentalManagementDB> _List;
        public ObservableCollection<RentalManagementDB> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private string _IsSelectedValue;
        public string IsSelectedValue { get => _IsSelectedValue; set { _IsSelectedValue = value; OnPropertyChanged(); } }

        private string _Search;
        public string Search { get => _Search; set { _Search = value; OnPropertyChanged(); } }

        private ObservableCollection<ImageDB> _autoImageDelete;
        public ObservableCollection<ImageDB> autoImageDelete { get => _autoImageDelete; set { _autoImageDelete = value; OnPropertyChanged(); } }

        public ICommand SearchButton { get; set; }

        public ICommand PrintsButton { get; set; }

        public ICommand RentalDetailsView { get; set; }

        public ICommand RentalFix { get; set; }

        public ICommand RentalDelete { get; set; }

        public ICommand ContractDetailsCommandWD { get; set; }

        public ICommand RentalContract { get; set; }

        private RentalManagementDB _SelectedItem;
        public RentalManagementDB SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    HouseNo = SelectedItem.HouseNo;
                }
            }
        }

        private Nullable<int> _HouseNo;
        public Nullable<int> HouseNo { get => _HouseNo; set { _HouseNo = value; OnPropertyChanged(); } }

        List<RentalManagementDB> LoadRecord(int page, int recordNum)
        {
            List<RentalManagementDB> result = new List<RentalManagementDB>();
            string Result = null;
            Result = Search;
            result = DataProvider.Ins.DB.RentalManagementDB.Where(t => t.HouseNo.ToString().Contains(Result) || t.HouseName.Contains(Result) || t.HouseAddress.Contains(Result)).OrderBy(a => a.HouseNo).Skip(page).Take(recordNum).ToList();
            return result;
        }
        public RentalSearchViewModel()
        {
            string Result = null;
            List = new ObservableCollection<RentalManagementDB>(DataProvider.Ins.DB.RentalManagementDB.Where(t => t.HouseNo.ToString().Contains(Result) || t.HouseName.Contains(Result) || t.HouseAddress.Contains(Result)));
            #region SearchButton
            //int loadedRecord = 0;
            //int pageNumber = 1;
            //int numberRecord = 10;

            SearchButton = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //List = LoadRecord(loadedRecord, numberRecord);
                RentalSearch selectRentalNo = new RentalSearch();
                
                Result = Search;
                if (!String.IsNullOrWhiteSpace(Result) && Result != null && Result != "")
                {
                    List = new ObservableCollection<RentalManagementDB>(DataProvider.Ins.DB.RentalManagementDB.Where(t => t.HouseNo.ToString().Contains(Result) || t.HouseName.Contains(Result) || t.HouseAddress.Contains(Result)));

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

            PrintsButton = new RelayCommand<object>((p) => { return true; }, (p) => { printsButton(); });
            RentalDetailsView = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RentalSearch selectRentalNo = new RentalSearch();

                if (selectRentalNo.House.Text != "")
                {
                    RentalDetailsView openWindowDetails = new RentalDetailsView(); openWindowDetails.ShowDialog();
                }
                else
                {
                    MessageBox.Show("選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            });
            RentalFix = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RentalSearch selectRentalNo = new RentalSearch();

                if (selectRentalNo.House.Text != "")
                {
                    rentalFixOpenWithWindow();
                }
                else
                {
                    MessageBox.Show("選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            });
            RentalDelete = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RentalSearch selectRentalNo = new RentalSearch();

                if (selectRentalNo.House.Text != "")
                {
                    int isExist = DataProvider.Ins.DB.RentalContactDB.Where(i => i.HouseNo == HouseNo).Count();

                    //if (isExist != 0)
                    //{
                    //    MessageBox.Show("削除が出来ないです。まず賃貸契約（番号：" + HouseNo + "）を削除してください。", "確認", MessageBoxButton.OK, MessageBoxImage.Warning);
                    //}
                    //else
                    //{
                    rentalDelete();
                    selectRentalNo.House.Text = null;
                    //}
                }
                else
                {
                    MessageBox.Show("選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            });

            ContractDetailsCommandWD = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RentalSearch selectRentalNo = new RentalSearch();
                var selectRentalSearch = Int32.Parse(selectRentalNo.House.Text);

                if (selectRentalSearch != 0)
                {
                    if (DataProvider.Ins.DB.ContractDetailsDB.Where(h => h.HouseNo == selectRentalSearch).Count() == 0)
                    {
                        ContractDetails wd = new ContractDetails(); wd.ShowDialog();
                    }
                    else
                    {
                        contractDetailsFixOpenWithWindow();
                    }
                }
                else
                {
                    MessageBox.Show("選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
            RentalContract = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RentalSearch selectRentalNo = new RentalSearch();
                var selectRentalSearch = Int32.Parse(selectRentalNo.House.Text);
                var displayList = DataProvider.Ins.DB.RentalContactDB.Where(x => x.HouseNo == selectRentalSearch);
                int a = displayList.Count();

                if (selectRentalSearch != 0 && selectRentalSearch != null && displayList.Count() == 0)
                {
                    RentalContractInput openWindowRentalContractInput = new RentalContractInput(); openWindowRentalContractInput.ShowDialog();
                }
                else if (displayList.Count() != 0)
                {
                    MessageBox.Show("物件（物件No：" + selectRentalSearch + "）がありました。", "選択", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    MessageBox.Show("選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }
        private void printsButton()
        {
            if (List.Count != 0) // if List.Count = 0 then Search Result not had 
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
                        pa.Workbook.Properties.Title = "賃貸物件詳細";
                        ExcelWorksheet ws = pa.Workbook.Worksheets.Add("賃貸一覧");
                        ws.Name = "賃貸物件詳細";
                        ws.Cells.Style.Font.Size = 11;
                        ws.Cells.Style.Font.Name = "Calibri";

                        string[] arrColumnHeader = {
                                                        "物件番号",
                                                        "物件名",
                                                        "所在地"
                                                        };
                        var countColHeader = arrColumnHeader.Count();

                        ws.Cells[1, 1].Value = "賃貸管理の一覧表示";
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

                        foreach (var item in List)
                        {
                            colIndex = 1;
                            rowIndex++;
                            ws.Cells[rowIndex, colIndex++].Value = item.HouseNo;
                            ws.Cells[rowIndex, colIndex++].Value = item.HouseName;
                            ws.Cells[rowIndex, colIndex++].Value = item.HouseAddress;
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

        private void rentalFixOpenWithWindow()
        {
            RentalSearch rentalSearch = new RentalSearch();
            var rentalSearchHouseNo = Int32.Parse(rentalSearch.House.Text);

            if (rentalSearchHouseNo != 0)
            {
                string Result = null;
                Result = Search;
                Window window = new Window
                {
                    Title = "賃貸修正",
                    Width = 835,
                    Height = 450,
                    Content = new RentalFixs(),
                    ResizeMode = ResizeMode.NoResize,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen,
                    WindowStyle = WindowStyle.None
                };
                window.ShowDialog();
                List = new ObservableCollection<RentalManagementDB>(DataProvider.Ins.DB.RentalManagementDB.Where(t => t.HouseNo.ToString().Contains(Result) || t.HouseName.Contains(Result) || t.HouseAddress.Contains(Result)));
            }
            else
            {
                MessageBox.Show("物件を選択してください！", "Warring", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void rentalDelete()
        {
            RentalSearch rentalSearch = new RentalSearch();
            int rentalHouseDelete = Int32.Parse(rentalSearch.House.Text);
            var resultButtonDeleteHouse = MessageBox.Show("この物件（物件番号：" + rentalHouseDelete + "）を削除しますか？", "警告", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultButtonDeleteHouse == MessageBoxResult.Yes)
            {
                string Result = null;
                Result = Search;

                autoImageDelete = new ObservableCollection<ImageDB>(DataProvider.Ins.DB.ImageDB.Where(img => img.HouseNo == rentalHouseDelete));
                foreach (var imagePathDB in autoImageDelete)
                {
                    string imagePath = imagePathDB.ImagePath;
                    string imageName = imagePathDB.ImageName;
                    DeleteImage(imageName);
                }

                var imageDeleteDB = DataProvider.Ins.DB.ImageDB.Where(imgDelete => imgDelete.HouseNo == rentalHouseDelete);
                DataProvider.Ins.DB.ImageDB.RemoveRange(imageDeleteDB);
                DataProvider.Ins.DB.SaveChanges();

                var HouseDeleteDB = DataProvider.Ins.DB.RentalManagementDB.Where(houseDelete => houseDelete.HouseNo == rentalHouseDelete);
                DataProvider.Ins.DB.RentalManagementDB.RemoveRange(HouseDeleteDB);
                DataProvider.Ins.DB.SaveChanges();

                MessageBox.Show("削除しました！");
                List = new ObservableCollection<RentalManagementDB>(DataProvider.Ins.DB.RentalManagementDB.Where(t => t.HouseNo.ToString().Contains(Result) || t.HouseName.Contains(Result) || t.HouseAddress.Contains(Result)));
                rentalSearch.House.Text = null;
            }
            else
            {
                MessageBox.Show("削除しなかったです。");
            }
        }
        private void contractDetailsFixOpenWithWindow()
        {
            RentalSearch rentalSearch = new RentalSearch();
            var contractSearchHouseNo = rentalSearch.House.Text;

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

                try
                {
                    ContractDetailsFix openWindowDetails = new ContractDetailsFix(); openWindowDetails.ShowDialog();
                }
                catch (Exception e)
                {
                    MessageBox.Show("物件を選択してください！" + e, "Warring", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("物件を選択してください！", "Warring", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void DeleteImage(string nameImage)
        {
            var PathRoot = ConfigurationManager.AppSettings["Path"];

            // Get current working directory (..\bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // GEt the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            // Create specific path file
            string SavePath = string.Format(@"{0}" + PathRoot + "images\\RentalImage\\", projectDirectory);

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
