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
using System.Configuration;

namespace matsukifudousan.ViewModel
{
    public class LandSearchViewModel : BaseViewModel
    {
        private ObservableCollection<LandDB> _List;
        public ObservableCollection<LandDB> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private string _Search;
        public string Search { get => _Search; set { _Search = value; OnPropertyChanged(); } }

        private int _HouseNumbers;
        public int HouseNumbers { get => _HouseNumbers; set { _HouseNumbers = value; OnPropertyChanged(); } }

        private ObservableCollection<ImageDB> _autoImageDelete;
        public ObservableCollection<ImageDB> autoImageDelete { get => _autoImageDelete; set { _autoImageDelete = value; OnPropertyChanged(); } }

        public ICommand SearchButton { get; set; }

        public ICommand PrintsButton { get; set; }

        public ICommand LandDetailsView { get; set; }

        public ICommand LandFix { get; set; }

        public ICommand LandDelete { get; set; }

        public ICommand TotalSearch { get; set; }

        private LandDB _SelectedItem;
        public LandDB SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    LandNo = (int)SelectedItem.LandNo;
                }
            }
        }

        private Nullable<int> _LandNo;
        public Nullable<int> LandNo { get => _LandNo; set { _LandNo = value; OnPropertyChanged(); } }

        public LandSearchViewModel()
        {
            string Result = null;
            List = new ObservableCollection<LandDB>(DataProvider.Ins.DB.LandDB.Where(t => t.LandNo.ToString().Contains(Result) || t.LandName.Contains(Result) || t.LandAddress.Contains(Result)));
            #region SearchButton
            SearchButton = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LandSearch selectLandNo = new LandSearch();
                //selectLandNo.LandNo.Text = null;
                Result = Search;
                if (!String.IsNullOrWhiteSpace(Result) && Result != null && Result != "")
                {
                    List = new ObservableCollection<LandDB>(DataProvider.Ins.DB.LandDB.Where(t => t.LandNo.ToString().Contains(Result) || t.LandName.Contains(Result) || t.LandAddress.Contains(Result)));
                    HouseNumbers = List.Count;
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
                List = new ObservableCollection<LandDB>(DataProvider.Ins.DB.LandDB.ToList());
                HouseNumbers = List.Count;
            });
            PrintsButton = new RelayCommand<object>((p) => { return true; }, (p) => { printsButton(); });
            LandDetailsView = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LandSearch selectLandNo = new LandSearch();

                if (selectLandNo.LandNo.Text != "")
                {
                    LandDetailsView openLand = new LandDetailsView(); openLand.ShowDialog();
                }
                else
                {
                    MessageBox.Show("物件を選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            });
            LandFix = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LandSearch selectLandNo = new LandSearch();

                if (selectLandNo.LandNo.Text != "")
                {
                    landFixOpenWithWindow();
                }
                else
                {
                    MessageBox.Show("物件を選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            });
            LandDelete = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LandSearch selectLandNo = new LandSearch();
                if (selectLandNo.LandNo.Text != "")
                {
                    landDelete();
                    selectLandNo.LandNo.Text = null;
                    List = new ObservableCollection<LandDB>(DataProvider.Ins.DB.LandDB.Where(t => t.LandNo.ToString().Contains(Result) || t.LandName.Contains(Result) || t.LandAddress.Contains(Result)));
                }
                else
                {
                    MessageBox.Show("物件を選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Question);
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
                            ws.Cells[rowIndex, colIndex++].Value = item.LandNo;
                            ws.Cells[rowIndex, colIndex++].Value = item.LandName;
                            ws.Cells[rowIndex, colIndex++].Value = item.LandAddress;
                        }
                        Byte[] bin = pa.GetAsByteArray();
                        File.WriteAllBytes(filePath, bin);
                    }
                    MessageBox.Show("一覧表示からリスト印刷出来ました❣", "成功", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception EE)
                {
                    MessageBox.Show("エラーがありました❕" + EE, "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("一覧表示がなかったです。検索のは検索してください❕", "検索しなかった", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        private void landFixOpenWithWindow()
        {
            LandSearch landSearch = new LandSearch();
            var landSearchNo = landSearch.LandNo.Text;
            if (landSearchNo != "")
            {
                Window window = new Window
                {
                    Title = "土地詳細",
                    Width = 835,
                    Height = 450,
                    Content = new LandFixs(),
                    ResizeMode = ResizeMode.NoResize,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen,
                    WindowStyle = WindowStyle.None
                };
                window.ShowDialog();
                List = new ObservableCollection<LandDB>(DataProvider.Ins.DB.LandDB.Where(t => t.LandNo.ToString().Contains(Search) || t.LandName.Contains(Search) || t.LandAddress.Contains(Search)));
            }
            else
            {
                MessageBox.Show("物件を選択してください！", "Warring", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void landDelete()
        {
            LandSearch landSearch = new LandSearch();
            int landSearchNo = Int32.Parse(landSearch.LandNo.Text);
            var resultButtonDeleteHouse = MessageBox.Show("この物件（物件番号：" + landSearchNo + "）を削除しますか？", "警告", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultButtonDeleteHouse == MessageBoxResult.Yes)
            {
                autoImageDelete = new ObservableCollection<ImageDB>(DataProvider.Ins.DB.ImageDB.Where(img => img.LandNo == landSearchNo));
                foreach (var imagePathDB in autoImageDelete)
                {
                    string imagePath = imagePathDB.ImagePath;
                    string imageName = imagePathDB.ImageName;
                    DeleteImage(imageName);
                }

                var imageDeleteDB = DataProvider.Ins.DB.ImageDB.Where(imgDelete => imgDelete.LandNo == landSearchNo);
                DataProvider.Ins.DB.ImageDB.RemoveRange(imageDeleteDB);
                DataProvider.Ins.DB.SaveChanges();

                var landDeleteDB = DataProvider.Ins.DB.LandDB.Where(dtDelete => dtDelete.LandNo == landSearchNo);
                DataProvider.Ins.DB.LandDB.RemoveRange(landDeleteDB);
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
            var PathRoot = ConfigurationManager.AppSettings["Path"];

            // Get current working directory (..\bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // GEt the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            // Create specific path file
            string SavePath = string.Format(@"{0}" + PathRoot + "images\\LandImage\\", projectDirectory);

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
