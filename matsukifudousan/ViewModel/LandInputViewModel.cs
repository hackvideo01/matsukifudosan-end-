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
    public class LandInputViewModel : BaseViewModel
    {
        #region Land Item Input
        private Nullable<int> _LandNo;
        public Nullable<int> LandNo { get => _LandNo; set { _LandNo = value; OnPropertyChanged(); } }

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
        #endregion
        public ICommand ContractDetailsCommandWD { get; set; }

        public ICommand AddLandCommand { get; set; }

        public ICommand AddImageCommand { get; set; }

        public ICommand deleteAction { get; set; }

        public string[] ImageObject;

        public string[] ImageNameObject;

        private ObservableCollection<Object> _NameIMG = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMG { get => _NameIMG; set { _NameIMG = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _NameIMG2 = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMG2 { get => _NameIMG2; set { _NameIMG2 = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _ImageListPath = new ObservableCollection<Object>();
        public ObservableCollection<Object> ImageListPath { get => _ImageListPath; set { _ImageListPath = value; OnPropertyChanged(); } }

        string conbineCharatarBefore = "[";
        string conbineCharatarAfter = "] ";
        public int Comfirm = 0;

        //public void ClearTextBoxes(System.Windows.Forms.Control.ControlCollection ctrlCollection)
        //{
        //    foreach (System.Windows.Forms.Control ctrl in ctrlCollection)
        //    {
        //        if (ctrl is TextBoxBase)
        //        {
        //            ctrl.Text = String.Empty;
        //        }
        //        else
        //        {
        //            ClearTextBoxes(ctrl.Controls);
        //        }
        //    }
        //}

        public LandInputViewModel()
        {
            var PathRoot = ConfigurationManager.AppSettings["Path"];

            // Get current working directory (..\bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // GEt the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            // Create specific path file
            string SavePath = string.Format(@"{0}" + PathRoot + "images\\LandImage", projectDirectory);

            string ImageNameString = ImageListPath.ToString();
            ContractDetailsCommandWD = new RelayCommand<object>((p) => { return true; }, (p) => { ContractDetails wd = new ContractDetails(); wd.ShowDialog(); });

            AddLandCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(LandNo.ToString()))
                    return false;
                var displayList = DataProvider.Ins.DB.LandDB.Where(x => x.LandNo == LandNo);
                if (displayList == null || displayList.Count() != 0) // if displayList = 0 then HouseNo had in database
                    return false;
                return true;
            }, (p) =>
            {
                LandInput testLandNo = new LandInput();
                //string chekLanNoField = testLandNo.txbLandNo.Text;
                string checkLanNoField = LandNo.ToString();
                var displayList = DataProvider.Ins.DB.LandDB.Where(x => x.LandNo == LandNo);
                if (LandNo.ToString() != "" && displayList.Count() == 0 && checkLanNoField != "")
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
                        #region Value Form ApartmentMangement
                        var Land = new LandDB()
                        {
                            LandNo = (int)LandNo,
                            LandName = LandName,
                            LandPost = LandPost,
                            LandAddress = LandAddress,
                            NearestSation = NearestSation,
                            Price = Price,
                            UnitPrice = UnitPrice,
                            LandArea = LandArea,
                            RoadBurden = RoadBurden,
                            LandRights = LandRights,
                            Ground = Ground,
                            CityPlan = CityPlan,
                            UseDistrict = UseDistrict,
                            BuildingCoverage = BuildingCoverage,
                            VolumeRaito = VolumeRaito,
                            OtherLegalRestrictions = OtherLegalRestrictions,
                            Terrain = Terrain,
                            CurrentSituation = CurrentSituation,
                            DeliveryConditionTime = DeliveryConditionTime,
                            BuildingConditions = BuildingConditions,
                            TransactionMode = TransactionMode,
                            RoadsideSituation = RoadsideSituation,
                            Facility = Facility,
                            SchoolDistrict = SchoolDistrict,
                            NeighborhoodInformation = NeighborhoodInformation,
                            Remarks = Remarks,
                        };

                        DataProvider.Ins.DB.LandDB.Add(Land);
                        DataProvider.Ins.DB.SaveChanges();

                        int nameImageCount = 0;
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
                        LandNo = null;
                    }
                }
                else if (checkLanNoField == "")
                {
                    MessageBox.Show("物件番号を入力してください！", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (displayList.Count() != 0)
                {
                    MessageBox.Show("物件番（番号：" + LandNo + "）号がありました！", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
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
            var PathRoot = ConfigurationManager.AppSettings["Path"];

            // Get current working directory (..\bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // GEt the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            // Create specific path file
            string SavePath = string.Format(@"{0}" + PathRoot + "images\\LandImage\\", projectDirectory);
            File.Delete(SavePath + nameImage);
        }
    }
}
