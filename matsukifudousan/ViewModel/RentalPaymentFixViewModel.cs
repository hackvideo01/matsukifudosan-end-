using matsukifudousan.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace matsukifudousan.ViewModel
{
    public class RentalPaymentFixViewModel : BaseViewModel
    {
        private ObservableCollection<Object> _RentalPaymentFix = new ObservableCollection<Object>();
        public ObservableCollection<Object> RentalPaymentFix { get => _RentalPaymentFix; set { _RentalPaymentFix = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _ComboxPrintsChoose = new ObservableCollection<Object>();
        public ObservableCollection<Object> ComboxPrintsChoose { get => _ComboxPrintsChoose; set { _ComboxPrintsChoose = value; OnPropertyChanged(); } }

        private ObservableCollection<object> _List;
        public ObservableCollection<object> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private Object _Months;
        public Object Months { get => _Months; set { _Months = value; OnPropertyChanged(); } }

        private object _SelectedItem;
        public object SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    string output = JsonConvert.SerializeObject(SelectedItem);
                    JObject jsonObj = JObject.Parse(output);
                    Months = Int32.Parse(jsonObj["MonthNumber"].ToString());
                }
            }
        }

        public ICommand RentalPaymentFixSelect { get; set; }

        public RentalPaymentFixViewModel()
        {
            var query = from s in DataProvider.Ins.DB.RentalContactDB
                        join rent in DataProvider.Ins.DB.RentalManagementDB
                            on s.HouseNo equals rent.HouseNo into r
                        from rent in r.DefaultIfEmpty()
                        join notPay in DataProvider.Ins.DB.NotPaymentDB
                            on s.HouseNo equals notPay.HouseNo into cs
                        from notPay in cs.DefaultIfEmpty()
                        join p in DataProvider.Ins.DB.RentalPaymentDB
                            on s.HouseNo equals p.HouseNo into c
                        from p in c.DefaultIfEmpty()
                            //where sa.HouseNo == "10"

                        orderby s.HouseNo ascending
                        select new
                        {
                            s.HouseName,
                            rent.Rent,
                            s.RentName,
                            s.HouseNo,
                            p.Year,
                            p.MoneyMonth1,
                            p.MoneyMonth2,
                            p.MoneyMonth3,
                            p.MoneyMonth4,
                            p.MoneyMonth5,
                            p.MoneyMonth6,
                            p.MoneyMonth7,
                            p.MoneyMonth8,
                            p.MoneyMonth9,
                            p.MoneyMonth10,
                            p.MoneyMonth11,
                            p.MoneyMonth12,
                            p.MoneyMonth1Date,
                            p.MoneyMonth2Date,
                            p.MoneyMonth3Date,
                            p.MoneyMonth4Date,
                            p.MoneyMonth5Date,
                            p.MoneyMonth6Date,
                            p.MoneyMonth7Date,
                            p.MoneyMonth8Date,
                            p.MoneyMonth9Date,
                            p.MoneyMonth10Date,
                            p.MoneyMonth11Date,
                            p.MoneyMonth12Date,
                            notPay.NotPayment
                        };
            RentalPaymentInput rentalPaymentInput = new RentalPaymentInput();
            string selectedRental = rentalPaymentInput.txbHouse.Text;
            int HouseSelect = Int32.Parse(selectedRental);
            DateTime dTimePaymentDate = DateTime.Now;
            string yearPaymentDate = dTimePaymentDate.Year.ToString();
            string monthPaymentDate = dTimePaymentDate.Month.ToString();
            string dayPaymentDate = dTimePaymentDate.Day.ToString();
            int yearCheck = DataProvider.Ins.DB.RentalPaymentDB.Where(y => y.Year == yearPaymentDate && y.HouseNo == HouseSelect).Count();
            var monthMoneyCheck = DataProvider.Ins.DB.RentalPaymentDB.Where(y => y.Year == yearPaymentDate && y.HouseNo == HouseSelect);
            string month1 = monthMoneyCheck.FirstOrDefault().MoneyMonth1;
            string month2 = monthMoneyCheck.FirstOrDefault().MoneyMonth2;
            string month3 = monthMoneyCheck.FirstOrDefault().MoneyMonth3;
            string month4 = monthMoneyCheck.FirstOrDefault().MoneyMonth4;
            string month5 = monthMoneyCheck.FirstOrDefault().MoneyMonth5;
            string month6 = monthMoneyCheck.FirstOrDefault().MoneyMonth6;
            string month7 = monthMoneyCheck.FirstOrDefault().MoneyMonth7;
            string month8 = monthMoneyCheck.FirstOrDefault().MoneyMonth8;
            string month9 = monthMoneyCheck.FirstOrDefault().MoneyMonth9;
            string month10 = monthMoneyCheck.FirstOrDefault().MoneyMonth10;
            string month11 = monthMoneyCheck.FirstOrDefault().MoneyMonth11;
            string month12 = monthMoneyCheck.FirstOrDefault().MoneyMonth12;
            string month1Date = monthMoneyCheck.FirstOrDefault().MoneyMonth1Date;
            string month2Date = monthMoneyCheck.FirstOrDefault().MoneyMonth2Date;
            string month3Date = monthMoneyCheck.FirstOrDefault().MoneyMonth3Date;
            string month4Date = monthMoneyCheck.FirstOrDefault().MoneyMonth4Date;
            string month5Date = monthMoneyCheck.FirstOrDefault().MoneyMonth5Date;
            string month6Date = monthMoneyCheck.FirstOrDefault().MoneyMonth6Date;
            string month7Date = monthMoneyCheck.FirstOrDefault().MoneyMonth7Date;
            string month8Date = monthMoneyCheck.FirstOrDefault().MoneyMonth8Date;
            string month9Date = monthMoneyCheck.FirstOrDefault().MoneyMonth9Date;
            string month10Date = monthMoneyCheck.FirstOrDefault().MoneyMonth10Date;
            string month11Date = monthMoneyCheck.FirstOrDefault().MoneyMonth11Date;
            string month12Date = monthMoneyCheck.FirstOrDefault().MoneyMonth12Date;
            RentalPaymentInput RentalSelect = new RentalPaymentInput();
            int HouseNoSelect = Int32.Parse(RentalSelect.txbHouse.Text);

            ComboxPrintsChoose.Add(new Month() { MonthNumber = 1, Money = month1, Date = month1Date });
            ComboxPrintsChoose.Add(new Month() { MonthNumber = 2, Money = month2, Date = month2Date });
            ComboxPrintsChoose.Add(new Month() { MonthNumber = 3, Money = month3, Date = month3Date });
            ComboxPrintsChoose.Add(new Month() { MonthNumber = 4, Money = month4, Date = month4Date });
            ComboxPrintsChoose.Add(new Month() { MonthNumber = 5, Money = month5, Date = month5Date });
            ComboxPrintsChoose.Add(new Month() { MonthNumber = 6, Money = month6, Date = month6Date });
            ComboxPrintsChoose.Add(new Month() { MonthNumber = 7, Money = month7, Date = month7Date });
            ComboxPrintsChoose.Add(new Month() { MonthNumber = 8, Money = month8, Date = month8Date });
            ComboxPrintsChoose.Add(new Month() { MonthNumber = 9, Money = month9, Date = month9Date });
            ComboxPrintsChoose.Add(new Month() { MonthNumber = 10, Money = month10, Date = month10Date });
            ComboxPrintsChoose.Add(new Month() { MonthNumber = 11, Money = month11, Date = month11Date });
            ComboxPrintsChoose.Add(new Month() { MonthNumber = 12, Money = month12, Date = month12Date });


            //List = new ObservableCollection<object>(query.Where(s => s.HouseNo == HouseNoSelect));


            RentalPaymentFixSelect = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RentalPaymentInput wd = new RentalPaymentInput();
                wd.txbMoneyMonthPayment.Text = "1";
            });
        }
        public class Month
        {
            public int MonthNumber { get; set; }
            public string Money { get; set; }
            public string Date { get; set; }
        }
    }
}
