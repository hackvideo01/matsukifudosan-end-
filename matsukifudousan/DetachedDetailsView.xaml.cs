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
using System.Windows.Shapes;

namespace matsukifudousan
{
    /// <summary>
    /// DetachedDetailsView.xaml の相互作用ロジック
    /// </summary>
    public partial class DetachedDetailsView : Window
    {
        public DetachedDetailsView()
        {
            InitializeComponent();

            DataContext = new DetachedDetailsViewViewModel();
        }
    }
}
