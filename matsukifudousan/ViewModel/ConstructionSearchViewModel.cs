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
    public class ConstructionSearchViewModel : BaseViewModel
    {
        private ObservableCollection<ConstructionDB> _List;
        public ObservableCollection<ConstructionDB> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private Nullable<int> _ConstructionId;
        public Nullable<int> ConstructionId { get => _ConstructionId; set { _ConstructionId = value; OnPropertyChanged(); } }


        private string _Date;
        public string Date
        {
            get => _Date;
            set
            {
                _Date = value; OnPropertyChanged();
            }
        }

        private string _ConstructionDetailsSearch;
        public string ConstructionDetailsSearch
        {
            get => _ConstructionDetailsSearch;
            set
            {
                _ConstructionDetailsSearch = value;
                OnPropertyChanged();
                List = new ObservableCollection<ConstructionDB>(DataProvider.Ins.DB.ConstructionDB.Where(t => t.ConstructionDetails.ToString().Contains(ConstructionDetailsSearch)));
            }
        }

        public ICommand ConstructionDetailsView { get; set; }

        public ICommand ConstructionFix { get; set; }

        public ICommand ConstructionDelete { get; set; }

        public ICommand ConstructionSearchClean { get; set; }

        private ConstructionDB _SelectedItem;
        public ConstructionDB SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    ConstructionId = SelectedItem.ConstructionId;
                    ConstructionSearch constructionSearch  = new ConstructionSearch();
                    constructionSearch.txbConstructionId.Focus();
                    Date = SelectedItem.Date;
                }
            }
        }

        private Nullable<int> _HouseNo;
        public Nullable<int> HouseNo { get => _HouseNo; set { _HouseNo = value; OnPropertyChanged(); } }

        public ConstructionSearchViewModel()
        {
            reload();

            ConstructionSearchClean = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                reload();
            });

            ConstructionDetailsView = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (Date != "" && Date != null)
                {
                    ConstructionDetailsView openWindowDetails = new ConstructionDetailsView(); openWindowDetails.ShowDialog();
                }
                else
                {
                    MessageBox.Show("選択してください。", "選択", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            });

            ConstructionFix = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (ConstructionId != null)
                {
                    ConstructionFixs openWindowDetails = new ConstructionFixs(); openWindowDetails.ShowDialog();
                    ConstructionSearch constructionSearch = new ConstructionSearch();
                    if (ConstructionDetailsSearch != null && ConstructionDetailsSearch != "")
                    {
                        List = new ObservableCollection<ConstructionDB>(DataProvider.Ins.DB.ConstructionDB.Where(t => t.ConstructionDetails.ToString().Contains(ConstructionDetailsSearch)));
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
            ConstructionDelete = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ConstructionSearch constructionSearch = new ConstructionSearch();

                if (constructionSearch.txbDate.Text != null)
                {
                    constructionDelete();
                    if (ConstructionDetailsSearch != null && ConstructionDetailsSearch != "")
                    {
                        List = new ObservableCollection<ConstructionDB>(DataProvider.Ins.DB.ConstructionDB.Where(t => t.ConstructionDetails.ToString().Contains(ConstructionDetailsSearch)));
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
        }

        private void constructionDelete()
        {
            ConstructionSearch constructionSearch = new ConstructionSearch();
            int ConstructionDelete = Int32.Parse(constructionSearch.txbConstructionId.Text);
            var resultButtonDelete = MessageBox.Show("この工事台帳（工事台帳番号：" + ConstructionDelete + "）を削除しますか？", "警告", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultButtonDelete == MessageBoxResult.Yes)
            {
                var constructionDeleteDB = DataProvider.Ins.DB.ConstructionDB.Where(constructDelete => constructDelete.ConstructionId == ConstructionDelete);
                DataProvider.Ins.DB.ConstructionDB.RemoveRange(constructionDeleteDB);
                DataProvider.Ins.DB.SaveChanges();

                MessageBox.Show("削除しました！");
                constructionSearch.txbConstructionId.Text = null;
                constructionSearch.txbDate.Text = null;
            }
            else
            {
                MessageBox.Show("削除しなかったです。");
            }
        }

        private void reload()
        {
            List = new ObservableCollection<ConstructionDB>(DataProvider.Ins.DB.ConstructionDB.Where(t => t.ConstructionId > 0));
        }
    }
}
