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

namespace matsukifudousan.ViewModel
{
    public class RentalContractSearchViewModel : BaseViewModel
    {
        private ObservableCollection<object> _List;
        public ObservableCollection<object> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private Nullable<int> _HouseNo;
        public Nullable<int> HouseNo { get => _HouseNo; set { _HouseNo = value; OnPropertyChanged(); } }

        private string _Search;
        public string Search { get => _Search; set { _Search = value; OnPropertyChanged(); } }

        public ICommand SearchButton { get; set; }

        public ICommand RentalPaymentInputWD { get; set; }

        public ICommand RentalContractFix { get; set; }

        public ICommand RentalContractView { get; set; }

        public ICommand RentalContractDelete { get; set; }

        public RentalContractSearchViewModel()
        {
            //var query = from s in DataProvider.Ins.DB.RentalManagementDB
            //            join sa in DataProvider.Ins.DB.RentalContactDB on s.HouseNo equals sa.HouseNo
            //            //where sa.HouseNo == "10"
            //            select new
            //            { s.HouseNo, s.HouseName, s.Rent, sa.RentName };

            //List = new ObservableCollection<object>(query.ToList());

            RentalPaymentInputWD = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (HouseNo != 0 && HouseNo != null)
                {
                    RentalPaymentInput openWindowDetails = new RentalPaymentInput(); openWindowDetails.ShowDialog();
                }
                else
                {
                    MessageBox.Show("物件を選択ください。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            RentalContractFix = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (HouseNo != 0 && HouseNo != null)
                {
                    RentalContractFix openWindowDetails = new RentalContractFix(); openWindowDetails.ShowDialog();
                }
                else
                {
                    MessageBox.Show("物件を選択ください。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            RentalContractView = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (HouseNo != 0 && HouseNo != null)
                {
                    RentalContractFix openWindowDetails = new RentalContractFix(); openWindowDetails.ShowDialog();
                }
                else
                {
                    MessageBox.Show("物件を選択ください。", "選択", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            SearchButton = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RentalContractSearch rentalContractSearch = new RentalContractSearch();
                string Result = null;
                Result = Search;
                rentalContractSearch.House.Text = null;
                if (!String.IsNullOrWhiteSpace(Result) && Result != null && Result != "")
                {
                    var querySearch = from s in DataProvider.Ins.DB.RentalManagementDB
                                      join sa in DataProvider.Ins.DB.RentalContactDB on s.HouseNo equals sa.HouseNo
                                      where sa.HouseNo.ToString().Contains(Search) || sa.RentName.Contains(Search) || sa.RenterName.Contains(Search)
                                      select new
                                      { s.HouseNo, s.HouseName, s.Rent, sa.RentName };

                    List = new ObservableCollection<object>(querySearch.ToList());

                    if (List.Count == 0)
                    {
                        MessageBox.Show("検索の結果がなかったです。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                }

            });

            RentalContractDelete = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RentalContractSearch selectRentalNo = new RentalContractSearch();

                if (selectRentalNo.House.Text != "")
                {
                    //int isExsit = DataProvider.Ins.DB.RentalPaymentDB.Where(e => e.HouseNo == HouseNo).Count();
                    //if (isExsit != 0)
                    //{
                    //    MessageBox.Show("削除が出来なかったです。まず入金（番号："+ HouseNo + "）を削除してください。", "確認", MessageBoxButton.OK, MessageBoxImage.Warning);
                    //}
                    //else
                    //{

                    //}
                    rentalContractDelete();
                }
                else
                {
                    MessageBox.Show("物件を選択ください。", "選択", MessageBoxButton.OK, MessageBoxImage.Question);
                }
            });
        }
        private void rentalContractDelete()
        {
            RentalContractSearch rentalSearch = new RentalContractSearch();
            var rentalHouseDelete = Int32.Parse(rentalSearch.House.Text);
            var resultButtonDeleteHouse = MessageBox.Show("この物件（物件番号：" + rentalHouseDelete + "）を削除しますか？", "警告", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultButtonDeleteHouse == MessageBoxResult.Yes)
            {
                string Result = null;
                Result = Search;

                var HouseDeleteDB = DataProvider.Ins.DB.RentalContactDB.Where(houseDelete => houseDelete.HouseNo == rentalHouseDelete);
                DataProvider.Ins.DB.RentalContactDB.RemoveRange(HouseDeleteDB);
                DataProvider.Ins.DB.SaveChanges();

                MessageBox.Show("削除しました！", "削除", MessageBoxButton.OK, MessageBoxImage.Information);
                List = new ObservableCollection<object>(DataProvider.Ins.DB.RentalContactDB.Where(t => t.HouseNo.ToString().Contains(Result) || t.RenterName.Contains(Result) || t.RentName.Contains(Result)));
            }
            else
            {
                MessageBox.Show("削除しなかったです！", "削除しない", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
