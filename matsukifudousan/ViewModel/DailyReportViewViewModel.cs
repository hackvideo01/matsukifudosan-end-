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
using System.Windows.Controls.Primitives;

namespace matsukifudousan.ViewModel
{
    public class DailyReportViewViewModel : BaseViewModel
    {
        #region DailyReport Item Input
        private string _Date;
        public string Date { get => _Date; set { _Date = value; OnPropertyChanged(); } }

        private Nullable<int> _CustomerNo;
        public Nullable<int> CustomerNo { get => _CustomerNo; set { _CustomerNo = value; OnPropertyChanged(); } }

        private Nullable<int> _HouseNo;
        public Nullable<int> HouseNo { get => _HouseNo; set { _HouseNo = value; OnPropertyChanged(); } }

        private string _CustomerName;
        public string CustomerName { get => _CustomerName; set { _CustomerName = value; OnPropertyChanged(); } }

        private string _HouseName;
        public string HouseName { get => _HouseName; set { _HouseName = value; OnPropertyChanged(); } }

        private string _CustomerNameOther;
        public string CustomerNameOther { get => _CustomerNameOther; set { _CustomerNameOther = value; OnPropertyChanged(); } }

        private string _Comment;
        public string Comment { get => _Comment; set { _Comment = value; OnPropertyChanged(); } }

        #endregion

        private string _TypeSelected;
        public string TypeSelected { get => _TypeSelected; set { _TypeSelected = value; OnPropertyChanged(); } }

        public ICommand AddDailyReportCommand { get; set; }

        public DailyReportViewViewModel()
        {
            DateTime today = DateTime.Today;
            Date = DateTime.Now.ToString("yyyy/MM/dd");

            reload();
        }
        private void reload()
        {
            DailyReportSearch dailyReportSearch = new DailyReportSearch();
            string id = dailyReportSearch.txbDailyReportId.Text;
            int dailyId = Int32.Parse(id);
            #region Display Column of value
            //CustomerDetailsView = new ObservableCollection<CustomerDB>(DataProvider.Ins.DB.CustomerDB.Where(v => v.CustomerNo == customerSearchNo));

            CustomerNo = DataProvider.Ins.DB.DailyReportDB.Where(v => v.DailyReportId == dailyId).First().CustomerNo;
            CustomerName = DataProvider.Ins.DB.DailyReportDB.Where(v => v.DailyReportId == dailyId).First().CustomerName;
            HouseNo = DataProvider.Ins.DB.DailyReportDB.Where(v => v.DailyReportId == dailyId).First().HouseNo;
            HouseName = DataProvider.Ins.DB.DailyReportDB.Where(v => v.DailyReportId == dailyId).First().HouseName;
            CustomerNameOther = DataProvider.Ins.DB.DailyReportDB.Where(v => v.DailyReportId == dailyId).First().CustomerNameOther;
            Comment = DataProvider.Ins.DB.DailyReportDB.Where(v => v.DailyReportId == dailyId).First().Comment;
            Date = DataProvider.Ins.DB.DailyReportDB.Where(v => v.DailyReportId == dailyId).First().Date;
            TypeSelected = DataProvider.Ins.DB.DailyReportDB.Where(v => v.DailyReportId == dailyId).First().TypeSelect;
            #endregion
        }
    }
}
