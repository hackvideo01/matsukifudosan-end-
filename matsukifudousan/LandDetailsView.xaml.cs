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
using System.Windows.Shapes;
using matsukifudousan.ViewModel;

namespace matsukifudousan
{
    /// <summary>
    /// LandDetails.xaml の相互作用ロジック
    /// </summary>
    public partial class LandDetailsView : Window
    {
        public LandDetailsView()
        {
            InitializeComponent();
            DataContext = new LandDetailsViewModel();
        }
    }
}
