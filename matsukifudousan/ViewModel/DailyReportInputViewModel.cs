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
    public class DailyReportInputViewModel : BaseViewModel
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

        private ObservableCollection<Object> _TypeCombox = new ObservableCollection<Object>();
        public ObservableCollection<Object> TypeCombox { get => _TypeCombox; set { _TypeCombox = value; OnPropertyChanged(); } }

        private string _TypeSelected;
        public string TypeSelected { get => _TypeSelected; set { _TypeSelected = value; OnPropertyChanged(); } }

        public ICommand AddDailyReportCommand { get; set; }

        public DailyReportInputViewModel()
        {
            DateTime today = DateTime.Today;
            Date = DateTime.Now.ToString("yyyy/MM/dd");

            TypeCombox.Add("来店");
            TypeCombox.Add("電話");
            TypeCombox.Add("メール");
            TypeCombox.Add("その他");


            AddDailyReportCommand = new RelayCommand<object>((p) =>
            {
                //if (string.IsNullOrEmpty(CustomerNo.ToString()))
                //    return false;
                //var displayList = DataProvider.Ins.DB.CustomerDB.Where(x => x.CustomerNo == CustomerNo);
                //if (displayList == null || displayList.Count() != 0) // if displayList = 0 then HouseNo had in database
                //    return false;
                return true;
            }, (p) =>
            {
                DateTime dTimePaymentDate = DateTime.Parse(Date);
                string yearPaymentDate = dTimePaymentDate.Year.ToString();
                string monthPaymentDate = dTimePaymentDate.Month.ToString();
                string dayPaymentDate = dTimePaymentDate.Day.ToString();
                var DailyReport = new DailyReportDB()
                {
                    Date = yearPaymentDate + "/" + monthPaymentDate + "/" + dayPaymentDate,
                    TypeSelect = TypeSelected,
                    HouseNo = HouseNo,
                    HouseName = HouseName,
                    CustomerNo = CustomerNo,
                    CustomerName = CustomerName,
                    CustomerNameOther = CustomerNameOther,
                    Comment = Comment,
                };

                DataProvider.Ins.DB.DailyReportDB.Add(DailyReport);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("日報の内容が保存しました。", "保存", MessageBoxButton.OK, MessageBoxImage.Information);
            });
        }
    }
}
