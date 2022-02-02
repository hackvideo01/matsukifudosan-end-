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
    public class RentalPrintsViewModel : BaseViewModel
    {
        private ObservableCollection<RentalManagementDB> _List;
        public ObservableCollection<RentalManagementDB> List { get => _List; set { _List = value; OnPropertyChanged(); } }

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
                    HouseNo = (int)SelectedItem.HouseNo;
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

        private void printPreview_PrintClick(object sender, EventArgs e)
        {
            PdfDocument doc = new PdfDocument();
            string path = "C:/Users/user/source/repos/matsukifudousan-git-backup/matsukifudousan/files/test.pdf";
            doc.LoadFromFile(path);

            PrintDialog dialogPrint = new PrintDialog();
            dialogPrint.AllowPrintToFile = true;
            dialogPrint.AllowSomePages = true;
            dialogPrint.PrinterSettings.MinimumPage = 1;
            dialogPrint.PrinterSettings.MaximumPage = doc.Pages.Count;
            dialogPrint.PrinterSettings.FromPage = 1;
            dialogPrint.PrinterSettings.ToPage = doc.Pages.Count;
            dialogPrint.PrinterSettings.ToPage = doc.Pages.Count;

            PageSetupDialog setupDlg = new PageSetupDialog();
            PrintDocument printDoc = doc.PrintDocument;
            setupDlg.AllowMargins = false;
            setupDlg.AllowOrientation = false;
            setupDlg.AllowPaper = false;
            setupDlg.AllowPrinter = false;

            if (dialogPrint.ShowDialog() == DialogResult.OK)
            {
                doc.PrintFromPage = dialogPrint.PrinterSettings.FromPage;
                doc.PrintToPage = dialogPrint.PrinterSettings.ToPage;
                doc.PrinterName = dialogPrint.PrinterSettings.PrinterName;
                try
                {
                    //printDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A3", 1169, 1654);
                    printDoc.PrinterSettings =
                        dialogPrint.PrinterSettings;
                    printDoc.Print();
                }
                catch (Exception)
                {
                    System.Windows.MessageBox.Show("プリンターがありません。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }
        public RentalPrintsViewModel()
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

            PDFButton = new RelayCommand<object>((px) => { return true; }, (px) =>
            {
                RentalPrints prs = new RentalPrints();
                string path = savePathFile + "/test.pdf";
                PdfDocument doc = new PdfDocument();
                try
                {
                    doc.LoadFromFile(path);
                }
                catch (Exception)
                {
                    System.Windows.MessageBox.Show("パスが正しくないです。", "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                PrintDialog dialogPrint = new PrintDialog();

                PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                previewDialog.ClientSize =
                    new System.Drawing.Size(400, 300);
                previewDialog.Location =
                    new System.Drawing.Point(29, 29);
                previewDialog.Name = "PrintPreviewDialog1";
                PrintDocument printDoc = doc.PrintDocument;
                previewDialog.Document = printDoc;

                ToolStripButton b = new ToolStripButton();
                b.Image = Bitmap.FromFile(savePathImage + "/printer.png");
                b.DisplayStyle = ToolStripItemDisplayStyle.Image;
                b.Click += printPreview_PrintClick;
                ((ToolStrip)(previewDialog.Controls[1])).Items.RemoveAt(0);
                ((ToolStrip)(previewDialog.Controls[1])).Items.Insert(0, b);

                previewDialog.ShowDialog();
            });

            string Result = null;
            List = new ObservableCollection<RentalManagementDB>(DataProvider.Ins.DB.RentalManagementDB.Where(t => t.HouseNo.ToString().Contains(Result) || t.HouseName.Contains(Result) || t.HouseAddress.Contains(Result)));
            #region SearchButton
            //int loadedRecord = 0;
            //int pageNumber = 1;
            //int numberRecord = 10;

            SearchButton = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RentalPrints rentalPrints = new RentalPrints();
                rentalPrints.House.Text = null;
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
            Combox.Add("物件賃貸契約書");
            //Combox.Add("委任状(土地)");
            Combox.Add("委任状");
            //Combox.Add("管理報告書(2)");
            Combox.Add("管理報告書");
            Combox.Add("契約の種類");
            Combox.Add("建物賃貸借契約書");
            Combox.Add("鍵受取書");
            Combox.Add("取引台帳");
            Combox.Add("住宅賃貸借契約書");
            Combox.Add("住宅賃貸借媒介契約書(貸主用)");
            Combox.Add("重要事項説明書");
            Combox.Add("請求書");
            Combox.Add("駐車場賃貸借契約書");
            Combox.Add("賃貸借契約書");
            Combox.Add("定期建物賃貸借(定期借家)契約についての説明書");
            Combox.Add("定期建物賃貸借契約書(居住用)");
            Combox.Add("土地賃貸借契約書");
            Combox.Add("買付証明書");
            Combox.Add("売渡確認書");
            Combox.Add("物件(入居者名)");
            Combox.Add("明細書");
            Combox.Add("間取り図(賃貸)");
            EXCELButton = new RelayCommand<object>((px) => { return true; }, (px) =>
            {
                RentalPrints select = new RentalPrints();

                //int selectHouseNo = Int32.Parse(select.House.Text);

                if (SelectedPrints == "物件賃貸契約書" && HouseNo != null && HouseNo.ToString() != "")
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
                            //貸主
                            string lender = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().MNGMTCOName;

                            string borrower = "";
                            string RenterAddress = "";
                            string RenterPhoneNumber = "";
                            var checkRentalContact = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == HouseNo);
                            if (checkRentalContact != null && checkRentalContact.Count() != 0)
                            {
                                //借主
                                borrower = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().RenterName;
                                RenterAddress = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().RenterAddress;
                                RenterPhoneNumber = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().RenterPhoneNumber;
                            }

                            //所在地
                            string location = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().HouseAddress;
                            //名称
                            string name = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().HouseName;

                            string room = "";
                            var checkContractDetails = DataProvider.Ins.DB.ContractDetailsDB.Where(r => r.HouseNo == HouseNo);
                            int count = checkContractDetails.Count();
                            if (checkContractDetails != null && checkContractDetails.Count() != 0)
                            {
                                //号室
                                room = DataProvider.Ins.DB.ContractDetailsDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().IssueRoom;
                            }

                            //種類
                            string type = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().HouseType;
                            //構造
                            string structure = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Construction;
                            //総面積
                            string area = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().TotalArea;
                            //駐車場
                            string Parking = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Parking;
                            //家賃・月額 Money
                            string rentMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Rent;
                            //共益費月額　Money
                            string commonFeeMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().CommonFee;
                            //管理費月額　Money
                            string managementFeeMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().ManagementFee;
                            //駐車料月額　Money
                            string parkingFeeMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().ParkingFee;
                            //敷金　Money
                            string securityDepositMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().SecurityDeposit;
                            //礼金　Money
                            string keyMoneyMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().KeyMoney;
                            // Open a File
                            try
                            {
                                this.book = xls.Workbooks.Open(savePathFile + "/建物賃貸借契約書.xlsx");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("パースがないです。");
                            }

                            this.xls.Cells[3, "C"] = lender;
                            this.xls.Cells[4, "C"] = borrower;
                            this.xls.Cells[9, "C"] = location;
                            this.xls.Cells[10, "C"] = name;
                            this.xls.Cells[11, "C"] = room;
                            this.xls.Cells[12, "C"] = type;
                            this.xls.Cells[13, "C"] = structure;
                            this.xls.Cells[14, "C"] = area;
                            this.xls.Cells[16, "C"] = Parking;
                            this.xls.Cells[30, "C"] = rentMoney;
                            this.xls.Cells[31, "C"] = commonFeeMoney;
                            this.xls.Cells[32, "C"] = managementFeeMoney;
                            this.xls.Cells[33, "C"] = parkingFeeMoney;
                            this.xls.Cells[34, "C"] = securityDepositMoney;
                            this.xls.Cells[34, "E"] = keyMoneyMoney;

                            this.xls.Cells[300, "C"] = RenterAddress;
                            this.xls.Cells[300, "E"] = RenterPhoneNumber;
                            this.xls.Cells[303, "C"] = borrower;
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
                else if (SelectedPrints == "間取り図(賃貸)" && HouseNo != null)
                {

                    //if (SelectedPrints == "物件賃貸契約書" && selectHouseNo != null && selectHouseNo != "")
                    //{
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
                                this.book = xls.Workbooks.Open(savePathFile + "/間取り図(賃貸).xlsx");
                                this.sheet = (Excel.Worksheet)book.Worksheets.get_Item(1);
                                this.sheet.Shapes.AddPicture(GuideMapText, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 3, 50, 380, 300);
                                this.sheet.Shapes.AddPicture(FloorPlanText1, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 385, 50, 140, 90);
                                this.sheet.Shapes.AddPicture(FloorPlanText2, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 385, 150, 140, 90);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("パースがないです。");
                            }
                            xls.Cells[4, "L"] = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().HouseAddress;
                            xls.Cells[6, "L"] = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Construction;
                            xls.Cells[11, "L"] = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().TotalArea;
                            xls.Cells[13, "L"] = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Rent;
                            xls.Cells[14, "L"] = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().SecurityDeposit;
                            xls.Cells[15, "L"] = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().KeyMoney;
                            xls.Cells[16, "L"] = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().CommonFee;
                            xls.Cells[17, "L"] = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().ParkingFee;
                            xls.Cells[18, "L"] = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().OtherFee;
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
                else if (SelectedPrints == "委任状" && HouseNo != null)
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
                            //所在地
                            string location = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().HouseAddress;
                            //名称
                            string name = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().HouseName;

                            //家賃・月額 Money
                            string rentMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Rent;
                            //共益費月額　Money
                            string commonFeeMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().CommonFee;
                            //管理費月額　Money
                            string managementFeeMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().ManagementFee;
                            //駐車料月額　Money
                            string parkingFeeMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().ParkingFee;
                            //敷金　Money
                            string securityDepositMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().SecurityDeposit;
                            //礼金　Money
                            string keyMoneyMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().KeyMoney;

                            // Open a File
                            try
                            {
                                this.book = xls.Workbooks.Open(savePathFile + "/委任状.xlsx");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("パースがないです。");
                            }

                            this.xls.Cells[22, "B"] = location;
                            this.xls.Cells[23, "B"] = name;

                            this.xls.Cells[27, "C"] = rentMoney + "円";
                            this.xls.Cells[27, "F"] = managementFeeMoney + "円";
                            this.xls.Cells[27, "H"] = parkingFeeMoney + "円";
                            this.xls.Cells[28, "C"] = securityDepositMoney + "円";
                            this.xls.Cells[28, "F"] = keyMoneyMoney + "円";
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
                else if (SelectedPrints == "管理報告書(2)" && HouseNo != null)
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
                                this.book = xls.Workbooks.Open(savePathFile + "/管理報告書(2).xlsx");
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
                else if (SelectedPrints == "管理報告書" && HouseNo != null)
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
                                this.book = xls.Workbooks.Open(savePathFile + "/管理報告書.xlsx");
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
                else if (SelectedPrints == "契約の種類" && HouseNo != null)
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
                                this.book = xls.Workbooks.Open(savePathFile + "/契約の種類.xlsx");
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
                else if (SelectedPrints == "建物賃貸借契約書" && HouseNo != null)
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
                                this.book = xls.Workbooks.Open(savePathFile + "/建物賃貸借契約書.xlsx");
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
                else if (SelectedPrints == "鍵受取書" && HouseNo != null)
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
                            //貸主
                            string lender = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().MNGMTCOName;

                            string borrower = "";
                            string RenterAddress = "";
                            string RenterPhoneNumber = "";
                            var checkRentalContact = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == HouseNo);
                            if (checkRentalContact != null && checkRentalContact.Count() != 0)
                            {
                                //借主
                                borrower = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().RenterName;
                                RenterAddress = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().RenterAddress;
                                RenterPhoneNumber = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().RenterPhoneNumber;
                            }

                            //所在地
                            string location = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().HouseAddress;
                            //名称
                            string name = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().HouseName;

                            string room = "";
                            var checkContractDetails = DataProvider.Ins.DB.ContractDetailsDB.Where(r => r.HouseNo == HouseNo);
                            int count = checkContractDetails.Count();
                            if (checkContractDetails != null && checkContractDetails.Count() != 0)
                            {
                                //号室
                                room = DataProvider.Ins.DB.ContractDetailsDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().IssueRoom;
                            }

                            //種類
                            string type = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().HouseType;
                            //構造
                            string structure = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Construction;
                            //総面積
                            string area = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().TotalArea;
                            //駐車場
                            string Parking = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Parking;
                            //家賃・月額 Money
                            string rentMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Rent;
                            //共益費月額　Money
                            string commonFeeMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().CommonFee;
                            //管理費月額　Money
                            string managementFeeMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().ManagementFee;
                            //駐車料月額　Money
                            string parkingFeeMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().ParkingFee;
                            //敷金　Money
                            string securityDepositMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().SecurityDeposit;
                            //礼金　Money
                            string keyMoneyMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().KeyMoney;
                            //間取り
                            string Decorate = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Decorate;
                            // Open a File
                            try
                            {
                                this.book = xls.Workbooks.Open(savePathFile + "/鍵受取書.xlsx");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("パースがないです。");
                            }
                            this.xls.Cells[25, "B"] = borrower;
                            this.xls.Cells[26, "B"] = RenterAddress;
                            this.xls.Cells[27, "B"] = RenterPhoneNumber;

                            this.xls.Cells[29, "B"] = location;
                            this.xls.Cells[30, "B"] = name;
                            this.xls.Cells[31, "B"] = room;
                            this.xls.Cells[32, "B"] = structure;
                            this.xls.Cells[33, "B"] = type;

                            this.xls.Cells[34, "B"] = Decorate;
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
                else if (SelectedPrints == "取引台帳" && HouseNo != null)
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
                                this.book = xls.Workbooks.Open(savePathFile + "/取引台帳.xlsx");
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
                else if (SelectedPrints == "住宅賃貸借契約書" && HouseNo != null)
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
                            //貸主
                            string lender = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().MNGMTCOName;

                            string borrower = "";
                            string RenterAddress = "";
                            string RenterPhoneNumber = "";
                            var checkRentalContact = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == HouseNo);
                            if (checkRentalContact != null && checkRentalContact.Count() != 0)
                            {
                                //借主
                                borrower = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().RenterName;
                                RenterAddress = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().RenterAddress;
                                RenterPhoneNumber = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().RenterPhoneNumber;
                            }

                            //所在地
                            string location = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().HouseAddress;
                            //名称
                            string name = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().HouseName;

                            string room = "";
                            var checkContractDetails = DataProvider.Ins.DB.ContractDetailsDB.Where(r => r.HouseNo == HouseNo);
                            int count = checkContractDetails.Count();
                            if (checkContractDetails != null && checkContractDetails.Count() != 0)
                            {
                                //号室
                                room = DataProvider.Ins.DB.ContractDetailsDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().IssueRoom;
                            }

                            //種類
                            string type = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().HouseType;
                            //構造
                            string structure = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Construction;
                            //総面積
                            string area = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().TotalArea;
                            //駐車場
                            string Parking = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Parking;
                            //家賃・月額 Money
                            string rentMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Rent;
                            //共益費月額　Money
                            string commonFeeMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().CommonFee;
                            //管理費月額　Money
                            string managementFeeMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().ManagementFee;
                            //駐車料月額　Money
                            string parkingFeeMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().ParkingFee;
                            //敷金　Money
                            string securityDepositMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().SecurityDeposit;
                            //礼金　Money
                            string keyMoneyMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().KeyMoney;
                            //間取り
                            string Decorate = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Decorate;
                            // Open a File
                            try
                            {
                                this.book = xls.Workbooks.Open(savePathFile + "/住宅賃貸借契約書.xlsx");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("パースがないです。");
                            }
                            this.xls.Cells[2, "C"] = lender;
                            this.xls.Cells[3, "C"] = borrower;

                            this.xls.Cells[7, "C"] = location;
                            this.xls.Cells[8, "C"] = name;
                            this.xls.Cells[9, "C"] = room;
                            this.xls.Cells[10, "C"] = structure;
                            this.xls.Cells[11, "C"] = type;
                            this.xls.Cells[12, "C"] = Decorate;
                            this.xls.Cells[14, "C"] = Parking;

                            this.xls.Cells[22, "E"] = rentMoney;
                            this.xls.Cells[23, "E"] = commonFeeMoney;
                            this.xls.Cells[24, "E"] = managementFeeMoney;
                            this.xls.Cells[25, "E"] = parkingFeeMoney;
                            this.xls.Cells[26, "E"] = securityDepositMoney;
                            this.xls.Cells[26, "I"] = keyMoneyMoney;

                            this.xls.Cells[179, "C"] = RenterAddress;
                            this.xls.Cells[179, "H"] = RenterPhoneNumber;
                            this.xls.Cells[181, "C"] = borrower;
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
                else if (SelectedPrints == "住宅賃貸借媒介契約書(貸主用)" && HouseNo != null)
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
                                this.book = xls.Workbooks.Open(savePathFile + "/住宅賃貸借媒介契約書(貸主用).xlsx");
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
                else if (SelectedPrints == "重要事項説明書" && HouseNo != null)
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
                            //貸主
                            string lender = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().MNGMTCOName;

                            string borrower = "";
                            string RenterAddress = "";
                            string RenterPhoneNumber = "";
                            var checkRentalContact = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == HouseNo);
                            if (checkRentalContact != null && checkRentalContact.Count() != 0)
                            {
                                //借主
                                borrower = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().RenterName;
                                RenterAddress = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().RenterAddress;
                                RenterPhoneNumber = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().RenterPhoneNumber;
                            }

                            //所在地
                            string location = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().HouseAddress;
                            //名称
                            string name = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().HouseName;

                            string room = "";
                            string Electricity = "";
                            string Gas = "";
                            string WaterCrew = "";
                            string Toilet = "";
                            string Bathroom = "";
                            string Stove = "";
                            string LightingEquipment = "";
                            string TelevisionAntenna = "";
                            string AirConditioning = "";
                            string Elevator = "";

                            var checkContractDetails = DataProvider.Ins.DB.ContractDetailsDB.Where(r => r.HouseNo == HouseNo);
                            int count = checkContractDetails.Count();
                            if (checkContractDetails != null && checkContractDetails.Count() != 0)
                            {
                                //号室
                                room = DataProvider.Ins.DB.ContractDetailsDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().IssueRoom;
                                //電気
                                Electricity = DataProvider.Ins.DB.ContractDetailsDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Electricity;
                                //ガス
                                Gas = DataProvider.Ins.DB.ContractDetailsDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Gas;
                                //水道
                                WaterCrew = DataProvider.Ins.DB.ContractDetailsDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().WaterCrew;
                                //トイレ
                                Toilet = DataProvider.Ins.DB.ContractDetailsDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Toilet;
                                //浴室
                                Bathroom = DataProvider.Ins.DB.ContractDetailsDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Bathroom;
                                //コンロ
                                Stove = DataProvider.Ins.DB.ContractDetailsDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Stove;
                                //照明器具
                                LightingEquipment = DataProvider.Ins.DB.ContractDetailsDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().LightingEquipment;
                                //テレビアンテナ
                                TelevisionAntenna = DataProvider.Ins.DB.ContractDetailsDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().TelevisionAntenna;
                                //冷暖房
                                AirConditioning = DataProvider.Ins.DB.ContractDetailsDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().AirConditioning;
                                //エレベーター
                                Elevator = DataProvider.Ins.DB.ContractDetailsDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Elevator;
                            }

                            //種類
                            string type = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().HouseType;
                            //構造
                            string structure = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Construction;
                            //総面積
                            string area = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().TotalArea;
                            //駐車場
                            string Parking = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Parking;
                            //家賃・月額 Money
                            string rentMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Rent;
                            //共益費月額　Money
                            string commonFeeMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().CommonFee;
                            //管理費月額　Money
                            string managementFeeMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().ManagementFee;
                            //駐車料月額　Money
                            string parkingFeeMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().ParkingFee;
                            //敷金　Money
                            string securityDepositMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().SecurityDeposit;
                            //礼金　Money
                            string keyMoneyMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().KeyMoney;
                            //間取り
                            string Decorate = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Decorate;
                            // Open a File
                            try
                            {
                                this.book = xls.Workbooks.Open(savePathFile + "/重要事項説明書.xlsx");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("パースがないです。");
                            }
                            this.xls.Cells[3, "A"] = borrower;

                            this.xls.Cells[18, "E"] = location;
                            this.xls.Cells[19, "E"] = name;
                            this.xls.Cells[20, "E"] = room;
                            this.xls.Cells[21, "E"] = structure;
                            this.xls.Cells[22, "E"] = type;
                            this.xls.Cells[23, "E"] = Decorate;
                            //this.xls.Cells[24, "E"] = Parking;

                            this.xls.Cells[27, "C"] = rentMoney;
                            this.xls.Cells[28, "C"] = commonFeeMoney;
                            this.xls.Cells[29, "C"] = managementFeeMoney;
                            this.xls.Cells[30, "C"] = parkingFeeMoney;
                            this.xls.Cells[31, "C"] = securityDepositMoney;
                            this.xls.Cells[32, "C"] = keyMoneyMoney;

                            this.xls.Cells[27, "F"] = Electricity;
                            this.xls.Cells[28, "F"] = Gas;
                            this.xls.Cells[29, "F"] = WaterCrew;
                            this.xls.Cells[30, "F"] = Toilet;

                            this.xls.Cells[32, "F"] = Bathroom;
                            this.xls.Cells[33, "F"] = Stove;
                            this.xls.Cells[34, "F"] = LightingEquipment;
                            this.xls.Cells[35, "F"] = TelevisionAntenna;

                            this.xls.Cells[37, "F"] = AirConditioning;
                            this.xls.Cells[38, "F"] = Elevator;

                            this.xls.Cells[52, "A"] = RenterAddress;
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
                else if (SelectedPrints == "請求書" && HouseNo != null)
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
                            //貸主
                            string lender = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().MNGMTCOName;

                            string borrower = "";
                            string RenterAddress = "";
                            string RenterPhoneNumber = "";
                            var checkRentalContact = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == HouseNo);
                            if (checkRentalContact != null && checkRentalContact.Count() != 0)
                            {
                                //借主
                                borrower = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().RenterName;
                                RenterAddress = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().RenterAddress;
                                RenterPhoneNumber = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().RenterPhoneNumber;
                            }

                            //所在地
                            string location = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().HouseAddress;
                            //名称
                            string name = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().HouseName;

                            string room = "";
                            string ResidentName1 = "";

                            var checkContractDetails = DataProvider.Ins.DB.ContractDetailsDB.Where(r => r.HouseNo == HouseNo);
                            int count = checkContractDetails.Count();
                            if (checkContractDetails != null && checkContractDetails.Count() != 0)
                            {
                                //号室
                                room = DataProvider.Ins.DB.ContractDetailsDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().IssueRoom;
                                //入居者
                                ResidentName1 = DataProvider.Ins.DB.ContractDetailsDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().ResidentName1;
                            }

                            //種類
                            string type = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().HouseType;
                            //構造
                            string structure = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Construction;
                            //総面積
                            string area = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().TotalArea;
                            //駐車場
                            string Parking = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Parking;
                            //家賃・月額 Money
                            string rentMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Rent;
                            //共益費月額　Money
                            string commonFeeMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().CommonFee;
                            //管理費月額　Money
                            string managementFeeMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().ManagementFee;
                            //駐車料月額　Money
                            string parkingFeeMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().ParkingFee;
                            //敷金　Money
                            string securityDepositMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().SecurityDeposit;
                            //礼金　Money
                            string keyMoneyMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().KeyMoney;
                            //間取り
                            string Decorate = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Decorate;
                            // Open a File
                            try
                            {
                                this.book = xls.Workbooks.Open(savePathFile + "/請求書.xlsx");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("パースがないです。");
                            }

                            this.xls.Cells[6, "A"] = borrower;

                            this.xls.Cells[16, "C"] = securityDepositMoney;
                            this.xls.Cells[17, "C"] = keyMoneyMoney;
                            this.xls.Cells[18, "C"] = rentMoney;
                            this.xls.Cells[19, "C"] = commonFeeMoney;
                            this.xls.Cells[20, "C"] = managementFeeMoney;
                            this.xls.Cells[21, "C"] = parkingFeeMoney;

                            this.xls.Cells[28, "B"] = location;
                            this.xls.Cells[29, "B"] = name;
                            this.xls.Cells[30, "B"] = room;
                            this.xls.Cells[31, "B"] = ResidentName1;

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
                else if (SelectedPrints == "駐車場賃貸借契約書" && HouseNo != null)
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
                                this.book = xls.Workbooks.Open(savePathFile + "/駐車場賃貸借契約書.xlsx");
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
                else if (SelectedPrints == "賃貸借契約書" && HouseNo != null)
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
                                this.book = xls.Workbooks.Open(savePathFile + "/賃貸借契約書.xlsx");
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
                else if (SelectedPrints == "定期建物賃貸借(定期借家)契約についての説明書" && HouseNo != null)
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
                                this.book = xls.Workbooks.Open(savePathFile + "/定期建物賃貸借(定期借家)契約についての説明書.xlsx");
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
                else if (SelectedPrints == "定期建物賃貸借契約書(居住用)" && HouseNo != null)
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
                                this.book = xls.Workbooks.Open(savePathFile + "/定期建物賃貸借契約書(居住用).xlsx");
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
                else if (SelectedPrints == "土地賃貸借契約書" && HouseNo != null)
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
                                this.book = xls.Workbooks.Open(savePathFile + "/土地賃貸借契約書.xlsx");
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
                else if (SelectedPrints == "物件(入居者名)" && HouseNo != null)
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
                                this.book = xls.Workbooks.Open(savePathFile + "/物件(入居者名).xlsx");
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
                else if (SelectedPrints == "明細書" && HouseNo != null)
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
                            //貸主
                            string lender = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().MNGMTCOName;

                            string borrower = "";
                            string RenterAddress = "";
                            string RenterPhoneNumber = "";
                            var checkRentalContact = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == HouseNo);
                            if (checkRentalContact != null && checkRentalContact.Count() != 0)
                            {
                                //借主
                                borrower = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().RenterName;
                                RenterAddress = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().RenterAddress;
                                RenterPhoneNumber = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().RenterPhoneNumber;
                            }

                            //所在地
                            string location = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().HouseAddress;
                            //名称
                            string name = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().HouseName;

                            string room = "";
                            string ResidentName1 = "";

                            var checkContractDetails = DataProvider.Ins.DB.ContractDetailsDB.Where(r => r.HouseNo == HouseNo);
                            int count = checkContractDetails.Count();
                            if (checkContractDetails != null && checkContractDetails.Count() != 0)
                            {
                                //号室
                                room = DataProvider.Ins.DB.ContractDetailsDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().IssueRoom;
                                //入居者
                                ResidentName1 = DataProvider.Ins.DB.ContractDetailsDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().ResidentName1;
                            }

                            //種類
                            string type = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().HouseType;
                            //構造
                            string structure = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Construction;
                            //総面積
                            string area = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().TotalArea;
                            //駐車場
                            string Parking = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Parking;
                            //家賃・月額 Money
                            string rentMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Rent;
                            //共益費月額　Money
                            string commonFeeMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().CommonFee;
                            //管理費月額　Money
                            string managementFeeMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().ManagementFee;
                            //駐車料月額　Money
                            string parkingFeeMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().ParkingFee;
                            //敷金　Money
                            string securityDepositMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().SecurityDeposit;
                            //礼金　Money
                            string keyMoneyMoney = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().KeyMoney;
                            //間取り
                            string Decorate = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == HouseNo).FirstOrDefault().Decorate;
                            // Open a File
                            try
                            {
                                this.book = xls.Workbooks.Open(savePathFile + "/明細書.xlsx");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("パースがないです。");
                            }

                            this.xls.Cells[6, "A"] = borrower;

                            this.xls.Cells[16, "C"] = securityDepositMoney;
                            this.xls.Cells[17, "C"] = keyMoneyMoney;
                            this.xls.Cells[18, "C"] = rentMoney;
                            this.xls.Cells[19, "C"] = commonFeeMoney;
                            this.xls.Cells[20, "C"] = managementFeeMoney;
                            this.xls.Cells[21, "C"] = parkingFeeMoney;

                            this.xls.Cells[25, "B"] = location;
                            this.xls.Cells[26, "B"] = name;
                            this.xls.Cells[27, "B"] = ResidentName1;
                        }
                        //this.sheet =
                        //(Microsoft.Office.Interop.Excel.Worksheet)this.book.Sheets[sheetName];
                        ExcelVisibleToggle(xls, true);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("もう一度印刷してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
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
                RentalPrints select = new RentalPrints();

                string selectHouseNo = select.House.Text;

                if (SelectedPrints == "間取り図(賃貸)" && selectHouseNo != null && selectHouseNo != "")
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
                else if (SelectedPrints == "間取り図(賃貸)" && (selectHouseNo == null || selectHouseNo == ""))
                {
                    MessageBox.Show("物件を選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("間取り図(賃貸)を選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
            FloorPlan1 = new RelayCommand<object>((gm) => { return true; }, (gm) =>
            {
                RentalPrints select = new RentalPrints();

                string selectHouseNo = select.House.Text;

                if (SelectedPrints == "間取り図(賃貸)" && selectHouseNo != null && selectHouseNo != "")
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
                else if (SelectedPrints == "間取り図(賃貸)" && (selectHouseNo == null || selectHouseNo == ""))
                {
                    MessageBox.Show("物件を選択してください。。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("間取り図(賃貸)を選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            FloorPlan2 = new RelayCommand<object>((gm) => { return true; }, (gm) =>
            {
                RentalPrints select = new RentalPrints();

                string selectHouseNo = select.House.Text;

                if (SelectedPrints == "間取り図(賃貸)" && selectHouseNo != null && selectHouseNo != "")
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
                else if (SelectedPrints == "間取り図(賃貸)" && (selectHouseNo == null || selectHouseNo == ""))
                {
                    MessageBox.Show("物件を選択してください。。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("間取り図(賃貸)を選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
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
