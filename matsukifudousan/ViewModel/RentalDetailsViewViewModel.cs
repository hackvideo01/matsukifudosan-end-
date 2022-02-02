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
    public class RentalDetailsViewViewModel : BaseViewModel
    {
        private int _houseNoView;
        public int houseNoView { get => _houseNoView; set { _houseNoView = value; OnPropertyChanged(); } }

        private string _ImagePath;
        public string ImagePath { get => _ImagePath; set { _ImagePath = value; OnPropertyChanged(); } }

        private ObservableCollection<RentalManagementDB> _RentalDetailsView;
        public ObservableCollection<RentalManagementDB> RentalDetailsView { get => _RentalDetailsView; set { _RentalDetailsView = value; OnPropertyChanged(); } }

        private ObservableCollection<ImageDB> _rentalImageView;
        public ObservableCollection<ImageDB> rentalImageView { get => _rentalImageView; set { _rentalImageView = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _NameIMG = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMG { get => _NameIMG; set { _NameIMG = value; OnPropertyChanged("NameIMG"); } }

        string conbineCharatarBefore = "[";
        string conbineCharatarAfter = "] ";
        public RentalDetailsViewViewModel()
        {
            RentalSearch rentalSearchView = new RentalSearch();
            houseNoView = Int32.Parse(rentalSearchView.House.Text);
            RentalDetailsView = new ObservableCollection<RentalManagementDB>(DataProvider.Ins.DB.RentalManagementDB.Where(v => v.HouseNo == houseNoView));
            reload();
        }
        private void reload()
        {
            if (houseNoView != 0)
            {
                rentalImageView = new ObservableCollection<ImageDB>(DataProvider.Ins.DB.ImageDB.Where(img => img.HouseNo == houseNoView));
                foreach (var imagePathDB in rentalImageView)
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
