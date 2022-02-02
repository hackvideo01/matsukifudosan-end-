using matsukifudousan.Model;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ImageDB = matsukifudousan.Model.ImageDB;
using Image = System.Windows.Controls.Image;
using Brushes = System.Windows.Media.Brushes;
using Button = System.Windows.Controls.Button;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using System.Windows.Controls.Primitives;
using System.Configuration;

namespace matsukifudousan.ViewModel
{
    public class RentalInputViewModel : BaseViewModel
    {
        #region Rental Item Input
        private Nullable<int> _HouseNo;
        public Nullable<int> HouseNo { get => _HouseNo; set { _HouseNo = value; OnPropertyChanged(); } }

        private string _HouseName;
        public string HouseName { get => _HouseName; set { _HouseName = value; OnPropertyChanged(); } }

        private string _HousePost;
        public string HousePost { get => _HousePost; set { _HousePost = value; OnPropertyChanged(); } }

        private string _HouseAddress;
        public string HouseAddress { get => _HouseAddress; set { _HouseAddress = value; OnPropertyChanged(); } }

        private string _NearestSation;
        public string NearestSation { get => _NearestSation; set { _NearestSation = value; OnPropertyChanged(); } }

        private string _HouseType;
        public string HouseType { get => _HouseType; set { _HouseType = value; OnPropertyChanged(); } }

        private string _Construction;
        public string Construction { get => _Construction; set { _Construction = value; OnPropertyChanged(); } }

        private string _YearConstruction;
        public string YearConstruction { get => _YearConstruction; set { _YearConstruction = value; OnPropertyChanged(); } }

        private string _Decorate;
        public string Decorate { get => _Decorate; set { _Decorate = value; OnPropertyChanged(); } }

        private string _TotalArea;
        public string TotalArea { get => _TotalArea; set { _TotalArea = value; OnPropertyChanged(); } }

        private string _Parking;
        public string Parking { get => _Parking; set { _Parking = value; OnPropertyChanged(); } }

        private string _Pets;
        public string Pets { get => _Pets; set { _Pets = value; OnPropertyChanged(); } }

        private string _OtherEquipment;
        public string OtherEquipment { get => _OtherEquipment; set { _OtherEquipment = value; OnPropertyChanged(); } }

        private string _HouseRemarks;
        public string HouseRemarks { get => _HouseRemarks; set { _HouseRemarks = value; OnPropertyChanged(); } }

        private string _SecurityDeposit;
        public string SecurityDeposit { get => _SecurityDeposit; set { _SecurityDeposit = value; OnPropertyChanged(); } }

        private string _KeyMoney;
        public string KeyMoney { get => _KeyMoney; set { _KeyMoney = value; OnPropertyChanged(); } }

        private string _CommonFee;
        public string CommonFee { get => _CommonFee; set { _CommonFee = value; OnPropertyChanged(); } }

        private string _ManagementFee;
        public string ManagementFee { get => _ManagementFee; set { _ManagementFee = value; OnPropertyChanged(); } }

        private string _Rent;
        public string Rent { get => _Rent; set { _Rent = value; OnPropertyChanged(); } }

        private string _ParkingFee;
        public string ParkingFee { get => _ParkingFee; set { _ParkingFee = value; OnPropertyChanged(); } }

        private string _CATVFee;
        public string CATVFee { get => _CATVFee; set { _CATVFee = value; OnPropertyChanged(); } }

        private string _OtherFee;
        public string OtherFee { get => _OtherFee; set { _OtherFee = value; OnPropertyChanged(); } }

        private string _MNGMTCOName;
        public string MNGMTCOName { get => _MNGMTCOName; set { _MNGMTCOName = value; OnPropertyChanged(); } }

        private string _CompanyAddress;
        public string CompanyAddress { get => _CompanyAddress; set { _CompanyAddress = value; OnPropertyChanged(); } }

        private string _COPhone;
        public string COPhone { get => _COPhone; set { _COPhone = value; OnPropertyChanged(); } }

        private string _COFax;
        public string COFax { get => _COFax; set { _COFax = value; OnPropertyChanged(); } }

        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }

        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }

        private string _Fax;
        public string Fax { get => _Fax; set { _Fax = value; OnPropertyChanged(); } }

        private string _MNGMTForm;
        public string MNGMTForm { get => _MNGMTForm; set { _MNGMTForm = value; OnPropertyChanged(); } }

        private string _Remarks;
        public string Remarks { get => _Remarks; set { _Remarks = value; OnPropertyChanged(); } }

        private string _Image;
        public string Image { get => _Image; set { _Image = value; OnPropertyChanged(); } }

        #endregion

        #region
        private string _ImagePath;
        public string ImagePath { get => _ImagePath; set { _ImagePath = value; OnPropertyChanged(); } }

        private string _ImageFullPath;
        public string ImageFullPath { get => _ImageFullPath; set { _ImageFullPath = value; OnPropertyChanged(); } }
        #endregion
        //public ICommand ContractDetailsCommandWD { get; set; }

        public ICommand AddRentalCommand { get; set; }

        public ICommand AddImageCommand { get; set; }

        public ICommand deleteAction { get; set; }

        public string[] ImageObject;

        public string[] ImageObjectSave;

        public string[] ImageObject2;

        public string[] ImageNameObject;

        //private ObservableCollection<Object> _ImageObject = new ObservableCollection<Object>();
        //public ObservableCollection<Object> ImageObject { get => _ImageObject; set { _ImageObject = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _NameIMG = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMG { get => _NameIMG; set { _NameIMG = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _NameIMG2 = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMG2 { get => _NameIMG2; set { _NameIMG2 = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _ImageListPath = new ObservableCollection<Object>();
        public ObservableCollection<Object> ImageListPath { get => _ImageListPath; set { _ImageListPath = value; OnPropertyChanged(); } }

        private string _SelectedMNGMTCOName;
        public string SelectedMNGMTCOName { get => _SelectedMNGMTCOName; set { _SelectedMNGMTCOName = value; OnPropertyChanged(); } }

        private int _SelectedMNGMTCOId;
        public int SelectedMNGMTCOId { get => _SelectedMNGMTCOId; set { _SelectedMNGMTCOId = value; OnPropertyChanged(); } }

        //private List<object> ImageListPath = new List<object>();

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

        public RentalInputViewModel()
        {
            var PathRoot = ConfigurationManager.AppSettings["Path"];

            // Get current working directory (..\bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // GEt the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            // Create specific path file
            string SavePath = string.Format(@"{0}" + PathRoot + "images\\RentalImage", projectDirectory);

            string ImageNameString = ImageListPath.ToString();
            //ContractDetailsCommandWD = new RelayCommand<object>((p) => { return true; }, (p) => { ContractDetails wd = new ContractDetails(); wd.ShowDialog(); });

            AddRentalCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(HouseNo.ToString()))
                    return false;

                var displayList = DataProvider.Ins.DB.RentalManagementDB.Where(x => x.HouseNo == HouseNo);
                if (displayList == null || displayList.Count() != 0) // if displayList = 0 then HouseNo had in database
                    return false;

                return true;
            }, (p) =>
            {
                RentalInput testRental = new RentalInput();
                //string checkRentalField = testRental.txbHouseNo.Text;
                string checkRentalField = HouseNo.ToString();
                var displayList = DataProvider.Ins.DB.RentalManagementDB.Where(x => x.HouseNo == HouseNo);
                if (HouseNo.ToString() != "" && displayList.Count() == 0 && checkRentalField != "")
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

                        if (DataProvider.Ins.DB.CustomerDB.Where(cs => cs.CustomerName == SelectedMNGMTCOName).Count() != 0)
                        {
                            SelectedMNGMTCOId = DataProvider.Ins.DB.CustomerDB.Where(cs => cs.CustomerName == SelectedMNGMTCOName).FirstOrDefault().CustomerNo;

                            var AddRentalCustomerHave = new RentalManagementDB()
                            {
                                HouseNo = (int)HouseNo,
                                HouseName = HouseName,
                                HousePost = HousePost,
                                HouseAddress = HouseAddress,
                                NearestSation = NearestSation,
                                HouseType = HouseType,
                                Construction = Construction,
                                YearConstruction = YearConstruction,
                                Decorate = Decorate,
                                TotalArea = TotalArea,
                                Parking = Parking,
                                Pets = Pets,
                                OtherEquipment = OtherEquipment,
                                HouseRemarks = HouseRemarks,
                                SecurityDeposit = SecurityDeposit,
                                KeyMoney = KeyMoney,
                                CommonFee = CommonFee,
                                ManagementFee = ManagementFee,
                                Rent = Rent,
                                ParkingFee = ParkingFee,
                                CATVFee = CATVFee,
                                OtherFee = OtherFee,
                                MNGMTCOName = SelectedMNGMTCOName,
                                CompanyAddress = CompanyAddress,
                                COPhone = COPhone,
                                COFax = COFax,
                                Name = Name,
                                Address = Address,
                                Phone = Phone,
                                Fax = Fax,
                                MNGMTForm = MNGMTForm,
                                Remarks = Remarks,
                                CustomerNo = SelectedMNGMTCOId,
                            };

                            DataProvider.Ins.DB.RentalManagementDB.Add(AddRentalCustomerHave);
                            DataProvider.Ins.DB.SaveChanges();
                        }
                        else
                        {
                            #region Value Form RentalMangement
                            var AddRental = new RentalManagementDB()
                            {
                                HouseNo = (int)HouseNo,
                                HouseName = HouseName,
                                HousePost = HousePost,
                                HouseAddress = HouseAddress,
                                NearestSation = NearestSation,
                                HouseType = HouseType,
                                Construction = Construction,
                                YearConstruction = YearConstruction,
                                Decorate = Decorate,
                                TotalArea = TotalArea,
                                Parking = Parking,
                                Pets = Pets,
                                OtherEquipment = OtherEquipment,
                                HouseRemarks = HouseRemarks,
                                SecurityDeposit = SecurityDeposit,
                                KeyMoney = KeyMoney,
                                CommonFee = CommonFee,
                                ManagementFee = ManagementFee,
                                Rent = Rent,
                                ParkingFee = ParkingFee,
                                CATVFee = CATVFee,
                                OtherFee = OtherFee,
                                MNGMTCOName = SelectedMNGMTCOName,
                                CompanyAddress = CompanyAddress,
                                COPhone = COPhone,
                                COFax = COFax,
                                Name = Name,
                                Address = Address,
                                Phone = Phone,
                                Fax = Fax,
                                MNGMTForm = MNGMTForm,
                                Remarks = Remarks,
                                CustomerNo = 0,
                            };
                            DataProvider.Ins.DB.RentalManagementDB.Add(AddRental);
                            DataProvider.Ins.DB.SaveChanges();
                        }
                        
                        //string appDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                        int nameImageCount = 0;
                        foreach (string saveImageDB in ImageListPath)
                        {
                            var AddImage = new ImageDB()
                            {
                                ImageName = saveImageDB,
                                ImagePath = SavePath + "\\" + saveImageDB,
                                HouseNo = HouseNo
                            };
                            DataProvider.Ins.DB.ImageDB.Add(AddImage);
                            DataProvider.Ins.DB.SaveChanges();

                            nameImageCount++;
                        }

                        for (int i = nameImageCount * 2 - 1; i >= 0; i--)
                        {
                            NameIMG.RemoveAt(i);
                            if (i % 2 == 0)
                            {
                                ImageListPath.RemoveAt(i / 2);
                            }
                            ImagePath = "";
                        }
                        MessageBox.Show("物件内容を登録しました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        Comfirm = 0;
                        HouseNo = null;
                    }
                    #endregion
                }
                else if (checkRentalField == "")
                {
                    MessageBox.Show("物件番号を入力してください！", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (displayList.Count() != 0)
                {
                    MessageBox.Show("物件番(番号：" + HouseNo + "）号がありました！", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
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
            var PathRoot = ConfigurationManager.AppSettings["Path"];

            // Get current working directory (..\bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // GEt the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            // Create specific path file
            string SavePath = string.Format(@"{0}" + PathRoot + "images\\RentalImage\\", projectDirectory);
            File.Delete(SavePath + nameImage);
        }
    }
}
