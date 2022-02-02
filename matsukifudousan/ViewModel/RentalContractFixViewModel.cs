using matsukifudousan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Org.BouncyCastle.Bcpg.OpenPgp;
using ImageDB = matsukifudousan.Model.ImageDB;
using Image = System.Windows.Controls.Image;
using BatchedObservableCollection.Batch;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2013.PowerPoint;
using GleamTech.Util;
using ImageProcessor.Common.Extensions;
using MaterialDesignThemes.Wpf;
using Brushes = System.Windows.Media.Brushes;
using Button = System.Windows.Controls.Button;
using Control = System.Windows.Controls.Control;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using Orientation = System.Windows.Controls.Orientation;
using Excel = Microsoft.Office.Interop.Excel;

namespace matsukifudousan.ViewModel
{
    public class RentalContractFixViewModel : BaseViewModel
    {
        #region RentalPayment Item Input
        private int _HouseNo;
        public int HouseNo { get => _HouseNo; set { _HouseNo = value; OnPropertyChanged(); } }

        private string _ContractDate;
        public string ContractDate { get => _ContractDate; set { _ContractDate = value; OnPropertyChanged(); } }

        private string _RenterName;
        public string RenterName { get => _RenterName; set { _RenterName = value; OnPropertyChanged(); } }

        private string _RenterAddressNo;
        public string RenterAddressNo { get => _RenterAddressNo; set { _RenterAddressNo = value; OnPropertyChanged(); } }

        private string _RenterAddress;
        public string RenterAddress { get => _RenterAddress; set { _RenterAddress = value; OnPropertyChanged(); } }

        private string _RenterPhoneNumber;
        public string RenterPhoneNumber { get => _RenterPhoneNumber; set { _RenterPhoneNumber = value; OnPropertyChanged(); } }

        private string _RenterBirthday;
        public string RenterBirthday { get => _RenterBirthday; set { _RenterBirthday = value; OnPropertyChanged(); } }

        private string _RenterOfficeName;
        public string RenterOfficeName { get => _RenterOfficeName; set { _RenterOfficeName = value; OnPropertyChanged(); } }

        private string _RenterOfficePhone;
        public string RenterOfficePhone { get => _RenterOfficePhone; set { _RenterOfficePhone = value; OnPropertyChanged(); } }

        private string _RentName;
        public string RentName { get => _RentName; set { _RentName = value; OnPropertyChanged(); } }

        private string _RentAddressNo;
        public string RentAddressNo { get => _RentAddressNo; set { _RentAddressNo = value; OnPropertyChanged(); } }

        private string _RentAddress;
        public string RentAddress { get => _RentAddress; set { _RentAddress = value; OnPropertyChanged(); } }

        private string _RentPhoneNumber;
        public string RentPhoneNumber { get => _RentPhoneNumber; set { _RentPhoneNumber = value; OnPropertyChanged(); } }

        private string _RentBirthday;
        public string RentBirthday { get => _RentBirthday; set { _RentBirthday = value; OnPropertyChanged(); } }

        private string _RentOfficeName;
        public string RentOfficeName { get => _RentOfficeName; set { _RentOfficeName = value; OnPropertyChanged(); } }

        private string _RentOfficePhone;
        public string RentOfficePhone { get => _RentOfficePhone; set { _RentOfficePhone = value; OnPropertyChanged(); } }

        private string _JointGuarantorName1;
        public string JointGuarantorName1 { get => _JointGuarantorName1; set { _JointGuarantorName1 = value; OnPropertyChanged(); } }

        private string _JointGuarantorAddressNo1;
        public string JointGuarantorAddressNo1 { get => _JointGuarantorAddressNo1; set { _JointGuarantorAddressNo1 = value; OnPropertyChanged(); } }

        private string _JointGuarantorAddress1;
        public string JointGuarantorAddress1 { get => _JointGuarantorAddress1; set { _JointGuarantorAddress1 = value; OnPropertyChanged(); } }

        private string _JointGuarantorPhone1;
        public string JointGuarantorPhone1 { get => _JointGuarantorPhone1; set { _JointGuarantorPhone1 = value; OnPropertyChanged(); } }

        private string _JointGuarantorBirthday1;
        public string JointGuarantorBirthday1 { get => _JointGuarantorBirthday1; set { _JointGuarantorBirthday1 = value; OnPropertyChanged(); } }

        private string _JointGuarantorOfficeName1;
        public string JointGuarantorOfficeName1 { get => _JointGuarantorOfficeName1; set { _JointGuarantorOfficeName1 = value; OnPropertyChanged(); } }

        private string _JointGuarantorOfficePhone1;
        public string JointGuarantorOfficePhone1 { get => _JointGuarantorOfficePhone1; set { _JointGuarantorOfficePhone1 = value; OnPropertyChanged(); } }

        private string _JointGuarantorName2;
        public string JointGuarantorName2 { get => _JointGuarantorName2; set { _JointGuarantorName2 = value; OnPropertyChanged(); } }

        private string _JointGuarantorAddressNo2;
        public string JointGuarantorAddressNo2 { get => _JointGuarantorAddressNo2; set { _JointGuarantorAddressNo2 = value; OnPropertyChanged(); } }

        private string _JointGuarantorAddress2;
        public string JointGuarantorAddress2 { get => _JointGuarantorAddress2; set { _JointGuarantorAddress2 = value; OnPropertyChanged(); } }

        private string _JointGuarantorPhone2;
        public string JointGuarantorPhone2 { get => _JointGuarantorPhone2; set { _JointGuarantorPhone2 = value; OnPropertyChanged(); } }

        private string _JointGuarantorBirthday2;
        public string JointGuarantorBirthday2 { get => _JointGuarantorBirthday2; set { _JointGuarantorBirthday2 = value; OnPropertyChanged(); } }

        private string _JointGuarantorOfficeName2;
        public string JointGuarantorOfficeName2 { get => _JointGuarantorOfficeName2; set { _JointGuarantorOfficeName2 = value; OnPropertyChanged(); } }

        private string _JointGuarantorOfficePhone2;
        public string JointGuarantorOfficePhone2 { get => _JointGuarantorOfficePhone2; set { _JointGuarantorOfficePhone2 = value; OnPropertyChanged(); } }

        private string _ComboxPrints;
        public string ComboxPrints { get => _ComboxPrints; set { _ComboxPrints = value; OnPropertyChanged(); } }

        private string _rentalContractSearchHouseNo;
        public string rentalContractSearchHouseNo { get => _rentalContractSearchHouseNo; set { _rentalContractSearchHouseNo = value; OnPropertyChanged(); } }

        #endregion

        private ObservableCollection<Object> _ComboxPrintsChoose = new ObservableCollection<Object>();
        public ObservableCollection<Object> ComboxPrintsChoose { get => _ComboxPrintsChoose; set { _ComboxPrintsChoose = value; OnPropertyChanged(); } }

        public ICommand AddRentalContractCommand { get; set; }

        public ICommand PrintsRentalContract { get; set; }

        public ICommand deleteAction { get; set; }

        public int Comfirm = 0;

        private bool isNewXlsFile = false;
        private Microsoft.Office.Interop.Excel.Application xls = null;
        private Microsoft.Office.Interop.Excel.Workbook book = null;
        private Microsoft.Office.Interop.Excel.Worksheet sheet = null;

        public RentalContractFixViewModel()
        {
            reload();
            // Get current working directory (..\bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // GEt the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            // Create specific path file
            string savePathFile = string.Format(@"{0}\\matsuki\matsuki\files", projectDirectory);
            // Create specific path image
            string savePathImage = string.Format(@"{0}\\matsuki\matsuki\images", projectDirectory);

            RentalContractSearch Result = new RentalContractSearch();
            int resultSearch = Int32.Parse(Result.House.Text);

            AddRentalContractCommand = new RelayCommand<object>((p) =>
            {
                //if (string.IsNullOrEmpty(HouseNo))
                //    return false;

                //var displayList = DataProvider.Ins.DB.RentalContactDB.Where(x => x.HouseNo == HouseNo);
                //if (displayList == null || displayList.Count() != 0) // if displayList = 0 then HouseNo had in database
                //    return false;

                return true;
            }, (p) =>
            {
                if (Comfirm == 0)
                {
                    var AddRentalContract = DataProvider.Ins.DB.RentalContactDB.Where(hno => hno.HouseNo == resultSearch).SingleOrDefault();
                    AddRentalContract.ContractDate = ContractDate;
                    AddRentalContract.RenterName = RenterName;
                    AddRentalContract.RenterAddressNo = RenterAddressNo;
                    AddRentalContract.RenterAddress = RenterAddress;
                    AddRentalContract.RenterPhoneNumber = RenterPhoneNumber;
                    AddRentalContract.RenterBirthday = RenterBirthday;
                    AddRentalContract.RenterOfficeName = RenterOfficeName;
                    AddRentalContract.RenterOfficePhone = RenterOfficeName;
                    AddRentalContract.RentName = RentName;
                    AddRentalContract.RentAddressNo = RentAddressNo;
                    AddRentalContract.RentAddress = RentAddress;
                    AddRentalContract.RentPhoneNumber = RentPhoneNumber;
                    AddRentalContract.RentBirthday = RentBirthday;
                    AddRentalContract.RentOfficeName = RentOfficeName;
                    AddRentalContract.RentOfficePhone = RentOfficePhone;
                    AddRentalContract.JointGuarantorName1 = JointGuarantorName1;
                    AddRentalContract.JointGuarantorAddressNo1 = JointGuarantorAddressNo1;
                    AddRentalContract.JointGuarantorAddress1 = JointGuarantorAddress1;
                    AddRentalContract.JointGuarantorPhone1 = JointGuarantorPhone1;
                    AddRentalContract.JointGuarantorBirthday1 = JointGuarantorBirthday1;
                    AddRentalContract.JointGuarantorOfficeName1 = JointGuarantorOfficeName1;
                    AddRentalContract.JointGuarantorOfficePhone1 = JointGuarantorOfficePhone1;
                    AddRentalContract.JointGuarantorName2 = JointGuarantorName2;
                    AddRentalContract.JointGuarantorAddressNo2 = JointGuarantorAddressNo2;
                    AddRentalContract.JointGuarantorAddress2 = JointGuarantorAddress2;
                    AddRentalContract.JointGuarantorPhone2 = JointGuarantorPhone2;
                    AddRentalContract.JointGuarantorBirthday2 = JointGuarantorBirthday2;
                    AddRentalContract.JointGuarantorOfficeName2 = JointGuarantorOfficeName2;
                    AddRentalContract.JointGuarantorOfficePhone2 = JointGuarantorOfficePhone2;

                    DataProvider.Ins.DB.SaveChanges();
                    Comfirm = 1;
                    MessageBox.Show("賃貸契約が修正しました。");
                }

            });
            ComboxPrintsChoose.Add("住宅賃貸借契約書");
            ComboxPrintsChoose.Add("建物賃貸借契約書");
            ComboxPrintsChoose.Add("土地賃貸借契約書");
            ComboxPrintsChoose.Add("駐車場賃貸借契約書");
            ComboxPrintsChoose.Add("定期物件賃貸借契約書");
            PrintsRentalContract = new RelayCommand<object>((p) =>
            {
                //if (Comfirm == 0)
                //    return false;

                return true;
            }, (p) =>
            {
                //if (Comfirm == 1)
                //{
                if (ComboxPrints == "住宅賃貸借契約書")
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
                            RentalContractSearch select = new RentalContractSearch();
                            int selectHouseNo = Int32.Parse(select.House.Text);
                            var accessValueSearchRentalContract = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == selectHouseNo);
                            var accessValueSearchRental = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == selectHouseNo);

                            string RenterName = accessValueSearchRentalContract.FirstOrDefault().RenterName;
                            string RenterAddress = accessValueSearchRentalContract.FirstOrDefault().RenterAddress;
                            string RenterPhoneNumber = accessValueSearchRentalContract.FirstOrDefault().RenterPhoneNumber;

                            string RentName = accessValueSearchRentalContract.FirstOrDefault().RentName;
                            string RentAddress = accessValueSearchRentalContract.FirstOrDefault().RentAddress;
                            string RentPhoneNumber = accessValueSearchRentalContract.FirstOrDefault().RentPhoneNumber;
                            string RentOfficeName = accessValueSearchRentalContract.FirstOrDefault().RentOfficeName;
                            string RentOfficePhone = accessValueSearchRentalContract.FirstOrDefault().RentOfficePhone;

                            string JointGuarantorName1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorName1;
                            string JointGuarantorAddressNo1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorAddressNo1;
                            string JointGuarantorAddress1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorAddress1;
                            string JointGuarantorPhone1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorPhone1;
                            string JointGuarantorBirthday1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorBirthday1;
                            string JointGuarantorOfficeName1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorOfficeName1;
                            string JointGuarantorOfficePhone1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorOfficePhone1;

                            string JointGuarantorName2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorName2;
                            string JointGuarantorAddressNo2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorAddressNo2;
                            string JointGuarantorAddress2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorAddress2;
                            string JointGuarantorPhone2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorPhone2;
                            string JointGuarantorBirthday2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorBirthday2;
                            string JointGuarantorOfficeName2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorOfficeName2;
                            string JointGuarantorOfficePhone2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorOfficePhone2;

                            //賃貸入力から引き出せる
                            string HouseAddress = accessValueSearchRental.FirstOrDefault().HouseAddress;
                            string HouseName = accessValueSearchRental.FirstOrDefault().HouseName;
                            string HouseType = accessValueSearchRental.FirstOrDefault().HouseType;
                            string Construction = accessValueSearchRental.FirstOrDefault().Construction;
                            string Decorate = accessValueSearchRental.FirstOrDefault().Decorate;
                            string Parking = accessValueSearchRental.FirstOrDefault().Parking;

                            string Rent = accessValueSearchRental.FirstOrDefault().Rent;
                            string CommonFee = accessValueSearchRental.FirstOrDefault().CommonFee;
                            string ManagementFee = accessValueSearchRental.FirstOrDefault().ManagementFee;
                            string ParkingFee = accessValueSearchRental.FirstOrDefault().ParkingFee;
                            string SecurityDeposit = accessValueSearchRental.FirstOrDefault().SecurityDeposit;
                            string KeyMoney = accessValueSearchRental.FirstOrDefault().KeyMoney;
                            // Open a File
                            try
                            {
                                this.book = xls.Workbooks.Open(savePathFile + "/住宅賃貸借契約書.xlsx");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("パースがないです。");
                            }

                            this.xls.Cells[2, "C"] = RenterName;
                            this.xls.Cells[3, "C"] = RentName;
                            this.xls.Cells[7, "C"] = HouseAddress;
                            this.xls.Cells[8, "C"] = HouseName;
                            //this.xls.Cells[9, "C"] = securityDepositMoney;
                            this.xls.Cells[10, "C"] = Construction;
                            this.xls.Cells[11, "C"] = HouseType;
                            this.xls.Cells[12, "C"] = Decorate;
                            //this.xls.Cells[13, "C"] = managementFeeMoney;
                            this.xls.Cells[14, "C"] = Parking;

                            this.xls.Cells[22, "E"] = Rent;
                            this.xls.Cells[23, "E"] = CommonFee;
                            this.xls.Cells[24, "E"] = ManagementFee;
                            this.xls.Cells[25, "E"] = ParkingFee;
                            this.xls.Cells[26, "E"] = SecurityDeposit;
                            this.xls.Cells[22, "I"] = Rent;
                            this.xls.Cells[26, "I"] = KeyMoney;

                            this.xls.Cells[179, "C"] = RenterAddress;
                            this.xls.Cells[181, "C"] = RenterName;
                            this.xls.Cells[179, "H"] = RenterPhoneNumber;

                            this.xls.Cells[184, "C"] = RentAddress;
                            this.xls.Cells[186, "C"] = RentName;
                            this.xls.Cells[188, "C"] = RentOfficeName;
                            this.xls.Cells[184, "H"] = RentPhoneNumber;
                            this.xls.Cells[188, "H"] = RentOfficePhone;

                            this.xls.Cells[193, "C"] = JointGuarantorAddress1;
                            this.xls.Cells[195, "C"] = JointGuarantorName1;
                            this.xls.Cells[197, "C"] = JointGuarantorOfficeName1;
                            this.xls.Cells[193, "H"] = JointGuarantorPhone1;
                            this.xls.Cells[197, "H"] = JointGuarantorOfficePhone1;

                            this.xls.Cells[202, "C"] = JointGuarantorAddress2;
                            this.xls.Cells[204, "C"] = JointGuarantorName2;
                            this.xls.Cells[206, "C"] = JointGuarantorOfficeName2;
                            this.xls.Cells[202, "H"] = JointGuarantorPhone2;
                            this.xls.Cells[206, "H"] = JointGuarantorOfficePhone2;
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
                else if (ComboxPrints == "建物賃貸借契約書")
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
                            RentalContractSearch select = new RentalContractSearch();
                            int selectHouseNo = Int32.Parse(select.House.Text);
                            var accessValueSearchRentalContract = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == selectHouseNo);
                            var accessValueSearchRental = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == selectHouseNo);

                            string RenterName = accessValueSearchRentalContract.FirstOrDefault().RenterName;
                            string RenterAddress = accessValueSearchRentalContract.FirstOrDefault().RenterAddress;
                            string RenterPhoneNumber = accessValueSearchRentalContract.FirstOrDefault().RenterPhoneNumber;

                            string RentName = accessValueSearchRentalContract.FirstOrDefault().RentName;
                            string RentAddress = accessValueSearchRentalContract.FirstOrDefault().RentAddress;
                            string RentPhoneNumber = accessValueSearchRentalContract.FirstOrDefault().RentPhoneNumber;
                            string RentOfficeName = accessValueSearchRentalContract.FirstOrDefault().RentOfficeName;
                            string RentOfficePhone = accessValueSearchRentalContract.FirstOrDefault().RentOfficePhone;

                            string JointGuarantorName1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorName1;
                            string JointGuarantorAddressNo1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorAddressNo1;
                            string JointGuarantorAddress1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorAddress1;
                            string JointGuarantorPhone1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorPhone1;
                            string JointGuarantorBirthday1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorBirthday1;
                            string JointGuarantorOfficeName1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorOfficeName1;
                            string JointGuarantorOfficePhone1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorOfficePhone1;

                            string JointGuarantorName2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorName2;
                            string JointGuarantorAddressNo2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorAddressNo2;
                            string JointGuarantorAddress2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorAddress2;
                            string JointGuarantorPhone2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorPhone2;
                            string JointGuarantorBirthday2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorBirthday2;
                            string JointGuarantorOfficeName2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorOfficeName2;
                            string JointGuarantorOfficePhone2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorOfficePhone2;

                            //賃貸入力から引き出せる
                            string HouseAddress = accessValueSearchRental.FirstOrDefault().HouseAddress;
                            string HouseName = accessValueSearchRental.FirstOrDefault().HouseName;
                            string HouseType = accessValueSearchRental.FirstOrDefault().HouseType;
                            string Construction = accessValueSearchRental.FirstOrDefault().Construction;
                            string TotalArea = accessValueSearchRental.FirstOrDefault().TotalArea;
                            string Parking = accessValueSearchRental.FirstOrDefault().Parking;

                            string Rent = accessValueSearchRental.FirstOrDefault().Rent;
                            string CommonFee = accessValueSearchRental.FirstOrDefault().CommonFee;
                            string ManagementFee = accessValueSearchRental.FirstOrDefault().ManagementFee;
                            string ParkingFee = accessValueSearchRental.FirstOrDefault().ParkingFee;
                            string SecurityDeposit = accessValueSearchRental.FirstOrDefault().SecurityDeposit;
                            string KeyMoney = accessValueSearchRental.FirstOrDefault().KeyMoney;

                            DateTime dTimeRentBirthday = DateTime.Parse(RentBirthday);
                            string yearRentBirthday = dTimeRentBirthday.Year.ToString();
                            string monthRentBirthday = dTimeRentBirthday.Month.ToString();
                            string dayRentBirthday = dTimeRentBirthday.Day.ToString();

                            string RentBirthdayConvert = yearRentBirthday + "年" + monthRentBirthday + "月" + dayRentBirthday + "日生";

                            DateTime dTimeJointGuarantorBirthdayConvert1 = DateTime.Parse(JointGuarantorBirthday1);
                            string yearJointGuarantorBirthday1 = dTimeJointGuarantorBirthdayConvert1.Year.ToString();
                            string monthJointGuarantorBirthday1 = dTimeJointGuarantorBirthdayConvert1.Month.ToString();
                            string dayJointGuarantorBirthday1 = dTimeJointGuarantorBirthdayConvert1.Day.ToString();
                            string JointGuarantorBirthdayConvert1 = yearJointGuarantorBirthday1 + "年" + monthJointGuarantorBirthday1 + "月" + dayJointGuarantorBirthday1 + "日生";

                            DateTime dTimeJointGuarantorBirthdayConvert2 = DateTime.Parse(JointGuarantorBirthday2);
                            string yearJointGuarantorBirthday2 = dTimeJointGuarantorBirthdayConvert2.Year.ToString();
                            string monthJointGuarantorBirthday2 = dTimeJointGuarantorBirthdayConvert2.Month.ToString();
                            string dayJointGuarantorBirthday2 = dTimeJointGuarantorBirthdayConvert2.Day.ToString();

                            string JointGuarantorBirthdayConvert2 = yearJointGuarantorBirthday2 + "年" + monthJointGuarantorBirthday2 + "月" + dayJointGuarantorBirthday2 + "日生";

                            // Open a File
                            try
                            {
                                this.book = xls.Workbooks.Open(savePathFile + "/建物賃貸借契約書.xlsx");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("パースがないです。");
                            }
                            this.xls.Cells[3, "C"] = RenterName;
                            this.xls.Cells[4, "C"] = RentName;
                            this.xls.Cells[9, "C"] = HouseAddress;
                            this.xls.Cells[10, "C"] = HouseName;
                            //this.xls.Cells[9, "C"] = securityDepositMoney;
                            this.xls.Cells[12, "C"] = HouseType;
                            this.xls.Cells[13, "C"] = Construction;
                            this.xls.Cells[14, "C"] = TotalArea;
                            //this.xls.Cells[13, "C"] = managementFeeMoney;
                            this.xls.Cells[16, "C"] = Parking;

                            this.xls.Cells[30, "C"] = Rent;
                            this.xls.Cells[31, "C"] = CommonFee;
                            this.xls.Cells[32, "C"] = ManagementFee;
                            this.xls.Cells[33, "C"] = ParkingFee;
                            this.xls.Cells[34, "C"] = SecurityDeposit;
                            this.xls.Cells[30, "E"] = Rent;
                            this.xls.Cells[34, "E"] = KeyMoney;

                            this.xls.Cells[300, "C"] = RenterAddress;
                            this.xls.Cells[303, "C"] = RenterName;
                            this.xls.Cells[300, "E"] = RenterPhoneNumber;

                            this.xls.Cells[305, "C"] = RentAddress;
                            this.xls.Cells[308, "C"] = RentName;
                            this.xls.Cells[310, "C"] = RentOfficeName;
                            this.xls.Cells[305, "E"] = RentPhoneNumber;
                            this.xls.Cells[308, "E"] = RentBirthdayConvert;
                            this.xls.Cells[310, "E"] = RentOfficePhone;

                            this.xls.Cells[304, "C"] = JointGuarantorAddress1;
                            this.xls.Cells[317, "C"] = JointGuarantorName1;
                            this.xls.Cells[319, "C"] = JointGuarantorOfficeName1;
                            this.xls.Cells[314, "E"] = JointGuarantorPhone1;
                            this.xls.Cells[319, "E"] = JointGuarantorOfficePhone1;
                            this.xls.Cells[317, "E"] = JointGuarantorBirthdayConvert1;

                            this.xls.Cells[323, "C"] = JointGuarantorAddress2;
                            this.xls.Cells[326, "C"] = JointGuarantorName2;
                            this.xls.Cells[328, "C"] = JointGuarantorOfficeName2;
                            this.xls.Cells[323, "E"] = JointGuarantorPhone2;
                            this.xls.Cells[328, "E"] = JointGuarantorOfficePhone2;
                            this.xls.Cells[326, "E"] = JointGuarantorBirthdayConvert2;
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
                else if (ComboxPrints == "土地賃貸借契約書")
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
                            RentalContractSearch select = new RentalContractSearch();
                            int selectHouseNo = Int32.Parse(select.House.Text);
                            var accessValueSearchRentalContract = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == selectHouseNo);
                            var accessValueSearchRental = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == selectHouseNo);

                            string RenterName = accessValueSearchRentalContract.FirstOrDefault().RenterName;
                            string RenterAddress = accessValueSearchRentalContract.FirstOrDefault().RenterAddress;
                            string RenterPhoneNumber = accessValueSearchRentalContract.FirstOrDefault().RenterPhoneNumber;

                            string RentName = accessValueSearchRentalContract.FirstOrDefault().RentName;
                            string RentAddress = accessValueSearchRentalContract.FirstOrDefault().RentAddress;
                            string RentPhoneNumber = accessValueSearchRentalContract.FirstOrDefault().RentPhoneNumber;
                            string RentOfficeName = accessValueSearchRentalContract.FirstOrDefault().RentOfficeName;
                            string RentOfficePhone = accessValueSearchRentalContract.FirstOrDefault().RentOfficePhone;

                            string JointGuarantorName1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorName1;
                            string JointGuarantorAddressNo1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorAddressNo1;
                            string JointGuarantorAddress1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorAddress1;
                            string JointGuarantorPhone1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorPhone1;
                            string JointGuarantorBirthday1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorBirthday1;
                            string JointGuarantorOfficeName1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorOfficeName1;
                            string JointGuarantorOfficePhone1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorOfficePhone1;

                            string JointGuarantorName2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorName2;
                            string JointGuarantorAddressNo2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorAddressNo2;
                            string JointGuarantorAddress2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorAddress2;
                            string JointGuarantorPhone2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorPhone2;
                            string JointGuarantorBirthday2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorBirthday2;
                            string JointGuarantorOfficeName2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorOfficeName2;
                            string JointGuarantorOfficePhone2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorOfficePhone2;

                            //賃貸入力から引き出せる
                            string HouseAddress = accessValueSearchRental.FirstOrDefault().HouseAddress;
                            string HouseName = accessValueSearchRental.FirstOrDefault().HouseName;
                            string HouseType = accessValueSearchRental.FirstOrDefault().HouseType;
                            string Construction = accessValueSearchRental.FirstOrDefault().Construction;
                            string TotalArea = accessValueSearchRental.FirstOrDefault().TotalArea;
                            string Parking = accessValueSearchRental.FirstOrDefault().Parking;

                            string Rent = accessValueSearchRental.FirstOrDefault().Rent;
                            string CommonFee = accessValueSearchRental.FirstOrDefault().CommonFee;
                            string ManagementFee = accessValueSearchRental.FirstOrDefault().ManagementFee;
                            string ParkingFee = accessValueSearchRental.FirstOrDefault().ParkingFee;
                            string SecurityDeposit = accessValueSearchRental.FirstOrDefault().SecurityDeposit;
                            string KeyMoney = accessValueSearchRental.FirstOrDefault().KeyMoney;
                            // Open a File
                            try
                            {
                                this.book = xls.Workbooks.Open(savePathFile + "/土地賃貸借契約書.xlsx");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("パースがないです。");
                            }

                            this.xls.Cells[2, "C"] = RenterName;
                            this.xls.Cells[3, "C"] = RentName;
                            this.xls.Cells[6, "C"] = HouseAddress;
                            this.xls.Cells[8, "C"] = TotalArea;
                            //this.xls.Cells[9, "C"] = securityDepositMoney;
                            //this.xls.Cells[10, "C"] = Construction;
                            //this.xls.Cells[11, "C"] = HouseType;
                            //this.xls.Cells[12, "C"] = Decorate;
                            //this.xls.Cells[13, "C"] = managementFeeMoney;
                            //this.xls.Cells[14, "C"] = Parking;

                            this.xls.Cells[17, "D"] = Rent;
                            this.xls.Cells[18, "D"] = ParkingFee;
                            this.xls.Cells[19, "D"] = SecurityDeposit;
                            this.xls.Cells[17, "H"] = Rent;
                            this.xls.Cells[18, "H"] = ParkingFee;
                            this.xls.Cells[19, "H"] = KeyMoney;

                            this.xls.Cells[133, "C"] = RenterAddress;
                            this.xls.Cells[135, "C"] = RenterName;
                            this.xls.Cells[134, "H"] = ManagementFee;
                            this.xls.Cells[137, "C"] = RentAddress;
                            this.xls.Cells[139, "C"] = RentName;
                            this.xls.Cells[141, "C"] = RentOfficeName;
                            this.xls.Cells[141, "H"] = RentOfficePhone;

                            this.xls.Cells[146, "C"] = JointGuarantorAddress1;
                            this.xls.Cells[148, "C"] = JointGuarantorName1;
                            this.xls.Cells[150, "C"] = JointGuarantorOfficeName1;
                            this.xls.Cells[193, "H"] = JointGuarantorPhone1;
                            this.xls.Cells[197, "H"] = JointGuarantorOfficePhone1;

                            this.xls.Cells[202, "C"] = JointGuarantorAddress2;
                            this.xls.Cells[204, "C"] = JointGuarantorName2;
                            this.xls.Cells[206, "C"] = JointGuarantorOfficeName2;
                            this.xls.Cells[146, "H"] = JointGuarantorPhone2;
                            this.xls.Cells[150, "H"] = JointGuarantorOfficePhone2;
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
                else if (ComboxPrints == "駐車場賃貸借契約書")
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
                            RentalContractSearch select = new RentalContractSearch();
                            int selectHouseNo = Int32.Parse(select.House.Text);
                            var accessValueSearchRentalContract = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == selectHouseNo);
                            var accessValueSearchRental = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == selectHouseNo);

                            string RenterName = accessValueSearchRentalContract.FirstOrDefault().RenterName;
                            string RenterAddress = accessValueSearchRentalContract.FirstOrDefault().RenterAddress;
                            string RenterPhoneNumber = accessValueSearchRentalContract.FirstOrDefault().RenterPhoneNumber;

                            string RentName = accessValueSearchRentalContract.FirstOrDefault().RentName;
                            string RentAddress = accessValueSearchRentalContract.FirstOrDefault().RentAddress;
                            string RentPhoneNumber = accessValueSearchRentalContract.FirstOrDefault().RentPhoneNumber;
                            string RentOfficeName = accessValueSearchRentalContract.FirstOrDefault().RentOfficeName;
                            string RentOfficePhone = accessValueSearchRentalContract.FirstOrDefault().RentOfficePhone;

                            string JointGuarantorName1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorName1;
                            string JointGuarantorAddressNo1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorAddressNo1;
                            string JointGuarantorAddress1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorAddress1;
                            string JointGuarantorPhone1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorPhone1;
                            string JointGuarantorBirthday1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorBirthday1;
                            string JointGuarantorOfficeName1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorOfficeName1;
                            string JointGuarantorOfficePhone1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorOfficePhone1;

                            string JointGuarantorName2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorName2;
                            string JointGuarantorAddressNo2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorAddressNo2;
                            string JointGuarantorAddress2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorAddress2;
                            string JointGuarantorPhone2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorPhone2;
                            string JointGuarantorBirthday2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorBirthday2;
                            string JointGuarantorOfficeName2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorOfficeName2;
                            string JointGuarantorOfficePhone2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorOfficePhone2;

                            //賃貸入力から引き出せる
                            string HouseAddress = accessValueSearchRental.FirstOrDefault().HouseAddress;
                            //string HouseName = accessValueSearchRental.FirstOrDefault().HouseName;
                            //string HouseType = accessValueSearchRental.FirstOrDefault().HouseType;
                            //string Construction = accessValueSearchRental.FirstOrDefault().Construction;
                            //string Decorate = accessValueSearchRental.FirstOrDefault().Decorate;
                            //string Parking = accessValueSearchRental.FirstOrDefault().Parking;

                            //string Rent = accessValueSearchRental.FirstOrDefault().Rent;
                            //string CommonFee = accessValueSearchRental.FirstOrDefault().CommonFee;
                            //string ManagementFee = accessValueSearchRental.FirstOrDefault().ManagementFee;
                            string ParkingFee = accessValueSearchRental.FirstOrDefault().ParkingFee;
                            string SecurityDeposit = accessValueSearchRental.FirstOrDefault().SecurityDeposit;
                            string KeyMoney = accessValueSearchRental.FirstOrDefault().KeyMoney;
                            // Open a File
                            try
                            {
                                this.book = xls.Workbooks.Open(savePathFile + "/駐車場賃貸借契約書.xlsx");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("パースがないです。");
                            }

                            this.xls.Cells[2, "C"] = RenterName;
                            this.xls.Cells[4, "C"] = RentName;
                            //this.xls.Cells[7, "C"] = HouseAddress;
                            //this.xls.Cells[8, "C"] = HouseName;
                            //this.xls.Cells[9, "C"] = securityDepositMoney;
                            //this.xls.Cells[10, "C"] = Construction;
                            //this.xls.Cells[11, "C"] = HouseType;
                            //this.xls.Cells[12, "C"] = Decorate;
                            //this.xls.Cells[13, "C"] = managementFeeMoney;
                            //this.xls.Cells[14, "C"] = Parking;

                            //this.xls.Cells[22, "E"] = Rent;
                            //this.xls.Cells[23, "E"] = CommonFee;
                            //this.xls.Cells[24, "E"] = ManagementFee;
                            this.xls.Cells[14, "C"] = ParkingFee;
                            this.xls.Cells[14, "F"] = ParkingFee;
                            this.xls.Cells[16, "F"] = SecurityDeposit;
                            this.xls.Cells[17, "F"] = KeyMoney;

                            this.xls.Cells[88, "C"] = RenterAddress;
                            this.xls.Cells[90, "C"] = RenterName;
                            this.xls.Cells[88, "G"] = RenterPhoneNumber;
                            this.xls.Cells[93, "C"] = RentAddress;
                            this.xls.Cells[95, "C"] = RentName;
                            this.xls.Cells[97, "C"] = RentOfficeName;
                            this.xls.Cells[93, "G"] = RentPhoneNumber;
                            this.xls.Cells[97, "G"] = RentOfficePhone;

                            this.xls.Cells[101, "C"] = JointGuarantorAddress1;
                            this.xls.Cells[103, "C"] = JointGuarantorName1;
                            this.xls.Cells[105, "C"] = JointGuarantorOfficeName1;
                            this.xls.Cells[101, "G"] = JointGuarantorPhone1;
                            this.xls.Cells[105, "G"] = JointGuarantorOfficePhone1;

                            //this.xls.Cells[202, "C"] = JointGuarantorAddress2;
                            //this.xls.Cells[204, "C"] = JointGuarantorName2;
                            //this.xls.Cells[206, "C"] = JointGuarantorOfficeName2;
                            //this.xls.Cells[202, "H"] = JointGuarantorPhone2;
                            //this.xls.Cells[206, "H"] = JointGuarantorOfficePhone2;
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
                else if (ComboxPrints == "定期物件賃貸借契約書")
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
                            RentalContractSearch select = new RentalContractSearch();
                            int selectHouseNo = Int32.Parse(select.House.Text);
                            var accessValueSearchRentalContract = DataProvider.Ins.DB.RentalContactDB.Where(r => r.HouseNo == selectHouseNo);
                            var accessValueSearchRental = DataProvider.Ins.DB.RentalManagementDB.Where(r => r.HouseNo == selectHouseNo);

                            string RenterName = accessValueSearchRentalContract.FirstOrDefault().RenterName;
                            string RenterAddress = accessValueSearchRentalContract.FirstOrDefault().RenterAddress;
                            string RenterPhoneNumber = accessValueSearchRentalContract.FirstOrDefault().RenterPhoneNumber;

                            string RentName = accessValueSearchRentalContract.FirstOrDefault().RentName;
                            string RentAddress = accessValueSearchRentalContract.FirstOrDefault().RentAddress;
                            string RentPhoneNumber = accessValueSearchRentalContract.FirstOrDefault().RentPhoneNumber;
                            string RentOfficeName = accessValueSearchRentalContract.FirstOrDefault().RentOfficeName;
                            string RentOfficePhone = accessValueSearchRentalContract.FirstOrDefault().RentOfficePhone;

                            string JointGuarantorName1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorName1;
                            string JointGuarantorAddressNo1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorAddressNo1;
                            string JointGuarantorAddress1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorAddress1;
                            string JointGuarantorPhone1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorPhone1;
                            string JointGuarantorBirthday1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorBirthday1;
                            string JointGuarantorOfficeName1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorOfficeName1;
                            string JointGuarantorOfficePhone1 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorOfficePhone1;

                            string JointGuarantorName2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorName2;
                            string JointGuarantorAddressNo2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorAddressNo2;
                            string JointGuarantorAddress2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorAddress2;
                            string JointGuarantorPhone2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorPhone2;
                            string JointGuarantorBirthday2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorBirthday2;
                            string JointGuarantorOfficeName2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorOfficeName2;
                            string JointGuarantorOfficePhone2 = accessValueSearchRentalContract.FirstOrDefault().JointGuarantorOfficePhone2;

                            //賃貸入力から引き出せる
                            string HouseAddress = accessValueSearchRental.FirstOrDefault().HouseAddress;
                            string HouseName = accessValueSearchRental.FirstOrDefault().HouseName;
                            string HouseType = accessValueSearchRental.FirstOrDefault().HouseType;
                            string Construction = accessValueSearchRental.FirstOrDefault().Construction;
                            string Decorate = accessValueSearchRental.FirstOrDefault().Decorate;
                            string Parking = accessValueSearchRental.FirstOrDefault().Parking;

                            string Rent = accessValueSearchRental.FirstOrDefault().Rent;
                            string CommonFee = accessValueSearchRental.FirstOrDefault().CommonFee;
                            string ManagementFee = accessValueSearchRental.FirstOrDefault().ManagementFee;
                            string ParkingFee = accessValueSearchRental.FirstOrDefault().ParkingFee;
                            string SecurityDeposit = accessValueSearchRental.FirstOrDefault().SecurityDeposit;
                            string KeyMoney = accessValueSearchRental.FirstOrDefault().KeyMoney;

                            DateTime dTimeRentBirthday = DateTime.Parse(RentBirthday);
                            string yearRentBirthday = dTimeRentBirthday.Year.ToString();
                            string monthRentBirthday = dTimeRentBirthday.Month.ToString();
                            string dayRentBirthday = dTimeRentBirthday.Day.ToString();

                            string RentBirthdayConvert = yearRentBirthday + "年" + monthRentBirthday + "月" + dayRentBirthday + "日生";

                            DateTime dTimeJointGuarantorBirthdayConvert1 = DateTime.Parse(JointGuarantorBirthday1);
                            string yearJointGuarantorBirthday1 = dTimeJointGuarantorBirthdayConvert1.Year.ToString();
                            string monthJointGuarantorBirthday1 = dTimeJointGuarantorBirthdayConvert1.Month.ToString();
                            string dayJointGuarantorBirthday1 = dTimeJointGuarantorBirthdayConvert1.Day.ToString();
                            string JointGuarantorBirthdayConvert1 = yearJointGuarantorBirthday1 + "年" + monthJointGuarantorBirthday1 + "月" + dayJointGuarantorBirthday1 + "日生";

                            DateTime dTimeJointGuarantorBirthdayConvert2 = DateTime.Parse(JointGuarantorBirthday2);
                            string yearJointGuarantorBirthday2 = dTimeJointGuarantorBirthdayConvert2.Year.ToString();
                            string monthJointGuarantorBirthday2 = dTimeJointGuarantorBirthdayConvert2.Month.ToString();
                            string dayJointGuarantorBirthday2 = dTimeJointGuarantorBirthdayConvert2.Day.ToString();

                            string JointGuarantorBirthdayConvert2 = yearJointGuarantorBirthday2 + "年" + monthJointGuarantorBirthday2 + "月" + dayJointGuarantorBirthday2 + "日生";
                            // Open a File
                            try
                            {
                                this.book = xls.Workbooks.Open(savePathFile + "/定期物件賃貸借契約書.xlsx");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("パースがないです。");
                            }
                            this.xls.Cells[6, "C"] = Construction;
                            this.xls.Cells[7, "C"] = HouseType;
                            this.xls.Cells[8, "C"] = Decorate;
                            this.xls.Cells[10, "C"] = Parking;

                            this.xls.Cells[19, "D"] = RenterName;
                            this.xls.Cells[20, "D"] = RenterAddress;
                            this.xls.Cells[22, "D"] = HouseAddress;
                            this.xls.Cells[23, "D"] = RenterPhoneNumber;
                            this.xls.Cells[27, "C"] = RentName;
                            //this.xls.Cells[9, "C"] = securityDepositMoney;
                            //this.xls.Cells[13, "C"] = managementFeeMoney;


                            this.xls.Cells[33, "D"] = Rent;
                            this.xls.Cells[34, "D"] = CommonFee;
                            this.xls.Cells[35, "D"] = ManagementFee;
                            this.xls.Cells[36, "D"] = ParkingFee;
                            this.xls.Cells[37, "D"] = SecurityDeposit;
                            //this.xls.Cells[33, "I"] = Rent;
                            this.xls.Cells[37, "I"] = KeyMoney;

                            this.xls.Cells[228, "C"] = RenterAddress;
                            this.xls.Cells[230, "C"] = RenterName;
                            this.xls.Cells[228, "I"] = RenterPhoneNumber;
                            this.xls.Cells[233, "C"] = RentAddress;
                            this.xls.Cells[235, "C"] = RentName;
                            this.xls.Cells[237, "C"] = RentOfficeName;
                            this.xls.Cells[233, "I"] = RentOfficePhone;
                            this.xls.Cells[235, "I"] = RentBirthdayConvert;

                            this.xls.Cells[242, "D"] = JointGuarantorAddress1;
                            this.xls.Cells[244, "D"] = JointGuarantorName1;
                            this.xls.Cells[246, "D"] = JointGuarantorOfficeName1;
                            this.xls.Cells[242, "I"] = JointGuarantorPhone1;
                            this.xls.Cells[244, "I"] = JointGuarantorBirthdayConvert1;

                            this.xls.Cells[251, "D"] = JointGuarantorAddress2;
                            this.xls.Cells[253, "D"] = JointGuarantorName2;
                            this.xls.Cells[255, "D"] = JointGuarantorOfficeName2;
                            this.xls.Cells[251, "I"] = JointGuarantorPhone2;
                            this.xls.Cells[253, "I"] = JointGuarantorBirthdayConvert2;
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
                else
                {
                    MessageBox.Show("書類を選択ください。");
                }
                //}
            });
        }
        public void ExcelVisibleToggle(Microsoft.Office.Interop.Excel.Application xls, bool setting)
        {
            if (xls.Visible == !setting)
            {
                xls.Visible = setting;
            }
        }

        private void reload()
        {
            RentalContractSearch Result = new RentalContractSearch();
            int resultSearch = Int32.Parse(Result.House.Text);

            HouseNo = (int)DataProvider.Ins.DB.RentalManagementDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().HouseNo;
            ContractDate = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().ContractDate;
            RenterName = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().RenterName;
            RenterAddressNo = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().RenterAddressNo;
            RenterAddress = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().RenterAddress;
            RenterPhoneNumber = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().RenterPhoneNumber;
            RenterBirthday = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().RenterBirthday;
            RenterOfficeName = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().RenterOfficeName;
            RenterOfficePhone = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().RenterOfficePhone;
            RentName = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().RentName;
            RentAddressNo = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().RentAddressNo;
            RentAddress = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().RentAddress;
            RentPhoneNumber = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().RentPhoneNumber;
            RentBirthday = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().RentBirthday;
            RentOfficeName = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().RentOfficeName;
            RentOfficePhone = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().RentOfficePhone;
            JointGuarantorName1 = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().JointGuarantorName1;
            JointGuarantorAddressNo1 = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().JointGuarantorAddressNo1;
            JointGuarantorAddress1 = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().JointGuarantorAddress1;
            JointGuarantorPhone1 = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().JointGuarantorPhone1;
            JointGuarantorBirthday1 = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().JointGuarantorBirthday1;
            JointGuarantorOfficeName1 = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().JointGuarantorOfficeName1;
            JointGuarantorOfficePhone1 = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().JointGuarantorOfficePhone1;
            JointGuarantorName2 = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().JointGuarantorName2;
            JointGuarantorAddressNo2 = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().JointGuarantorAddressNo2;
            JointGuarantorAddress2 = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().JointGuarantorAddress2;
            JointGuarantorPhone2 = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().JointGuarantorPhone2;
            JointGuarantorBirthday2 = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().JointGuarantorBirthday2;
            JointGuarantorOfficeName2 = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().JointGuarantorOfficeName2;
            JointGuarantorOfficePhone2 = DataProvider.Ins.DB.RentalContactDB.Where(c => c.HouseNo == resultSearch).FirstOrDefault().JointGuarantorOfficePhone2;
        }
    }
}
