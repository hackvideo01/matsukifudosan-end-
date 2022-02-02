using matsukifudousan.Model;
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
    public class RentalPaymentViewModel : BaseViewModel
    {
        #region init Payment
        private string _MoneyMonthPayment;
        public string MoneyMonthPayment
        {
            get => _MoneyMonthPayment;
            set
            {
                _MoneyMonthPayment = value;
                OnPropertyChanged();
                int inputmoney = Int32.Parse(MoneyMonthPayment);
                int notPay = 0;
                int rent = Int32.Parse(Rent);
                int moneyDB = 0;
                string notpay = "";
                DateTime dTimePaymentDate = DateTime.Parse(PaymentDate);
                string yearPaymentDate = dTimePaymentDate.Year.ToString();
                string monthPaymentDate = dTimePaymentDate.Month.ToString();
                string dayPaymentDate = dTimePaymentDate.Day.ToString();
                if (ComboxSelect == "" || ComboxSelect == null)
                {
                    if (monthPaymentDate == "1")
                    {
                        if (DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).Count() != 0)
                        {
                            string month1 = DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.Year == yearPaymentDate && d.HouseNo == HouseNo).SingleOrDefault().MoneyMonth1;
                            if (month1 != null)
                            {
                                notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                                int notpayDB = Int32.Parse(notpay);
                                NotPayment = (notpayDB - inputmoney).ToString();
                            }
                            else
                            {
                                if (Rent != null)
                                {
                                    rent = Int32.Parse(Rent);
                                }
                                notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                                if (notpay != null)
                                {
                                    notPay = Int32.Parse(notpay);
                                }
                                NotPayment = (rent - inputmoney + notPay).ToString();
                            }
                        }
                        else
                        {
                            NotPayment = (rent - inputmoney).ToString();
                        }
                    }
                    else if (monthPaymentDate == "2")
                    {
                        if (DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).Count() != 0)
                        {
                            string month2 = DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.Year == yearPaymentDate && d.HouseNo == HouseNo).SingleOrDefault().MoneyMonth2;
                            if (month2 != null)
                            {
                                notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                                int notpayDB = Int32.Parse(notpay);
                                NotPayment = (notpayDB - inputmoney).ToString();
                            }
                            else
                            {
                                if (Rent != null)
                                {
                                    rent = Int32.Parse(Rent);
                                }
                                notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                                if (notpay != null)
                                {
                                    notPay = Int32.Parse(notpay);
                                }
                                NotPayment = (rent - inputmoney + notPay).ToString();
                            }
                        }
                        else
                        {
                            NotPayment = (rent - inputmoney).ToString();
                        }
                    }
                    else if (monthPaymentDate == "3")
                    {
                        if (DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).Count() != 0)
                        {
                            string month3 = DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.Year == yearPaymentDate && d.HouseNo == HouseNo).SingleOrDefault().MoneyMonth3;
                            if (month3 != null)
                            {
                                notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                                int notpayDB = Int32.Parse(notpay);
                                NotPayment = (notpayDB - inputmoney).ToString();
                            }
                            else
                            {
                                if (Rent != null)
                                {
                                    rent = Int32.Parse(Rent);
                                }
                                notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                                if (notpay != null)
                                {
                                    notPay = Int32.Parse(notpay);
                                }
                                NotPayment = (rent - inputmoney + notPay).ToString();
                            }
                        }
                        else
                        {
                            NotPayment = (rent - inputmoney).ToString();
                        }
                    }
                    else if (monthPaymentDate == "4")
                    {
                        if (DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).Count() != 0)
                        {
                            string month4 = DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.Year == yearPaymentDate && d.HouseNo == HouseNo).SingleOrDefault().MoneyMonth4;
                            if (month4 != null)
                            {
                                notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                                int notpayDB = Int32.Parse(notpay);
                                NotPayment = (notpayDB - inputmoney).ToString();
                            }
                            else
                            {
                                if (Rent != null)
                                {
                                    rent = Int32.Parse(Rent);
                                }
                                notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                                if (notpay != null)
                                {
                                    notPay = Int32.Parse(notpay);
                                }
                                NotPayment = (rent - inputmoney + notPay).ToString();
                            }
                        }
                        else
                        {
                            NotPayment = (rent - inputmoney).ToString();
                        }
                    }
                    else if (monthPaymentDate == "5")
                    {
                        if (DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).Count() != 0)
                        {
                            string month5 = DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.Year == yearPaymentDate && d.HouseNo == HouseNo).SingleOrDefault().MoneyMonth5;
                            if (month5 != null)
                            {
                                notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                                int notpayDB = Int32.Parse(notpay);
                                NotPayment = (notpayDB - inputmoney).ToString();
                            }
                            else
                            {
                                if (Rent != null)
                                {
                                    rent = Int32.Parse(Rent);
                                }
                                notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                                if (notpay != null)
                                {
                                    notPay = Int32.Parse(notpay);
                                }
                                NotPayment = (rent - inputmoney + notPay).ToString();
                            }
                        }
                        else
                        {
                            NotPayment = (rent - inputmoney).ToString();
                        }
                    }
                    else if (monthPaymentDate == "6")
                    {
                        if (DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).Count() != 0)
                        {
                            string month6 = DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.Year == yearPaymentDate && d.HouseNo == HouseNo).SingleOrDefault().MoneyMonth6;
                            if (month6 != null)
                            {
                                notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                                int notpayDB = Int32.Parse(notpay);
                                NotPayment = (notpayDB - inputmoney).ToString();
                            }
                            else
                            {
                                if (Rent != null)
                                {
                                    rent = Int32.Parse(Rent);
                                }
                                notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                                if (notpay != null)
                                {
                                    notPay = Int32.Parse(notpay);
                                }
                                NotPayment = (rent - inputmoney + notPay).ToString();
                            }
                        }
                        else
                        {
                            NotPayment = (rent - inputmoney).ToString();
                        }
                    }
                    else if (monthPaymentDate == "7")
                    {
                        if (DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).Count() != 0)
                        {
                            string month7 = DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.Year == yearPaymentDate && d.HouseNo == HouseNo).SingleOrDefault().MoneyMonth7;
                            if (month7 != null)
                            {
                                notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                                int notpayDB = Int32.Parse(notpay);
                                NotPayment = (notpayDB - inputmoney).ToString();
                            }
                            else
                            {
                                if (Rent != null)
                                {
                                    rent = Int32.Parse(Rent);
                                }
                                notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                                if (notpay != null)
                                {
                                    notPay = Int32.Parse(notpay);
                                }
                                NotPayment = (rent - inputmoney + notPay).ToString();
                            }
                        }
                        else
                        {
                            NotPayment = (rent - inputmoney).ToString();
                        }
                    }
                    else if (monthPaymentDate == "8")
                    {
                        if (DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).Count() != 0)
                        {
                            string month8 = DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.Year == yearPaymentDate && d.HouseNo == HouseNo).SingleOrDefault().MoneyMonth8;
                            if (month8 != null)
                            {
                                notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                                int notpayDB = Int32.Parse(notpay);
                                NotPayment = (notpayDB - inputmoney).ToString();
                            }
                            else
                            {
                                if (Rent != null)
                                {
                                    rent = Int32.Parse(Rent);
                                }
                                notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                                if (notpay != null)
                                {
                                    notPay = Int32.Parse(notpay);
                                }
                                NotPayment = (rent - inputmoney + notPay).ToString();
                            }
                        }
                        else
                        {
                            NotPayment = (rent - inputmoney).ToString();
                        }
                    }
                    else if (monthPaymentDate == "9")
                    {
                        if (DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).Count() != 0)
                        {
                            string month9 = DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.Year == yearPaymentDate && d.HouseNo == HouseNo).SingleOrDefault().MoneyMonth9;
                            if (month9 != null)
                            {
                                notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                                int notpayDB = Int32.Parse(notpay);
                                NotPayment = (notpayDB - inputmoney).ToString();
                            }
                            else
                            {
                                if (Rent != null)
                                {
                                    rent = Int32.Parse(Rent);
                                }
                                notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                                if (notpay != null)
                                {
                                    notPay = Int32.Parse(notpay);
                                }
                                NotPayment = (rent - inputmoney + notPay).ToString();
                            }
                        }
                        else
                        {
                            NotPayment = (rent - inputmoney).ToString();
                        }
                    }
                    else if (monthPaymentDate == "10")
                    {
                        if (DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).Count() != 0)
                        {
                            string month10 = DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.Year == yearPaymentDate && d.HouseNo == HouseNo).SingleOrDefault().MoneyMonth10;
                            if (month10 != null)
                            {
                                notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                                int notpayDB = Int32.Parse(notpay);
                                NotPayment = (notpayDB - inputmoney).ToString();
                            }
                            else
                            {
                                if (Rent != null)
                                {
                                    rent = Int32.Parse(Rent);
                                }
                                notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                                if (notpay != null)
                                {
                                    notPay = Int32.Parse(notpay);
                                }
                                NotPayment = (rent - inputmoney + notPay).ToString();
                            }
                        }
                        else
                        {
                            NotPayment = (rent - inputmoney).ToString();
                        }
                    }
                    else if (monthPaymentDate == "11")
                    {
                        if (DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).Count() != 0)
                        {
                            string month11 = DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.Year == yearPaymentDate && d.HouseNo == HouseNo).SingleOrDefault().MoneyMonth11;
                            if (month11 != null)
                            {
                                notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                                int notpayDB = Int32.Parse(notpay);
                                NotPayment = (notpayDB - inputmoney).ToString();
                            }
                            else
                            {
                                if (Rent != null)
                                {
                                    rent = Int32.Parse(Rent);
                                }
                                notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                                if (notpay != null)
                                {
                                    notPay = Int32.Parse(notpay);
                                }
                                NotPayment = (rent - inputmoney + notPay).ToString();
                            }
                        }
                        else
                        {
                            NotPayment = (rent - inputmoney).ToString();
                        }
                    }
                    else if (monthPaymentDate == "12")
                    {
                        if (DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).Count() != 0)
                        {
                            string month12 = DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.Year == yearPaymentDate && d.HouseNo == HouseNo).SingleOrDefault().MoneyMonth12;
                            if (month12 != null)
                            {
                                notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                                int notpayDB = Int32.Parse(notpay);
                                NotPayment = (notpayDB - inputmoney).ToString();
                            }
                            else
                            {
                                if (Rent != null)
                                {
                                    rent = Int32.Parse(Rent);
                                }
                                notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                                if (notpay != null)
                                {
                                    notPay = Int32.Parse(notpay);
                                }
                                NotPayment = (rent - inputmoney + notPay).ToString();
                            }
                        }
                        else
                        {
                            NotPayment = (rent - inputmoney).ToString();
                        }
                    }
                }
                else
                {
                    if (ComboxSelect == "1月")
                    {
                        notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                        string money = DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().MoneyMonth1;
                        moneyDB = Int32.Parse(money);
                        int notpayDB = Int32.Parse(notpay);
                        NotPayment = (notpayDB + (moneyDB - inputmoney)).ToString();
                    }
                    else if (ComboxSelect == "2月")
                    {
                        notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                        string money = DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().MoneyMonth2;
                        moneyDB = Int32.Parse(money);
                        int notpayDB = Int32.Parse(notpay);
                        NotPayment = (notpayDB + (moneyDB - inputmoney)).ToString();
                    }
                    else if (ComboxSelect == "3月")
                    {
                        notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                        string money = DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().MoneyMonth3;
                        moneyDB = Int32.Parse(money);
                        int notpayDB = Int32.Parse(notpay);
                        NotPayment = (notpayDB + (moneyDB - inputmoney)).ToString();
                    }
                    else if (ComboxSelect == "4月")
                    {
                        notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                        string money = DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().MoneyMonth4;
                        moneyDB = Int32.Parse(money);
                        int notpayDB = Int32.Parse(notpay);
                        NotPayment = (notpayDB + (moneyDB - inputmoney)).ToString();
                    }
                    else if (ComboxSelect == "5月")
                    {
                        notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                        string money = DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().MoneyMonth5;
                        moneyDB = Int32.Parse(money);
                        int notpayDB = Int32.Parse(notpay);
                        NotPayment = (notpayDB + (moneyDB - inputmoney)).ToString();

                    }
                    else if (ComboxSelect == "6月")
                    {
                        notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                        string money = DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().MoneyMonth6;
                        moneyDB = Int32.Parse(money);
                        int notpayDB = Int32.Parse(notpay);
                        NotPayment = (notpayDB + (moneyDB - inputmoney)).ToString();
                    }
                    else if (ComboxSelect == "7月")
                    {
                        notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                        string money = DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().MoneyMonth7;
                        moneyDB = Int32.Parse(money);
                        int notpayDB = Int32.Parse(notpay);
                        NotPayment = (notpayDB + (moneyDB - inputmoney)).ToString();
                    }
                    else if (ComboxSelect == "8月")
                    {
                        notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                        string money = DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().MoneyMonth8;
                        moneyDB = Int32.Parse(money);
                        int notpayDB = Int32.Parse(notpay);
                        NotPayment = (notpayDB + (moneyDB - inputmoney)).ToString();
                    }
                    else if (ComboxSelect == "9月")
                    {
                        notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                        string money = DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().MoneyMonth9;
                        moneyDB = Int32.Parse(money);
                        int notpayDB = Int32.Parse(notpay);
                        NotPayment = (notpayDB + (moneyDB - inputmoney)).ToString();
                    }
                    else if (ComboxSelect == "10月")
                    {
                        notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                        string money = DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().MoneyMonth10;
                        moneyDB = Int32.Parse(money);
                        int notpayDB = Int32.Parse(notpay);
                        NotPayment = (notpayDB + (moneyDB - inputmoney)).ToString();
                    }
                    else if (ComboxSelect == "11月")
                    {
                        notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                        string money = DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().MoneyMonth11;
                        moneyDB = Int32.Parse(money);
                        int notpayDB = Int32.Parse(notpay);
                        NotPayment = (notpayDB + (moneyDB - inputmoney)).ToString();
                    }
                    else if (ComboxSelect == "12月")
                    {
                        notpay = DataProvider.Ins.DB.NotPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().NotPayment;
                        string money = DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).SingleOrDefault().MoneyMonth12;
                        moneyDB = Int32.Parse(money);
                        int notpayDB = Int32.Parse(notpay);
                        NotPayment = (notpayDB + (moneyDB - inputmoney)).ToString();
                    }
                }
            }
        }

        private string _PaymentDate = DateTime.Now.ToString();
        public string PaymentDate
        {
            get => _PaymentDate;
            set
            {
                _PaymentDate = value;
                OnPropertyChanged();


                DateTime dTimePaymentDate = DateTime.Parse(PaymentDate);
                string yearPaymentDate = dTimePaymentDate.Year.ToString();
                string monthPaymentDate = dTimePaymentDate.Month.ToString();
                string dayPaymentDate = dTimePaymentDate.Day.ToString();
                //int inputDateHouseNo = Int32.Parse(HouseNo);
                int countFollowDay = DataProvider.Ins.DB.NotPaymentDB.Where(x => x.HouseNo == HouseNo).Count();
                if (countFollowDay != 0)
                {
                    if (DataProvider.Ins.DB.NotPaymentDB.Where(x => x.HouseNo == HouseNo).FirstOrDefault().NotPayment == null)
                    {
                        //txbNotPayment.Text = "0";
                    }
                    else
                    {
                        NotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(x => x.HouseNo == HouseNo).FirstOrDefault().NotPayment;
                    }
                }
                MoneyMonthPayment = "";
            }
        }

        private int _HouseNo;
        public int HouseNo { get => _HouseNo; set { _HouseNo = value; OnPropertyChanged(); } }

        private string _MoneyMonth1;
        public string MoneyMonth1 { get => _MoneyMonth1; set { _MoneyMonth1 = value; OnPropertyChanged(); } }

        private string _MoneyMonth2;
        public string MoneyMonth2 { get => _MoneyMonth2; set { _MoneyMonth2 = value; OnPropertyChanged(); } }

        private string _MoneyMonth3;
        public string MoneyMonth3 { get => _MoneyMonth3; set { _MoneyMonth3 = value; OnPropertyChanged(); } }

        private string _MoneyMonth4;
        public string MoneyMonth4 { get => _MoneyMonth4; set { _MoneyMonth4 = value; OnPropertyChanged(); } }

        private string _MoneyMonth5;
        public string MoneyMonth5 { get => _MoneyMonth5; set { _MoneyMonth5 = value; OnPropertyChanged(); } }

        private string _MoneyMonth6;
        public string MoneyMonth6 { get => _MoneyMonth6; set { _MoneyMonth6 = value; OnPropertyChanged(); } }

        private string _MoneyMonth7;
        public string MoneyMonth7 { get => _MoneyMonth7; set { _MoneyMonth7 = value; OnPropertyChanged(); } }

        private string _MoneyMonth8;
        public string MoneyMonth8 { get => _MoneyMonth8; set { _MoneyMonth8 = value; OnPropertyChanged(); } }

        private string _MoneyMonth9;
        public string MoneyMonth9 { get => _MoneyMonth9; set { _MoneyMonth9 = value; OnPropertyChanged(); } }

        private string _MoneyMonth10;
        public string MoneyMonth10 { get => _MoneyMonth10; set { _MoneyMonth10 = value; OnPropertyChanged(); } }

        private string _MoneyMonth11;
        public string MoneyMonth11 { get => _MoneyMonth11; set { _MoneyMonth11 = value; OnPropertyChanged(); } }

        private string _MoneyMonth12;
        public string MoneyMonth12 { get => _MoneyMonth12; set { _MoneyMonth12 = value; OnPropertyChanged(); } }

        private string _MoneyMonth1Date;
        public string MoneyMonth1Date { get => _MoneyMonth1Date; set { _MoneyMonth1Date = value; OnPropertyChanged(); } }

        private string _MoneyMonth2Date;
        public string MoneyMonth2Date { get => _MoneyMonth2Date; set { _MoneyMonth2Date = value; OnPropertyChanged(); } }

        private string _MoneyMonth3Date;
        public string MoneyMonth3Date { get => _MoneyMonth3Date; set { _MoneyMonth3Date = value; OnPropertyChanged(); } }

        private string _MoneyMonth4Date;
        public string MoneyMonth4Date { get => _MoneyMonth4Date; set { _MoneyMonth4Date = value; OnPropertyChanged(); } }

        private string _MoneyMonth5Date;
        public string MoneyMonth5Date { get => _MoneyMonth5Date; set { _MoneyMonth5Date = value; OnPropertyChanged(); } }

        private string _MoneyMonth6Date;
        public string MoneyMonth6Date { get => _MoneyMonth6Date; set { _MoneyMonth6Date = value; OnPropertyChanged(); } }

        private string _MoneyMonth7Date;
        public string MoneyMonth7Date { get => _MoneyMonth7Date; set { _MoneyMonth7Date = value; OnPropertyChanged(); } }

        private string _MoneyMonth8Date;
        public string MoneyMonth8Date { get => _MoneyMonth8Date; set { _MoneyMonth8Date = value; OnPropertyChanged(); } }

        private string _MoneyMonth9Date;
        public string MoneyMonth9Date { get => _MoneyMonth9Date; set { _MoneyMonth9Date = value; OnPropertyChanged(); } }

        private string _MoneyMonth10Date;
        public string MoneyMonth10Date { get => _MoneyMonth10Date; set { _MoneyMonth10Date = value; OnPropertyChanged(); } }

        private string _MoneyMonth11Date;
        public string MoneyMonth11Date { get => _MoneyMonth11Date; set { _MoneyMonth11Date = value; OnPropertyChanged(); } }

        private string _MoneyMonth12Date;
        public string MoneyMonth12Date { get => _MoneyMonth12Date; set { _MoneyMonth12Date = value; OnPropertyChanged(); } }

        private string _MoneyMonthDisplay;
        public string MoneyMonthDisplay { get => _MoneyMonthDisplay; set { _MoneyMonthDisplay = value; OnPropertyChanged(); } }

        private string _Year;
        public string Year { get => _Year; set { _Year = value; OnPropertyChanged(); } }

        private string _NotPayment;
        public string NotPayment
        {
            get => _NotPayment;
            set
            {
                _NotPayment = value;
                OnPropertyChanged();
            }
        }

        private string _Rent;
        public string Rent { get => _Rent; set { _Rent = value; OnPropertyChanged(); } }
        #endregion

        private ObservableCollection<Object> _Combox = new ObservableCollection<Object>();
        public ObservableCollection<Object> Combox { get => _Combox; set { _Combox = value; OnPropertyChanged(); } }

        private string _ComboxSelect;
        public string ComboxSelect
        {
            get => _ComboxSelect;
            set
            {
                _ComboxSelect = value;
                OnPropertyChanged();
                DateTime dTimePaymentDate = DateTime.Now;
                string yearPaymentDate = dTimePaymentDate.Year.ToString();
                string monthPaymentDate = dTimePaymentDate.Month.ToString();
                string dayPaymentDate = dTimePaymentDate.Day.ToString();
                var monthMoneyCheck = DataProvider.Ins.DB.RentalPaymentDB.Where(y => y.Year == yearPaymentDate && y.HouseNo == HouseNo);
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
                if (ComboxSelect == "1月")
                {
                    MoneyMonthPayment = month1;
                    MoneyMonthDisplay = month1Date;
                    PaymentDate = month1Date;
                }
                else if (ComboxSelect == "2月")
                {
                    MoneyMonthPayment = month2;
                    MoneyMonthDisplay = month2Date;
                    PaymentDate = month2Date;
                }
                else if (ComboxSelect == "3月")
                {
                    MoneyMonthPayment = month3;
                    MoneyMonthDisplay = month3Date;
                    PaymentDate = month3Date;
                }
                else if (ComboxSelect == "4月")
                {
                    MoneyMonthPayment = month4;
                    MoneyMonthDisplay = month4Date;
                    PaymentDate = month4Date;
                }
                else if (ComboxSelect == "5月")
                {
                    MoneyMonthDisplay = month5Date;
                    PaymentDate = month5Date;
                    PaymentDate = month5Date;
                }
                else if (ComboxSelect == "6月")
                {
                    MoneyMonthPayment = month6;
                    MoneyMonthDisplay = month6Date;
                    PaymentDate = month6Date;
                }
                else if (ComboxSelect == "7月")
                {
                    MoneyMonthPayment = month7;
                    MoneyMonthDisplay = month7Date;
                    PaymentDate = month7Date;
                }
                else if (ComboxSelect == "8月")
                {
                    MoneyMonthPayment = month8;
                    MoneyMonthDisplay = month8Date;
                    PaymentDate = month8Date;
                }
                else if (ComboxSelect == "9月")
                {
                    MoneyMonthPayment = month9;
                    MoneyMonthDisplay = month9Date;
                    PaymentDate = month9Date;
                }
                else if (ComboxSelect == "10月")
                {
                    MoneyMonthPayment = month10;
                    MoneyMonthDisplay = month10Date;
                    PaymentDate = month10Date;
                }
                else if (ComboxSelect == "11月")
                {
                    MoneyMonthPayment = month11;
                    MoneyMonthDisplay = month11Date;
                    PaymentDate = month11Date;
                }
                else if (ComboxSelect == "12月")
                {
                    MoneyMonthPayment = month12;
                    MoneyMonthDisplay = month12Date;
                    PaymentDate = month12Date;
                }
            }
        }

        public ICommand RentalPaymentButton { get; set; }

        public ICommand RentalPaymentFixButton { get; set; }

        public ICommand SelectFix { get; set; }

        public int Comfirm = 0;

        public RentalPaymentViewModel()
        {
            RentalContractPaymentSearch selectHouseNo = new RentalContractPaymentSearch();

            int HouseSelect = Int32.Parse(selectHouseNo.House.Text);

            HouseNo = Int32.Parse(selectHouseNo.House.Text);

            Rent = DataProvider.Ins.DB.RentalManagementDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault().Rent;

            if (DataProvider.Ins.DB.NotPaymentDB.Where(x => x.HouseNo == HouseSelect).Count() != 0 && DataProvider.Ins.DB.NotPaymentDB.Where(x => x.HouseNo == HouseSelect).FirstOrDefault().NotPayment != null)
            {
                NotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(x => x.HouseNo == HouseSelect).FirstOrDefault().NotPayment;
            }
            else
            {
                NotPayment = "0";
            }

            SelectFix = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                Combox.Clear();
                DateTime dTimePaymentDate = DateTime.Now;
                string yearPaymentDate = dTimePaymentDate.Year.ToString();
                string monthPaymentDate = dTimePaymentDate.Month.ToString();
                string dayPaymentDate = dTimePaymentDate.Day.ToString();
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

                if (month1 != null)
                {
                    Combox.Add("1月");
                }
                if (month2 != null)
                {
                    Combox.Add("2月");
                }
                if (month3 != null)
                {
                    Combox.Add("3月");
                }
                if (month4 != null)
                {
                    Combox.Add("4月");
                }
                if (month5 != null)
                {
                    Combox.Add("5月");
                }
                if (month6 != null)
                {
                    Combox.Add("6月");
                }
                if (month7 != null)
                {
                    Combox.Add("7月");
                }
                if (month8 != null)
                {
                    Combox.Add("8月");
                }
                if (month9 != null)
                {
                    Combox.Add("9月");
                }
                if (month10 != null)
                {
                    Combox.Add("10月");
                }
                if (month11 != null)
                {
                    Combox.Add("11月");
                }
                if (month12 != null)
                {
                    Combox.Add("12月");
                }

                //Combox.Add(new Month() { MonthNumber = 2, Money = month2, Date = month2Date });
                //Combox.Add(new Month() { MonthNumber = 3, Money = month3, Date = month3Date });
                //Combox.Add(new Month() { MonthNumber = 4, Money = month4, Date = month4Date });
                //Combox.Add(new Month() { MonthNumber = 5, Money = month5, Date = month5Date });
                //Combox.Add(new Month() { MonthNumber = 6, Money = month6, Date = month6Date });
                //Combox.Add(new Month() { MonthNumber = 7, Money = month7, Date = month7Date });
                //Combox.Add(new Month() { MonthNumber = 8, Money = month8, Date = month8Date });
                //Combox.Add(new Month() { MonthNumber = 9, Money = month9, Date = month9Date });
                //Combox.Add(new Month() { MonthNumber = 10, Money = month10, Date = month10Date });
                //Combox.Add(new Month() { MonthNumber = 11, Money = month11, Date = month11Date });
                //Combox.Add(new Month() { MonthNumber = 12, Money = month12, Date = month12Date });
            });

            RentalPaymentButton = new RelayCommand<object>((p) =>
            {
                //if (string.IsNullOrEmpty(HouseNo))
                //    return false;

                //var displayList = DataProvider.Ins.DB.RentalContactDB.Where(x => x.HouseNo == HouseNo);
                //if (displayList == null || displayList.Count() != 0) // if displayList = 0 then HouseNo had in database
                //    return false;

                return true;
            }, (p) =>
            {
                try
                {
                    DateTime dTimePaymentDate = DateTime.Parse(PaymentDate);
                    string yearPaymentDate = dTimePaymentDate.Year.ToString();
                    string monthPaymentDate = dTimePaymentDate.Month.ToString();
                    string dayPaymentDate = dTimePaymentDate.Day.ToString();
                    int yearCheck = DataProvider.Ins.DB.RentalPaymentDB.Where(y => y.Year == yearPaymentDate && y.HouseNo == HouseSelect).Count();
                    var monthMoneyCheck = DataProvider.Ins.DB.RentalPaymentDB.Where(y => y.Year == yearPaymentDate && y.HouseNo == HouseSelect);

                    if (yearCheck == 0)
                    {
                        if (monthPaymentDate == "1")
                        {
                            var AddRentalPayment = new RentalPaymentDB()
                            {
                                HouseNo = HouseSelect,
                                //NotPayment = NotPayment,
                                MoneyMonth1 = MoneyMonthPayment,
                                MoneyMonth1Date = dTimePaymentDate.ToString("yyyy/MM/dd"),
                                Year = yearPaymentDate
                            };
                            DataProvider.Ins.DB.RentalPaymentDB.Add(AddRentalPayment);
                            DataProvider.Ins.DB.SaveChanges();
                            int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                            if (notPaymentCheck == 0)
                            {
                                var AddNotPayment = new NotPaymentDB()
                                {
                                    HouseNo = HouseSelect,
                                    NotPayment = NotPayment,
                                };
                                DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            else
                            {
                                var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                AddNotPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                            }

                            MessageBox.Show("入金されていました。");
                        }
                        else if (monthPaymentDate == "2")
                        {
                            var AddRentalPayment = new RentalPaymentDB()
                            {
                                HouseNo = HouseSelect,
                                //NotPayment = NotPayment,
                                MoneyMonth2 = MoneyMonthPayment,
                                MoneyMonth2Date = dTimePaymentDate.ToString("yyyy/MM/dd"),
                                Year = yearPaymentDate
                            };
                            DataProvider.Ins.DB.RentalPaymentDB.Add(AddRentalPayment);
                            DataProvider.Ins.DB.SaveChanges();

                            int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                            if (notPaymentCheck == 0)
                            {
                                var AddNotPayment = new NotPaymentDB()
                                {
                                    HouseNo = HouseSelect,
                                    NotPayment = NotPayment,
                                };
                                DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            else
                            {
                                var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                AddNotPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                            }

                            MessageBox.Show("入金されていました。");
                        }
                        else if (monthPaymentDate == "3")
                        {
                            var AddRentalPayment = new RentalPaymentDB()
                            {
                                HouseNo = HouseSelect,
                                MoneyMonth3 = MoneyMonthPayment,
                                MoneyMonth3Date = dTimePaymentDate.ToString("yyyy/MM/dd"),
                                Year = yearPaymentDate
                            };
                            DataProvider.Ins.DB.RentalPaymentDB.Add(AddRentalPayment);
                            DataProvider.Ins.DB.SaveChanges();

                            MessageBox.Show("入金されていました。");
                        }
                        else if (monthPaymentDate == "4")
                        {
                            var AddRentalPayment = new RentalPaymentDB()
                            {
                                HouseNo = HouseSelect,
                                //NotPayment = NotPayment,
                                MoneyMonth4 = MoneyMonthPayment,
                                MoneyMonth4Date = dTimePaymentDate.ToString("yyyy/MM/dd"),
                                Year = yearPaymentDate
                            };
                            DataProvider.Ins.DB.RentalPaymentDB.Add(AddRentalPayment);
                            DataProvider.Ins.DB.SaveChanges();

                            int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                            if (notPaymentCheck == 0)
                            {
                                var AddNotPayment = new NotPaymentDB()
                                {
                                    HouseNo = HouseSelect,
                                    NotPayment = NotPayment,
                                };
                                DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            else
                            {
                                var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                AddNotPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                            }

                            MessageBox.Show("入金されていました。");
                        }
                        else if (monthPaymentDate == "5")
                        {
                            var AddRentalPayment = new RentalPaymentDB()
                            {
                                HouseNo = HouseSelect,
                                //NotPayment = NotPayment,
                                MoneyMonth5 = MoneyMonthPayment,
                                MoneyMonth5Date = dTimePaymentDate.ToString("yyyy/MM/dd"),
                                Year = yearPaymentDate
                            };
                            DataProvider.Ins.DB.RentalPaymentDB.Add(AddRentalPayment);
                            DataProvider.Ins.DB.SaveChanges();

                            MessageBox.Show("入金されていました。");
                        }
                        else if (monthPaymentDate == "6")
                        {
                            var AddRentalPayment = new RentalPaymentDB()
                            {
                                HouseNo = HouseSelect,
                                MoneyMonth6 = MoneyMonthPayment,
                                MoneyMonth6Date = dTimePaymentDate.ToString("yyyy/MM/dd"),
                                Year = yearPaymentDate
                            };
                            DataProvider.Ins.DB.RentalPaymentDB.Add(AddRentalPayment);
                            DataProvider.Ins.DB.SaveChanges();

                            int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                            if (notPaymentCheck == 0)
                            {
                                var AddNotPayment = new NotPaymentDB()
                                {
                                    HouseNo = HouseSelect,
                                    NotPayment = NotPayment,
                                };
                                DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            else
                            {
                                var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                AddNotPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                            }

                            MessageBox.Show("入金されていました。");
                        }
                        else if (monthPaymentDate == "7")
                        {
                            var AddRentalPayment = new RentalPaymentDB()
                            {
                                HouseNo = HouseSelect,
                                //NotPayment = NotPayment,
                                MoneyMonth7 = MoneyMonthPayment,
                                MoneyMonth7Date = dTimePaymentDate.ToString("yyyy/MM/dd"),
                                Year = yearPaymentDate
                            };
                            DataProvider.Ins.DB.RentalPaymentDB.Add(AddRentalPayment);
                            DataProvider.Ins.DB.SaveChanges();

                            int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                            if (notPaymentCheck == 0)
                            {
                                var AddNotPayment = new NotPaymentDB()
                                {
                                    HouseNo = HouseSelect,
                                    NotPayment = NotPayment,
                                };
                                DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            else
                            {
                                var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                AddNotPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                            }

                            MessageBox.Show("入金されていました。");
                        }
                        else if (monthPaymentDate == "8")
                        {
                            var AddRentalPayment = new RentalPaymentDB()
                            {
                                HouseNo = HouseSelect,
                                //NotPayment = NotPayment,
                                MoneyMonth8 = MoneyMonthPayment,
                                MoneyMonth8Date = dTimePaymentDate.ToString("yyyy/MM/dd"),
                                Year = yearPaymentDate
                            };
                            DataProvider.Ins.DB.RentalPaymentDB.Add(AddRentalPayment);
                            DataProvider.Ins.DB.SaveChanges();

                            int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                            if (notPaymentCheck == 0)
                            {
                                var AddNotPayment = new NotPaymentDB()
                                {
                                    HouseNo = HouseSelect,
                                    NotPayment = NotPayment,
                                };
                                DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            else
                            {
                                var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                AddNotPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                            }

                            MessageBox.Show("入金されていました。");
                        }
                        else if (monthPaymentDate == "9")
                        {
                            var AddRentalPayment = new RentalPaymentDB()
                            {
                                HouseNo = HouseSelect,
                                //NotPayment = NotPayment,
                                MoneyMonth9 = MoneyMonthPayment,
                                MoneyMonth9Date = dTimePaymentDate.ToString("yyyy/MM/dd"),
                                Year = yearPaymentDate
                            };
                            DataProvider.Ins.DB.RentalPaymentDB.Add(AddRentalPayment);
                            DataProvider.Ins.DB.SaveChanges();

                            int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                            if (notPaymentCheck == 0)
                            {
                                var AddNotPayment = new NotPaymentDB()
                                {
                                    HouseNo = HouseSelect,
                                    NotPayment = NotPayment,
                                };
                                DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            else
                            {
                                var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                AddNotPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                            }

                            MessageBox.Show("入金されていました。");
                        }
                        else if (monthPaymentDate == "10")
                        {
                            var AddRentalPayment = new RentalPaymentDB()
                            {
                                HouseNo = HouseSelect,
                                //NotPayment = NotPayment,
                                MoneyMonth10 = MoneyMonthPayment,
                                MoneyMonth10Date = dTimePaymentDate.ToString("yyyy/MM/dd"),
                                Year = yearPaymentDate
                            };
                            DataProvider.Ins.DB.RentalPaymentDB.Add(AddRentalPayment);
                            DataProvider.Ins.DB.SaveChanges();

                            int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                            if (notPaymentCheck == 0)
                            {
                                var AddNotPayment = new NotPaymentDB()
                                {
                                    HouseNo = HouseSelect,
                                    NotPayment = NotPayment,
                                };
                                DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            else
                            {
                                var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                AddNotPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                            }

                            MessageBox.Show("入金されていました。");
                        }
                        else if (monthPaymentDate == "11")
                        {
                            var AddRentalPayment = new RentalPaymentDB()
                            {
                                HouseNo = HouseSelect,
                                //NotPayment = NotPayment,
                                MoneyMonth11 = MoneyMonthPayment,
                                MoneyMonth11Date = dTimePaymentDate.ToString("yyyy/MM/dd"),
                                Year = yearPaymentDate
                            };
                            DataProvider.Ins.DB.RentalPaymentDB.Add(AddRentalPayment);
                            DataProvider.Ins.DB.SaveChanges();

                            int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                            if (notPaymentCheck == 0)
                            {
                                var AddNotPayment = new NotPaymentDB()
                                {
                                    HouseNo = HouseSelect,
                                    NotPayment = NotPayment,
                                };
                                DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            else
                            {
                                var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                AddNotPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                            }

                            MessageBox.Show("入金されていました。");
                        }
                        else if (monthPaymentDate == "12")
                        {
                            var AddRentalPayment = new RentalPaymentDB()
                            {
                                HouseNo = HouseSelect,
                                //NotPayment = NotPayment,
                                MoneyMonth12 = MoneyMonthPayment,
                                MoneyMonth12Date = dTimePaymentDate.ToString("yyyy/MM/dd"),
                                Year = yearPaymentDate
                            };
                            DataProvider.Ins.DB.RentalPaymentDB.Add(AddRentalPayment);
                            DataProvider.Ins.DB.SaveChanges();

                            int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                            if (notPaymentCheck == 0)
                            {
                                var AddNotPayment = new NotPaymentDB()
                                {
                                    HouseNo = HouseSelect,
                                    NotPayment = NotPayment,
                                };
                                DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            else
                            {
                                var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                AddNotPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                            }

                            MessageBox.Show("入金されていました。");
                        }
                    }
                    else if (yearCheck != 0)
                    {
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

                        if (monthPaymentDate == "1")
                        {
                            if (month1 == null)
                            {
                                var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                                AddRentalPayment.MoneyMonth1 = MoneyMonthPayment;
                                //AddRentalPayment.NotPayment = NotPayment;
                                AddRentalPayment.MoneyMonth1Date = dTimePaymentDate.ToString("yyyy/MM/dd");
                                DataProvider.Ins.DB.SaveChanges();
                                int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                                if (notPaymentCheck == 0)
                                {
                                    var AddNotPayment = new NotPaymentDB()
                                    {
                                        HouseNo = HouseSelect,
                                        NotPayment = NotPayment,
                                    };
                                    DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                                else
                                {
                                    var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                    AddNotPayment.NotPayment = NotPayment;
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                                MessageBox.Show("入金されていました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else if (month1 != null)
                            {
                                if (DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).Count() != 0)
                                {
                                    string MonthPaymentSQL = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault().MoneyMonth1;
                                    int MoneyMonthPaymentDB = Int32.Parse(MonthPaymentSQL);
                                    int MoneyMonthPaymentWD = Int32.Parse(MoneyMonthPayment);
                                    var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                                    AddRentalPayment.MoneyMonth1 = (MoneyMonthPaymentDB + MoneyMonthPaymentWD).ToString();
                                    AddRentalPayment.MoneyMonth1Date = dTimePaymentDate.ToString("yyyy/MM/dd");
                                    var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                    AddNotPayment.NotPayment = NotPayment;
                                    DataProvider.Ins.DB.SaveChanges();
                                    MessageBox.Show("入金されていました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                        }

                        if (monthPaymentDate == "2")
                        {
                            if (month2 == null)
                            {
                                var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                                AddRentalPayment.MoneyMonth2 = MoneyMonthPayment;
                                AddRentalPayment.MoneyMonth2Date = dTimePaymentDate.ToString("yyyy/MM/dd");
                                //AddRentalPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                                int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                                if (notPaymentCheck == 0)
                                {
                                    var AddNotPayment = new NotPaymentDB()
                                    {
                                        HouseNo = HouseSelect,
                                        NotPayment = NotPayment,
                                    };
                                    DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                                else
                                {
                                    var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                    AddNotPayment.NotPayment = NotPayment;
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                                MessageBox.Show("入金されていました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else if (month2 != null)
                            {
                                if (DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).Count() != 0)
                                {
                                    string MonthPaymentSQL = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault().MoneyMonth2;
                                    int MoneyMonthPaymentDB = Int32.Parse(MonthPaymentSQL);
                                    int MoneyMonthPaymentWD = Int32.Parse(MoneyMonthPayment);
                                    var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                                    AddRentalPayment.MoneyMonth2 = (MoneyMonthPaymentDB + MoneyMonthPaymentWD).ToString();
                                    AddRentalPayment.MoneyMonth2Date = dTimePaymentDate.ToString("yyyy/MM/dd");
                                    var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                    AddNotPayment.NotPayment = NotPayment;
                                    DataProvider.Ins.DB.SaveChanges();
                                    MessageBox.Show("入金されていました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                        }

                        if (monthPaymentDate == "3")
                        {
                            if (month3 == null)
                            {
                                var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                                AddRentalPayment.MoneyMonth3 = MoneyMonthPayment;
                                AddRentalPayment.MoneyMonth3Date = dTimePaymentDate.ToString("yyyy/MM/dd");
                                //AddRentalPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                                int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                                if (notPaymentCheck == 0)
                                {
                                    var AddNotPayment = new NotPaymentDB()
                                    {
                                        HouseNo = HouseSelect,
                                        NotPayment = NotPayment,
                                    };
                                    DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                                else
                                {
                                    var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                    AddNotPayment.NotPayment = NotPayment;
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                                MessageBox.Show("入金されていました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else if (month3 != null)
                            {
                                if (DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).Count() != 0)
                                {
                                    string MonthPaymentSQL = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault().MoneyMonth3;
                                    int MoneyMonthPaymentDB = Int32.Parse(MonthPaymentSQL);
                                    int MoneyMonthPaymentWD = Int32.Parse(MoneyMonthPayment);
                                    var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                                    AddRentalPayment.MoneyMonth3 = (MoneyMonthPaymentDB + MoneyMonthPaymentWD).ToString();
                                    AddRentalPayment.MoneyMonth3Date = dTimePaymentDate.ToString("yyyy/MM/dd");
                                    var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                    AddNotPayment.NotPayment = NotPayment;
                                    DataProvider.Ins.DB.SaveChanges();
                                    MessageBox.Show("入金されていました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                        }

                        if (monthPaymentDate == "4")
                        {
                            if (month4 == null)
                            {
                                var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                                AddRentalPayment.MoneyMonth4 = MoneyMonthPayment;
                                AddRentalPayment.MoneyMonth4Date = dTimePaymentDate.ToString("yyyy/MM/dd");
                                //AddRentalPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                                int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                                if (notPaymentCheck == 0)
                                {
                                    var AddNotPayment = new NotPaymentDB()
                                    {
                                        HouseNo = HouseSelect,
                                        NotPayment = NotPayment,
                                    };
                                    DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                                else
                                {
                                    var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                    AddNotPayment.NotPayment = NotPayment;
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                                MessageBox.Show("入金されていました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else if (month4 != null)
                            {
                                if (DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).Count() != 0)
                                {
                                    string MonthPaymentSQL = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault().MoneyMonth4;
                                    int MoneyMonthPaymentDB = Int32.Parse(MonthPaymentSQL);
                                    int MoneyMonthPaymentWD = Int32.Parse(MoneyMonthPayment);
                                    var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                                    AddRentalPayment.MoneyMonth4 = (MoneyMonthPaymentDB + MoneyMonthPaymentWD).ToString();
                                    AddRentalPayment.MoneyMonth4Date = dTimePaymentDate.ToString("yyyy/MM/dd");
                                    var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                    AddNotPayment.NotPayment = NotPayment;
                                    DataProvider.Ins.DB.SaveChanges();
                                    MessageBox.Show("入金されていました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                        }

                        if (monthPaymentDate == "5")
                        {
                            if (month5 == null)
                            {
                                var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                                AddRentalPayment.MoneyMonth5 = MoneyMonthPayment;
                                AddRentalPayment.MoneyMonth5Date = dTimePaymentDate.ToString("yyyy/MM/dd");
                                //AddRentalPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                                int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                                if (notPaymentCheck == 0)
                                {
                                    var AddNotPayment = new NotPaymentDB()
                                    {
                                        HouseNo = HouseSelect,
                                        NotPayment = NotPayment,
                                    };
                                    DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                                else
                                {
                                    var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                    AddNotPayment.NotPayment = NotPayment;
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                                MessageBox.Show("入金されていました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else if (month5 != null)
                            {
                                if (DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).Count() != 0)
                                {
                                    string MonthPaymentSQL = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault().MoneyMonth5;
                                    int MoneyMonthPaymentDB = Int32.Parse(MonthPaymentSQL);
                                    int MoneyMonthPaymentWD = Int32.Parse(MoneyMonthPayment);
                                    var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                                    AddRentalPayment.MoneyMonth5 = (MoneyMonthPaymentDB + MoneyMonthPaymentWD).ToString();
                                    AddRentalPayment.MoneyMonth5Date = dTimePaymentDate.ToString("yyyy/MM/dd");
                                    var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                    AddNotPayment.NotPayment = NotPayment;
                                    DataProvider.Ins.DB.SaveChanges();
                                    MessageBox.Show("入金されていました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                        }

                        if (monthPaymentDate == "6")
                        {
                            if (month6 == null)
                            {
                                var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                                AddRentalPayment.MoneyMonth6 = MoneyMonthPayment;
                                AddRentalPayment.MoneyMonth6Date = dTimePaymentDate.ToString("yyyy/MM/dd");
                                //AddRentalPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                                int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                                if (notPaymentCheck == 0)
                                {
                                    var AddNotPayment = new NotPaymentDB()
                                    {
                                        HouseNo = HouseSelect,
                                        NotPayment = NotPayment,
                                    };
                                    DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                                else
                                {
                                    var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                    AddNotPayment.NotPayment = NotPayment;
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                                MessageBox.Show("入金されていました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else if (month6 != null)
                            {
                                if (DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).Count() != 0)
                                {
                                    string MonthPaymentSQL = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault().MoneyMonth6;
                                    int MoneyMonthPaymentDB = Int32.Parse(MonthPaymentSQL);
                                    int MoneyMonthPaymentWD = Int32.Parse(MoneyMonthPayment);
                                    var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                                    AddRentalPayment.MoneyMonth6 = (MoneyMonthPaymentDB + MoneyMonthPaymentWD).ToString();
                                    AddRentalPayment.MoneyMonth6Date = dTimePaymentDate.ToString("yyyy/MM/dd");
                                    var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                    AddNotPayment.NotPayment = NotPayment;
                                    DataProvider.Ins.DB.SaveChanges();
                                    MessageBox.Show("入金されていました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                        }

                        if (monthPaymentDate == "7")
                        {
                            if (month7 == null)
                            {
                                var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                                AddRentalPayment.MoneyMonth7 = MoneyMonthPayment;
                                AddRentalPayment.MoneyMonth7Date = dTimePaymentDate.ToString("yyyy/MM/dd");
                                //AddRentalPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                                int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                                if (notPaymentCheck == 0)
                                {
                                    var AddNotPayment = new NotPaymentDB()
                                    {
                                        HouseNo = HouseSelect,
                                        NotPayment = NotPayment,
                                    };
                                    DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                                else
                                {
                                    var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                    AddNotPayment.NotPayment = NotPayment;
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                                MessageBox.Show("入金されていました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else if (month7 != null)
                            {
                                if (DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).Count() != 0)
                                {
                                    string MonthPaymentSQL = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault().MoneyMonth7;
                                    int MoneyMonthPaymentDB = Int32.Parse(MonthPaymentSQL);
                                    int MoneyMonthPaymentWD = Int32.Parse(MoneyMonthPayment);
                                    var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                                    AddRentalPayment.MoneyMonth7 = (MoneyMonthPaymentDB + MoneyMonthPaymentWD).ToString();
                                    AddRentalPayment.MoneyMonth7Date = dTimePaymentDate.ToString("yyyy/MM/dd");
                                    var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                    AddNotPayment.NotPayment = NotPayment;
                                    DataProvider.Ins.DB.SaveChanges();
                                    MessageBox.Show("入金されていました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                        }

                        if (monthPaymentDate == "8")
                        {
                            if (month8 == null)
                            {
                                var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                                AddRentalPayment.MoneyMonth8 = MoneyMonthPayment;
                                AddRentalPayment.MoneyMonth8Date = dTimePaymentDate.ToString("yyyy/MM/dd");
                                //AddRentalPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                                int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                                if (notPaymentCheck == 0)
                                {
                                    var AddNotPayment = new NotPaymentDB()
                                    {
                                        HouseNo = HouseSelect,
                                        NotPayment = NotPayment,
                                    };
                                    DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                                else
                                {
                                    var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                    AddNotPayment.NotPayment = NotPayment;
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                                MessageBox.Show("入金されていました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else if (month8 != null)
                            {
                                if (DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).Count() != 0)
                                {
                                    string MonthPaymentSQL = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault().MoneyMonth8;
                                    int MoneyMonthPaymentDB = Int32.Parse(MonthPaymentSQL);
                                    int MoneyMonthPaymentWD = Int32.Parse(MoneyMonthPayment);
                                    var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                                    AddRentalPayment.MoneyMonth8 = (MoneyMonthPaymentDB + MoneyMonthPaymentWD).ToString();
                                    AddRentalPayment.MoneyMonth8Date = dTimePaymentDate.ToString("yyyy/MM/dd");
                                    var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                    AddNotPayment.NotPayment = NotPayment;
                                    DataProvider.Ins.DB.SaveChanges();
                                    MessageBox.Show("入金されていました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                        }

                        if (monthPaymentDate == "9")
                        {
                            if (month9 == null)
                            {
                                var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                                AddRentalPayment.MoneyMonth9 = MoneyMonthPayment;
                                AddRentalPayment.MoneyMonth9Date = dTimePaymentDate.ToString("yyyy/MM/dd");
                                //AddRentalPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                                int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                                if (notPaymentCheck == 0)
                                {
                                    var AddNotPayment = new NotPaymentDB()
                                    {
                                        HouseNo = HouseSelect,
                                        NotPayment = NotPayment,
                                    };
                                    DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                                else
                                {
                                    var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                    AddNotPayment.NotPayment = NotPayment;
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                                MessageBox.Show("入金されていました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else if (month9 != null)
                            {
                                if (DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).Count() != 0)
                                {
                                    string MonthPaymentSQL = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault().MoneyMonth9;
                                    int MoneyMonthPaymentDB = Int32.Parse(MonthPaymentSQL);
                                    int MoneyMonthPaymentWD = Int32.Parse(MoneyMonthPayment);
                                    var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                                    AddRentalPayment.MoneyMonth9 = (MoneyMonthPaymentDB + MoneyMonthPaymentWD).ToString();
                                    AddRentalPayment.MoneyMonth9Date = dTimePaymentDate.ToString("yyyy/MM/dd");
                                    var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                    AddNotPayment.NotPayment = NotPayment;
                                    DataProvider.Ins.DB.SaveChanges();
                                    MessageBox.Show("入金されていました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                        }

                        if (monthPaymentDate == "10")
                        {
                            if (month10 == null)
                            {
                                var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                                //AddRentalPayment.MoneyMonth10 = MoneyMonthPayment;
                                AddRentalPayment.MoneyMonth10 = MoneyMonthPayment;
                                AddRentalPayment.MoneyMonth10Date = dTimePaymentDate.ToString("yyyy/MM/dd");
                                DataProvider.Ins.DB.SaveChanges();
                                int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                                if (notPaymentCheck == 0)
                                {
                                    var AddNotPayment = new NotPaymentDB()
                                    {
                                        HouseNo = HouseSelect,
                                        NotPayment = NotPayment,
                                    };
                                    DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                                else
                                {
                                    var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                    AddNotPayment.NotPayment = NotPayment;
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                                MessageBox.Show("入金されていました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else if (month10 != null)
                            {
                                if (DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).Count() != 0)
                                {
                                    string MonthPaymentSQL = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault().MoneyMonth10;
                                    int MoneyMonthPaymentDB = Int32.Parse(MonthPaymentSQL);
                                    int MoneyMonthPaymentWD = Int32.Parse(MoneyMonthPayment);
                                    var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                                    AddRentalPayment.MoneyMonth10 = (MoneyMonthPaymentDB + MoneyMonthPaymentWD).ToString();
                                    AddRentalPayment.MoneyMonth10Date = dTimePaymentDate.ToString("yyyy/MM/dd");
                                    var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                    AddNotPayment.NotPayment = NotPayment;
                                    DataProvider.Ins.DB.SaveChanges();
                                    MessageBox.Show("入金されていました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                        }

                        if (monthPaymentDate == "11")
                        {
                            if (month11 == null)
                            {
                                var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                                //AddRentalPayment.MoneyMonth11 = MoneyMonthPayment;
                                AddRentalPayment.MoneyMonth11 = MoneyMonthPayment;
                                AddRentalPayment.MoneyMonth11Date = dTimePaymentDate.ToString("yyyy/MM/dd");
                                DataProvider.Ins.DB.SaveChanges();
                                int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                                if (notPaymentCheck == 0)
                                {
                                    var AddNotPayment = new NotPaymentDB()
                                    {
                                        HouseNo = HouseSelect,
                                        NotPayment = NotPayment,
                                    };
                                    DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                                else
                                {
                                    var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                    AddNotPayment.NotPayment = NotPayment;
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                                MessageBox.Show("入金されていました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else if (month11 != null)
                            {
                                if (DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).Count() != 0)
                                {
                                    string MonthPaymentSQL = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault().MoneyMonth11;
                                    int MoneyMonthPaymentDB = Int32.Parse(MonthPaymentSQL);
                                    int MoneyMonthPaymentWD = Int32.Parse(MoneyMonthPayment);
                                    var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                                    AddRentalPayment.MoneyMonth11 = (MoneyMonthPaymentDB + MoneyMonthPaymentWD).ToString();
                                    AddRentalPayment.MoneyMonth11Date = dTimePaymentDate.ToString("yyyy/MM/dd");
                                    var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                    AddNotPayment.NotPayment = NotPayment;
                                    DataProvider.Ins.DB.SaveChanges();
                                    MessageBox.Show("入金されていました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                        }

                        if (monthPaymentDate == "12")
                        {
                            if (month12 == null)
                            {
                                var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                                //AddRentalPayment.MoneyMonth12 = MoneyMonthPayment;
                                AddRentalPayment.MoneyMonth12 = MoneyMonthPayment;
                                AddRentalPayment.MoneyMonth12Date = dTimePaymentDate.ToString("yyyy/MM/dd");
                                DataProvider.Ins.DB.SaveChanges();
                                int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                                if (notPaymentCheck == 0)
                                {
                                    var AddNotPayment = new NotPaymentDB()
                                    {
                                        HouseNo = HouseSelect,
                                        NotPayment = NotPayment,
                                    };
                                    DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                                else
                                {
                                    var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                    AddNotPayment.NotPayment = NotPayment;
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                                MessageBox.Show("入金されていました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else if (month12 != null)
                            {
                                if (DataProvider.Ins.DB.RentalPaymentDB.Where(d => d.HouseNo == HouseNo).Count() != 0)
                                {
                                    string MonthPaymentSQL = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault().MoneyMonth12;
                                    int MoneyMonthPaymentDB = Int32.Parse(MonthPaymentSQL);
                                    int MoneyMonthPaymentWD = Int32.Parse(MoneyMonthPayment);
                                    var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                                    AddRentalPayment.MoneyMonth12 = (MoneyMonthPaymentDB + MoneyMonthPaymentWD).ToString();
                                    AddRentalPayment.MoneyMonth12Date = dTimePaymentDate.ToString("yyyy/MM/dd");
                                    var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                    AddNotPayment.NotPayment = NotPayment;
                                    MessageBox.Show("入金されていました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                                    DataProvider.Ins.DB.SaveChanges();
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {

                    MessageBox.Show("入力してください。", "入力", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            RentalPaymentFixButton = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                DateTime dTimePaymentDate = DateTime.Parse(PaymentDate);
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

                if (yearCheck != 0)
                {
                    if (monthPaymentDate == "1")
                    {
                        if (month1 != null)
                        {
                            var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                            AddRentalPayment.MoneyMonth1 = MoneyMonthPayment;
                            //AddRentalPayment.NotPayment = NotPayment;
                            DataProvider.Ins.DB.SaveChanges();
                            int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                            if (notPaymentCheck == 0)
                            {
                                var AddNotPayment = new NotPaymentDB()
                                {
                                    HouseNo = HouseSelect,
                                    NotPayment = NotPayment,
                                };
                                DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            else
                            {
                                var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                AddNotPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            MessageBox.Show("入金を修正しました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (month1 == null)
                        {
                            MessageBox.Show("物件がないので入金ボータンを押してください！", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }

                    if (monthPaymentDate == "2")
                    {
                        if (month2 != null)
                        {
                            var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                            AddRentalPayment.MoneyMonth2 = MoneyMonthPayment;
                            //AddRentalPayment.NotPayment = NotPayment;
                            DataProvider.Ins.DB.SaveChanges();
                            int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                            if (notPaymentCheck == 0)
                            {
                                var AddNotPayment = new NotPaymentDB()
                                {
                                    HouseNo = HouseSelect,
                                    NotPayment = NotPayment,
                                };
                                DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            else
                            {
                                var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                AddNotPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                            }

                            MessageBox.Show("入金を修正しました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (month2 == null)
                        {
                            MessageBox.Show("物件がないので入金ボータンを押してください！", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }

                    if (monthPaymentDate == "3")
                    {
                        if (month3 != null)
                        {
                            var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                            AddRentalPayment.MoneyMonth3 = MoneyMonthPayment;
                            //AddRentalPayment.NotPayment = NotPayment;
                            DataProvider.Ins.DB.SaveChanges();
                            int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                            if (notPaymentCheck == 0)
                            {
                                var AddNotPayment = new NotPaymentDB()
                                {
                                    HouseNo = HouseSelect,
                                    NotPayment = NotPayment,
                                };
                                DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            else
                            {
                                var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                AddNotPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            MessageBox.Show("入金を修正しました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (month3 == null)
                        {
                            MessageBox.Show("物件がないので入金ボータンを押してください！", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }

                    if (monthPaymentDate == "4")
                    {
                        if (month4 != null)
                        {
                            var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                            AddRentalPayment.MoneyMonth4 = MoneyMonthPayment;
                            //AddRentalPayment.NotPayment = NotPayment;
                            DataProvider.Ins.DB.SaveChanges();
                            int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                            if (notPaymentCheck == 0)
                            {
                                var AddNotPayment = new NotPaymentDB()
                                {
                                    HouseNo = HouseSelect,
                                    NotPayment = NotPayment,
                                };
                                DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            else
                            {
                                var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                AddNotPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            MessageBox.Show("入金を修正しました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (month4 != null)
                        {
                            MessageBox.Show("物件がないので入金ボータンを押してください！", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }

                    if (monthPaymentDate == "5")
                    {
                        if (month5 != null)
                        {
                            var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                            AddRentalPayment.MoneyMonth5 = MoneyMonthPayment;
                            //AddRentalPayment.NotPayment = NotPayment;
                            DataProvider.Ins.DB.SaveChanges();
                            int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                            if (notPaymentCheck == 0)
                            {
                                var AddNotPayment = new NotPaymentDB()
                                {
                                    HouseNo = HouseSelect,
                                    NotPayment = NotPayment,
                                };
                                DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            else
                            {
                                var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                AddNotPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            MessageBox.Show("入金を修正しました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (month5 == null)
                        {
                            MessageBox.Show("物件がないので入金ボータンを押してください！", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }

                    if (monthPaymentDate == "6")
                    {
                        if (month6 != null)
                        {
                            var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                            AddRentalPayment.MoneyMonth6 = MoneyMonthPayment;
                            //AddRentalPayment.NotPayment = NotPayment;
                            DataProvider.Ins.DB.SaveChanges();
                            int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                            if (notPaymentCheck == 0)
                            {
                                var AddNotPayment = new NotPaymentDB()
                                {
                                    HouseNo = HouseSelect,
                                    NotPayment = NotPayment,
                                };
                                DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            else
                            {
                                var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                AddNotPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            MessageBox.Show("入金を修正しました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (month6 == null)
                        {
                            MessageBox.Show("物件がないので入金ボータンを押してください！", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }

                    if (monthPaymentDate == "7")
                    {
                        if (month7 != null)
                        {
                            var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                            AddRentalPayment.MoneyMonth7 = MoneyMonthPayment;
                            //AddRentalPayment.NotPayment = NotPayment;
                            DataProvider.Ins.DB.SaveChanges();
                            int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                            if (notPaymentCheck == 0)
                            {
                                var AddNotPayment = new NotPaymentDB()
                                {
                                    HouseNo = HouseSelect,
                                    NotPayment = NotPayment,
                                };
                                DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            else
                            {
                                var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                AddNotPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            MessageBox.Show("入金を修正しました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (month7 == null)
                        {
                            MessageBox.Show("物件がないので入金ボータンを押してください！", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }

                    if (monthPaymentDate == "8")
                    {
                        if (month8 != null)
                        {
                            var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                            AddRentalPayment.MoneyMonth8 = MoneyMonthPayment;
                            //AddRentalPayment.NotPayment = NotPayment;
                            DataProvider.Ins.DB.SaveChanges();
                            int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                            if (notPaymentCheck == 0)
                            {
                                var AddNotPayment = new NotPaymentDB()
                                {
                                    HouseNo = HouseSelect,
                                    NotPayment = NotPayment,
                                };
                                DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            else
                            {
                                var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                AddNotPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            MessageBox.Show("入金を修正しました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (month8 == null)
                        {
                            MessageBox.Show("物件がないので入金ボータンを押してください！", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }

                    if (monthPaymentDate == "9")
                    {
                        if (month9 != null)
                        {
                            var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                            AddRentalPayment.MoneyMonth9 = MoneyMonthPayment;
                            //AddRentalPayment.NotPayment = NotPayment;
                            DataProvider.Ins.DB.SaveChanges();
                            int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                            if (notPaymentCheck == 0)
                            {
                                var AddNotPayment = new NotPaymentDB()
                                {
                                    HouseNo = HouseSelect,
                                    NotPayment = NotPayment,
                                };
                                DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            else
                            {
                                var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                AddNotPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            MessageBox.Show("入金を修正しました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (month9 == null)
                        {
                            MessageBox.Show("物件がないので入金ボータンを押してください！", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }

                    if (monthPaymentDate == "10")
                    {
                        if (month10 != null)
                        {
                            var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                            AddRentalPayment.MoneyMonth10 = MoneyMonthPayment;
                            //AddRentalPayment.NotPayment = NotPayment;
                            DataProvider.Ins.DB.SaveChanges();
                            int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                            if (notPaymentCheck == 0)
                            {
                                var AddNotPayment = new NotPaymentDB()
                                {
                                    HouseNo = HouseSelect,
                                    NotPayment = NotPayment,
                                };
                                DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            else
                            {
                                var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                AddNotPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            MessageBox.Show("入金を修正しました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (month10 == null)
                        {
                            MessageBox.Show("物件がないので入金ボータンを押してください！", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }

                    if (monthPaymentDate == "11")
                    {
                        if (month11 != null)
                        {
                            var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                            AddRentalPayment.MoneyMonth11 = MoneyMonthPayment;
                            //AddRentalPayment.NotPayment = NotPayment;
                            DataProvider.Ins.DB.SaveChanges();
                            int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                            if (notPaymentCheck == 0)
                            {
                                var AddNotPayment = new NotPaymentDB()
                                {
                                    HouseNo = HouseSelect,
                                    NotPayment = NotPayment,
                                };
                                DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            else
                            {
                                var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                AddNotPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            MessageBox.Show("入金を修正しました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (month11 == null)
                        {
                            MessageBox.Show("物件がないので入金ボータンを押してください！", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }

                    if (monthPaymentDate == "12")
                    {
                        if (month12 != null)
                        {
                            var AddRentalPayment = DataProvider.Ins.DB.RentalPaymentDB.Where(hno => hno.HouseNo == HouseSelect && hno.Year == yearPaymentDate).SingleOrDefault();
                            AddRentalPayment.MoneyMonth12 = MoneyMonthPayment;
                            //AddRentalPayment.NotPayment = NotPayment;
                            DataProvider.Ins.DB.SaveChanges();
                            int notPaymentCheck = DataProvider.Ins.DB.NotPaymentDB.Where(y => y.HouseNo == HouseSelect).Count();
                            if (notPaymentCheck == 0)
                            {
                                var AddNotPayment = new NotPaymentDB()
                                {
                                    HouseNo = HouseSelect,
                                    NotPayment = NotPayment,
                                };
                                DataProvider.Ins.DB.NotPaymentDB.Add(AddNotPayment);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            else
                            {
                                var AddNotPayment = DataProvider.Ins.DB.NotPaymentDB.Where(hno => hno.HouseNo == HouseSelect).SingleOrDefault();
                                AddNotPayment.NotPayment = NotPayment;
                                DataProvider.Ins.DB.SaveChanges();
                            }
                            MessageBox.Show("入金を修正しました。", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (month12 == null)
                        {
                            MessageBox.Show("物件がないので入金ボータンを押してください！", "Comfirm", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
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