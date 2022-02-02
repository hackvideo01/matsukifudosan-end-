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
    public class DetachedFixsViewModel : BaseViewModel, System.ComponentModel.INotifyPropertyChanged
    {
        #region Detached Item ViewsFixs
        private int _DetachedHouseNo;
        public int DetachedHouseNo { get => _DetachedHouseNo; set { _DetachedHouseNo = value; OnPropertyChanged(); } }

        private string _DetachedHouseName;
        public string DetachedHouseName { get => _DetachedHouseName; set { _DetachedHouseName = value; OnPropertyChanged(); } }

        private string _DetachedPost;
        public string DetachedPost { get => _DetachedPost; set { _DetachedPost = value; OnPropertyChanged(); } }

        private string _DetachedAddress;
        public string DetachedAddress { get => _DetachedAddress; set { _DetachedAddress = value; OnPropertyChanged(); } }

        private string _NearestSation;
        public string NearestSation { get => _NearestSation; set { _NearestSation = value; OnPropertyChanged(); } }

        private string _Price;
        public string Price { get => _Price; set { _Price = value; OnPropertyChanged(); } }

        private string _FloorPlanType;
        public string FloorPlanType { get => _FloorPlanType; set { _FloorPlanType = value; OnPropertyChanged(); } }

        private string _FloorPlanDetails;
        public string FloorPlanDetails { get => _FloorPlanDetails; set { _FloorPlanDetails = value; OnPropertyChanged(); } }

        private string _LandArea;
        public string LandArea { get => _LandArea; set { _LandArea = value; OnPropertyChanged(); } }

        private string _BuildingArea;
        public string BuildingArea { get => _BuildingArea; set { _BuildingArea = value; OnPropertyChanged(); } }

        private string _BuildingStructure;
        public string BuildingStructure { get => _BuildingStructure; set { _BuildingStructure = value; OnPropertyChanged(); } }

        private string _DateConstruction;
        public string DateConstruction { get => _DateConstruction; set { _DateConstruction = value; OnPropertyChanged(); } }

        private string _LandRights;
        public string LandRights { get => _LandRights; set { _LandRights = value; OnPropertyChanged(); } }

        private string _Ground;
        public string Ground { get => _Ground; set { _Ground = value; OnPropertyChanged(); } }

        private string _CityPlanning;
        public string CityPlanning { get => _CityPlanning; set { _CityPlanning = value; OnPropertyChanged(); } }

        private string _UseDistrict;
        public string UseDistrict { get => _UseDistrict; set { _UseDistrict = value; OnPropertyChanged(); } }

        private string _BuildingCoverageRatio;
        public string BuildingCoverageRatio { get => _BuildingCoverageRatio; set { _BuildingCoverageRatio = value; OnPropertyChanged(); } }

        private string _FloorAreaRatio;
        public string FloorAreaRatio { get => _FloorAreaRatio; set { _FloorAreaRatio = value; OnPropertyChanged(); } }

        private string _OtherLegalRestrictions;
        public string OtherLegalRestrictions { get => _OtherLegalRestrictions; set { _OtherLegalRestrictions = value; OnPropertyChanged(); } }

        private string _Terrain;
        public string Terrain { get => _Terrain; set { _Terrain = value; OnPropertyChanged(); } }

        private string _CurrentSituation;
        public string CurrentSituation { get => _CurrentSituation; set { _CurrentSituation = value; OnPropertyChanged(); } }

        private string _DeliveryConditionTime;
        public string DeliveryConditionTime { get => _DeliveryConditionTime; set { _DeliveryConditionTime = value; OnPropertyChanged(); } }

        private string _Parking;
        public string Parking { get => _Parking; set { _Parking = value; OnPropertyChanged(); } }

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

        private int _detachedSearchHouseNo;
        public int detachedSearchHouseNo { get => _detachedSearchHouseNo; set { _detachedSearchHouseNo = value; OnPropertyChanged(); } }
        #endregion
        public ICommand ContractDetailsCommandWD { get; set; }

        public ICommand AddDetachedCommand { get; set; }

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

        private ObservableCollection<DetachedDB> _DetachedDetailsView;
        public ObservableCollection<DetachedDB> DetachedDetailsView { get => _DetachedDetailsView; set { _DetachedDetailsView = value; OnPropertyChanged(); } }

        private ObservableCollection<ImageDB> _detachedImageView;
        public ObservableCollection<ImageDB> detachedImageView { get => _detachedImageView; set { _detachedImageView = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _NameIMGDeleteList = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMGDeleteList { get => _NameIMGDeleteList; set { _NameIMGDeleteList = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _ImageData = new ObservableCollection<Object>();
        public ObservableCollection<Object> ImageData { get => _ImageData; set { _ImageData = value; OnPropertyChanged(); } }

        string conbineCharatarBefore = "[";
        string conbineCharatarAfter = "] ";

        public int Comfirm = 0;
        public DetachedFixsViewModel()
        {
            var PathRoot = ConfigurationManager.AppSettings["Path"];

            // Get current working directory (..\bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // GEt the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            // Create specific path file
            string SavePath = string.Format(@"{0}" + PathRoot + "images\\DetachedImage", projectDirectory);

            string[] a = ImageObject;

            DetachedSearch detachedSearch = new DetachedSearch();
            detachedSearchHouseNo = Int32.Parse(detachedSearch.House.Text);
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
                        //string appdirect = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                        //string appdirect1 = AppDomain.CurrentDomain.BaseDirectory;

                        //string appdirect2 = System.IO.Directory.GetCurrentDirectory();

                        //string appdirect3 = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

                        foreach (String item in openDialog.FileNames)
                        {
                            //var displayListImage = DataProvider.Ins.DB.ImageDB.Where(x => x.ImageName == item);

                            //if (displayListImage == null || displayListImage.Count() != 0)
                            //{

                            //    var result = MessageBox.Show("がありました。この写真を保存しますか？", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Error);
                            //    if (result == MessageBoxResult.No)
                            //    {
                            //        goto duplicateImage;
                            //    }
                            //}
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
                            //while (File.Exists(SavePath + "\\" + fileName))
                            //{
                            //    MessageBox.Show("ありました!");

                            //    fileName = filenamewithoutextension + count + extension;
                            //}

                            //ImageObject.Add(filePathWithoutName + "\\" + fileName);
                            //File.Copy(fileNameRandom, System.IO.Path.Combine(SavePath, System.IO.Path.GetFileName(fileNameRandom)), true);
                            //string curDir = Path.GetDirectoryName(fileNameRandom);
                            //File.Move(fileNameRandom, Path.Combine(curDir, "NewNameForFile.txt"));
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

                        //foreach (String SaveImageItem in ImageObject)
                        //{
                        //    File.Copy(SaveImageItem, System.IO.Path.Combine(SavePath, System.IO.Path.GetFileName(SaveImageItem)), true);
                        //}
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    MessageBox.Show("Fix!" + e, "ERROR!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            AddDetachedCommand = new RelayCommand<object>((p) =>
            {
                //if (string.IsNullOrEmpty(HouseNo))
                //    return false;

                //var displayList = DataProvider.Ins.DB.DetachedDB.Where(x => x.HouseNo == HouseNo);
                //if (displayList == null || displayList.Count() != 0) // if displayList = 0 then HouseNo had in database
                //    return false;

                return true;
            }, (p) =>

            {
                foreach (string SaveImageItem in NameIMG2)
                {
                    if (!File.Exists(SavePath + "\\" + Path.GetFileName(SaveImageItem)))
                    {
                        File.Copy(SaveImageItem, System.IO.Path.Combine(SavePath, System.IO.Path.GetFileName(SaveImageItem)), true);
                    }
                }

                #region Value Form Detached
                var AddDetached = DataProvider.Ins.DB.DetachedDB.Where(hno => hno.DetachedHouseNo == detachedSearchHouseNo).SingleOrDefault();

                AddDetached.DetachedHouseName = DetachedHouseName;
                AddDetached.DetachedPost = DetachedPost;
                AddDetached.DetachedAddress = DetachedAddress;
                AddDetached.NearestSation = NearestSation;
                AddDetached.Price = Price;
                AddDetached.FloorPlanType = FloorPlanType;
                AddDetached.FloorPlanDetails = FloorPlanDetails;
                AddDetached.LandArea = LandArea;
                AddDetached.BuildingArea = BuildingArea;
                AddDetached.BuildingStructure = BuildingStructure;
                AddDetached.DateConstruction = DateConstruction;
                AddDetached.LandRights = LandRights;
                AddDetached.Ground = Ground;
                AddDetached.CityPlanning = CityPlanning;
                AddDetached.UseDistrict = UseDistrict;
                AddDetached.BuildingCoverageRatio = BuildingCoverageRatio;
                AddDetached.FloorAreaRatio = FloorAreaRatio;
                AddDetached.OtherLegalRestrictions = OtherLegalRestrictions;
                AddDetached.Terrain = Terrain;
                AddDetached.CurrentSituation = CurrentSituation;
                AddDetached.DeliveryConditionTime = DeliveryConditionTime;
                AddDetached.Parking = Parking;
                AddDetached.TransactionMode = TransactionMode;
                AddDetached.RoadsideSituation = RoadsideSituation;
                AddDetached.Facility = Facility;
                AddDetached.SchoolDistrict = SchoolDistrict;
                AddDetached.NeighborhoodInformation = NeighborhoodInformation;
                AddDetached.Remarks = Remarks;

                DataProvider.Ins.DB.SaveChanges();
                string appDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                int nameImageCount = 0;

                detachedImageView = new ObservableCollection<ImageDB>(DataProvider.Ins.DB.ImageDB.Where(img => img.DetachedHouseNo == detachedSearchHouseNo));
                DataProvider.Ins.DB.ImageDB.RemoveRange(detachedImageView);
                DataProvider.Ins.DB.SaveChanges();
                foreach (string saveImageDB in ImageListPath)
                {
                    var AddImage = new ImageDB()
                    {
                        ImageName = saveImageDB,
                        ImagePath = SavePath + "\\" + saveImageDB,
                        DetachedHouseNo = DetachedHouseNo
                    };
                    DataProvider.Ins.DB.ImageDB.Add(AddImage);
                    DataProvider.Ins.DB.SaveChanges();
                    nameImageCount++;
                }
                Comfirm = 1;

                if (Comfirm == 1)
                {
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
                NameIMG2.RemoveAt(0);
                ImageListPath.RemoveAt(0);
                NameIMG.RemoveAt(index: indexBtn);
                NameIMG.RemoveAt(index: indexImg);

                if (comfirmDeleteImage == 0)
                {
                    var resultButtonDeleteImg = MessageBox.Show("本当にこの物件（画像：" + nameImage + "）を削除しますか？", "警告", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (resultButtonDeleteImg == MessageBoxResult.Yes)
                    {
                        DeleteImage(nameImage);
                        var imageDeleteDB = DataProvider.Ins.DB.ImageDB.Where(d => d.DetachedHouseNo == detachedSearchHouseNo && d.ImageName == nameImage);
                        DataProvider.Ins.DB.ImageDB.RemoveRange(imageDeleteDB);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                }
            }
            else
            {
                string nameImage = ImageListPath.ElementAt(indexImg / 2).ToString();
                ImageListPath.RemoveAt(indexImg / 2);
                NameIMG2.RemoveAt(indexImg / 2);
                NameIMG.RemoveAt(index: indexBtn);
                NameIMG.RemoveAt(index: indexImg);

                if (comfirmDeleteImage == 0)
                {
                    var resultButtonDeleteImg = MessageBox.Show("本当にこの物件（画像：" + nameImage + "）を削除しますか？", "警告", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (resultButtonDeleteImg == MessageBoxResult.Yes)
                    {
                        DeleteImage(nameImage);
                        var imageDeleteDB = DataProvider.Ins.DB.ImageDB.Where(d => d.DetachedHouseNo == detachedSearchHouseNo && d.ImageName == nameImage);
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
            if (detachedSearchHouseNo != 0)
            {
                #region Display Column of value

                DetachedDetailsView = new ObservableCollection<DetachedDB>(DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo));

                DetachedHouseNo = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().DetachedHouseNo;
                DetachedHouseName = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().DetachedHouseName;
                DetachedPost = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().DetachedPost;
                DetachedAddress = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().DetachedAddress;
                NearestSation = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().NearestSation;
                Price = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().Price;
                FloorPlanType = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().FloorPlanType;
                FloorPlanDetails = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().FloorPlanDetails;
                LandArea = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().LandArea;
                BuildingArea = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().BuildingArea;
                BuildingStructure = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().BuildingStructure;
                DateConstruction = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().DateConstruction;
                LandRights = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().LandRights;
                Ground = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().Ground;
                CityPlanning = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().CityPlanning;
                UseDistrict = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().UseDistrict;
                BuildingCoverageRatio = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().BuildingCoverageRatio;
                FloorAreaRatio = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().FloorAreaRatio;
                OtherLegalRestrictions = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().OtherLegalRestrictions;
                Terrain = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().Terrain;
                CurrentSituation = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().CurrentSituation;
                DeliveryConditionTime = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().DeliveryConditionTime;
                Parking = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().Parking;
                TransactionMode = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().TransactionMode;
                RoadsideSituation = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().RoadsideSituation;
                Facility = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().Facility;
                SchoolDistrict = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().SchoolDistrict;
                NeighborhoodInformation = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().NeighborhoodInformation;
                Remarks = DataProvider.Ins.DB.DetachedDB.Where(v => v.DetachedHouseNo == detachedSearchHouseNo).First().Remarks;

                #endregion
                detachedImageView = new ObservableCollection<ImageDB>(DataProvider.Ins.DB.ImageDB.Where(img => img.DetachedHouseNo == detachedSearchHouseNo));
                foreach (var imagePathDB in detachedImageView)
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
            string SavePath = string.Format(@"{0}" + PathRoot + "images\\DetachedImage\\", projectDirectory);

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
