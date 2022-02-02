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
    public class CustomerInputViewModel : BaseViewModel
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

        public ICommand AddCustomerCommand { get; set; }

        public ICommand AddPhoto1Command { get; set; }

        public ICommand AddPhoto2Command { get; set; }

        public ICommand CardRightCommand { get; set; }

        public ICommand CardLeftCommand { get; set; }

        public ICommand deleteAction { get; set; }

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

        private ObservableCollection<Object> _NameIMGCardRight2 = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMGCardRight2 { get => _NameIMGCardRight2; set { _NameIMGCardRight2 = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _NameIMGCardLeft1 = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMGCardLeft1 { get => _NameIMGCardLeft1; set { _NameIMGCardLeft1 = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _NameIMGCardLeft2 = new ObservableCollection<Object>();
        public ObservableCollection<Object> NameIMGCardLeft2 { get => _NameIMGCardLeft2; set { _NameIMGCardLeft2 = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _ImageListPath1 = new ObservableCollection<Object>();
        public ObservableCollection<Object> ImageListPath1 { get => _ImageListPath1; set { _ImageListPath1 = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _ImageListPath2 = new ObservableCollection<Object>();
        public ObservableCollection<Object> ImageListPath2 { get => _ImageListPath2; set { _ImageListPath2 = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _ImageListPath3 = new ObservableCollection<Object>();
        public ObservableCollection<Object> ImageListPath3 { get => _ImageListPath3; set { _ImageListPath3 = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _ImageListPath4 = new ObservableCollection<Object>();
        public ObservableCollection<Object> ImageListPath4 { get => _ImageListPath4; set { _ImageListPath4 = value; OnPropertyChanged(); } }

        string conbineCharatarBefore = "[";
        string conbineCharatarAfter = "] ";
        public int Comfirm = 0;

        public CustomerInputViewModel()
        {
            var PathRoot = ConfigurationManager.AppSettings["Path"];

            // Get current working directory (..\bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // GEt the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            // Create specific path file
            string SavePath = string.Format(@"{0}" + PathRoot + "images\\Customer", projectDirectory);

            string ImageName1String = ImageListPath1.ToString();
            string ImageName2String = ImageListPath2.ToString();

            AddCustomerCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(CustomerNo.ToString()))
                    return false;
                var displayList = DataProvider.Ins.DB.CustomerDB.Where(x => x.CustomerNo == CustomerNo);
                if (displayList == null || displayList.Count() != 0) // if displayList = 0 then HouseNo had in database
                    return false;
                return true;
            }, (p) =>
            {
                CustomerInput testCustomerNo = new CustomerInput();
                //string checkCustomerNoField = testCustomerNo.txbCustomerNo.Text;
                string checkCustomerNoField = CustomerNo.ToString();
                var displayList = DataProvider.Ins.DB.CustomerDB.Where(x => x.CustomerNo == CustomerNo);
                if (CustomerNo.ToString() != "" && displayList.Count() == 0 && checkCustomerNoField != "")
                {
                    Comfirm = 1;
                    if (Comfirm == 1)
                    {
                        foreach (string SaveImageItem in NameIMGFirst2)
                        {
                            try
                            {
                                File.Copy(SaveImageItem, System.IO.Path.Combine(SavePath, System.IO.Path.GetFileName(SaveImageItem)), true);
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show("" + e, "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }

                        foreach (string SaveImageItem in NameIMGSecond2)
                        {
                            File.Copy(SaveImageItem, System.IO.Path.Combine(SavePath, System.IO.Path.GetFileName(SaveImageItem)), true);
                        }

                        foreach (string SaveImageItem in NameIMGCardRight2)
                        {
                            File.Copy(SaveImageItem, System.IO.Path.Combine(SavePath, System.IO.Path.GetFileName(SaveImageItem)), true);
                        }

                        foreach (string SaveImageItem in NameIMGCardLeft2)
                        {
                            File.Copy(SaveImageItem, System.IO.Path.Combine(SavePath, System.IO.Path.GetFileName(SaveImageItem)), true);
                        }
                        OpenFileDialog openDialog = new OpenFileDialog();
                        openDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
                    }

                    if (Comfirm == 1)
                    {
                        #region Value Form Customer
                        var Customer = new CustomerDB()
                        {
                            CustomerNo = (int)CustomerNo,
                            CustomerName = CustomerName,
                            PostCode = PostCode,
                            Address = Address,
                            TelephoneNumber = TelephoneNumber,
                            FaxNumber = FaxNumber,
                            EmailAddress = EmailAddress,
                            Manager = Manager,
                            ContactInformation = ContactInformation,
                            RegistrationDate = RegistrationDate,
                            LastUpdateDate = LastUpdateDate,
                            Comment1 = Comment1,
                            Comment2 = Comment2,
                        };

                        DataProvider.Ins.DB.CustomerDB.Add(Customer);
                        DataProvider.Ins.DB.SaveChanges();

                        int nameImageCountPhoto1 = 0;
                        foreach (string saveImageDB in ImageListPath1)
                        {
                            var AddImage = new ImageDB()
                            {
                                ImageName = saveImageDB,
                                ImagePath = SavePath + "\\" + saveImageDB,
                                CustomerNo = CustomerNo,
                                ImageType = "1"
                            };
                            DataProvider.Ins.DB.ImageDB.Add(AddImage);
                            DataProvider.Ins.DB.SaveChanges();
                            nameImageCountPhoto1++;
                        }
                        #endregion

                        for (int i = nameImageCountPhoto1 * 2 - 1; i >= 0; i--)
                        {
                            NameIMGFirst1.RemoveAt(i);
                            if (i % 2 == 0)
                            {
                                ImageListPath1.RemoveAt(i / 2);
                            }
                        }
                        ImagePath1 = "";

                        int nameImageCountPhoto2 = 0;
                        foreach (string saveImageDB in ImageListPath2)
                        {
                            var AddImage = new ImageDB()
                            {
                                ImageName = saveImageDB,
                                ImagePath = SavePath + "\\" + saveImageDB,
                                CustomerNo = CustomerNo,
                                ImageType = "2"
                            };
                            DataProvider.Ins.DB.ImageDB.Add(AddImage);
                            DataProvider.Ins.DB.SaveChanges();
                            nameImageCountPhoto2++;
                        }

                        for (int i = nameImageCountPhoto2 * 2 - 1; i >= 0; i--)
                        {
                            NameIMGSecond1.RemoveAt(i);
                            if (i % 2 == 0)
                            {
                                ImageListPath2.RemoveAt(i / 2);
                            }
                        }
                        ImagePath2 = "";

                        int nameImageCountPhoto3 = 0;
                        foreach (string saveImageDB in ImageListPath3)
                        {
                            var AddImage = new ImageDB()
                            {
                                ImageName = saveImageDB,
                                ImagePath = SavePath + "\\" + saveImageDB,
                                CustomerNo = CustomerNo,
                                ImageType = "3"
                            };
                            DataProvider.Ins.DB.ImageDB.Add(AddImage);
                            DataProvider.Ins.DB.SaveChanges();
                            nameImageCountPhoto3++;
                        }

                        for (int i = nameImageCountPhoto3 * 2 - 1; i >= 0; i--)
                        {
                            NameIMGCardRight1.RemoveAt(i);
                            if (i % 2 == 0)
                            {
                                ImageListPath3.RemoveAt(i / 2);
                            }
                        }
                        ImagePath3 = "";

                        int nameImageCountPhoto4 = 0;
                        foreach (string saveImageDB in ImageListPath4)
                        {
                            var AddImage = new ImageDB()
                            {
                                ImageName = saveImageDB,
                                ImagePath = SavePath + "\\" + saveImageDB,
                                CustomerNo = CustomerNo,
                                ImageType = "4"
                            };
                            DataProvider.Ins.DB.ImageDB.Add(AddImage);
                            DataProvider.Ins.DB.SaveChanges();
                            nameImageCountPhoto4++;
                        }

                        for (int i = nameImageCountPhoto4 * 2 - 1; i >= 0; i--)
                        {
                            NameIMGCardLeft1.RemoveAt(i);
                            if (i % 2 == 0)
                            {
                                ImageListPath4.RemoveAt(i / 2);
                            }
                        }
                        ImagePath4 = "";

                        MessageBox.Show("得意先内容を保存しました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        Comfirm = 0;
                        CustomerNo = null;
                    }
                }
                else if (checkCustomerNoField == "")
                {
                    MessageBox.Show("得意先番号を入力してください！", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (displayList.Count() != 0)
                {
                    MessageBox.Show("得意先番" + CustomerNo + "号がありました！", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            });

            int nameduplicatePhoto1 = 0;
            AddPhoto1Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {
                duplicateImage:
                    OpenFileDialog openDialog = new OpenFileDialog();
                    openDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
                    openDialog.Multiselect = false;

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

                            foreach (String nameDuplicate in ImageListPath1)
                            {
                                if (nameDuplicate == fileName)
                                {
                                    nameduplicatePhoto1++;
                                }
                            }

                            if (File.Exists(SavePath + "\\" + fileName) || nameduplicatePhoto1 > 0)
                            {
                                var result = MessageBox.Show("【" + fileName + "】 " + "がありました。\nもう一度写真を選択或いはアップデートしたい写真の名前を変更ください！", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                                if (result == MessageBoxResult.OK)
                                {
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
                            imageControl.MouseLeftButtonDown += popupFirst_read_click;

                            Button deleteButton = new Button();
                            deleteButton.Content = "X";
                            deleteButton.Name = "Delete";
                            deleteButton.Command = deleteAction;
                            deleteButton.Background = Brushes.Red;
                            deleteButton.Click += new RoutedEventHandler(photo1_home_read_click);

                            NameIMGFirst1.Add(imageControl);
                            NameIMGFirst1.Add(deleteButton);
                        }

                        ImageObject1 = openDialog.FileNames;
                        ImageNameObject1 = openDialog.SafeFileNames;
                        foreach (String saveImageName2 in ImageObject1)
                        {
                            NameIMGFirst2.Add(saveImageName2);
                        }

                        foreach (String saveImageName in ImageNameObject1)
                        {
                            ImageListPath1.Add(saveImageName);
                        }

                        ImagePath1 = "";
                        foreach (var saveImageName in ImageListPath1)
                        {
                            ImagePath1 += conbineCharatarBefore + saveImageName + conbineCharatarAfter;
                        }
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    MessageBox.Show("Fix!" + e, "ERROR!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            int nameduplicatePhoto2 = 0;
            AddPhoto2Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {
                duplicateImage:
                    OpenFileDialog openDialog = new OpenFileDialog();
                    openDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
                    openDialog.Multiselect = false;

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

                            foreach (String nameDuplicate in ImageListPath2)
                            {
                                if (nameDuplicate == fileName)
                                {
                                    nameduplicatePhoto2++;
                                }
                            }

                            if (File.Exists(SavePath + "\\" + fileName) || nameduplicatePhoto2 > 0)
                            {
                                var result = MessageBox.Show("【" + fileName + "】 " + "がありました。\nもう一度写真を選択或いはアップデートしたい写真の名前を変更ください！", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                                if (result == MessageBoxResult.OK)
                                {
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
                            imageControl.MouseLeftButtonDown += popupSecond_read_click;

                            Button deleteButton = new Button();
                            deleteButton.Content = "X";
                            deleteButton.Name = "Delete";
                            deleteButton.Command = deleteAction;
                            deleteButton.Background = Brushes.Red;
                            deleteButton.Click += new RoutedEventHandler(photo2_home_read_click);

                            NameIMGSecond1.Add(imageControl);
                            NameIMGSecond1.Add(deleteButton);
                        }

                        ImageObject2 = openDialog.FileNames;
                        ImageNameObject2 = openDialog.SafeFileNames;
                        foreach (String saveImageName2 in ImageObject2)
                        {
                            NameIMGSecond2.Add(saveImageName2);
                        }

                        foreach (String saveImageName in ImageNameObject2)
                        {
                            ImageListPath2.Add(saveImageName);
                        }

                        ImagePath2 = "";
                        foreach (var saveImageName in ImageListPath2)
                        {
                            ImagePath2 += conbineCharatarBefore + saveImageName + conbineCharatarAfter;
                        }
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    MessageBox.Show("Fix!" + e, "ERROR!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            int nameduplicatePhoto3 = 0;
            CardRightCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {
                duplicateImage:
                    OpenFileDialog openDialog = new OpenFileDialog();
                    openDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
                    openDialog.Multiselect = false;

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

                            foreach (String nameDuplicate in ImageListPath3)
                            {
                                if (nameDuplicate == fileName)
                                {
                                    nameduplicatePhoto3++;
                                }
                            }

                            if (File.Exists(SavePath + "\\" + fileName) || nameduplicatePhoto3 > 0)
                            {
                                var result = MessageBox.Show("【" + fileName + "】 " + "がありました。\nもう一度写真を選択或いはアップデートしたい写真の名前を変更ください！", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                                if (result == MessageBoxResult.OK)
                                {
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
                            imageControl.MouseLeftButtonDown += popupCardRight_read_click;

                            Button deleteButton = new Button();
                            deleteButton.Content = "X";
                            deleteButton.Name = "Delete";
                            deleteButton.Command = deleteAction;
                            deleteButton.Background = Brushes.Red;
                            deleteButton.Click += new RoutedEventHandler(photo3_home_read_click);

                            NameIMGCardRight1.Add(imageControl);
                            NameIMGCardRight1.Add(deleteButton);
                        }

                        ImageObject3 = openDialog.FileNames;
                        ImageNameObject3 = openDialog.SafeFileNames;
                        foreach (String saveImageName3 in ImageObject3)
                        {
                            NameIMGCardRight2.Add(saveImageName3);
                        }

                        foreach (String saveImageName in ImageNameObject3)
                        {
                            ImageListPath3.Add(saveImageName);
                        }

                        ImagePath3 = "";
                        foreach (var saveImageName in ImageListPath3)
                        {
                            ImagePath3 += conbineCharatarBefore + saveImageName + conbineCharatarAfter;
                        }
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    MessageBox.Show("Fix!" + e, "ERROR!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            int nameduplicatePhoto4 = 0;
            CardLeftCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {
                duplicateImage:
                    OpenFileDialog openDialog = new OpenFileDialog();
                    openDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
                    openDialog.Multiselect = false;

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

                            foreach (String nameDuplicate in ImageListPath4)
                            {
                                if (nameDuplicate == fileName)
                                {
                                    nameduplicatePhoto4++;
                                }
                            }

                            if (File.Exists(SavePath + "\\" + fileName) || nameduplicatePhoto4 > 0)
                            {
                                var result = MessageBox.Show("【" + fileName + "】 " + "がありました。\nもう一度写真を選択或いはアップデートしたい写真の名前を変更ください！", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                                if (result == MessageBoxResult.OK)
                                {
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
                            imageControl.MouseLeftButtonDown += popupCardLeft_read_click;

                            Button deleteButton = new Button();
                            deleteButton.Content = "X";
                            deleteButton.Name = "Delete";
                            deleteButton.Command = deleteAction;
                            deleteButton.Background = Brushes.Red;
                            deleteButton.Click += new RoutedEventHandler(photo4_home_read_click);

                            NameIMGCardLeft1.Add(imageControl);
                            NameIMGCardLeft1.Add(deleteButton);
                        }

                        ImageObject4 = openDialog.FileNames;
                        ImageNameObject4 = openDialog.SafeFileNames;
                        foreach (String saveImageName4 in ImageObject4)
                        {
                            NameIMGCardLeft2.Add(saveImageName4);
                        }

                        foreach (String saveImageName in ImageNameObject4)
                        {
                            ImageListPath4.Add(saveImageName);
                        }

                        ImagePath4 = "";
                        foreach (var saveImageName in ImageListPath4)
                        {
                            ImagePath4 += conbineCharatarBefore + saveImageName + conbineCharatarAfter;
                        }
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    MessageBox.Show("Fix!" + e, "ERROR!!!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

        private void photo1_home_read_click(object sender, RoutedEventArgs e)
        {
            FrameworkElement parent = (FrameworkElement)((Button)sender);
            int comfirmDeleteImage = Comfirm;
            var button = sender as Button;
            var indexBtn = NameIMGFirst1.IndexOf(button);
            var indexImg = indexBtn - 1;
            if (indexImg == 0)
            {
                string nameImage = ImageListPath1.ElementAt(0).ToString();
                ImageListPath1.RemoveAt(0);
                NameIMGFirst2.RemoveAt(0);
                NameIMGFirst1.RemoveAt(index: indexBtn);
                NameIMGFirst1.RemoveAt(index: indexImg);
            }
            else
            {
                string nameImage = ImageListPath1.ElementAt(indexImg / 2).ToString();
                ImageListPath1.RemoveAt(indexImg / 2);
                NameIMGFirst2.RemoveAt(indexImg / 2);
                NameIMGFirst1.RemoveAt(index: indexBtn);
                NameIMGFirst1.RemoveAt(index: indexImg);
            }

            ImagePath1 = "";
            foreach (var saveImageName in ImageListPath1)
            {
                ImagePath1 += conbineCharatarBefore + saveImageName + conbineCharatarAfter;
            }
        }

        private void photo2_home_read_click(object sender, RoutedEventArgs e)
        {
            FrameworkElement parent = (FrameworkElement)((Button)sender);
            int comfirmDeleteImage = Comfirm;
            var button = sender as Button;
            var indexBtn = NameIMGSecond1.IndexOf(button);
            var indexImg = indexBtn - 1;
            if (indexImg == 0)
            {
                string nameImage = ImageListPath2.ElementAt(0).ToString();
                ImageListPath2.RemoveAt(0);
                NameIMGSecond2.RemoveAt(0);
                NameIMGSecond1.RemoveAt(index: indexBtn);
                NameIMGSecond1.RemoveAt(index: indexImg);
            }
            else
            {
                string nameImage = ImageListPath2.ElementAt(indexImg / 2).ToString();
                ImageListPath2.RemoveAt(indexImg / 2);
                NameIMGSecond2.RemoveAt(indexImg / 2);
                NameIMGSecond1.RemoveAt(index: indexBtn);
                NameIMGSecond1.RemoveAt(index: indexImg);
            }

            ImagePath2 = "";
            foreach (var saveImageName in ImageListPath2)
            {
                ImagePath2 += conbineCharatarBefore + saveImageName + conbineCharatarAfter;
            }
        }

        private void photo3_home_read_click(object sender, RoutedEventArgs e)
        {
            FrameworkElement parent = (FrameworkElement)((Button)sender);
            int comfirmDeleteImage = Comfirm;
            var button = sender as Button;
            var indexBtn = NameIMGCardRight1.IndexOf(button);
            var indexImg = indexBtn - 1;
            if (indexImg == 0)
            {
                string nameImage = ImageListPath3.ElementAt(0).ToString();
                ImageListPath3.RemoveAt(0);
                NameIMGCardRight2.RemoveAt(0);
                NameIMGCardRight1.RemoveAt(index: indexBtn);
                NameIMGCardRight1.RemoveAt(index: indexImg);
            }
            else
            {
                string nameImage = ImageListPath3.ElementAt(indexImg / 2).ToString();
                ImageListPath3.RemoveAt(indexImg / 2);
                NameIMGCardRight2.RemoveAt(indexImg / 2);
                NameIMGCardRight1.RemoveAt(index: indexBtn);
                NameIMGCardRight1.RemoveAt(index: indexImg);
            }

            ImagePath3 = "";
            foreach (var saveImageName in ImageListPath3)
            {
                ImagePath3 += conbineCharatarBefore + saveImageName + conbineCharatarAfter;
            }
        }

        private void photo4_home_read_click(object sender, RoutedEventArgs e)
        {
            FrameworkElement parent = (FrameworkElement)((Button)sender);
            int comfirmDeleteImage = Comfirm;
            var button = sender as Button;
            var indexBtn = NameIMGCardLeft1.IndexOf(button);
            var indexImg = indexBtn - 1;
            if (indexImg == 0)
            {
                string nameImage = ImageListPath4.ElementAt(0).ToString();
                ImageListPath4.RemoveAt(0);
                NameIMGCardLeft2.RemoveAt(0);
                NameIMGCardLeft1.RemoveAt(index: indexBtn);
                NameIMGCardLeft1.RemoveAt(index: indexImg);
            }
            else
            {
                string nameImage = ImageListPath4.ElementAt(indexImg / 2).ToString();
                ImageListPath4.RemoveAt(indexImg / 2);
                NameIMGCardLeft2.RemoveAt(indexImg / 2);
                NameIMGCardLeft1.RemoveAt(index: indexBtn);
                NameIMGCardLeft1.RemoveAt(index: indexImg);
            }

            ImagePath4 = "";
            foreach (var saveImageName in ImageListPath4)
            {
                ImagePath4 += conbineCharatarBefore + saveImageName + conbineCharatarAfter;
            }
        }

        private void popupFirst_read_click(object sender, EventArgs e)
        {
            string pathPP = "";
            //FrameworkElement parent = (FrameworkElement)((Button)sender);
            var btn = (Image)sender;
            int indexImage = NameIMGFirst1.IndexOf(btn);
            if (indexImage == 0)
            {
                pathPP = NameIMGFirst2[0].ToString();
            }
            else
            {
                pathPP = NameIMGFirst2[indexImage / 2].ToString();
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

        private void popupSecond_read_click(object sender, EventArgs e)
        {
            string pathPP = "";
            //FrameworkElement parent = (FrameworkElement)((Button)sender);
            var btn = (Image)sender;
            int indexImage = NameIMGSecond1.IndexOf(btn);
            if (indexImage == 0)
            {
                pathPP = NameIMGSecond2[0].ToString();
            }
            else
            {
                pathPP = NameIMGSecond2[indexImage / 2].ToString();
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

        private void popupCardRight_read_click(object sender, EventArgs e)
        {
            string pathPP = "";
            //FrameworkElement parent = (FrameworkElement)((Button)sender);
            var btn = (Image)sender;
            int indexImage = NameIMGCardRight1.IndexOf(btn);
            if (indexImage == 0)
            {
                pathPP = NameIMGCardRight2[0].ToString();
            }
            else
            {
                pathPP = NameIMGCardRight2[indexImage / 2].ToString();
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

        private void popupCardLeft_read_click(object sender, EventArgs e)
        {
            string pathPP = "";
            //FrameworkElement parent = (FrameworkElement)((Button)sender);
            var btn = (Image)sender;
            int indexImage = NameIMGCardLeft1.IndexOf(btn);
            if (indexImage == 0)
            {
                pathPP = NameIMGCardLeft2[0].ToString();
            }
            else
            {
                pathPP = NameIMGCardLeft2[indexImage / 2].ToString();
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
            string SavePath = string.Format(@"{0}\\matsuki\matsuki\images\Customer\", projectDirectory);
            File.Delete(SavePath + nameImage);
        }
    }
}
