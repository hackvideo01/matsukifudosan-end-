using matsukifudousan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace matsukifudousan.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            try
            {
                DataProvider.Ins.DB.RentalManagementDB.FirstOrDefault();
            }
            catch (Exception e)
            {
                MessageBox.Show("データベースを接続できません！"+e);
            }
        }
    }
}
