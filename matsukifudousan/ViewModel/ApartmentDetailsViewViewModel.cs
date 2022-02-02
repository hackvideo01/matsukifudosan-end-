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
    public class ApartmentDetailsViewViewModel : BaseViewModel
    {
        private int _apartmentNoView;
        public int apartmentNoView { get => _apartmentNoView; set { _apartmentNoView = value; OnPropertyChanged(); } }

        private string _ImagePath;
        public string ImagePath { get => _ImagePath; set { _ImagePath = value; OnPropertyChanged(); } }

        private ObservableCollection<ApartmentDB> _apartmentDetailsView;
        public ObservableCollection<ApartmentDB> apartmentDetailsView { get => _apartmentDetailsView; set { _apartmentDetailsView = value; OnPropertyChanged(); } }

        private ObservableCollection<ImageDB> _apartmentImageView;
        public ObservableCollection<ImageDB> apartmentImageView { get => _apartmentImageView; set { _apartmentImageView = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _NameIMG = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMG { get => _NameIMG; set { _NameIMG = value; OnPropertyChanged("NameIMG"); } }

        string conbineCharatarBefore = "[";
        string conbineCharatarAfter = "] ";
        public ApartmentDetailsViewViewModel()
        {
            ApartmentSearch apartmentSearchView = new ApartmentSearch();
            apartmentNoView = Int32.Parse(apartmentSearchView.House.Text);

            apartmentDetailsView = new ObservableCollection<ApartmentDB>(DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentNoView));

            reload();
        }
        private void reload()
        {
            if (apartmentNoView != 0)
            {

                apartmentImageView = new ObservableCollection<ImageDB>(DataProvider.Ins.DB.ImageDB.Where(img => img.ApartmentHouseNo == apartmentNoView));


                foreach (var imagePathDB in apartmentImageView)
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
