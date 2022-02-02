using matsukifudousan.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace matsukifudousan.ViewModel
{

    public class ContractDetailsFixViewModel : BaseViewModel

    {
        #region initi
        private int _HouseNo;
        public int HouseNo { get => _HouseNo; set { _HouseNo = value; OnPropertyChanged(); } }

        private string _ContractType;
        public string ContractType { get => _ContractType; set { _ContractType = value; OnPropertyChanged(); } }

        private string _PickupMode;
        public string PickupMode { get => _PickupMode; set { _PickupMode = value; OnPropertyChanged(); } }

        private string _DateCurrent;
        public string DateCurrent { get => _DateCurrent; set { _DateCurrent = value; OnPropertyChanged(); } }

        private string _ContractDate;
        public string ContractDate { get => _ContractDate; set { _ContractDate = value; OnPropertyChanged(); } }

        private string _ContractBegin;
        public string ContractBegin { get => _ContractBegin; set { _ContractBegin = value; OnPropertyChanged(); } }

        private string _ContractEnd;
        public string ContractEnd { get => _ContractEnd; set { _ContractEnd = value; OnPropertyChanged(); } }

        private string _ContractOpenDays;
        public string ContractOpenDays { get => _ContractOpenDays; set { _ContractOpenDays = value; OnPropertyChanged(); } }

        private string _OwnerName;
        public string OwnerName { get => _OwnerName; set { _OwnerName = value; OnPropertyChanged(); } }

        private string _OwnerBirthday;
        public string OwnerBirthday { get => _OwnerBirthday; set { _OwnerBirthday = value; OnPropertyChanged(); } }

        private string _OwnerAddress;
        public string OwnerAddress { get => _OwnerAddress; set { _OwnerAddress = value; OnPropertyChanged(); } }

        private string _OwnerAddressNo;
        public string OwnerAddressNo { get => _OwnerAddressNo; set { _OwnerAddressNo = value; OnPropertyChanged(); } }

        private string _OwnerTel;
        public string OwnerTel { get => _OwnerTel; set { _OwnerTel = value; OnPropertyChanged(); } }

        private string _RenterName;
        public string RenterName { get => _RenterName; set { _RenterName = value; OnPropertyChanged(); } }

        private string _RenterBirthday;
        public string RenterBirthday { get => _RenterBirthday; set { _RenterBirthday = value; OnPropertyChanged(); } }

        private string _RenterAddress;
        public string RenterAddress { get => _RenterAddress; set { _RenterAddress = value; OnPropertyChanged(); } }

        private string _RenterAddressNo;
        public string RenterAddressNo { get => _RenterAddressNo; set { _RenterAddressNo = value; OnPropertyChanged(); } }

        private string _RenterTel;
        public string RenterTel { get => _RenterTel; set { _RenterTel = value; OnPropertyChanged(); } }

        private string _RentName;
        public string RentName { get => _RentName; set { _RentName = value; OnPropertyChanged(); } }

        private string _RentBirthday;
        public string RentBirthday { get => _RentBirthday; set { _RentBirthday = value; OnPropertyChanged(); } }

        private string _RentAddress;
        public string RentAddress { get => _RentAddress; set { _RentAddress = value; OnPropertyChanged(); } }

        private string _RentTel;
        public string RentTel { get => _RentTel; set { _RentTel = value; OnPropertyChanged(); } }

        private string _ResidentName1;
        public string ResidentName1 { get => _ResidentName1; set { _ResidentName1 = value; OnPropertyChanged(); } }

        private string _ResidentBirthday1;
        public string ResidentBirthday1 { get => _ResidentBirthday1; set { _ResidentBirthday1 = value; OnPropertyChanged(); } }

        private string _ResidentName2;
        public string ResidentName2 { get => _ResidentName2; set { _ResidentName2 = value; OnPropertyChanged(); } }

        private string _ResidentBirthday2;
        public string ResidentBirthday2 { get => _ResidentBirthday2; set { _ResidentBirthday2 = value; OnPropertyChanged(); } }

        private string _ResidentName3;
        public string ResidentName3 { get => _ResidentName3; set { _ResidentName3 = value; OnPropertyChanged(); } }

        private string _ResidentBirthday3;
        public string ResidentBirthday3 { get => _ResidentBirthday3; set { _ResidentBirthday3 = value; OnPropertyChanged(); } }

        private string _Location;
        public string Location { get => _Location; set { _Location = value; OnPropertyChanged(); } }

        private string _LocationName;
        public string LocationName { get => _LocationName; set { _LocationName = value; OnPropertyChanged(); } }

        private string _IssueRoom;
        public string IssueRoom { get => _IssueRoom; set { _IssueRoom = value; OnPropertyChanged(); } }

        private string _HouseNumber;
        public string HouseNumber { get => _HouseNumber; set { _HouseNumber = value; OnPropertyChanged(); } }

        private string _Type;
        public string Type { get => _Type; set { _Type = value; OnPropertyChanged(); } }

        private string _Structure;
        public string Structure { get => _Structure; set { _Structure = value; OnPropertyChanged(); } }

        private string _OuterWall;
        public string OuterWall { get => _OuterWall; set { _OuterWall = value; OnPropertyChanged(); } }

        private string _FloorPlan1;
        public string FloorPlan1 { get => _FloorPlan1; set { _FloorPlan1 = value; OnPropertyChanged(); } }

        private string _FloorPlan2;
        public string FloorPlan2 { get => _FloorPlan2; set { _FloorPlan2 = value; OnPropertyChanged(); } }

        private string _PakingYesNo;
        public string PakingYesNo { get => _PakingYesNo; set { _PakingYesNo = value; OnPropertyChanged(); } }

        private string _ParkingForm;
        public string ParkingForm { get => _ParkingForm; set { _ParkingForm = value; OnPropertyChanged(); } }

        private string _UsedNumber1;
        public string UsedNumber1 { get => _UsedNumber1; set { _UsedNumber1 = value; OnPropertyChanged(); } }

        private string _UsedNumber2;
        public string UsedNumber2 { get => _UsedNumber2; set { _UsedNumber2 = value; OnPropertyChanged(); } }

        private string _UsedNumber3;
        public string UsedNumber3 { get => _UsedNumber3; set { _UsedNumber3 = value; OnPropertyChanged(); } }

        private string _ParkingLocation;
        public string ParkingLocation { get => _ParkingLocation; set { _ParkingLocation = value; OnPropertyChanged(); } }

        private string _Electricity;
        public string Electricity { get => _Electricity; set { _Electricity = value; OnPropertyChanged(); } }

        private string _CurrentSupplier;
        public string CurrentSupplier { get => _CurrentSupplier; set { _CurrentSupplier = value; OnPropertyChanged(); } }

        private string _Gas;
        public string Gas { get => _Gas; set { _Gas = value; OnPropertyChanged(); } }

        private string _GasType;
        public string GasType { get => _GasType; set { _GasType = value; OnPropertyChanged(); } }

        private string _Supplier;
        public string Supplier { get => _Supplier; set { _Supplier = value; OnPropertyChanged(); } }

        private string _WaterCrew;
        public string WaterCrew { get => _WaterCrew; set { _WaterCrew = value; OnPropertyChanged(); } }

        private string _WaterCrewChoose;
        public string WaterCrewChoose { get => _WaterCrewChoose; set { _WaterCrewChoose = value; OnPropertyChanged(); } }

        private string _WaterTank;
        public string WaterTank { get => _WaterTank; set { _WaterTank = value; OnPropertyChanged(); } }

        private string _WaterTankChoose;
        public string WaterTankChoose { get => _WaterTankChoose; set { _WaterTankChoose = value; OnPropertyChanged(); } }

        private string _Toilet;
        public string Toilet { get => _Toilet; set { _Toilet = value; OnPropertyChanged(); } }

        private string _ToiletChoose;
        public string ToiletChoose { get => _ToiletChoose; set { _ToiletChoose = value; OnPropertyChanged(); } }

        private string _ProcessEquipment;
        public string ProcessEquipment { get => _ProcessEquipment; set { _ProcessEquipment = value; OnPropertyChanged(); } }

        private string _ProcessEquipmentChoose;
        public string ProcessEquipmentChoose { get => _ProcessEquipmentChoose; set { _ProcessEquipmentChoose = value; OnPropertyChanged(); } }

        private string _Sink;
        public string Sink { get => _Sink; set { _Sink = value; OnPropertyChanged(); } }

        private string _SinkChoose;
        public string SinkChoose { get => _SinkChoose; set { _SinkChoose = value; OnPropertyChanged(); } }

        private string _Faucet;
        public string Faucet { get => _Faucet; set { _Faucet = value; OnPropertyChanged(); } }

        private string _FaucetChoose;
        public string FaucetChoose { get => _FaucetChoose; set { _FaucetChoose = value; OnPropertyChanged(); } }

        private string _Kitchen;
        public string Kitchen { get => _Kitchen; set { _Kitchen = value; OnPropertyChanged(); } }

        private string _KitchenChoose;
        public string KitchenChoose { get => _KitchenChoose; set { _KitchenChoose = value; OnPropertyChanged(); } }

        private string _WaterHeater;
        public string WaterHeater { get => _WaterHeater; set { _WaterHeater = value; OnPropertyChanged(); } }

        private string _WaterHeaterChoose;
        public string WaterHeaterChoose { get => _WaterHeaterChoose; set { _WaterHeaterChoose = value; OnPropertyChanged(); } }

        private string _Stove;
        public string Stove { get => _Stove; set { _Stove = value; OnPropertyChanged(); } }

        private string _StoveChoose;
        public string StoveChoose { get => _StoveChoose; set { _StoveChoose = value; OnPropertyChanged(); } }

        private string _Bathroom;
        public string Bathroom { get => _Bathroom; set { _Bathroom = value; OnPropertyChanged(); } }

        private string _BathroomChoose;
        public string BathroomChoose { get => _BathroomChoose; set { _BathroomChoose = value; OnPropertyChanged(); } }

        private string _Shower;
        public string Shower { get => _Shower; set { _Shower = value; OnPropertyChanged(); } }

        private string _ShowerChoose;
        public string ShowerChoose { get => _ShowerChoose; set { _ShowerChoose = value; OnPropertyChanged(); } }

        private string _Reheating;
        public string Reheating { get => _Reheating; set { _Reheating = value; OnPropertyChanged(); } }

        private string _ReheatingChoose;
        public string ReheatingChoose { get => _ReheatingChoose; set { _ReheatingChoose = value; OnPropertyChanged(); } }

        private string _ShowerWith;
        public string ShowerWith { get => _ShowerWith; set { _ShowerWith = value; OnPropertyChanged(); } }

        private string _ShowerWithChoose;
        public string ShowerWithChoose { get => _ShowerWithChoose; set { _ShowerWithChoose = value; OnPropertyChanged(); } }

        private string _Bathtub;
        public string Bathtub { get => _Bathtub; set { _Bathtub = value; OnPropertyChanged(); } }

        private string _BathtubChoose;
        public string BathtubChoose { get => _BathtubChoose; set { _BathtubChoose = value; OnPropertyChanged(); } }

        private string _WashingMachine;
        public string WashingMachine { get => _WashingMachine; set { _WashingMachine = value; OnPropertyChanged(); } }

        private string _WashingMachineChoose;
        public string WashingMachineChoose { get => _WashingMachineChoose; set { _WashingMachineChoose = value; OnPropertyChanged(); } }

        private string _ConnectionBracket;
        public string ConnectionBracket { get => _ConnectionBracket; set { _ConnectionBracket = value; OnPropertyChanged(); } }

        private string _ConnectionBracketChoose;
        public string ConnectionBracketChoose { get => _ConnectionBracketChoose; set { _ConnectionBracketChoose = value; OnPropertyChanged(); } }

        private string _LightingEquipment;
        public string LightingEquipment { get => _LightingEquipment; set { _LightingEquipment = value; OnPropertyChanged(); } }

        private string _LightingEquipmentChoose;
        public string LightingEquipmentChoose { get => _LightingEquipmentChoose; set { _LightingEquipmentChoose = value; OnPropertyChanged(); } }

        private string _LightBulbBall;
        public string LightBulbBall { get => _LightBulbBall; set { _LightBulbBall = value; OnPropertyChanged(); } }

        private string _LightBulbBallChoose;
        public string LightBulbBallChoose { get => _LightBulbBallChoose; set { _LightBulbBallChoose = value; OnPropertyChanged(); } }

        private string _TelevisionAntenna;
        public string TelevisionAntenna { get => _TelevisionAntenna; set { _TelevisionAntenna = value; OnPropertyChanged(); } }

        private string _TelevisionAntennaChoose;
        public string TelevisionAntennaChoose { get => _TelevisionAntennaChoose; set { _TelevisionAntennaChoose = value; OnPropertyChanged(); } }

        private string _FixedTelephone;
        public string FixedTelephone { get => _FixedTelephone; set { _FixedTelephone = value; OnPropertyChanged(); } }

        private string _FixedTelephoneChoose;
        public string FixedTelephoneChoose { get => _FixedTelephoneChoose; set { _FixedTelephoneChoose = value; OnPropertyChanged(); } }

        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }

        private string _PhoneChoose;
        public string PhoneChoose { get => _PhoneChoose; set { _PhoneChoose = value; OnPropertyChanged(); } }

        private string _InternetEquipment;
        public string InternetEquipment { get => _InternetEquipment; set { _InternetEquipment = value; OnPropertyChanged(); } }

        private string _InternetEquipmentChoose;
        public string InternetEquipmentChoose { get => _InternetEquipmentChoose; set { _InternetEquipmentChoose = value; OnPropertyChanged(); } }

        private string _Provider;
        public string Provider { get => _Provider; set { _Provider = value; OnPropertyChanged(); } }

        private string _ProviderChoose;
        public string ProviderChoose { get => _ProviderChoose; set { _ProviderChoose = value; OnPropertyChanged(); } }

        private string _Router;
        public string Router { get => _Router; set { _Router = value; OnPropertyChanged(); } }

        private string _AirConditioning;
        public string AirConditioning { get => _AirConditioning; set { _AirConditioning = value; OnPropertyChanged(); } }

        private string _AirConditioningChoose;
        public string AirConditioningChoose { get => _AirConditioningChoose; set { _AirConditioningChoose = value; OnPropertyChanged(); } }

        private string _Elevator;
        public string Elevator { get => _Elevator; set { _Elevator = value; OnPropertyChanged(); } }

        private string _GarbageStorage;
        public string GarbageStorage { get => _GarbageStorage; set { _GarbageStorage = value; OnPropertyChanged(); } }

        private string _GarbageStorageChoose;
        public string GarbageStorageChoose { get => _GarbageStorageChoose; set { _GarbageStorageChoose = value; OnPropertyChanged(); } }

        private string _Pet;
        public string Pet { get => _Pet; set { _Pet = value; OnPropertyChanged(); } }

        private string _PetChoose;
        public string PetChoose { get => _PetChoose; set { _PetChoose = value; OnPropertyChanged(); } }

        private string _EvacutionLadder;
        public string EvacutionLadder { get => _EvacutionLadder; set { _EvacutionLadder = value; OnPropertyChanged(); } }

        private string _BicycleParkingSpace;
        public string BicycleParkingSpace { get => _BicycleParkingSpace; set { _BicycleParkingSpace = value; OnPropertyChanged(); } }

        private string _DoorPocket;
        public string DoorPocket { get => _DoorPocket; set { _DoorPocket = value; OnPropertyChanged(); } }

        private string _ScreenDoor;
        public string ScreenDoor { get => _ScreenDoor; set { _ScreenDoor = value; OnPropertyChanged(); } }

        private string _FireAlarm;
        public string FireAlarm { get => _FireAlarm; set { _FireAlarm = value; OnPropertyChanged(); } }

        private string _FireExtinguisher;
        public string FireExtinguisher { get => _FireExtinguisher; set { _FireExtinguisher = value; OnPropertyChanged(); } }

        private string _FireHydrant;
        public string FireHydrant { get => _FireHydrant; set { _FireHydrant = value; OnPropertyChanged(); } }

        private string _Storage;
        public string Storage { get => _Storage; set { _Storage = value; OnPropertyChanged(); } }

        private string _StorageChoose;
        public string StorageChoose { get => _StorageChoose; set { _StorageChoose = value; OnPropertyChanged(); } }

        private string _InstallationSunlight;
        public string InstallationSunlight { get => _InstallationSunlight; set { _InstallationSunlight = value; OnPropertyChanged(); } }

        private string _UseNoYes;
        public string UseNoYes { get => _UseNoYes; set { _UseNoYes = value; OnPropertyChanged(); } }

        private string _UseNoYesChoose;
        public string UseNoYesChoose { get => _UseNoYesChoose; set { _UseNoYesChoose = value; OnPropertyChanged(); } }

        private string _HotSpring;
        public string HotSpring { get => _HotSpring; set { _HotSpring = value; OnPropertyChanged(); } }

        private string _HotSpringChoose;
        public string HotSpringChoose { get => _HotSpringChoose; set { _HotSpringChoose = value; OnPropertyChanged(); } }

        private string _OtherBuildings;
        public string OtherBuildings { get => _OtherBuildings; set { _OtherBuildings = value; OnPropertyChanged(); } }

        private string _OtherBuildingsChoose;
        public string OtherBuildingsChoose { get => _OtherBuildingsChoose; set { _OtherBuildingsChoose = value; OnPropertyChanged(); } }

        private string _OtherConditions;
        public string OtherConditions { get => _OtherConditions; set { _OtherConditions = value; OnPropertyChanged(); } }

        private string _OtherConditionsChoose;
        public string OtherConditionsChoose { get => _OtherConditionsChoose; set { _OtherConditionsChoose = value; OnPropertyChanged(); } }

        private string _TransportationFacilities;
        public string TransportationFacilities { get => _TransportationFacilities; set { _TransportationFacilities = value; OnPropertyChanged(); } }

        private string _Rent;
        public string Rent { get => _Rent; set { _Rent = value; OnPropertyChanged(); } }

        private string _CommonServiceFee;
        public string CommonServiceFee { get => _CommonServiceFee; set { _CommonServiceFee = value; OnPropertyChanged(); } }

        private string _CATVFee;
        public string CATVFee { get => _CATVFee; set { _CATVFee = value; OnPropertyChanged(); } }

        private string _ParkingFee;
        public string ParkingFee { get => _ParkingFee; set { _ParkingFee = value; OnPropertyChanged(); } }

        private string _SecurityDeposit;
        public string SecurityDeposit { get => _SecurityDeposit; set { _SecurityDeposit = value; OnPropertyChanged(); } }

        private string _KeyMoney;
        public string KeyMoney { get => _KeyMoney; set { _KeyMoney = value; OnPropertyChanged(); } }

        //private string _RentForMonth;
        //public string RentForMonth { get => RentForMonth; set { RentForMonth = value; OnPropertyChanged(); } }

        //private string _CommonServiceFeeMonth;
        //public string CommonServiceFeeMonth { get => _CommonServiceFeeMonth; set { _CommonServiceFeeMonth = value; OnPropertyChanged(); } }

        //private string _CATVFeeMonth;
        //public string CATVFeeMonth { get => _CATVFeeMonth; set { _CATVFeeMonth = value; OnPropertyChanged(); } }

        //private string _ParkingFeeMonth;
        //public string ParkingFeeMonth { get => _ParkingFeeMonth; set { _ParkingFeeMonth = value; OnPropertyChanged(); } }

        //private string _NextMonthFee;
        //public string NextMonthFee { get => _NextMonthFee; set { _NextMonthFee = value; OnPropertyChanged(); } }

        //private string _RentalInsurancePremium;
        //public string RentalInsurancePremium { get => _RentalInsurancePremium; set { _RentalInsurancePremium = value; OnPropertyChanged(); } }

        //private string _RentalGuaranteeFee;
        //public string RentalGuaranteeFee { get => _RentalGuaranteeFee; set { _RentalGuaranteeFee = value; OnPropertyChanged(); } }

        //private string _FeeTaxIncluded;
        //public string FeeTaxIncluded { get => _FeeTaxIncluded; set { _FeeTaxIncluded = value; OnPropertyChanged(); } }

        private string _Total;
        public string Total { get => _Total; set { _Total = value; OnPropertyChanged(); } }

        private object _Choose1;
        public object Choose1 { get => _Choose1; set { _Choose1 = value; OnPropertyChanged(); } }

        private object _Choose2;
        public object Choose2 { get => _Choose2; set { _Choose2 = value; OnPropertyChanged(); } }

        private object _ParkingFormSelect;
        public object ParkingFormSelect { get => _ParkingFormSelect; set { _ParkingFormSelect = value; OnPropertyChanged(); } }

        private object _WaterCrewChooseSelect;
        public object WaterCrewChooseSelect { get => _WaterCrewChooseSelect; set { _WaterCrewChooseSelect = value; OnPropertyChanged(); } }

        private object _WaterTankChooseSelect;
        public object WaterTankChooseSelect { get => _WaterTankChooseSelect; set { _WaterTankChooseSelect = value; OnPropertyChanged(); } }

        private object _ToiletChooseSelect;
        public object ToiletChooseSelect { get => _ToiletChooseSelect; set { _ToiletChooseSelect = value; OnPropertyChanged(); } }

        private object _ProcessEquipmentChooseSelect;
        public object ProcessEquipmentChooseSelect { get => _ProcessEquipmentChooseSelect; set { _ProcessEquipmentChooseSelect = value; OnPropertyChanged(); } }

        private object _SinkChooseSelect;
        public object SinkChooseSelect { get => _SinkChooseSelect; set { _SinkChooseSelect = value; OnPropertyChanged(); } }

        private object _FaucetChooseSelect;
        public object FaucetChooseSelect { get => _FaucetChooseSelect; set { _FaucetChooseSelect = value; OnPropertyChanged(); } }

        private object _KitchenChooseSelect;
        public object KitchenChooseSelect { get => _KitchenChooseSelect; set { _KitchenChooseSelect = value; OnPropertyChanged(); } }

        private object _WaterHeaterChooseSelect;
        public object WaterHeaterChooseSelect { get => _WaterHeaterChooseSelect; set { _WaterHeaterChooseSelect = value; OnPropertyChanged(); } }

        private object _StoveChooseSelect;
        public object StoveChooseSelect { get => _StoveChooseSelect; set { _StoveChooseSelect = value; OnPropertyChanged(); } }

        private object _BathroomChooseSelect;
        public object BathroomChooseSelect { get => _BathroomChooseSelect; set { _BathroomChooseSelect = value; OnPropertyChanged(); } }

        private object _ShowerChooseSelect;
        public object ShowerChooseSelect { get => _ShowerChooseSelect; set { _ShowerChooseSelect = value; OnPropertyChanged(); } }

        private object _ReheatingChooseSelect;
        public object ReheatingChooseSelect { get => _ReheatingChooseSelect; set { _ReheatingChooseSelect = value; OnPropertyChanged(); } }

        private object _ShowerWithChooseSelect;
        public object ShowerWithChooseSelect { get => _ShowerWithChooseSelect; set { _ShowerWithChooseSelect = value; OnPropertyChanged(); } }

        private object _BathtubChooseSelect;
        public object BathtubChooseSelect { get => _BathtubChooseSelect; set { _BathtubChooseSelect = value; OnPropertyChanged(); } }

        private object _WashingMachineChooseSelect;
        public object WashingMachineChooseSelect { get => _WashingMachineChooseSelect; set { _WashingMachineChooseSelect = value; OnPropertyChanged(); } }

        private object _LightingEquipmentChooseSelect;
        public object LightingEquipmentChooseSelect { get => _LightingEquipmentChooseSelect; set { _LightingEquipmentChooseSelect = value; OnPropertyChanged(); } }

        private object _LightBulbBallChooseSelect;
        public object LightBulbBallChooseSelect { get => _LightBulbBallChooseSelect; set { _LightBulbBallChooseSelect = value; OnPropertyChanged(); } }

        private object _UseNoYesChooseSelect;
        public object UseNoYesChooseSelect { get => _UseNoYesChooseSelect; set { _UseNoYesChooseSelect = value; OnPropertyChanged(); } }

        private object _GaschooseSelect;
        public object GaschooseSelect { get => _GaschooseSelect; set { _GaschooseSelect = value; OnPropertyChanged(); } }

        #endregion

        private string _Electronic;
        public string Electronic { get => _Electronic; set { _Electronic = value; OnPropertyChanged(); } }

        private ObservableCollection<ContractDetailsDB> _contractDetailsView;
        public ObservableCollection<ContractDetailsDB> contractDetailsView { get => _contractDetailsView; set { _contractDetailsView = value; OnPropertyChanged(); } }

        public ICommand AddContractDetailsCommand { get; set; }

        public ContractDetailsFixViewModel()
        {
            //DateTime today = DateTime.Today;
            //DateCurrent = DateTime.Now.ToString("yyyy/MM/dd");

            reloadContract();

            //HouseNo = DataProvider.Ins.DB.RentalManagementDB.Where(o => o.HouseNo == resultSearch).First().HouseNo;
            //ParkingFee = DataProvider.Ins.DB.RentalManagementDB.Where(o => o.HouseNo == resultSearch).First().Parking;
            //Rent = DataProvider.Ins.DB.RentalManagementDB.Where(o => o.HouseNo == resultSearch).First().Rent;
            //CommonServiceFee = DataProvider.Ins.DB.RentalManagementDB.Where(o => o.HouseNo == resultSearch).First().CommonFee;
            //ParkingFee = DataProvider.Ins.DB.RentalManagementDB.Where(o => o.HouseNo == resultSearch).First().ParkingFee;
            //SecurityDeposit = DataProvider.Ins.DB.RentalManagementDB.Where(o => o.HouseNo == resultSearch).First().SecurityDeposit;
            //KeyMoney = DataProvider.Ins.DB.RentalManagementDB.Where(o => o.HouseNo == resultSearch).First().KeyMoney;

            Choose1 = new ObservableCollection<string>
            {
                "有",
                "無"
            };

            Choose2 = new ObservableCollection<string>
            {
                "不可",
                "可"
            };

            ParkingFormSelect = new ObservableCollection<string>
            {
                "砂利",
                "アスファルト",
                "コンクリート"
            };

            GaschooseSelect = new ObservableCollection<string>
            {
                "都市ガス",
                "LPG",
                "供給会社"
            };

            WaterCrewChooseSelect = new ObservableCollection<string>
            {
                "公共",
                "簡易水道",
                "井戸",
                "無し"
            };

            WaterTankChooseSelect = new ObservableCollection<string>
            {
                "ポンプ付き"
            };

            ToiletChooseSelect = new ObservableCollection<string>
            {
                "水洗",
                "汲み取り",
                "洋式," +
                "和式"
            };

            ProcessEquipmentChooseSelect = new ObservableCollection<string>
            {
                "本下水",
                "合併浄化槽",
                "集中浄化槽",
                "単独浄化槽",
                "汲み取り"
            };

            SinkChooseSelect = new ObservableCollection<string>
            {
                "単独使用",
                "共同使用"
            };

            FaucetChooseSelect = new ObservableCollection<string>
            {
                "単独水道のみ",
                "混合水戦",
                "水お湯セパレイト型"
            };

            KitchenChooseSelect = new ObservableCollection<string>
            {
                "セパレイト型",
                "システムキッチン"
            };

            WaterHeaterChooseSelect = new ObservableCollection<string>
            {
                "ガス",
                "電気",
                "温水器"
            };

            StoveChooseSelect = new ObservableCollection<string>
            {
                "ガス",
                "プロパン",
                "都市ガス",
                "IH",
                "電熱ヒーター"
            };

            BathroomChooseSelect = new ObservableCollection<string>
            {
                "ガス",
                "電気",
                "乾燥暖房"
            };

            ShowerChooseSelect = new ObservableCollection<string>
            {
                "ガス",
                "電気",
                "節水機能",
                "手元切替式シャワーヘッド"
            };

            ReheatingChooseSelect = new ObservableCollection<string>
            {
                "ガス",
                "電気",
                "保温機能"
            };

            ShowerWithChooseSelect = new ObservableCollection<string>
            {
                "ガス",
                "電気",
                "節水機能",
                "手元切替式シャワーヘッド"
            };

            BathtubChooseSelect = new ObservableCollection<string>
            {
                "ガス",
                "電気",
                "手すり"
            };

            WashingMachineChooseSelect = new ObservableCollection<string>
            {
                "屋内",
                "屋外"
            };

            LightingEquipmentChooseSelect = new ObservableCollection<string>
            {
                "白熱",
                "蛍光灯",
                "LED",
                "電気",
                "リモコン"
            };

            LightBulbBallChooseSelect = new ObservableCollection<string>
            {
                "白熱",
                "蛍光灯",
                "LED",
                "切れたときは借主負担"
            };

            UseNoYesChooseSelect = new ObservableCollection<string>
            {
                "他人の利用",
                "借主利用不可",
                "借主利用可"
            };

            AddContractDetailsCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RentalSearch contractSearch = new RentalSearch();
                int HouseNoSelect = Int32.Parse(contractSearch.House.Text);
                var AddContract = DataProvider.Ins.DB.ContractDetailsDB.Where(hno => hno.HouseNo == HouseNoSelect).SingleOrDefault();
                AddContract.ContractType = ContractType;
                AddContract.PickupMode = PickupMode;
                AddContract.DateCurrent = DateCurrent;
                AddContract.ContractDate = ContractDate;
                AddContract.ContractBegin = ContractBegin;
                AddContract.ContractEnd = ContractEnd;
                AddContract.ContractOpenDays = ContractOpenDays;
                AddContract.OwnerName = OwnerName;
                AddContract.OwnerBirthday = OwnerBirthday;
                AddContract.OwnerAddress = OwnerAddress;
                AddContract.OwnerAddressNo = OwnerAddressNo;
                AddContract.OwnerTel = OwnerTel;
                AddContract.RenterName = RenterName;
                AddContract.RenterBirthday = RenterBirthday;
                AddContract.RenterAddress = RenterAddress;
                AddContract.RenterAddressNo = RenterAddressNo;
                AddContract.RenterTel = RenterTel;
                AddContract.RentName = RentName;
                AddContract.RentBirthday = RentBirthday;
                AddContract.RentAddress = RentAddress;
                AddContract.RentTel = RentTel;
                AddContract.ResidentName1 = ResidentName1;
                AddContract.ResidentBirthday1 = ResidentBirthday1;
                AddContract.ResidentName2 = ResidentName2;
                AddContract.ResidentBirthday2 = ResidentBirthday2;
                AddContract.ResidentName3 = ResidentName3;
                AddContract.ResidentBirthday3 = ResidentBirthday3;
                AddContract.Location = Location;
                AddContract.LocationName = LocationName;
                AddContract.IssueRoom = IssueRoom;
                AddContract.HouseNumber = HouseNumber;
                AddContract.Type = Type;
                AddContract.Structure = Structure;
                AddContract.OuterWall = OuterWall;
                AddContract.FloorPlan1 = FloorPlan1;
                AddContract.FloorPlan2 = FloorPlan2;
                AddContract.PakingYesNo = PakingYesNo;
                AddContract.ParkingForm = ParkingForm;
                AddContract.UsedNumber1 = UsedNumber1;
                AddContract.UsedNumber2 = UsedNumber2;
                AddContract.UsedNumber3 = UsedNumber3;
                AddContract.ParkingLocation = ParkingLocation;
                AddContract.Electricity = Electricity;
                AddContract.CurrentSupplier = CurrentSupplier;
                AddContract.Gas = Gas;
                AddContract.GasType = GasType;
                AddContract.Supplier = Supplier;
                AddContract.WaterCrew = WaterCrew;
                AddContract.WaterCrewChoose = WaterCrewChoose;
                AddContract.WaterTank = WaterTank;
                AddContract.WaterTankChoose = WaterTankChoose;
                AddContract.Toilet = Toilet;
                AddContract.ToiletChoose = ToiletChoose;
                AddContract.ProcessEquipmentChoose = ProcessEquipmentChoose;
                AddContract.Sink = Sink;
                AddContract.SinkChoose = SinkChoose;
                AddContract.Faucet = Faucet;
                AddContract.FaucetChoose = FaucetChoose;
                AddContract.Kitchen = Kitchen;
                AddContract.KitchenChoose = KitchenChoose;
                AddContract.WaterHeater = WaterHeater;
                AddContract.WaterHeaterChoose = WaterHeaterChoose;
                AddContract.Stove = Stove;
                AddContract.StoveChoose = StoveChoose;
                AddContract.Bathroom = Bathroom;
                AddContract.BathroomChoose = BathroomChoose;
                AddContract.Shower = Shower;
                AddContract.ShowerChoose = ShowerChoose;
                AddContract.Reheating = Reheating;
                AddContract.ReheatingChoose = ReheatingChoose;
                AddContract.ShowerWith = ShowerWith;
                AddContract.ShowerWithChoose = ShowerWithChoose;
                AddContract.Bathtub = Bathtub;
                AddContract.BathtubChoose = BathtubChoose;
                AddContract.WashingMachine = WashingMachine;
                AddContract.WashingMachineChoose = WashingMachineChoose;
                AddContract.ConnectionBracket = ConnectionBracket;
                AddContract.ConnectionBracketChoose = ConnectionBracketChoose;
                AddContract.LightingEquipment = LightingEquipment;
                AddContract.LightingEquipmentChoose = LightingEquipmentChoose;
                AddContract.LightBulbBall = LightBulbBall;
                AddContract.LightBulbBallChoose = LightBulbBallChoose;
                AddContract.TelevisionAntenna = TelevisionAntenna;
                AddContract.FixedTelephone = FixedTelephone;
                AddContract.FixedTelephoneChoose = FixedTelephoneChoose;
                AddContract.Phone = Phone;
                AddContract.PhoneChoose = PhoneChoose;
                AddContract.InternetEquipment = InternetEquipment;
                AddContract.InternetEquipmentChoose = InternetEquipmentChoose;
                AddContract.Provider = Provider;
                AddContract.ProviderChoose = ProviderChoose;
                AddContract.Router = Router;
                AddContract.AirConditioning = AirConditioning;
                AddContract.AirConditioningChoose = AirConditioningChoose;
                AddContract.Elevator = Elevator;
                AddContract.GarbageStorage = GarbageStorage;
                AddContract.GarbageStorageChoose = GarbageStorageChoose;
                AddContract.Pet = Pet;
                AddContract.PetChoose = PetChoose;
                AddContract.EvacutionLadder = EvacutionLadder;
                AddContract.BicycleParkingSpace = BicycleParkingSpace;
                AddContract.DoorPocket = DoorPocket;
                AddContract.ScreenDoor = ScreenDoor;
                AddContract.FireAlarm = FireAlarm;
                AddContract.FireExtinguisher = FireExtinguisher;
                AddContract.FireHydrant = FireHydrant;
                AddContract.Storage = Storage;
                AddContract.StorageChoose = StorageChoose;
                AddContract.InstallationSunlight = InstallationSunlight;
                AddContract.UseNoYes = UseNoYes;
                AddContract.UseNoYesChoose = UseNoYesChoose;
                AddContract.HotSpring = HotSpring;
                AddContract.HotSpringChoose = HotSpringChoose;
                AddContract.OtherBuildings = OtherBuildings;
                AddContract.OtherBuildingsChoose = OtherBuildingsChoose;
                AddContract.OtherConditions = OtherConditions;
                AddContract.OtherConditionsChoose = OtherConditionsChoose;
                //AddContract.TransportationFacilities = TransportationFacilities;
                //AddContract.Rent = Rent;
                //AddContract.CommonServiceFee = CommonServiceFee;
                //AddContract.CATVFee = CATVFee;
                //AddContract.ParkingFee = ParkingFee;
                //AddContract.SecurityDeposit = SecurityDeposit;
                //AddContract.KeyMoney = KeyMoney;
                AddContract.Total = Total;

                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("物件内容を修正しました。", "修正成功", MessageBoxButton.OK, MessageBoxImage.Information);
            });
        }
        private void reloadContract()
        {
            RentalSearch contractSearch = new RentalSearch();
            int HouseNoSelect = Int32.Parse(contractSearch.House.Text);

            #region Display Column of value
            contractDetailsView = new ObservableCollection<ContractDetailsDB>(DataProvider.Ins.DB.ContractDetailsDB.Where(i => i.HouseNo == HouseNoSelect));
            HouseNo = HouseNoSelect;
            ContractType = contractDetailsView.First().ContractType;
            PickupMode = contractDetailsView.First().PickupMode;
            DateCurrent = contractDetailsView.First().DateCurrent;
            ContractDate = contractDetailsView.First().ContractDate;
            ContractBegin = contractDetailsView.First().ContractBegin;
            ContractEnd = contractDetailsView.First().ContractEnd;
            ContractOpenDays = contractDetailsView.First().ContractOpenDays;
            OwnerName = contractDetailsView.First().OwnerName;
            OwnerBirthday = contractDetailsView.First().OwnerBirthday;
            OwnerAddress = contractDetailsView.First().OwnerAddress;
            OwnerAddressNo = contractDetailsView.First().OwnerAddressNo;
            OwnerTel = contractDetailsView.First().OwnerTel;
            RenterName = contractDetailsView.First().RenterName;
            RenterBirthday = contractDetailsView.First().RenterBirthday;
            RenterAddress = contractDetailsView.First().RenterAddress;
            RenterAddressNo = contractDetailsView.First().RenterAddressNo;
            RenterTel = contractDetailsView.First().RenterTel;
            RentName = contractDetailsView.First().RentName;
            RentBirthday = contractDetailsView.First().RentBirthday;
            RentAddress = contractDetailsView.First().RentAddress;
            RentTel = contractDetailsView.First().RentTel;
            ResidentName1 = contractDetailsView.First().ResidentName1;
            ResidentBirthday1 = contractDetailsView.First().ResidentBirthday1;
            ResidentName2 = contractDetailsView.First().ResidentName2;
            ResidentBirthday2 = contractDetailsView.First().ResidentBirthday2;
            ResidentName3 = contractDetailsView.First().ResidentName3;
            ResidentBirthday3 = contractDetailsView.First().ResidentBirthday3;
            Location = contractDetailsView.First().Location;
            LocationName = contractDetailsView.First().LocationName;
            IssueRoom = contractDetailsView.First().IssueRoom;
            HouseNumber = contractDetailsView.First().HouseNumber;
            Type = contractDetailsView.First().Type;
            Structure = contractDetailsView.First().Structure;
            OuterWall = contractDetailsView.First().OuterWall;
            FloorPlan1 = contractDetailsView.First().FloorPlan1;
            FloorPlan2 = contractDetailsView.First().FloorPlan2;
            PakingYesNo = contractDetailsView.First().PakingYesNo;
            ParkingForm = contractDetailsView.First().ParkingForm;
            UsedNumber1 = contractDetailsView.First().UsedNumber1;
            UsedNumber2 = contractDetailsView.First().UsedNumber2;
            UsedNumber3 = contractDetailsView.First().UsedNumber3;
            ParkingLocation = contractDetailsView.First().ParkingLocation;
            Electricity = contractDetailsView.First().Electricity;
            CurrentSupplier = contractDetailsView.First().CurrentSupplier;
            Gas = contractDetailsView.First().Gas;
            GasType = contractDetailsView.First().GasType;
            Supplier = contractDetailsView.First().Supplier;
            WaterCrew = contractDetailsView.First().WaterCrew;
            WaterCrewChoose = contractDetailsView.First().WaterCrewChoose;
            WaterTank = contractDetailsView.First().WaterTank;
            WaterTankChoose = contractDetailsView.First().WaterTankChoose;
            Toilet = contractDetailsView.First().Toilet;
            ToiletChoose = contractDetailsView.First().ToiletChoose;
            ProcessEquipmentChoose = contractDetailsView.First().ProcessEquipmentChoose;
            Sink = contractDetailsView.First().Sink;
            SinkChoose = contractDetailsView.First().SinkChoose;
            Faucet = contractDetailsView.First().Faucet;
            FaucetChoose = contractDetailsView.First().FaucetChoose;
            Kitchen = contractDetailsView.First().Kitchen;
            KitchenChoose = contractDetailsView.First().KitchenChoose;
            WaterHeater = contractDetailsView.First().WaterHeater;
            WaterHeaterChoose = contractDetailsView.First().WaterHeaterChoose;
            Stove = contractDetailsView.First().Stove;
            StoveChoose = contractDetailsView.First().StoveChoose;
            Bathroom = contractDetailsView.First().Bathroom;
            BathroomChoose = contractDetailsView.First().BathroomChoose;
            Shower = contractDetailsView.First().Shower;
            ShowerChoose = contractDetailsView.First().ShowerChoose;
            Reheating = contractDetailsView.First().Reheating;
            ReheatingChoose = contractDetailsView.First().ReheatingChoose;
            ShowerWith = contractDetailsView.First().ShowerWith;
            ShowerWithChoose = contractDetailsView.First().ShowerWithChoose;
            Bathtub = contractDetailsView.First().Bathtub;
            BathtubChoose = contractDetailsView.First().BathtubChoose;
            WashingMachine = contractDetailsView.First().WashingMachine;
            WashingMachineChoose = contractDetailsView.First().WashingMachineChoose;
            ConnectionBracket = contractDetailsView.First().ConnectionBracket;
            ConnectionBracketChoose = contractDetailsView.First().ConnectionBracketChoose;
            LightingEquipment = contractDetailsView.First().LightingEquipment;
            LightingEquipmentChoose = contractDetailsView.First().LightingEquipmentChoose;
            LightBulbBall = contractDetailsView.First().LightBulbBall;
            LightBulbBallChoose = contractDetailsView.First().LightBulbBallChoose;
            TelevisionAntenna = contractDetailsView.First().TelevisionAntenna;
            FixedTelephone = contractDetailsView.First().FixedTelephone;
            FixedTelephoneChoose = contractDetailsView.First().FixedTelephoneChoose;
            Phone = contractDetailsView.First().Phone;
            PhoneChoose = contractDetailsView.First().PhoneChoose;
            InternetEquipment = contractDetailsView.First().InternetEquipment;
            InternetEquipmentChoose = contractDetailsView.First().InternetEquipmentChoose;
            Provider = contractDetailsView.First().Provider;
            ProviderChoose = contractDetailsView.First().ProviderChoose;
            Router = contractDetailsView.First().Router;
            AirConditioning = contractDetailsView.First().AirConditioning;
            AirConditioningChoose = contractDetailsView.First().AirConditioningChoose;
            Elevator = contractDetailsView.First().Elevator;
            GarbageStorage = contractDetailsView.First().GarbageStorage;
            GarbageStorageChoose = contractDetailsView.First().GarbageStorageChoose;
            Pet = contractDetailsView.First().Pet;
            PetChoose = contractDetailsView.First().PetChoose;
            EvacutionLadder = contractDetailsView.First().EvacutionLadder;
            BicycleParkingSpace = contractDetailsView.First().BicycleParkingSpace;
            DoorPocket = contractDetailsView.First().DoorPocket;
            ScreenDoor = contractDetailsView.First().ScreenDoor;
            FireAlarm = contractDetailsView.First().FireAlarm;
            FireExtinguisher = contractDetailsView.First().FireExtinguisher;
            FireHydrant = contractDetailsView.First().FireHydrant;
            Storage = contractDetailsView.First().Storage;
            StorageChoose = contractDetailsView.First().StorageChoose;
            InstallationSunlight = contractDetailsView.First().InstallationSunlight;
            UseNoYes = contractDetailsView.First().UseNoYes;
            UseNoYesChoose = contractDetailsView.First().UseNoYesChoose;
            HotSpring = contractDetailsView.First().HotSpring;
            HotSpringChoose = contractDetailsView.First().HotSpringChoose;
            OtherBuildings = contractDetailsView.First().OtherBuildings;
            OtherBuildingsChoose = contractDetailsView.First().OtherBuildingsChoose;
            OtherConditions = contractDetailsView.First().OtherConditions;
            OtherConditionsChoose = contractDetailsView.First().OtherConditionsChoose;
            TransportationFacilities = contractDetailsView.First().TransportationFacilities;
            Rent = contractDetailsView.First().Rent;
            CommonServiceFee = contractDetailsView.First().CommonServiceFee;
            CATVFee = contractDetailsView.First().CATVFee;
            ParkingFee = contractDetailsView.First().ParkingFee;
            SecurityDeposit = contractDetailsView.First().SecurityDeposit;
            KeyMoney = contractDetailsView.First().KeyMoney;
            Total = contractDetailsView.First().Total;
            #endregion
        }
    }
}
