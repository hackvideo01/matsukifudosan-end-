using matsukifudousan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace matsukifudousan.ViewModel
{
    public class ImageSearchViewModel : BaseViewModel
    {
        public ObservableCollection<string> List { get; private set; } = new ObservableCollection<string>();

        private string _Search;
        public string Search { get => _Search; set { _Search = value; OnPropertyChanged(); } }

        private Nullable<int> _SearchNo;
        public Nullable<int> SearchNo { get => _SearchNo; set { _SearchNo = value; OnPropertyChanged(); } }

        private ObservableCollection<ImageDB> _autoImageDelete;
        public ObservableCollection<ImageDB> autoImageDelete { get => _autoImageDelete; set { _autoImageDelete = value; OnPropertyChanged(); } }

        private ObservableCollection<ImageDB> _ImageView;
        public ObservableCollection<ImageDB> ImageView { get => _ImageView; set { _ImageView = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _Combox = new ObservableCollection<Object>();
        public ObservableCollection<Object> Combox { get => _Combox; set { _Combox = value; OnPropertyChanged(); } }

        //private string _SelectedPrints;
        //public string SelectedPrints { get => _SelectedPrints; set { _SelectedPrints = value; OnPropertyChanged(); } }

        private Object _SelectedPrints;
        public Object SelectedPrints
        {
            get => _SelectedPrints;
            set
            {
                _SelectedPrints = value;
                OnPropertyChanged();
                if (SelectedPrints != null)
                {
                    List.Clear();
                    ImageView = null;
                }
            }
        }

        private int _SelectedItem;
        public int SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    SearchNo = SelectedItem;

                    if (SelectedPrints == "賃貸")
                    {
                        ImageView = new ObservableCollection<ImageDB>(DataProvider.Ins.DB.ImageDB.Where(img => img.HouseNo == SearchNo));
                    }
                    else if (SelectedPrints == "戸建")
                    {
                        ImageView = new ObservableCollection<ImageDB>(DataProvider.Ins.DB.ImageDB.Where(img => img.DetachedHouseNo == SearchNo));
                    }
                    else if (SelectedPrints == "マンション")
                    {
                        ImageView = new ObservableCollection<ImageDB>(DataProvider.Ins.DB.ImageDB.Where(img => img.ApartmentHouseNo == SearchNo));
                    }
                    else if (SelectedPrints == "土地")
                    {
                        ImageView = new ObservableCollection<ImageDB>(DataProvider.Ins.DB.ImageDB.Where(img => img.LandNo == SearchNo));
                    }
                }
            }
        }

        public ICommand SearchButton { get; set; }

        public ImageSearchViewModel()
        {
            string Result = null;

            #region SearchButton
            //int loadedRecord = 0;
            //int pageNumber = 1;
            //int numberRecord = 10;
            Combox.Add("賃貸");
            Combox.Add("戸建");
            Combox.Add("マンション");
            Combox.Add("土地");

            SearchButton = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ImageSearch imageSelect = new ImageSearch();
                imageSelect.txbSearchNo.Text = null;
                Result = Search;
                if (!String.IsNullOrWhiteSpace(Result) && Result != null && Result != "")
                {
                    if (SelectedPrints == "賃貸")
                    {
                        var ListSearch = DataProvider.Ins.DB.RentalManagementDB.Where(t => t.HouseNo.ToString().Contains(Result) || t.HouseName.Contains(Result) || t.HouseAddress.Contains(Result)).Select(cl => cl.HouseNo.ToString()).ToList();

                        List.Clear();
                        foreach (var item in ListSearch)
                        {
                            List.Add(item);
                        }
                    }
                    else if (SelectedPrints == "戸建")
                    {
                        var ListSearch = DataProvider.Ins.DB.DetachedDB.Where(t => t.DetachedHouseNo.ToString().Contains(Result) || t.DetachedHouseName.Contains(Result) || t.DetachedAddress.Contains(Result)).Select(cl => cl.DetachedHouseNo.ToString()).ToList();

                        List.Clear();
                        foreach (var item in ListSearch)
                        {
                            List.Add(item);
                        }
                    }
                    else if (SelectedPrints == "マンション")
                    {
                        var ListSearch = DataProvider.Ins.DB.ApartmentDB.Where(t => t.ApartmentHouseNo.ToString().Contains(Result) || t.ApartmentHouseName.Contains(Result) || t.ApartmentAddress.Contains(Result)).Select(cl => cl.ApartmentHouseNo.ToString()).ToList();

                        List.Clear();
                        foreach (var item in ListSearch)
                        {
                            List.Add(item);
                        }
                    }
                    else if (SelectedPrints == "土地")
                    {
                        var ListSearch = DataProvider.Ins.DB.LandDB.Where(t => t.LandNo.ToString().Contains(Result) || t.LandName.Contains(Result) || t.LandAddress.Contains(Result)).Select(cl => cl.LandNo.ToString()).ToList();

                        List.Clear();
                        foreach (var item in ListSearch)
                        {
                            List.Add(item);
                        }
                    }
                    else
                    {
                        MessageBox.Show("選択ください。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }



                    //if (ListSearch.Count == 0)
                    //{
                    //    MessageBox.Show("検索の結果がなかったです。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                    //}
                }
                else
                {
                    MessageBox.Show("まだ入力しないです。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
            #endregion
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("ok");
        }
    }
}
