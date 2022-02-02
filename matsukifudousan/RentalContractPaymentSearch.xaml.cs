using matsukifudousan.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace matsukifudousan
{
    /// <summary>
    /// RentalContractSearch.xaml の相互作用ロジック
    /// </summary>
    public partial class RentalContractPaymentSearch : UserControl
    {
        public RentalContractPaymentSearch()
        {
            InitializeComponent();
            //DataContext = new RentalContractSearchViewModel();
        }

        private void dataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                //dataGrid.BeginEdit();
                //DataGridCellInfo cell = dataGrid.SelectedCells[0];
                //string value = ((TextBlock)cell.Column.GetCellContent(cell.Item)).Text;
                //House.Text = value;
                //DataGridCellInfo cell = dataGrid.SelectedCells[0];

                //string value = ((TextBlock)cell.Column.GetCellContent(cell.Item)).Text;

                //Customer customer = (Customer)myDataGrid.SelectedItem;
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
