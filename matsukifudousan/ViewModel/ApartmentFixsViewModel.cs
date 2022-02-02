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
    public class ApartmentFixsViewModel : BaseViewModel, System.ComponentModel.INotifyPropertyChanged
    {


        #region Apartment Item Input
        private int _ApartmentHouseNo;
        public int ApartmentHouseNo { get => _ApartmentHouseNo; set { _ApartmentHouseNo = value; OnPropertyChanged(); } }

        private string _ApartmentHouseName;
        public string ApartmentHouseName { get => _ApartmentHouseName; set { _ApartmentHouseName = value; OnPropertyChanged(); } }

        private string _ApartmentPost;
        public string ApartmentPost { get => _ApartmentPost; set { _ApartmentPost = value; OnPropertyChanged(); } }

        private string _ApartmentAddress;
        public string ApartmentAddress { get => _ApartmentAddress; set { _ApartmentAddress = value; OnPropertyChanged(); } }

        private string _NearestSation;
        public string NearestSation { get => _NearestSation; set { _NearestSation = value; OnPropertyChanged(); } }

        private string _Price;
        public string Price { get => _Price; set { _Price = value; OnPropertyChanged(); } }

        private string _FloorPlanType;
        public string FloorPlanType { get => _FloorPlanType; set { _FloorPlanType = value; OnPropertyChanged(); } }

        private string _FloorPlanDetails;
        public string FloorPlanDetails { get => _FloorPlanDetails; set { _FloorPlanDetails = value; OnPropertyChanged(); } }

        private string _OccupiedArea;
        public string OccupiedArea { get => _OccupiedArea; set { _OccupiedArea = value; OnPropertyChanged(); } }

        private string _BalconyArea;
        public string BalconyArea { get => _BalconyArea; set { _BalconyArea = value; OnPropertyChanged(); } }

        private string _LocationNumberFloors;
        public string LocationNumberFloors { get => _LocationNumberFloors; set { _LocationNumberFloors = value; OnPropertyChanged(); } }

        private string _TotalUnits;
        public string TotalUnits { get => _TotalUnits; set { _TotalUnits = value; OnPropertyChanged(); } }

        private string _BuildingStructure;
        public string BuildingStructure { get => _BuildingStructure; set { _BuildingStructure = value; OnPropertyChanged(); } }

        private string _DateConstruction;
        public string DateConstruction { get => _DateConstruction; set { _DateConstruction = value; OnPropertyChanged(); } }

        private string _ConstructionCompany;
        public string ConstructionCompany { get => _ConstructionCompany; set { _ConstructionCompany = value; OnPropertyChanged(); } }

        private string _ManagementCompany;
        public string ManagementCompany { get => _ManagementCompany; set { _ManagementCompany = value; OnPropertyChanged(); } }

        private string _ManagementForm;
        public string ManagementForm { get => _ManagementForm; set { _ManagementForm = value; OnPropertyChanged(); } }

        private string _ManagementFee;
        public string ManagementFee { get => _ManagementFee; set { _ManagementFee = value; OnPropertyChanged(); } }

        private string _RepairReserveFund;
        public string RepairReserveFund { get => _RepairReserveFund; set { _RepairReserveFund = value; OnPropertyChanged(); } }

        private string _OtherFee;
        public string OtherFee { get => _OtherFee; set { _OtherFee = value; OnPropertyChanged(); } }

        private string _Parking;
        public string Parking { get => _Parking; set { _Parking = value; OnPropertyChanged(); } }

        private string _CurrentSituation;
        public string CurrentSituation { get => _CurrentSituation; set { _CurrentSituation = value; OnPropertyChanged(); } }

        private string _DeliveryConditionTime;
        public string DeliveryConditionTime { get => _DeliveryConditionTime; set { _DeliveryConditionTime = value; OnPropertyChanged(); } }

        private string _TransactionMode;
        public string TransactionMode { get => _TransactionMode; set { _TransactionMode = value; OnPropertyChanged(); } }

        private string _RoadsideSituation;
        public string RoadsideSituation { get => _RoadsideSituation; set { _RoadsideSituation = value; OnPropertyChanged(); } }

        private string _MainEquipment;
        public string MainEquipment { get => _MainEquipment; set { _MainEquipment = value; OnPropertyChanged(); } }

        private string _EquipmentEachHouse;
        public string EquipmentEachHouse { get => _EquipmentEachHouse; set { _EquipmentEachHouse = value; OnPropertyChanged(); } }

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

        private int _apartmentSearchHouseNo;
        public int apartmentSearchHouseNo { get => _apartmentSearchHouseNo; set { _apartmentSearchHouseNo = value; OnPropertyChanged(); } }
        #endregion
        public ICommand ContractDetailsCommandWD { get; set; }

        public ICommand AddApartmentCommand { get; set; }

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

        private ObservableCollection<ApartmentDB> _ApartmentDetailsView;
        public ObservableCollection<ApartmentDB> ApartmentDetailsView { get => _ApartmentDetailsView; set { _ApartmentDetailsView = value; OnPropertyChanged(); } }

        private ObservableCollection<ImageDB> _apartmentImageView;
        public ObservableCollection<ImageDB> apartmentImageView { get => _apartmentImageView; set { _apartmentImageView = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _NameIMGDeleteList = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMGDeleteList { get => _NameIMGDeleteList; set { _NameIMGDeleteList = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _ImageData = new ObservableCollection<Object>();
        public ObservableCollection<Object> ImageData { get => _ImageData; set { _ImageData = value; OnPropertyChanged(); } }

        string conbineCharatarBefore = "[";

        string conbineCharatarAfter = "] ";

        public int Comfirm = 0;

        public ApartmentFixsViewModel()
        {
            var PathRoot = ConfigurationManager.AppSettings["Path"];

            // Get current working directory (..\bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // GEt the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            // Create specific path file
            string SavePath = string.Format(@"{0}" + PathRoot + "images\\ApartmentImage", projectDirectory);

            string[] a = ImageObject;

            ApartmentSearch apartmentSearch = new ApartmentSearch();

            apartmentSearchHouseNo = Int32.Parse(apartmentSearch.House.Text);

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

            AddApartmentCommand = new RelayCommand<object>((p) =>
            {
                //if (string.IsNullOrEmpty(HouseNo))
                //    return false;

                //var displayList = DataProvider.Ins.DB.ApartmentDB.Where(x => x.HouseNo == HouseNo);
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

                #region Value Form ApartmentMangement

                var AddApartment = DataProvider.Ins.DB.ApartmentDB.Where(hno => hno.ApartmentHouseNo == apartmentSearchHouseNo).SingleOrDefault();

                AddApartment.ApartmentHouseName = ApartmentHouseName;
                AddApartment.ApartmentPost = ApartmentPost;
                AddApartment.ApartmentAddress = ApartmentAddress;
                AddApartment.NearestSation = NearestSation;
                AddApartment.Price = Price;
                AddApartment.FloorPlanType = FloorPlanType;
                AddApartment.FloorPlanDetails = FloorPlanDetails;
                AddApartment.OccupiedArea = OccupiedArea;
                AddApartment.BalconyArea = BalconyArea;
                AddApartment.LocationNumberFloors = LocationNumberFloors;
                AddApartment.TotalUnits = TotalUnits;
                AddApartment.BuildingStructure = BuildingStructure;
                AddApartment.DateConstruction = DateConstruction;
                AddApartment.ConstructionCompany = ConstructionCompany;
                AddApartment.ManagementCompany = ManagementCompany;
                AddApartment.ManagementForm = ManagementForm;
                AddApartment.ManagementFee = ManagementFee;
                AddApartment.RepairReserveFund = RepairReserveFund;
                AddApartment.OtherFee = OtherFee;
                AddApartment.Parking = Parking;
                AddApartment.CurrentSituation = CurrentSituation;
                AddApartment.DeliveryConditionTime = DeliveryConditionTime;
                AddApartment.TransactionMode = TransactionMode;
                AddApartment.RoadsideSituation = RoadsideSituation;
                AddApartment.MainEquipment = MainEquipment;
                AddApartment.EquipmentEachHouse = EquipmentEachHouse;
                AddApartment.SchoolDistrict = SchoolDistrict;
                AddApartment.NeighborhoodInformation = NeighborhoodInformation;
                AddApartment.Remarks = Remarks;

                DataProvider.Ins.DB.SaveChanges();
                string appDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                int nameImageCount = 0;

                apartmentImageView = new ObservableCollection<ImageDB>(DataProvider.Ins.DB.ImageDB.Where(img => img.ApartmentHouseNo == apartmentSearchHouseNo));
                DataProvider.Ins.DB.ImageDB.RemoveRange(apartmentImageView);
                DataProvider.Ins.DB.SaveChanges();
                foreach (string saveImageDB in ImageListPath)
                {
                    var AddImage = new ImageDB()
                    {
                        ImageName = saveImageDB,
                        ImagePath = SavePath + "\\" + saveImageDB,
                        ApartmentHouseNo = ApartmentHouseNo
                    };
                    DataProvider.Ins.DB.ImageDB.Add(AddImage);
                    DataProvider.Ins.DB.SaveChanges();

                    nameImageCount++;
                }
                Comfirm = 1;

                if (Comfirm == 1)
                {

                    //foreach (string VARIABLE in NameIMGDeleteList)
                    //{
                    //    DeleteImage(VARIABLE);
                    //}

                    OpenFileDialog openDialog = new OpenFileDialog();
                    openDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";

                    MessageBox.Show("物件の内容を修正しました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);

                    Comfirm = 0;
                }

                //if (Comfirm == 1)
                //{
                //    for (int i = nameImageCount * 2 - 1; i >= 0; i--)
                //    {
                //        NameIMG.RemoveAt(i);
                //        ImagePath = "";
                //    }
                //}

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

            //string n = ((Button) sender).Content.ToString();

            //int index = Int32.Parse(n);

            var indexBtn = NameIMG.IndexOf(button);

            var indexImg = indexBtn - 1;

            if (indexImg == 0)
            {
                string nameImage = ImageListPath.ElementAt(0).ToString();
                ImageListPath.RemoveAt(0);
                NameIMG2.RemoveAt(0);
                NameIMG.RemoveAt(index: indexBtn);
                NameIMG.RemoveAt(index: indexImg);

                if (comfirmDeleteImage == 0)
                {
                    //NameIMGDeleteList.Add(nameImage);
                    var resultButtonDeleteImg = MessageBox.Show("本当にこの物件（画像：" + nameImage + "）を削除したいでしょうか？", "警告", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (resultButtonDeleteImg == MessageBoxResult.Yes)
                    {
                        DeleteImage(nameImage);

                        var imageDeleteDB = DataProvider.Ins.DB.ImageDB.Where(d => d.ApartmentHouseNo == apartmentSearchHouseNo && d.ImageName == nameImage);
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
                    //NameIMGDeleteList.Add(nameImage);
                    var resultButtonDeleteImg = MessageBox.Show("本当にこの物件（画像：" + nameImage + "）を削除したいでしょうか？", "警告", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (resultButtonDeleteImg == MessageBoxResult.Yes)
                    {
                        DeleteImage(nameImage);

                        var imageDeleteDB = DataProvider.Ins.DB.ImageDB.Where(d => d.ApartmentHouseNo == apartmentSearchHouseNo && d.ImageName == nameImage);
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
            if (apartmentSearchHouseNo != 0)
            {
                #region Display Column of value

                ApartmentDetailsView = new ObservableCollection<ApartmentDB>(DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo));

                ApartmentHouseNo = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().ApartmentHouseNo;
                ApartmentHouseName = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().ApartmentHouseName;
                ApartmentPost = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().ApartmentPost;
                ApartmentAddress = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().ApartmentAddress;
                NearestSation = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().NearestSation;
                Price = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().Price;
                FloorPlanType = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().FloorPlanType;
                FloorPlanDetails = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().FloorPlanDetails;
                OccupiedArea = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().OccupiedArea;
                BalconyArea = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().BalconyArea;
                LocationNumberFloors = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().LocationNumberFloors;
                TotalUnits = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().TotalUnits;
                BuildingStructure = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().BuildingStructure;
                DateConstruction = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().DateConstruction;
                ConstructionCompany = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().ConstructionCompany;
                ManagementCompany = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().ManagementCompany;
                ManagementForm = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().ManagementForm;
                ManagementFee = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().ManagementFee;
                RepairReserveFund = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().RepairReserveFund;
                OtherFee = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().OtherFee;
                Parking = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().Parking;
                CurrentSituation = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().CurrentSituation;
                DeliveryConditionTime = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().DeliveryConditionTime;
                TransactionMode = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().TransactionMode;
                RoadsideSituation = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().RoadsideSituation;
                MainEquipment = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().MainEquipment;
                EquipmentEachHouse = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().EquipmentEachHouse;
                SchoolDistrict = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().SchoolDistrict;
                NeighborhoodInformation = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().NeighborhoodInformation;
                Remarks = DataProvider.Ins.DB.ApartmentDB.Where(v => v.ApartmentHouseNo == apartmentSearchHouseNo).First().Remarks;

                #endregion


                apartmentImageView = new ObservableCollection<ImageDB>(DataProvider.Ins.DB.ImageDB.Where(img => img.ApartmentHouseNo == apartmentSearchHouseNo));


                foreach (var imagePathDB in apartmentImageView)
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
            string SavePath = string.Format(@"{0}" + PathRoot + "images\\ApartmentImage\\", projectDirectory);

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
