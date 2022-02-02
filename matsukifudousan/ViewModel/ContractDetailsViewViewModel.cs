using matsukifudousan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matsukifudousan.ViewModel
{
    public class ContractDetailsViewViewModel : BaseViewModel
    {
        private ObservableCollection<ContractDetailsDB> _contractDetailsView;
        public ObservableCollection<ContractDetailsDB> contractDetailsView { get => _contractDetailsView; set { _contractDetailsView = value; OnPropertyChanged(); } }
        public ContractDetailsViewViewModel()
        {
            ContractDetailsSearch contractSearch = new ContractDetailsSearch();
            int HouseNoSelect = Int32.Parse(contractSearch.HouseSelect.Text);
            contractDetailsView = new ObservableCollection<ContractDetailsDB>(DataProvider.Ins.DB.ContractDetailsDB.Where(i => i.HouseNo == HouseNoSelect));
        }
    }
}
