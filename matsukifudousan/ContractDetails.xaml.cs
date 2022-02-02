using matsukifudousan.Model;
using matsukifudousan.ViewModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace matsukifudousan
{
    /// <summary>
    /// ContractDetails.xaml の相互作用ロジック
    /// </summary>
    public partial class ContractDetails : Window
    {
        public ContractDetails()
        {
            InitializeComponent();

            DataContext = new ContractDetailsViewModel();

            ParkingForm.IsEnabled = false;
            ElectronicChoose.IsEnabled = false;
            Gaschoose.IsEnabled = false;
            WaterCrewChoose.IsEnabled = false;
            WaterTankChoose.IsEnabled = false;
            ToiletChoose.IsEnabled = false;
            ProcessEquipmentChoose.IsEnabled = false;
            SinkChoose.IsEnabled = false;
            FaucetChoose.IsEnabled = false;
            KitchenChoose.IsEnabled = false;
            WaterHeaterChoose.IsEnabled = false;
            StoveChoose.IsEnabled = false;
            BathroomChoose.IsEnabled = false;
            ShowerChoose.IsEnabled = false;
            ReheatingChoose.IsEnabled = false;
            ShowerWithChoose.IsEnabled = false;
            BathtubChoose.IsEnabled = false;
            WashingMachineChoose.IsEnabled = false;
            ConnectionBracketChoose.IsEnabled = false;
            LightingEquipmentChoose.IsEnabled = false;
            LightBulbBallChoose.IsEnabled = false;
            TelevisionAntennaChoose.IsEnabled = false;
            FixedTelephoneChoose.IsEnabled = false;
            PhoneChoose.IsEnabled = false;
            InternetEquipmentChoose.IsEnabled = false;
            ProviderChoose.IsEnabled = false;
            AirConditioningChoose.IsEnabled = false;
            GarbageStorageChoose.IsEnabled = false;
            PetChoose.IsEnabled = false;
            StorageChoose.IsEnabled = false;
            UseNoYesChoose.IsEnabled = false;
            HotSpringChoose.IsEnabled = false;
            OtherHouseChoose.IsEnabled = false;
            OtherConditionsChoose.IsEnabled = false;
        }
        private void ContractVM_Loaded(object sender, RoutedEventArgs e)
        {
            PakingYesNo.SelectionChanged += Parking_SelectionChanged;
            Electronic.SelectionChanged += Electronic_SelectionChanged;
            Gas.SelectionChanged += Gas_SelectionChanged;
            WaterCrew.SelectionChanged += WaterCrew_SelectionChanged;
            WaterTank.SelectionChanged += WaterTank_SelectionChanged;
            Toilet.SelectionChanged += Toilet_SelectionChanged;
            ProcessEquipment.SelectionChanged += ProcessEquipment_SelectionChanged;
            Sink.SelectionChanged += Sink_SelectionChanged;
            Faucet.SelectionChanged += Faucet_SelectionChanged;
            Kitchen.SelectionChanged += Kitchen_SelectionChanged;
            WaterHeater.SelectionChanged += WaterHeater_SelectionChanged;
            Stove.SelectionChanged += Stove_SelectionChanged;
            Bathroom.SelectionChanged += Bathroom_SelectionChanged;
            Shower.SelectionChanged += Shower_SelectionChanged;
            Reheating.SelectionChanged += Reheating_SelectionChanged;
            ShowerWith.SelectionChanged += ShowerWith_SelectionChanged;
            Bathtub.SelectionChanged += Bathtub_SelectionChanged;
            WashingMachine.SelectionChanged += WashingMachine_SelectionChanged;
            ConnectionBracket.SelectionChanged += ConnectionBracket_SelectionChanged;
            LightingEquipment.SelectionChanged += LightingEquipment_SelectionChanged;
            LightBulbBall.SelectionChanged += LightBulbBall_SelectionChanged;
            TelevisionAntenna.SelectionChanged += TelevisionAntenna_SelectionChanged;
            FixedTelephone.SelectionChanged += FixedTelephone_SelectionChanged;
            Phone.SelectionChanged += Phone_SelectionChanged;
            InternetEquipment.SelectionChanged += InternetEquipment_SelectionChanged;
            Provider.SelectionChanged += Provider_SelectionChanged;
            AirConditioning.SelectionChanged += AirConditioning_SelectionChanged;
            GarbageStorage.SelectionChanged += GarbageStorage_SelectionChanged;
            Pet.SelectionChanged += Pet_SelectionChanged;
            Storage.SelectionChanged += Storage_SelectionChanged;
            UseNoYes.SelectionChanged += UseNoYes_SelectionChanged;
            HotSpring.SelectionChanged += HotSpring_SelectionChanged;
            OtherHouse.SelectionChanged += OtherHouse_SelectionChanged;
            OtherConditions.SelectionChanged += OtherConditions_SelectionChanged;
        }
        private void Parking_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (PakingYesNo.SelectedValue == "有")
            {
                ParkingForm.IsEnabled = true;
            }
            else
            {
                ParkingForm.IsEnabled = false;
                ParkingForm.SelectedValue = null;
            }
        }
        private void Electronic_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (Electronic.SelectedValue == "有")
            {
                ElectronicChoose.IsEnabled = true;
                ElectronicChoose.Text = "東京電力エナジーパトナー㈱";
            }
            else
            {
                ElectronicChoose.IsEnabled = false;
                ElectronicChoose.Text = null;
            }
        }
        private void Gas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Gas.SelectedValue == "有")
            {
                Gaschoose.IsEnabled = true;
            }
            else
            {
                Gaschoose.IsEnabled = false;
                Gaschoose.SelectedValue = null;
            }
        }
        private void WaterCrew_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WaterCrew.SelectedValue == "有")
            {
                WaterCrewChoose.IsEnabled = true;
            }
            else
            {
                WaterCrewChoose.IsEnabled = false;
                WaterCrewChoose.SelectedValue = null;
            }
        }
        private void WaterTank_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WaterTank.SelectedValue == "有")
            {
                WaterTankChoose.IsEnabled = true;
            }
            else
            {
                WaterTankChoose.IsEnabled = false;
                WaterTankChoose.SelectedValue = null;
            }
        }
        private void Toilet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Toilet.SelectedValue == "有")
            {
                ToiletChoose.IsEnabled = true;
            }
            else
            {
                ToiletChoose.IsEnabled = false;
                ToiletChoose.SelectedValue = null;
            }
        }
        private void ProcessEquipment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProcessEquipment.SelectedValue == "有")
            {
                ProcessEquipmentChoose.IsEnabled = true;
            }
            else
            {
                ProcessEquipmentChoose.IsEnabled = false;
                ProcessEquipmentChoose.SelectedValue = null;
            }
        }
        private void Sink_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Sink.SelectedValue == "有")
            {
                SinkChoose.IsEnabled = true;
            }
            else
            {
                SinkChoose.IsEnabled = false;
                SinkChoose.SelectedValue = null;
            }
        }
        private void Faucet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Faucet.SelectedValue == "有")
            {
                FaucetChoose.IsEnabled = true;
            }
            else
            {
                FaucetChoose.IsEnabled = false;
                FaucetChoose.SelectedValue = null;
            }
        }
        private void Kitchen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Kitchen.SelectedValue == "有")
            {
                KitchenChoose.IsEnabled = true;
            }
            else
            {
                KitchenChoose.IsEnabled = false;
                KitchenChoose.SelectedValue = null;
            }
        }
        private void WaterHeater_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WaterHeater.SelectedValue == "有")
            {
                WaterHeaterChoose.IsEnabled = true;
            }
            else
            {
                WaterHeaterChoose.IsEnabled = false;
                WaterHeaterChoose.SelectedValue = null;
            }
        }
        private void Stove_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Stove.SelectedValue == "有")
            {
                StoveChoose.IsEnabled = true;
            }
            else
            {
                StoveChoose.IsEnabled = false;
                StoveChoose.SelectedValue = null;
            }
        }
        private void Bathroom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Bathroom.SelectedValue == "有")
            {
                BathroomChoose.IsEnabled = true;
            }
            else
            {
                BathroomChoose.IsEnabled = false;
                BathroomChoose.SelectedValue = null;
            }
        }
        private void Shower_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Shower.SelectedValue == "有")
            {
                ShowerChoose.IsEnabled = true;
            }
            else
            {
                ShowerChoose.IsEnabled = false;
                ShowerChoose.SelectedValue = null;
            }
        }
        private void Reheating_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Reheating.SelectedValue == "有")
            {
                ReheatingChoose.IsEnabled = true;
            }
            else
            {
                ReheatingChoose.IsEnabled = false;
                ReheatingChoose.SelectedValue = null;
            }
        }
        private void ShowerWith_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ShowerWith.SelectedValue == "有")
            {
                ShowerWithChoose.IsEnabled = true;
            }
            else
            {
                ShowerWithChoose.IsEnabled = false;
                ShowerWithChoose.SelectedValue = null;
            }
        }
        private void Bathtub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Bathtub.SelectedValue == "有")
            {
                BathtubChoose.IsEnabled = true;
            }
            else
            {
                BathtubChoose.IsEnabled = false;
                BathtubChoose.SelectedValue = null;
            }
        }
        private void WashingMachine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WashingMachine.SelectedValue == "有")
            {
                WashingMachineChoose.IsEnabled = true;
            }
            else
            {
                WashingMachineChoose.IsEnabled = false;
                WashingMachineChoose.SelectedValue = null;
            }
        }
        private void ConnectionBracket_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ConnectionBracket.SelectedValue == "有")
            {
                ConnectionBracketChoose.IsEnabled = true;
            }
            else
            {
                ConnectionBracketChoose.IsEnabled = false;
                ConnectionBracketChoose.Text = null;
            }
        }
        private void LightingEquipment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LightingEquipment.SelectedValue == "有")
            {
                LightingEquipmentChoose.IsEnabled = true;
            }
            else
            {
                LightingEquipmentChoose.IsEnabled = false;
            }
        }
        private void LightBulbBall_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LightBulbBall.SelectedValue == "有")
            {
                LightBulbBallChoose.IsEnabled = true;
            }
            else
            {
                LightBulbBallChoose.IsEnabled = false;
                LightBulbBallChoose.SelectedValue = null;
            }
        }
        private void TelevisionAntenna_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (TelevisionAntenna.SelectedValue == "有")
            {
                TelevisionAntennaChoose.IsEnabled = true;
            }
            else
            {
                TelevisionAntennaChoose.IsEnabled = false;
                TelevisionAntennaChoose.Text = null;
            }
        }
        private void FixedTelephone_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (FixedTelephone.SelectedValue == "有")
            {
                FixedTelephoneChoose.IsEnabled = true;
            }
            else
            {
                FixedTelephoneChoose.IsEnabled = false;
                FixedTelephoneChoose.Text = null;
            }
        }
        private void Phone_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (Phone.SelectedValue == "有")
            {
                PhoneChoose.IsEnabled = true;
            }
            else
            {
                PhoneChoose.IsEnabled = false;
                PhoneChoose.Text = null;
            }
        }
        private void InternetEquipment_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (InternetEquipment.SelectedValue == "有")
            {
                InternetEquipmentChoose.IsEnabled = true;
            }
            else
            {
                InternetEquipmentChoose.IsEnabled = false;
            }
        }
        private void Provider_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (Provider.SelectedValue == "有")
            {
                ProviderChoose.IsEnabled = true;
            }
            else
            {
                ProviderChoose.IsEnabled = false;
                ProviderChoose.Text = null;
            }
        }
        private void AirConditioning_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (AirConditioning.SelectedValue == "有")
            {
                AirConditioningChoose.IsEnabled = true;
            }
            else
            {
                AirConditioningChoose.IsEnabled = false;
                AirConditioningChoose.Text = null;
            }
        }
        private void GarbageStorage_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (GarbageStorage.SelectedValue == "有")
            {
                GarbageStorageChoose.IsEnabled = true;
            }
            else
            {
                GarbageStorageChoose.IsEnabled = false;
                GarbageStorageChoose.Text = null;
            }
        }
        private void Pet_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (Pet.SelectedValue == "可")
            {
                PetChoose.IsEnabled = true;
            }
            else
            {
                PetChoose.IsEnabled = false;
                PetChoose.Text = null;
            }
        }
        private void Storage_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (Storage.SelectedValue == "有")
            {
                StorageChoose.IsEnabled = true;
            }
            else
            {
                StorageChoose.IsEnabled = false;
                StorageChoose.Text = null;
            }
        }
        private void UseNoYes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (UseNoYes.SelectedValue == "有")
            {
                UseNoYesChoose.IsEnabled = true;
            }
            else
            {
                UseNoYesChoose.IsEnabled = false;
                UseNoYesChoose.SelectedValue = null;
            }
        }
        private void HotSpring_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (HotSpring.SelectedValue == "有")
            {
                HotSpringChoose.IsEnabled = true;
            }
            else
            {
                HotSpringChoose.IsEnabled = false;
            }
        }
        private void OtherHouse_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (OtherHouse.SelectedValue == "有")
            {
                OtherHouseChoose.IsEnabled = true;
            }
            else
            {
                OtherHouseChoose.IsEnabled = false;
                OtherHouseChoose.Text = null;
            }
        }
        private void OtherConditions_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (OtherConditions.SelectedValue == "有")
            {
                OtherConditionsChoose.IsEnabled = true;
            }
            else
            {
                OtherConditionsChoose.IsEnabled = false;
                OtherConditionsChoose.Text = null;
            }
        }

        private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var uie = e.OriginalSource as UIElement;

            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                uie.MoveFocus(
                new TraversalRequest(
                FocusNavigationDirection.Next));
            }
        }

        private void txbOwnerAddressNo_LostFocus(object sender, RoutedEventArgs e)
        {
            string zipcode = txbOwnerAddressNo.Text;
            //URL
            string url = "https://zipcloud.ibsnet.co.jp/api/search?zipcode=" + zipcode;
            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    // エンコーディングをUTF-8にしておく（取得してからEncoding変えてもパースできなかった）
                    webClient.Encoding = System.Text.Encoding.UTF8;

                    // JSONのテキストを取得
                    string jsonStr = webClient.DownloadString(url);

                    JObject jsonObj = JObject.Parse(jsonStr);

                    var jsonData = jsonObj["results"].First;
                    //var jsonData1 = jsonObj["results"];
                    //var jsonData2 = jsonObj["results"].FirstOrDefault();

                    var address1 = jsonData["address1"];
                    var address2 = jsonData["address2"];
                    var address3 = jsonData["address3"];

                    //var jsonPollution = jsonCurrent["pollution"];
                    //var json_aqius = jsonPollution["aqius"];
                    //var json_aqicn = jsonPollution["aqicn"];
                    // Dictionaryをシリアライズします。
                    //var jsonstr = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                    //MessageBox.Show(address1.ToString() + address2.ToString() + address3.ToString());

                    txbOwnerAddress.Text = address1.ToString() + address2.ToString() + address3.ToString();
                    txbOwnerAddress.SelectionStart = txbOwnerAddress.Text.Length;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("郵便局番号は恐らく間違っています。もう一度ご確認お願い致します。", "確認", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }

        private void txbRenterAddressNo_LostFocus(object sender, RoutedEventArgs e)
        {
            string zipcode = txbRenterAddressNo.Text;
            //URL
            string url = "https://zipcloud.ibsnet.co.jp/api/search?zipcode=" + zipcode;
            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    // エンコーディングをUTF-8にしておく（取得してからEncoding変えてもパースできなかった）
                    webClient.Encoding = System.Text.Encoding.UTF8;

                    // JSONのテキストを取得
                    string jsonStr = webClient.DownloadString(url);

                    JObject jsonObj = JObject.Parse(jsonStr);

                    var jsonData = jsonObj["results"].First;
                    //var jsonData1 = jsonObj["results"];
                    //var jsonData2 = jsonObj["results"].FirstOrDefault();

                    var address1 = jsonData["address1"];
                    var address2 = jsonData["address2"];
                    var address3 = jsonData["address3"];

                    //var jsonPollution = jsonCurrent["pollution"];
                    //var json_aqius = jsonPollution["aqius"];
                    //var json_aqicn = jsonPollution["aqicn"];
                    // Dictionaryをシリアライズします。
                    //var jsonstr = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                    //MessageBox.Show(address1.ToString() + address2.ToString() + address3.ToString());

                    txbRenterAddress.Text = address1.ToString() + address2.ToString() + address3.ToString();
                    txbRenterAddress.SelectionStart = txbRenterAddress.Text.Length;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("郵便局番号は恐らく間違っています。もう一度ご確認お願い致します。", "確認", MessageBoxButton.OK, MessageBoxImage.Question);
            }
        }
    }
}