using matsukifudousan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MaterialDesignThemes.Wpf;
using Button = System.Windows.Controls.Button;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using System.IO;
using System.Diagnostics;
using System.Threading;
using GleamTech.Reflection;
using ImageProcessor.Common.Extensions;
using UserControl = System.Windows.Controls.UserControl;
using System.Windows.Controls.Primitives;
using System.Configuration;

namespace matsukifudousan.ViewModel
{
    public class LandFixViewModel : BaseViewModel, System.ComponentModel.INotifyPropertyChanged
    {


        #region Land Item Input
        private int _LandNo;
        public int LandNo { get => _LandNo; set { _LandNo = value; OnPropertyChanged(); } }

        private string _LandName;
        public string LandName { get => _LandName; set { _LandName = value; OnPropertyChanged(); } }

        private string _LandPost;
        public string LandPost { get => _LandPost; set { _LandPost = value; OnPropertyChanged(); } }

        private string _LandAddress;
        public string LandAddress { get => _LandAddress; set { _LandAddress = value; OnPropertyChanged(); } }

        private string _NearestSation;
        public string NearestSation { get => _NearestSation; set { _NearestSation = value; OnPropertyChanged(); } }

        private string _Price;
        public string Price { get => _Price; set { _Price = value; OnPropertyChanged(); } }

        private string _UnitPrice;
        public string UnitPrice { get => _UnitPrice; set { _UnitPrice = value; OnPropertyChanged(); } }

        private string _LandArea;
        public string LandArea { get => _LandArea; set { _LandArea = value; OnPropertyChanged(); } }

        private string _RoadBurden;
        public string RoadBurden { get => _RoadBurden; set { _RoadBurden = value; OnPropertyChanged(); } }

        private string _LandRights;
        public string LandRights { get => _LandRights; set { _LandRights = value; OnPropertyChanged(); } }

        private string _Ground;
        public string Ground { get => _Ground; set { _Ground = value; OnPropertyChanged(); } }

        private string _CityPlan;
        public string CityPlan { get => _CityPlan; set { _CityPlan = value; OnPropertyChanged(); } }

        private string _UseDistrict;
        public string UseDistrict { get => _UseDistrict; set { _UseDistrict = value; OnPropertyChanged(); } }

        private string _BuildingCoverage;
        public string BuildingCoverage { get => _BuildingCoverage; set { _BuildingCoverage = value; OnPropertyChanged(); } }

        private string _VolumeRaito;
        public string VolumeRaito { get => _VolumeRaito; set { _VolumeRaito = value; OnPropertyChanged(); } }

        private string _OtherLegalRestrictions;
        public string OtherLegalRestrictions { get => _OtherLegalRestrictions; set { _OtherLegalRestrictions = value; OnPropertyChanged(); } }

        private string _Terrain;
        public string Terrain { get => _Terrain; set { _Terrain = value; OnPropertyChanged(); } }

        private string _CurrentSituation;
        public string CurrentSituation { get => _CurrentSituation; set { _CurrentSituation = value; OnPropertyChanged(); } }

        private string _DeliveryConditionTime;
        public string DeliveryConditionTime { get => _DeliveryConditionTime; set { _DeliveryConditionTime = value; OnPropertyChanged(); } }

        private string _BuildingConditions;
        public string BuildingConditions { get => _BuildingConditions; set { _BuildingConditions = value; OnPropertyChanged(); } }

        private string _TransactionMode;
        public string TransactionMode { get => _TransactionMode; set { _TransactionMode = value; OnPropertyChanged(); } }

        private string _RoadsideSituation;
        public string RoadsideSituation { get => _RoadsideSituation; set { _RoadsideSituation = value; OnPropertyChanged(); } }

        private string _Facility;
        public string Facility { get => _Facility; set { _Facility = value; OnPropertyChanged(); } }

        private string _SchoolDistrict;
        public string SchoolDistrict { get => _SchoolDistrict; set { _SchoolDistrict = value; OnPropertyChanged(); } }

        private string _NeighborhoodInformation;
        public string NeighborhoodInformation { get => _NeighborhoodInformation; set { _NeighborhoodInformation = value; OnPropertyChanged(); } }

        private string _Remarks;
        public string Remarks { get => _Remarks; set { _Remarks = value; OnPropertyChanged(); } }
        #endregion

        #region
        private string _ImagePath;
        public string ImagePath { get => _ImagePath; set { _ImagePath = value; OnPropertyChanged(); } }

        private string _ImageFullPath;
        public string ImageFullPath { get => _ImageFullPath; set { _ImageFullPath = value; OnPropertyChanged(); } }

        private int _landSearchHouseNo;
        public int landSearchHouseNo { get => _landSearchHouseNo; set { _landSearchHouseNo = value; OnPropertyChanged(); } }
        #endregion
        public ICommand ContractDetailsCommandWD { get; set; }

        public ICommand AddLandCommand { get; set; }

        public ICommand AddImageCommand { get; set; }

        public ICommand deleteAction { get; set; }

        public string[] ImageObject;

        public string[] ImageNameObject;

        private ObservableCollection<Object> _NameIMG = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMG { get => _NameIMG; set { _NameIMG = value; OnPropertyChanged("NameIMG"); } }

        private ObservableCollection<Object> _NameIMG2 = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMG2 { get => _NameIMG2; set { _NameIMG2 = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _ImageListPath = new ObservableCollection<Object>();
        public ObservableCollection<Object> ImageListPath { get => _ImageListPath; set { _ImageListPath = value; OnPropertyChanged(); } }

        private ObservableCollection<LandDB> _LandDetailsView;
        public ObservableCollection<LandDB> LandDetailsView { get => _LandDetailsView; set { _LandDetailsView = value; OnPropertyChanged(); } }

        private ObservableCollection<ImageDB> _landImageView;
        public ObservableCollection<ImageDB> landImageView { get => _landImageView; set { _landImageView = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _NameIMGDeleteList = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMGDeleteList { get => _NameIMGDeleteList; set { _NameIMGDeleteList = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _ImageData = new ObservableCollection<Object>();
        public ObservableCollection<Object> ImageData { get => _ImageData; set { _ImageData = value; OnPropertyChanged(); } }

        string conbineCharatarBefore = "[";
        string conbineCharatarAfter = "] ";

        public int Comfirm = 0;

        public LandFixViewModel()
        {
            var PathRoot = ConfigurationManager.AppSettings["Path"];

            // Get current working directory (..\bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // GEt the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            // Create specific path file
            string SavePath = string.Format(@"{0}" + PathRoot + "images\\LandImage", projectDirectory);

            string[] a = ImageObject;
            LandSearch landSearch = new LandSearch();
            landSearchHouseNo = Int32.Parse(landSearch.LandNo.Text);
            reload();

            AddImageCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {
                duplicateImage:
                    OpenFileDialog openDialog = new OpenFileDialog();
                    openDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
                    openDialog.Multiselect = true;
                    if (openDialog.ShowDialog() == true)
                    {
                        string appDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                        foreach (String item in openDialog.FileNames)
                        {
                            string fileNameRandom = item;
                            string filePathWithoutName = Path.GetDirectoryName(fileNameRandom);
                            string fileName = Path.GetFileName(fileNameRandom);
                            string filenamewithoutextension = Path.GetFileNameWithoutExtension(fileNameRandom);
                            string extension = Path.GetExtension(fileNameRandom);

                            if (File.Exists(SavePath + "\\" + fileName))
                            {
                                var result = MessageBox.Show("【" + fileName + "】 " + "がありました。\nもう一度写真を選択或いはアップデートしたい写真の名前を変更ください！", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                                if (result == MessageBoxResult.OK)
                                {
                                    goto duplicateImage;
                                }
                            }
                        }

                        int i = 1;
                        foreach (var imageLink in openDialog.FileNames)
                        {
                            string imagePath = imageLink;

                            var drawImageBitmap = new BitmapImage();
                            var stream = File.OpenRead(imagePath);
                            drawImageBitmap.BeginInit();
                            drawImageBitmap.CacheOption = BitmapCacheOption.OnLoad;
                            drawImageBitmap.StreamSource = stream;
                            drawImageBitmap.EndInit();
                            stream.Close();
                            stream.Dispose();
                            drawImageBitmap.Freeze();
                            var imageControl = new Image();
                            imageControl.Width = 100;  //set image of width 100 , guest of request
                            imageControl.Height = 100; //set image of height 100 , quest of request
                            imageControl.Source = drawImageBitmap;
                            imageControl.MouseLeftButtonDown += popup_read_click;

                            Button deleteButton = new Button();
                            deleteButton.Content = "X";
                            deleteButton.Name = "Delete";
                            deleteButton.Background = Brushes.Red;
                            deleteButton.Click += new RoutedEventHandler(home_read_click);

                            NameIMG.Add(imageControl);
                            NameIMG.Add(deleteButton);
                            i += 2;
                        }

                        ImageObject = openDialog.FileNames;
                        ImageNameObject = openDialog.SafeFileNames;
                        foreach (String saveImageName2 in ImageObject)
                        {
                            NameIMG2.Add(saveImageName2);
                        }

                        foreach (String saveImageName in ImageNameObject)
                        {
                            ImageListPath.Add(saveImageName);
                        }

                        ImagePath = "";
                        foreach (var saveImageName in ImageListPath)
                        {
                            ImagePath += conbineCharatarBefore + saveImageName + conbineCharatarAfter;
                        }
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    MessageBox.Show("Fix!" + e, "ERROR!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            AddLandCommand = new RelayCommand<object>((p) =>
            {
                //if (string.IsNullOrEmpty(HouseNo))
                //    return false;
                //var displayList = DataProvider.Ins.DB.ApartmentDB.Where(x => x.HouseNo == HouseNo);
                //if (displayList == null || displayList.Count() != 0) // if displayList = 0 then HouseNo had in database
                //    return false;
                return true;
            }, (p) =>
            {
                Comfirm = 1;
                if (Comfirm == 1)
                {
                    foreach (string SaveImageItem in NameIMG2)
                    {
                        if (!File.Exists(SavePath + "\\" + Path.GetFileName(SaveImageItem)))
                        {
                            File.Copy(SaveImageItem, System.IO.Path.Combine(SavePath, System.IO.Path.GetFileName(SaveImageItem)), true);
                        }
                    }
                    #region Value Form LandMangement
                    var AddLand = DataProvider.Ins.DB.LandDB.Where(hno => hno.LandNo == landSearchHouseNo).SingleOrDefault();

                    AddLand.LandName = LandName;
                    AddLand.LandPost = LandPost;
                    AddLand.LandAddress = LandAddress;
                    AddLand.NearestSation = NearestSation;
                    AddLand.Price = Price;
                    AddLand.UnitPrice = UnitPrice;
                    AddLand.LandArea = LandArea;
                    AddLand.RoadBurden = RoadBurden;
                    AddLand.LandRights = LandRights;
                    AddLand.Ground = Ground;
                    AddLand.CityPlan = CityPlan;
                    AddLand.UseDistrict = UseDistrict;
                    AddLand.BuildingCoverage = BuildingCoverage;
                    AddLand.VolumeRaito = VolumeRaito;
                    AddLand.OtherLegalRestrictions = OtherLegalRestrictions;
                    AddLand.Terrain = Terrain;
                    AddLand.CurrentSituation = CurrentSituation;
                    AddLand.DeliveryConditionTime = DeliveryConditionTime;
                    AddLand.BuildingConditions = BuildingConditions;
                    AddLand.TransactionMode = TransactionMode;
                    AddLand.RoadsideSituation = RoadsideSituation;
                    AddLand.Facility = Facility;
                    AddLand.SchoolDistrict = SchoolDistrict;
                    AddLand.NeighborhoodInformation = NeighborhoodInformation;
                    AddLand.Remarks = Remarks;

                    DataProvider.Ins.DB.SaveChanges();
                    string appDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    int nameImageCount = 0;

                    landImageView = new ObservableCollection<ImageDB>(DataProvider.Ins.DB.ImageDB.Where(img => img.LandNo == landSearchHouseNo));
                    DataProvider.Ins.DB.ImageDB.RemoveRange(landImageView);
                    DataProvider.Ins.DB.SaveChanges();
                    foreach (string saveImageDB in ImageListPath)
                    {
                        var AddImage = new ImageDB()
                        {
                            ImageName = saveImageDB,
                            ImagePath = SavePath + "\\" + saveImageDB,
                            LandNo = LandNo
                        };
                        DataProvider.Ins.DB.ImageDB.Add(AddImage);
                        DataProvider.Ins.DB.SaveChanges();
                        nameImageCount++;
                    }
                    OpenFileDialog openDialog = new OpenFileDialog();
                    openDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
                    MessageBox.Show("物件の内容を修正しました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                    Comfirm = 0;
                }
                #endregion
            });
        }

        private void popup_read_click(object sender, EventArgs e)
        {
            string pathPP = "";
            //FrameworkElement parent = (FrameworkElement)((Button)sender);
            var btn = (Image)sender;
            int indexImage = NameIMG.IndexOf(btn);
            if (indexImage == 0)
            {
                pathPP = NameIMG2[0].ToString();
            }
            else
            {
                pathPP = NameIMG2[indexImage / 2].ToString();
            }

            var drawImageBitmap = new BitmapImage();
            var stream = File.OpenRead(pathPP);
            drawImageBitmap.BeginInit();
            drawImageBitmap.CacheOption = BitmapCacheOption.OnLoad;
            drawImageBitmap.StreamSource = stream;
            //drawImageBitmap.DecodePixelWidth = 200;
            drawImageBitmap.EndInit();
            stream.Close();
            stream.Dispose();
            drawImageBitmap.Freeze();

            var imageControl = new Image();
            imageControl.Width = 500;  //set image of width 100 , guest of request
            imageControl.Height = 500; //set image of height 100 , quest of request
            imageControl.Source = drawImageBitmap;

            Popup PopupTest = new Popup();
            PopupTest.Placement = System.Windows.Controls.Primitives.PlacementMode.Mouse;
            PopupTest.StaysOpen = false;
            PopupTest.Child = imageControl;
            //PopupTest.Height = 1000;
            //PopupTest.Width = 500;
            PopupTest.IsOpen = true;
        }

        private void home_read_click(object sender, RoutedEventArgs e)
        {
            FrameworkElement parent = (FrameworkElement)((Button)sender);
            int comfirmDeleteImage = Comfirm;
            var button = sender as Button;
            var indexBtn = NameIMG.IndexOf(button);
            var indexImg = indexBtn - 1;
            if (indexImg == 0)
            {
                string nameImage = ImageListPath.ElementAt(0).ToString();
                ImageListPath.RemoveAt(0);
                NameIMG.RemoveAt(index: indexBtn);
                NameIMG.RemoveAt(index: indexImg);

                if (comfirmDeleteImage == 0)
                {
                    var resultButtonDeleteImg = MessageBox.Show("本当にこの物件（画像：" + nameImage + "）を削除したいでしょうか？", "警告", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resultButtonDeleteImg == MessageBoxResult.Yes)
                    {
                        DeleteImage(nameImage);
                        var imageDeleteDB = DataProvider.Ins.DB.ImageDB.Where(d => d.ApartmentHouseNo == landSearchHouseNo && d.ImageName == nameImage);
                        DataProvider.Ins.DB.ImageDB.RemoveRange(imageDeleteDB);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                }
            }
            else
            {
                string nameImage = ImageListPath.ElementAt(indexImg / 2).ToString();
                ImageListPath.RemoveAt(indexImg / 2);
                NameIMG.RemoveAt(index: indexBtn);
                NameIMG.RemoveAt(index: indexImg);

                if (comfirmDeleteImage == 0)
                {
                    var resultButtonDeleteImg = MessageBox.Show("本当にこの物件（画像：" + nameImage + "）を削除したいでしょうか？", "警告", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (resultButtonDeleteImg == MessageBoxResult.Yes)
                    {
                        DeleteImage(nameImage);
                        var imageDeleteDB = DataProvider.Ins.DB.ImageDB.Where(d => d.ApartmentHouseNo == landSearchHouseNo && d.ImageName == nameImage);
                        DataProvider.Ins.DB.ImageDB.RemoveRange(imageDeleteDB);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                }
            }

            ImagePath = "";
            foreach (var saveImageName in ImageListPath)
            {
                ImagePath += conbineCharatarBefore + saveImageName + conbineCharatarAfter;
            }
        }

        private void reload()
        {
            if (landSearchHouseNo != 0)
            {
                #region Display Column of value
                LandDetailsView = new ObservableCollection<LandDB>(DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo));

                LandNo = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().LandNo;
                LandName = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().LandName;
                LandPost = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().LandPost;
                LandAddress = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().LandAddress;
                NearestSation = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().NearestSation;
                Price = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().Price;
                UnitPrice = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().UnitPrice;
                LandArea = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().LandArea;
                RoadBurden = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().RoadBurden;
                LandRights = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().LandRights;
                Ground = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().Ground;
                CityPlan = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().CityPlan;
                UseDistrict = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().UseDistrict;
                BuildingCoverage = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().BuildingCoverage;
                VolumeRaito = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().VolumeRaito;
                OtherLegalRestrictions = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().OtherLegalRestrictions;
                Terrain = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().Terrain;
                CurrentSituation = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().CurrentSituation;
                DeliveryConditionTime = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().DeliveryConditionTime;
                BuildingConditions = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().BuildingConditions;
                TransactionMode = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().TransactionMode;
                RoadsideSituation = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().RoadsideSituation;
                Facility = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().Facility;
                SchoolDistrict = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().SchoolDistrict;
                NeighborhoodInformation = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().NeighborhoodInformation;
                Remarks = DataProvider.Ins.DB.LandDB.Where(v => v.LandNo == landSearchHouseNo).First().Remarks;
                #endregion

                landImageView = new ObservableCollection<ImageDB>(DataProvider.Ins.DB.ImageDB.Where(img => img.LandNo == landSearchHouseNo));
                foreach (var imagePathDB in landImageView)
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
                    imageControl.MouseLeftButtonDown += popup_read_click;

                    Button deleteButton = new Button();
                    deleteButton.Content = "X";
                    deleteButton.Name = "Delete";
                    //deleteButton.Command = deleteAction;
                    deleteButton.Background = Brushes.Red;
                    deleteButton.Click += new RoutedEventHandler(home_read_click);

                    NameIMG.Add(imageControl);
                    NameIMG.Add(deleteButton);
                    ImagePath += conbineCharatarBefore + imageName + conbineCharatarAfter;
                    ImageListPath.Add(imageName);

                    NameIMG2.Add(imagePath);
                }
            }
        }
        private void DeleteImage(string nameImage)
        {
            var PathRoot = ConfigurationManager.AppSettings["Path"];

            // Get current working directory (..\bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // GEt the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            // Create specific path file
            string SavePath = string.Format(@"{0}" + PathRoot + "images\\LandImage\\", projectDirectory);
            string path = SavePath + nameImage;
            try
            {
                if (File.Exists(path))
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    GC.Collect();
                    System.IO.File.Delete(path);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
