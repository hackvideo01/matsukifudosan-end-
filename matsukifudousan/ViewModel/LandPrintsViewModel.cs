using GemBox.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ExcelWorksheet = GemBox.Spreadsheet.ExcelWorksheet;
using System.Windows.Controls;
using System.Windows.Forms;
using PrintDialog = System.Windows.Forms.PrintDialog;
using System.Threading;
using System.Drawing.Printing;
using DocumentFormat.OpenXml.Wordprocessing;
using GleamTech.FileSystems.AmazonS3;
using System.Drawing;
using Spire.Pdf;
using Spire.Xls;
using matsukifudousan.Model;
using System.Collections.ObjectModel;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using MessageBox = System.Windows.MessageBox;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;
using Microsoft.Office.Interop.Excel;
using Picture = Microsoft.Office.Interop.Excel.Picture;
using System.Configuration;

namespace matsukifudousan.ViewModel
{
    public class LandPrintsViewModel : BaseViewModel
    {
        private ObservableCollection<LandDB> _List;
        public ObservableCollection<LandDB> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _Combox = new ObservableCollection<Object>();
        public ObservableCollection<Object> Combox { get => _Combox; set { _Combox = value; OnPropertyChanged(); } }

        private string _Search;
        public string Search { get => _Search; set { _Search = value; OnPropertyChanged(); } }

        private Nullable<int> _HouseNo;
        public Nullable<int> HouseNo { get => _HouseNo; set { _HouseNo = value; OnPropertyChanged(); } }

        private string _SelectedPrints;
        public string SelectedPrints { get => _SelectedPrints; set { _SelectedPrints = value; OnPropertyChanged(); } }

        private string _FloorPlanText1;
        public string FloorPlanText1 { get => _FloorPlanText1; set { _FloorPlanText1 = value; OnPropertyChanged(); } }

        private string _FloorPlanText2;
        public string FloorPlanText2 { get => _FloorPlanText2; set { _FloorPlanText2 = value; OnPropertyChanged(); } }

        private string _GuideMapText;
        public string GuideMapText { get => _GuideMapText; set { _GuideMapText = value; OnPropertyChanged(); } }

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
                    HouseNo = SelectedItem.LandNo;
                }
            }
        }

        public ICommand PDFButton { get; set; }

        public ICommand EXCELButton { get; set; }

        public ICommand EXCELButton2 { get; set; }

        public ICommand SearchButton { get; set; }

        public ICommand GuideMap { get; set; }

        public ICommand FloorPlan1 { get; set; }

        public ICommand FloorPlan2 { get; set; }

        private bool isNewXlsFile = false;
        private Microsoft.Office.Interop.Excel.Application xls = null;
        private Microsoft.Office.Interop.Excel.Workbook book = null;
        private Microsoft.Office.Interop.Excel.Worksheet sheet = null;

        public LandPrintsViewModel()
        {
            var Path = ConfigurationManager.AppSettings["Path"];

            // Get current working directory (..\bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // GEt the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            // Create specific path file
            string savePathFile = string.Format(@"{0}" + Path + "files", projectDirectory);
            // Create specific path image
            string savePathImage = string.Format(@"{0}" + Path + "images", projectDirectory);

            string Result = null;
            List = new ObservableCollection<LandDB>(DataProvider.Ins.DB.LandDB.Where(t => t.LandNo.ToString().Contains(Result) || t.LandName.Contains(Result) || t.LandAddress.Contains(Result)));
            #region SearchButton
            //int loadedRecord = 0;
            //int pageNumber = 1;
            //int numberRecord = 10;

            SearchButton = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LandPrints LandPrints = new LandPrints();
                LandPrints.House.Text = null;
                Result = Search;
                if (!String.IsNullOrWhiteSpace(Result) && Result != null && Result != "")
                {
                    List = new ObservableCollection<LandDB>(DataProvider.Ins.DB.LandDB.Where(t => t.LandNo.ToString().Contains(Result) || t.LandName.Contains(Result) || t.LandAddress.Contains(Result)));

                    if (List.Count == 0)
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
            Combox.Add("委任状(土地)");
            Combox.Add("買付証明書");
            Combox.Add("売渡確認書");
            Combox.Add("間取り図(土地)");
            EXCELButton = new RelayCommand<object>((px) => { return true; }, (px) =>
            {
                LandPrints select = new LandPrints();

                //int selectHouseNo = Int32.Parse(select.House.Text);
                if (SelectedPrints == "間取り図(土地)" && HouseNo != null)
                {
                    try
                    {
                        this.xls = new Microsoft.Office.Interop.Excel.Application();
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
                                this.book = xls.Workbooks.Open(savePathFile + "/間取り図(土地).xlsx");
                                this.sheet = (Excel.Worksheet)book.Worksheets.get_Item(1);

                                if (GuideMapText != null)
                                {
                                    this.sheet.Shapes.AddPicture(GuideMapText, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 3, 50, 380, 300);
                                }

                                if (FloorPlanText1 != null)
                                {
                                    this.sheet.Shapes.AddPicture(FloorPlanText1, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 385, 50, 140, 90);
                                }

                                if (FloorPlanText2 != null)
                                {
                                    this.sheet.Shapes.AddPicture(FloorPlanText2, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 385, 150, 140, 90);
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("パースがないです。");
                            }
                            xls.Cells[2, "L"] = DataProvider.Ins.DB.LandDB.Where(r => r.LandNo == HouseNo).FirstOrDefault().LandName;
                            xls.Cells[4, "L"] = DataProvider.Ins.DB.LandDB.Where(r => r.LandNo == HouseNo).FirstOrDefault().LandAddress;
                            xls.Cells[7, "L"] = DataProvider.Ins.DB.LandDB.Where(r => r.LandNo == HouseNo).FirstOrDefault().LandArea;
                            xls.Cells[11, "L"] = DataProvider.Ins.DB.LandDB.Where(r => r.LandNo == HouseNo).FirstOrDefault().LandRights;
                            xls.Cells[12, "L"] = DataProvider.Ins.DB.LandDB.Where(r => r.LandNo == HouseNo).FirstOrDefault().Ground;
                            xls.Cells[13, "L"] = DataProvider.Ins.DB.LandDB.Where(r => r.LandNo == HouseNo).FirstOrDefault().CurrentSituation;
                            xls.Cells[14, "L"] = DataProvider.Ins.DB.LandDB.Where(r => r.LandNo == HouseNo).FirstOrDefault().Terrain;
                            xls.Cells[15, "L"] = DataProvider.Ins.DB.LandDB.Where(r => r.LandNo == HouseNo).FirstOrDefault().Price;
                            xls.Cells[16, "L"] = DataProvider.Ins.DB.LandDB.Where(r => r.LandNo == HouseNo).FirstOrDefault().UnitPrice;
                        }


                        ExcelVisibleToggle(xls, true);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("もう一度印刷してください。" + e);
                    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("書類を選択ください。");
                    //}
                }
                else if (SelectedPrints == "委任状(土地)" && HouseNo != null)
                {
                    try
                    {
                        this.xls = new Microsoft.Office.Interop.Excel.Application();
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
                                this.book = xls.Workbooks.Open(savePathFile + "/委任状(土地).xlsx");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("パースがないです。");
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
                else if (SelectedPrints == "買付証明書" && HouseNo != null)
                {
                    try
                    {
                        this.xls = new Microsoft.Office.Interop.Excel.Application();
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
                                this.book = xls.Workbooks.Open(savePathFile + "/買付証明書.xlsx");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("パースがないです。");
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
                else if (SelectedPrints == "売渡確認書" && HouseNo != null)
                {
                    try
                    {
                        this.xls = new Microsoft.Office.Interop.Excel.Application();
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
                                this.book = xls.Workbooks.Open(savePathFile + "/売渡確認書.xlsx");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("パースがないです。");
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
                else if (SelectedPrints == null && HouseNo != null)
                {
                    MessageBox.Show("書類を選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (SelectedPrints != null && HouseNo == null)
                {
                    MessageBox.Show("物件を選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("物件と書類を選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            GuideMap = new RelayCommand<object>((gm) => { return true; }, (gm) =>
            {
                LandPrints select = new LandPrints();

                string selectHouseNo = select.House.Text;

                if (SelectedPrints == "間取り図(土地)" && selectHouseNo != null && selectHouseNo != "")
                {
                    OpenFileDialog openDialog = new OpenFileDialog();
                    openDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
                    if (openDialog.ShowDialog() == true)
                    {
                        GuideMapText = openDialog.FileName;
                        //MessageBox.Show(guidMap);
                    }

                    //Excel.Application xlApp;
                    //Excel.Workbook xlWorkBook;
                    //Excel.Worksheet xlWorkSheet;
                    //object misValue = System.Reflection.Missing.Value;

                    //xlApp = new Excel.Application();
                    //xlWorkBook = xlApp.Workbooks.Add(misValue);
                    //xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    ////add some text 
                    //xlWorkSheet.Cells[1, 1] = "http://csharp.net-informations.com";
                    //xlWorkSheet.Cells[2, "A"] = "Adding picture in Excel File";

                    //xlWorkSheet.Shapes.AddPicture(savePathImage + "\\bk.jpg", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 300, 300, 300, 300);


                    //xlWorkBook.SaveAs("csharp.net-informations.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    //xlWorkBook.Close(true, misValue, misValue);
                    //xlApp.Quit();


                    //MessageBox.Show("File created !");
                }
                else if (SelectedPrints == "間取り図(土地)" && (selectHouseNo == null || selectHouseNo == ""))
                {
                    MessageBox.Show("物件を選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("間取り図(土地)を選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
            FloorPlan1 = new RelayCommand<object>((gm) => { return true; }, (gm) =>
            {
                LandPrints select = new LandPrints();

                string selectHouseNo = select.House.Text;

                if (SelectedPrints == "間取り図(土地)" && selectHouseNo != null && selectHouseNo != "")
                {
                    OpenFileDialog openDialog = new OpenFileDialog();
                    openDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
                    if (openDialog.ShowDialog() == true)
                    {
                        FloorPlanText1 = openDialog.FileName;
                        //MessageBox.Show(FloorPlanText);
                    }

                    //Excel.Application xlApp;
                    //Excel.Workbook xlWorkBook;
                    //Excel.Worksheet xlWorkSheet;
                    //object misValue = System.Reflection.Missing.Value;

                    //xlApp = new Excel.Application();
                    //xlWorkBook = xlApp.Workbooks.Add(misValue);
                    //xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    ////add some text 
                    //xlWorkSheet.Cells[1, 1] = "http://csharp.net-informations.com";
                    //xlWorkSheet.Cells[2, "A"] = "Adding picture in Excel File";

                    //xlWorkSheet.Shapes.AddPicture(savePathImage + "\\bk.jpg", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 300, 300, 300, 300);


                    //xlWorkBook.SaveAs("csharp.net-informations.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    //xlWorkBook.Close(true, misValue, misValue);
                    //xlApp.Quit();


                    //MessageBox.Show("File created !");
                }
                else if (SelectedPrints == "間取り図(土地)" && (selectHouseNo == null || selectHouseNo == ""))
                {
                    MessageBox.Show("物件を選択してください。。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("間取り図(土地)を選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            FloorPlan2 = new RelayCommand<object>((gm) => { return true; }, (gm) =>
            {
                LandPrints select = new LandPrints();

                string selectHouseNo = select.House.Text;

                if (SelectedPrints == "間取り図(土地)" && selectHouseNo != null && selectHouseNo != "")
                {
                    OpenFileDialog openDialog = new OpenFileDialog();
                    openDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
                    if (openDialog.ShowDialog() == true)
                    {
                        FloorPlanText2 = openDialog.FileName;
                        //MessageBox.Show(FloorPlanText);
                    }

                    //Excel.Application xlApp;
                    //Excel.Workbook xlWorkBook;
                    //Excel.Worksheet xlWorkSheet;
                    //object misValue = System.Reflection.Missing.Value;

                    //xlApp = new Excel.Application();
                    //xlWorkBook = xlApp.Workbooks.Add(misValue);
                    //xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    ////add some text 
                    //xlWorkSheet.Cells[1, 1] = "http://csharp.net-informations.com";
                    //xlWorkSheet.Cells[2, "A"] = "Adding picture in Excel File";

                    //xlWorkSheet.Shapes.AddPicture(savePathImage + "\\bk.jpg", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 300, 300, 300, 300);


                    //xlWorkBook.SaveAs("csharp.net-informations.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    //xlWorkBook.Close(true, misValue, misValue);
                    //xlApp.Quit();


                    //MessageBox.Show("File created !");
                }
                else if (SelectedPrints == "間取り図(土地)" && (selectHouseNo == null || selectHouseNo == ""))
                {
                    MessageBox.Show("物件を選択してください。。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("間取り図(土地)を選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
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
