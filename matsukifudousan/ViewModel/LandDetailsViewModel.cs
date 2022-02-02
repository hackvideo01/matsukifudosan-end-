using matsukifudousan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace matsukifudousan.ViewModel
{
    public class LandDetailsViewModel : BaseViewModel
    {
        private int _landNoView;
        public int landNoView { get => _landNoView; set { _landNoView = value; OnPropertyChanged(); } }

        private string _ImagePath;
        public string ImagePath { get => _ImagePath; set { _ImagePath = value; OnPropertyChanged(); } }

        private ObservableCollection<LandDB> _landDetailsView;
        public ObservableCollection<LandDB> landDetailsView { get => _landDetailsView; set { _landDetailsView = value; OnPropertyChanged(); } }

        private ObservableCollection<ImageDB> _landImageView;
        public ObservableCollection<ImageDB> landImageView { get => _landImageView; set { _landImageView = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _NameIMG = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMG { get => _NameIMG; set { _NameIMG = value; OnPropertyChanged("NameIMG"); } }

        string conbineCharatarBefore = "[";
        string conbineCharatarAfter = "] ";
        public LandDetailsViewModel()
        {
            LandSearch landSearchView = new LandSearch();
            landNoView = Int32.Parse(landSearchView.LandNo.Text);
            if (landNoView != 0)
            {
                landDetailsView = new ObservableCollection<LandDB>(DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landNoView));
                reload();
            }
        }
        private void reload()
        {
            if (landNoView != 0)
            {
                landImageView = new ObservableCollection<ImageDB>(DataProvider.Ins.DB.ImageDB.Where(img => img.LandNo == landNoView));
                foreach (var imagePathDB in landImageView)
                {
                    string imagePath = imagePathDB.ImagePath;
                    string imageName = imagePathDB.ImageName;

                    var bitmap = new BitmapImage();
                    var stream = File.OpenRead(imagePath);
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                    stream.Close();
                    stream.Dispose();
                    bitmap.Freeze();
                    var imageControl = new Image();
                    imageControl.Width = 100;  //set image of width 100 , guest of request
                    imageControl.Height = 100; //set image of height 100 , quest of request
                    imageControl.Source = bitmap;

                    NameIMG.Add(imageControl);
                    ImagePath += conbineCharatarBefore + imageName + conbineCharatarAfter;
                }
            }
        }
    }
}
