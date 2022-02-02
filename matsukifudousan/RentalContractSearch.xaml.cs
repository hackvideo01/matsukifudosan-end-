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
    public partial class RentalContractSearch : UserControl
    {
        public RentalContractSearch()
        {
            InitializeComponent();
        }

        private void dataGridContract_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                dataGridContract.BeginEdit();
                DataGridCellInfo cell = dataGridContract.SelectedCells[0];
                string value = ((TextBlock)cell.Column.GetCellContent(cell.Item)).Text;
                House.Text = value;
            }
            catch (Exception)
            {
                //MessageBox.Show("ok");
            }
        }
    }
}
