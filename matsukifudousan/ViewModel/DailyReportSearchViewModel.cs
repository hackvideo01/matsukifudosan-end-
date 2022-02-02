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
    public class DailyReportSearchViewModel : BaseViewModel
    {
        private ObservableCollection<DailyReportDB> _List;
        public ObservableCollection<DailyReportDB> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private Nullable<int> _DailyReportId;
        public Nullable<int> DailyReportId { get => _DailyReportId; set { _DailyReportId = value; OnPropertyChanged(); } }


        private string _Date;
        public string Date
        {
            get => _Date;
            set
            {
                _Date = value; OnPropertyChanged();
            }
        }

        private string _Search;
        public string Search
        {
            get => _Search;
            set
            {
                _Search = value; 
                OnPropertyChanged();
                DateTime dTimePaymentDate = DateTime.Parse(Search);
                string yearPaymentDate = dTimePaymentDate.Year.ToString();
                string monthPaymentDate = dTimePaymentDate.Month.ToString();
                string dayPaymentDate = dTimePaymentDate.Day.ToString();
                List = new ObservableCollection<DailyReportDB>(DataProvider.Ins.DB.DailyReportDB.Where(t => t.Date.ToString().Contains(yearPaymentDate + "/" + monthPaymentDate + "/" + dayPaymentDate)));

            }
        }

        private ObservableCollection<Object> _TypeCombox = new ObservableCollection<Object>();
        public ObservableCollection<Object> TypeCombox
        {
            get => _TypeCombox;
            set
            {
                _TypeCombox = value;
                OnPropertyChanged();
            }
        }

        private string _TypeSelected;
        public string TypeSelected
        {
            get => _TypeSelected; 
            set
            {
                _TypeSelected = value;
                OnPropertyChanged();
                if (CommentSearch != null)
                {
                    List = new ObservableCollection<DailyReportDB>(DataProvider.Ins.DB.DailyReportDB.Where(t => t.TypeSelect.ToString().Contains(TypeSelected) && t.Comment.ToString().Contains(CommentSearch)));
                }
                else
                {
                    List = new ObservableCollection<DailyReportDB>(DataProvider.Ins.DB.DailyReportDB.Where(t => t.TypeSelect.ToString().Contains(TypeSelected)));
                }
            }
        }

        private string _CommentSearch;
        public string CommentSearch
        {
            get => _CommentSearch;
            set
            {
                _CommentSearch = value;
                OnPropertyChanged();
               
                if (TypeSelected != null)
                {
                    List = new ObservableCollection<DailyReportDB>(DataProvider.Ins.DB.DailyReportDB.Where(t => t.TypeSelect.ToString().Contains(TypeSelected) && t.Comment.ToString().Contains(CommentSearch)));
                }
                else
                {
                    List = new ObservableCollection<DailyReportDB>(DataProvider.Ins.DB.DailyReportDB.Where(t => t.Comment.ToString().Contains(CommentSearch)));
                }
            }
        }

        public ICommand SearchButton { get; set; }

        public ICommand DailyReportDetailsView { get; set; }

        public ICommand DailyReportFix { get; set; }

        public ICommand DailyReportDelete { get; set; }

        public ICommand DailyReportAllSearch { get; set; }

        public ICommand DailyReportCommmentSearch { get; set; }

        public ICommand DailyReportSearchClean { get; set; }

        private DailyReportDB _SelectedItem;
        public DailyReportDB SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DailyReportId = SelectedItem.DailyReportId;
                    DailyReportSearch dailyReportSearch = new DailyReportSearch();
                    dailyReportSearch.txbDailyReportId.Focus();
                    Date = SelectedItem.Date;
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
        public DailyReportSearchViewModel()
        {
            TypeCombox.Add("来店");
            TypeCombox.Add("電話");
            TypeCombox.Add("メール");
            TypeCombox.Add("その他");

            string Result = null;
            reload();
            #region SearchButton
            //int loadedRecord = 0;
            //int pageNumber = 1;
            //int numberRecord = 10;

            SearchButton = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                //List = LoadRecord(loadedRecord, numberRecord);

                Result = Search;
                if (!String.IsNullOrWhiteSpace(Result) && Result != null && Result != "")
                {
                    List = new ObservableCollection<DailyReportDB>(DataProvider.Ins.DB.DailyReportDB.Where(t => t.Date.ToString().Contains(Result)));

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

            DailyReportSearchClean = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (TypeSelected != null)
                {
                    TypeSelected = null;
                }
                if (CommentSearch != null)
                {
                    CommentSearch = null;
                }
                reload();
            });

            DailyReportDetailsView = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (Date != "" && Date != null)
                {
                    DailyReportView openWindowDetails = new DailyReportView(); openWindowDetails.ShowDialog();
                }
                else
                {
                    MessageBox.Show("選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            });

            DailyReportFix = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (Date != "" && Date != null)
                {
                    DailyReportFixs openWindowDetails = new DailyReportFixs(); openWindowDetails.ShowDialog();
                    DailyReportSearch dailyReportSearch = new DailyReportSearch();
                    if (TypeSelected != null && CommentSearch != null)
                    {
                        List = new ObservableCollection<DailyReportDB>(DataProvider.Ins.DB.DailyReportDB.Where(t => t.TypeSelect.ToString().Contains(TypeSelected) && t.Comment.ToString().Contains(CommentSearch)));
                    }
                    else if (TypeSelected == null && CommentSearch != null)
                    {
                        List = new ObservableCollection<DailyReportDB>(DataProvider.Ins.DB.DailyReportDB.Where(t => t.Comment.ToString().Contains(CommentSearch)));
                    }
                    else if (TypeSelected != null && CommentSearch == null)
                    {
                        List = new ObservableCollection<DailyReportDB>(DataProvider.Ins.DB.DailyReportDB.Where(t => t.TypeSelect.ToString().Contains(TypeSelected)));
                    }
                    else
                    {
                        reload();
                    }
                }
                else
                {
                    MessageBox.Show("選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            });
            DailyReportDelete = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                DailyReportSearch dailyReportSearch = new DailyReportSearch();

                if (dailyReportSearch.txbDate.Text != null)
                {
                    dailyReportDelete();
                    
                    if (TypeSelected != null && CommentSearch != null)
                    {
                        List = new ObservableCollection<DailyReportDB>(DataProvider.Ins.DB.DailyReportDB.Where(t => t.TypeSelect.ToString().Contains(TypeSelected) && t.Comment.ToString().Contains(CommentSearch)));
                    }
                    else if(TypeSelected == null && CommentSearch != null)
                    {
                        List = new ObservableCollection<DailyReportDB>(DataProvider.Ins.DB.DailyReportDB.Where(t => t.Comment.ToString().Contains(CommentSearch)));
                    }
                    else if (TypeSelected != null && CommentSearch == null)
                    {
                        List = new ObservableCollection<DailyReportDB>(DataProvider.Ins.DB.DailyReportDB.Where(t => t.TypeSelect.ToString().Contains(TypeSelected)));
                    }
                    else
                    {
                        reload();
                    }
                }
                else
                {
                    MessageBox.Show("選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            });

            DailyReportAllSearch = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (TypeSelected != null)
                {
                    TypeSelected = null;
                }
                if (CommentSearch != null)
                {
                    CommentSearch = null;
                }
                List = new ObservableCollection<DailyReportDB>(DataProvider.Ins.DB.DailyReportDB.Where(t => t.DailyReportId > 0));
                
            });

            DailyReportCommmentSearch = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                List = new ObservableCollection<DailyReportDB>(DataProvider.Ins.DB.DailyReportDB.Where(cmt => cmt.Comment.Contains(CommentSearch)));
                int CheckReport = List.Count;
                if (List.Count == 0)
                {
                    MessageBox.Show("検索の結果がなかったです。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
        }

        private void dailyReportDelete()
        {
            DailyReportSearch dailyReportSearch = new DailyReportSearch();
            int DailyReportDelete = Int32.Parse(dailyReportSearch.txbDailyReportId.Text);
            var resultButtonDeleteHouse = MessageBox.Show("この日報（日報番号：" + DailyReportDelete + "）を削除しますか？", "警告", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultButtonDeleteHouse == MessageBoxResult.Yes)
            {
                var dailyReportDeleteDB = DataProvider.Ins.DB.DailyReportDB.Where(dailyDelete => dailyDelete.DailyReportId == DailyReportDelete);
                DataProvider.Ins.DB.DailyReportDB.RemoveRange(dailyReportDeleteDB);
                DataProvider.Ins.DB.SaveChanges();

                MessageBox.Show("削除しました！");
                dailyReportSearch.txbDailyReportId.Text = null;
                dailyReportSearch.txbDate.Text = null;
            }
            else
            {
                MessageBox.Show("削除しなかったです。");
            }
        }

        private void reload()
        {
            List = new ObservableCollection<DailyReportDB>(DataProvider.Ins.DB.DailyReportDB.Where(t => t.DailyReportId > 0));
        }
    }
}
