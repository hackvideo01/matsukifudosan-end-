using matsukifudousan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Org.BouncyCastle.Bcpg.OpenPgp;
using ImageDB = matsukifudousan.Model.ImageDB;
using Image = System.Windows.Controls.Image;
using BatchedObservableCollection.Batch;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2013.PowerPoint;
using GleamTech.Util;
using ImageProcessor.Common.Extensions;
using MaterialDesignThemes.Wpf;
using Brushes = System.Windows.Media.Brushes;
using Button = System.Windows.Controls.Button;
using Control = System.Windows.Controls.Control;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using Orientation = System.Windows.Controls.Orientation;
using System.Windows.Controls.Primitives;
using System.Configuration;

namespace matsukifudousan.ViewModel
{
    public class DetachedInputViewModel : BaseViewModel
    {
        #region Detached Item Input
        private Nullable<int> _DetachedHouseNo;
        public Nullable<int> DetachedHouseNo { get => _DetachedHouseNo; set { _DetachedHouseNo = value; OnPropertyChanged(); } }

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
        #endregion
        public ICommand ContractDetailsCommandWD { get; set; }

        public ICommand AddDetachedCommand { get; set; }

        public ICommand AddImageCommand { get; set; }

        public ICommand deleteAction { get; set; }

        public string[] ImageObject;

        public string[] ImageNameObject;

        //private ObservableCollection<Object> _ImageObject = new ObservableCollection<Object>();
        //public ObservableCollection<Object> ImageObject { get => _ImageObject; set { _ImageObject = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _NameIMG = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMG { get => _NameIMG; set { _NameIMG = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _NameIMG2 = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMG2 { get => _NameIMG2; set { _NameIMG2 = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _ImageListPath = new ObservableCollection<Object>();
        public ObservableCollection<Object> ImageListPath { get => _ImageListPath; set { _ImageListPath = value; OnPropertyChanged(); } }

        string conbineCharatarBefore = "[";
        string conbineCharatarAfter = "] ";
        public int Comfirm = 0;

        public DetachedInputViewModel()
        {
            var PathRoot = ConfigurationManager.AppSettings["Path"];

            // Get current working directory (..\bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // GEt the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            // Create specific path file
            string SavePath = string.Format(@"{0}" + PathRoot + "images\\DetachedImage", projectDirectory);

            string ImageNameString = ImageListPath.ToString();
            ContractDetailsCommandWD = new RelayCommand<object>((p) => { return true; }, (p) => { ContractDetails wd = new ContractDetails(); wd.ShowDialog(); });

            AddDetachedCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DetachedHouseNo.ToString()))
                    return false;
                var displayList = DataProvider.Ins.DB.DetachedDB.Where(x => x.DetachedHouseNo == DetachedHouseNo);
                if (displayList == null || displayList.Count() != 0) // if displayList = 0 then HouseNo had in database
                    return false;
                return true;
            }, (p) =>

            {
                DetachedHouseInput testDetached = new DetachedHouseInput();
                //string checkDetachedNoField = testDetached.txbDetachedHouseNo.Text;
                string checkDetachedNoField = DetachedHouseNo.ToString();
                var displayList = DataProvider.Ins.DB.DetachedDB.Where(x => x.DetachedHouseNo == DetachedHouseNo);
                if (DetachedHouseNo.ToString() != "" && displayList.Count() == 0 && checkDetachedNoField != "")
                {
                    Comfirm = 1;
                    if (Comfirm == 1)
                    {
                        foreach (string SaveImageItem in NameIMG2)
                        {
                            File.Copy(SaveImageItem, System.IO.Path.Combine(SavePath, System.IO.Path.GetFileName(SaveImageItem)), true);
                        }
                        OpenFileDialog openDialog = new OpenFileDialog();
                        openDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
                    }

                    if (Comfirm == 1)
                    {
                        #region Value Form DetachedMangement
                        var AddRental = new DetachedDB()
                        {
                            DetachedHouseNo = (int)DetachedHouseNo,
                            DetachedHouseName = DetachedHouseName,
                            DetachedPost = DetachedPost,
                            DetachedAddress = DetachedAddress,
                            NearestSation = NearestSation,
                            Price = Price,
                            FloorPlanType = FloorPlanType,
                            FloorPlanDetails = FloorPlanDetails,
                            LandArea = LandArea,
                            BuildingArea = BuildingArea,
                            BuildingStructure = BuildingStructure,
                            DateConstruction = DateConstruction,
                            LandRights = LandRights,
                            Ground = Ground,
                            CityPlanning = CityPlanning,
                            UseDistrict = UseDistrict,
                            BuildingCoverageRatio = BuildingCoverageRatio,
                            FloorAreaRatio = FloorAreaRatio,
                            OtherLegalRestrictions = OtherLegalRestrictions,
                            Terrain = Terrain,
                            CurrentSituation = CurrentSituation,
                            DeliveryConditionTime = DeliveryConditionTime,
                            Parking = Parking,
                            TransactionMode = TransactionMode,
                            RoadsideSituation = RoadsideSituation,
                            Facility = Facility,
                            SchoolDistrict = SchoolDistrict,
                            NeighborhoodInformation = NeighborhoodInformation,
                            Remarks = Remarks,
                        };

                        DataProvider.Ins.DB.DetachedDB.Add(AddRental);
                        DataProvider.Ins.DB.SaveChanges();
                        //string appDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                        int nameImageCount = 0;
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
                        #endregion
                        for (int i = nameImageCount * 2 - 1; i >= 0; i--)
                        {
                            NameIMG.RemoveAt(i);
                            if (i % 2 == 0)
                            {
                                ImageListPath.RemoveAt(i / 2);
                            }
                        }
                        ImagePath = "";
                        MessageBox.Show("物件内容を登録しました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        Comfirm = 0;
                        DetachedHouseNo = null;
                    }
                }
                else if (checkDetachedNoField == "")
                {
                    MessageBox.Show("物件番号を入力してください！", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (displayList.Count() != 0)
                {
                    MessageBox.Show("物件番（番号：" + DetachedHouseNo + "）号がありました！", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });

            int nameduplicate = 0;
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

                            foreach (String nameDuplicate in ImageListPath)
                            {
                                if (nameDuplicate == fileName)
                                {
                                    nameduplicate++;
                                }
                            }

                            if (File.Exists(SavePath + "\\" + fileName) || nameduplicate > 0)
                            {
                                var result = MessageBox.Show("【" + fileName + "】 " + "がありました。\nもう一度写真を選択或いはアップデートしたい写真の名前を変更ください！", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                                if (result == MessageBoxResult.OK)
                                {
                                    nameduplicate = 0;
                                    goto duplicateImage;
                                }
                            }
                        }

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
                            deleteButton.Command = deleteAction;
                            deleteButton.Background = Brushes.Red;
                            deleteButton.Click += new RoutedEventHandler(home_read_click);

                            NameIMG.Add(imageControl);
                            NameIMG.Add(deleteButton);
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
                NameIMG2.RemoveAt(0);
                NameIMG.RemoveAt(index: indexBtn);
                NameIMG.RemoveAt(index: indexImg);
            }
            else
            {
                string nameImage = ImageListPath.ElementAt(indexImg / 2).ToString();
                ImageListPath.RemoveAt(indexImg / 2);
                NameIMG2.RemoveAt(indexImg / 2);
                NameIMG.RemoveAt(index: indexBtn);
                NameIMG.RemoveAt(index: indexImg);
            }

            ImagePath = "";
            foreach (var saveImageName in ImageListPath)
            {
                ImagePath += conbineCharatarBefore + saveImageName + conbineCharatarAfter;
            }
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

        private void DeleteImage(string nameImage)
        {
            // Get current working directory (..\bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // GEt the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            // Create specific path file
            string SavePath = string.Format(@"{0}\\matsuki\matsuki\images\DetachedImage\", projectDirectory);
            File.Delete(SavePath + nameImage);
        }
    }
}
