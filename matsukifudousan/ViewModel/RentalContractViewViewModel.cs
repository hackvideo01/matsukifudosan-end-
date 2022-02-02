using matsukifudousan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matsukifudousan.ViewModel
{
    public class RentalContractViewViewModel : BaseViewModel
    {
        private ObservableCollection<RentalContactDB> _rentalContractView;
        public ObservableCollection<RentalContactDB> rentalContractView { get => _rentalContractView; set { _rentalContractView = value; OnPropertyChanged(); } }
        public RentalContractViewViewModel()
        {
            RentalContractSearch contractSearch = new RentalContractSearch();
            int HouseNoSelect = Int32.Parse(contractSearch.House.Text);
            rentalContractView = new ObservableCollection<RentalContactDB>(DataProvider.Ins.DB.RentalContactDB.Where(i => i.HouseNo == HouseNoSelect));
        }
    }
}
