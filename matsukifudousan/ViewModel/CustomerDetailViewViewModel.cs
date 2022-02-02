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
    public class CustomerDetailViewViewModel : BaseViewModel
    {
        #region Customer Item Input
        private Nullable<int> _CustomerNo;
        public Nullable<int> CustomerNo { get => _CustomerNo; set { _CustomerNo = value; OnPropertyChanged(); } }

        private string _CustomerName;
        public string CustomerName { get => _CustomerName; set { _CustomerName = value; OnPropertyChanged(); } }

        private string _PostCode;
        public string PostCode { get => _PostCode; set { _PostCode = value; OnPropertyChanged(); } }

        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }

        private string _TelephoneNumber;
        public string TelephoneNumber { get => _TelephoneNumber; set { _TelephoneNumber = value; OnPropertyChanged(); } }

        private string _FaxNumber;
        public string FaxNumber { get => _FaxNumber; set { _FaxNumber = value; OnPropertyChanged(); } }

        private string _EmailAddress;
        public string EmailAddress { get => _EmailAddress; set { _EmailAddress = value; OnPropertyChanged(); } }

        private string _Manager;
        public string Manager { get => _Manager; set { _Manager = value; OnPropertyChanged(); } }

        private string _ContactInformation;
        public string ContactInformation { get => _ContactInformation; set { _ContactInformation = value; OnPropertyChanged(); } }

        private string _RegistrationDate;
        public string RegistrationDate { get => _RegistrationDate; set { _RegistrationDate = value; OnPropertyChanged(); } }

        private string _LastUpdateDate;
        public string LastUpdateDate { get => _LastUpdateDate; set { _LastUpdateDate = value; OnPropertyChanged(); } }

        private string _Comment1;
        public string Comment1 { get => _Comment1; set { _Comment1 = value; OnPropertyChanged(); } }

        private string _Comment2;
        public string Comment2 { get => _Comment2; set { _Comment2 = value; OnPropertyChanged(); } }

        #endregion

        #region Images
        private string _ImagePath1;
        public string ImagePath1 { get => _ImagePath1; set { _ImagePath1 = value; OnPropertyChanged(); } }

        private string _ImagePath2;
        public string ImagePath2 { get => _ImagePath2; set { _ImagePath2 = value; OnPropertyChanged(); } }

        private string _ImagePath3;
        public string ImagePath3 { get => _ImagePath3; set { _ImagePath3 = value; OnPropertyChanged(); } }

        private string _ImagePath4;
        public string ImagePath4 { get => _ImagePath4; set { _ImagePath4 = value; OnPropertyChanged(); } }

        private string _ImageFullPath;
        public string ImageFullPath { get => _ImageFullPath; set { _ImageFullPath = value; OnPropertyChanged(); } }
        #endregion

        private int _customerSearchNo;
        public int customerSearchNo { get => _customerSearchNo; set { _customerSearchNo = value; OnPropertyChanged(); } }

        public string[] ImageObject1;

        public string[] ImageNameObject1;

        public string[] ImageObject2;

        public string[] ImageNameObject2;

        public string[] ImageObject3;

        public string[] ImageNameObject3;

        public string[] ImageObject4;

        public string[] ImageNameObject4;

        private ObservableCollection<Object> _NameIMGFirst1 = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMGFirst1 { get => _NameIMGFirst1; set { _NameIMGFirst1 = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _NameIMGFirst2 = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMGFirst2 { get => _NameIMGFirst2; set { _NameIMGFirst2 = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _NameIMGSecond1 = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMGSecond1 { get => _NameIMGSecond1; set { _NameIMGSecond1 = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _NameIMGSecond2 = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMGSecond2 { get => _NameIMGSecond2; set { _NameIMGSecond2 = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _NameIMGCardRight1 = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMGCardRight1 { get => _NameIMGCardRight1; set { _NameIMGCardRight1 = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _NameIMGCardLeft1 = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMGCardLeft1 { get => _NameIMGCardLeft1; set { _NameIMGCardLeft1 = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _ImageListPath1 = new ObservableCollection<Object>();
        public ObservableCollection<Object> ImageListPath1 { get => _ImageListPath1; set { _ImageListPath1 = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _ImageListPath2 = new ObservableCollection<Object>();
        public ObservableCollection<Object> ImageListPath2 { get => _ImageListPath2; set { _ImageListPath2 = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _ImageListPath3 = new ObservableCollection<Object>();
        public ObservableCollection<Object> ImageListPath3 { get => _ImageListPath3; set { _ImageListPath3 = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _ImageListPath4 = new ObservableCollection<Object>();
        public ObservableCollection<Object> ImageListPath4 { get => _ImageListPath4; set { _ImageListPath4 = value; OnPropertyChanged(); } }

        private ObservableCollection<ImageDB> _customerImageView;
        public ObservableCollection<ImageDB> customerImageView { get => _customerImageView; set { _customerImageView = value; OnPropertyChanged(); } }

        private ObservableCollection<ImageDB> _customerImageView1;
        public ObservableCollection<ImageDB> customerImageView1 { get => _customerImageView1; set { _customerImageView1 = value; OnPropertyChanged(); } }

        private ObservableCollection<ImageDB> _customerImageView2;
        public ObservableCollection<ImageDB> customerImageView2 { get => _customerImageView2; set { _customerImageView2 = value; OnPropertyChanged(); } }

        private ObservableCollection<ImageDB> _customerImageView3;
        public ObservableCollection<ImageDB> customerImageView3 { get => _customerImageView3; set { _customerImageView3 = value; OnPropertyChanged(); } }

        private ObservableCollection<ImageDB> _customerImageView4;
        public ObservableCollection<ImageDB> customerImageView4 { get => _customerImageView4; set { _customerImageView4 = value; OnPropertyChanged(); } }

        private ObservableCollection<CustomerDB> _CustomerDetailsView;
        public ObservableCollection<CustomerDB> CustomerDetailsView { get => _CustomerDetailsView; set { _CustomerDetailsView = value; OnPropertyChanged(); } }

        string conbineCharatarBefore = "[";
        string conbineCharatarAfter = "] ";
        public int Comfirm = 0;
        public CustomerDetailViewViewModel()
        {
            CustomerSearch customerSearch = new CustomerSearch();
            customerSearchNo = Int32.Parse(customerSearch.CustomerNo.Text);
            reload();
            //if (landNoView != 0)
            //{
            //    landDetailsView = new ObservableCollection<LandDB>(DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landNoView));
            //    reload();
            //}
        }
        private void reload()
        {
            if (customerSearchNo != 0)
            {
                #region Display Column of value
                CustomerDetailsView = new ObservableCollection<CustomerDB>(DataProvider.Ins.DB.CustomerDB.Where(v => v.CustomerNo == customerSearchNo));

                CustomerNo = DataProvider.Ins.DB.CustomerDB.Where(v => v.CustomerNo == customerSearchNo).First().CustomerNo;
                CustomerName = DataProvider.Ins.DB.CustomerDB.Where(v => v.CustomerNo == customerSearchNo).First().CustomerName;
                PostCode = DataProvider.Ins.DB.CustomerDB.Where(v => v.CustomerNo == customerSearchNo).First().PostCode;
                Address = DataProvider.Ins.DB.CustomerDB.Where(v => v.CustomerNo == customerSearchNo).First().Address;
                TelephoneNumber = DataProvider.Ins.DB.CustomerDB.Where(v => v.CustomerNo == customerSearchNo).First().TelephoneNumber;
                FaxNumber = DataProvider.Ins.DB.CustomerDB.Where(v => v.CustomerNo == customerSearchNo).First().FaxNumber;
                EmailAddress = DataProvider.Ins.DB.CustomerDB.Where(v => v.CustomerNo == customerSearchNo).First().EmailAddress;
                Manager = DataProvider.Ins.DB.CustomerDB.Where(v => v.CustomerNo == customerSearchNo).First().Manager;
                ContactInformation = DataProvider.Ins.DB.CustomerDB.Where(v => v.CustomerNo == customerSearchNo).First().ContactInformation;
                RegistrationDate = DataProvider.Ins.DB.CustomerDB.Where(v => v.CustomerNo == customerSearchNo).First().RegistrationDate;
                LastUpdateDate = DataProvider.Ins.DB.CustomerDB.Where(v => v.CustomerNo == customerSearchNo).First().LastUpdateDate;
                Comment1 = DataProvider.Ins.DB.CustomerDB.Where(v => v.CustomerNo == customerSearchNo).First().Comment1;
                Comment2 = DataProvider.Ins.DB.CustomerDB.Where(v => v.CustomerNo == customerSearchNo).First().Comment2;
                #endregion

                customerImageView1 = new ObservableCollection<ImageDB>(DataProvider.Ins.DB.ImageDB.Where(img => img.CustomerNo == customerSearchNo && img.ImageType == "1"));
                foreach (var imagePathDB in customerImageView1)
                {
                    string imagePath = imagePathDB.ImagePath;
                    string imageName = imagePathDB.ImageName;
                    ImageFullPath = imagePath;
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

                    NameIMGFirst1.Add(imageControl);
                    ImagePath1 += conbineCharatarBefore + imageName + conbineCharatarAfter;
                }

                customerImageView2 = new ObservableCollection<ImageDB>(DataProvider.Ins.DB.ImageDB.Where(img => img.CustomerNo == customerSearchNo && img.ImageType == "2"));
                foreach (var imagePathDB in customerImageView2)
                {
                    string imagePath = imagePathDB.ImagePath;
                    string imageName = imagePathDB.ImageName;
                    ImageFullPath = imagePath;
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

                    NameIMGSecond1.Add(imageControl);
                    ImagePath2 += conbineCharatarBefore + imageName + conbineCharatarAfter;
                }

                customerImageView3 = new ObservableCollection<ImageDB>(DataProvider.Ins.DB.ImageDB.Where(img => img.CustomerNo == customerSearchNo && img.ImageType == "3"));
                foreach (var imagePathDB in customerImageView3)
                {
                    string imagePath = imagePathDB.ImagePath;
                    string imageName = imagePathDB.ImageName;
                    ImageFullPath = imagePath;
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

                    NameIMGCardRight1.Add(imageControl);
                    ImagePath3 += conbineCharatarBefore + imageName + conbineCharatarAfter;
                }

                customerImageView4 = new ObservableCollection<ImageDB>(DataProvider.Ins.DB.ImageDB.Where(img => img.CustomerNo == customerSearchNo && img.ImageType == "4"));
                foreach (var imagePathDB in customerImageView4)
                {
                    string imagePath = imagePathDB.ImagePath;
                    string imageName = imagePathDB.ImageName;
                    ImageFullPath = imagePath;
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

                    NameIMGCardLeft1.Add(imageControl);
                    ImagePath4 += conbineCharatarBefore + imageName + conbineCharatarAfter;
                }
            }
        }
    }
}

