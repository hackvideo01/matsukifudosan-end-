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
    public class DetachedDetailsViewViewModel : BaseViewModel
    {
        private int _detachedNoView;
        public int detachedNoView { get => _detachedNoView; set { _detachedNoView = value; OnPropertyChanged(); } }

        private string _ImagePath;
        public string ImagePath { get => _ImagePath; set { _ImagePath = value; OnPropertyChanged(); } }

        private ObservableCollection<DetachedDB> _detachedDetailsView;
        public ObservableCollection<DetachedDB> detachedDetailsView { get => _detachedDetailsView; set { _detachedDetailsView = value; OnPropertyChanged(); } }

        private ObservableCollection<ImageDB> _detachedImageView;
        public ObservableCollection<ImageDB> detachedImageView { get => _detachedImageView; set { _detachedImageView = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _NameIMG = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMG { get => _NameIMG; set { _NameIMG = value; OnPropertyChanged("NameIMG"); } }

        string conbineCharatarBefore = "[";
        string conbineCharatarAfter = "] ";
        public DetachedDetailsViewViewModel()
        {
            DetachedSearch detachedSearchView = new DetachedSearch();
            detachedNoView = Int32.Parse(detachedSearchView.House.Text);

            detachedDetailsView = new ObservableCollection<DetachedDB>(DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedNoView));

            reload();
        }
        private void reload()
        {
            if (detachedNoView != 0)
            {
                detachedImageView = new ObservableCollection<ImageDB>(DataProvider.Ins.DB.ImageDB.Where(img => img.DetachedHouseNo == detachedNoView));
                foreach (var imagePathDB in detachedImageView)
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
