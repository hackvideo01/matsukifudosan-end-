using matsukifudousan.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace matsukifudousan.ViewModel
{
    public class RentalContractPaymentSearchViewModel : BaseViewModel
    {
        private Nullable<int> _HouseNo;
        public Nullable<int> HouseNo { get => _HouseNo; set { _HouseNo = value; OnPropertyChanged(); } }

        private string _PaymentYear = DateTime.Now.ToString();
        public string PaymentYear { get => _PaymentYear; set { _PaymentYear = value; OnPropertyChanged(); } }

        private string _Search;
        public string Search { get => _Search; set { _Search = value; OnPropertyChanged(); } }

        private ObservableCollection<object> _List;
        public ObservableCollection<object> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private string _ComboxStatus;
        public string ComboxStatus { get => _ComboxStatus; set { _ComboxStatus = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _ComboxStatusChoose = new ObservableCollection<Object>();
        public ObservableCollection<Object> ComboxStatusChoose { get => _ComboxStatusChoose; set { _ComboxStatusChoose = value; OnPropertyChanged(); } }

        private string _ComboxStatusDate;
        public string ComboxStatusDate { get => _ComboxStatusDate; set { _ComboxStatusDate = value; OnPropertyChanged(); } }

        private ObservableCollection<Object> _ComboxDateList = new ObservableCollection<Object>();
        public ObservableCollection<Object> ComboxDateList { get => _ComboxDateList; set { _ComboxDateList = value; OnPropertyChanged(); } }

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
                    HouseNo = Int32.Parse(jsonObj["HouseNo"].ToString());
                }
            }
        }

        //private string _SelectedItem;
        //public string SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); } }

        public ICommand RentalPaymentInputWD { get; set; }

        public ICommand FreshList { get; set; }

        public ICommand FreshStatus { get; set; }

        public ICommand SearchButton { get; set; }

        public ICommand PaymentListPrintsButton { get; set; }

        public ICommand NotPaymentButton { get; set; }

        public RentalContractPaymentSearchViewModel()
        {

            DateTime dTimePaymentDate = DateTime.Parse(PaymentYear);
            string yearPaymentDate = dTimePaymentDate.Year.ToString();
            string monthPaymentDate = dTimePaymentDate.Month.ToString();
            string dayPaymentDate = dTimePaymentDate.Day.ToString();

            var duplicate = "";
            var Years = DataProvider.Ins.DB.RentalPaymentDB.OrderByDescending(d => d.Year).Where(y => y.Year != "").Select(x => x.Year).Distinct();
            foreach (var item in Years)
            {
                if (duplicate != item)
                {
                    ComboxDateList.Add(item);
                }

                duplicate = item;
            }
            RentalPaymentInputWD = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (HouseNo != 0 && HouseNo != null)
                {
                    RentalPaymentInput openWindowDetails = new RentalPaymentInput(); openWindowDetails.ShowDialog();
                    ComboxDateList.Clear();
                    var duplicate1 = "";
                    var Years1 = DataProvider.Ins.DB.RentalPaymentDB.OrderByDescending(d => d.Year).Where(y => y.Year != "").Select(x => x.Year).Distinct();
                    foreach (var item in Years1)
                    {
                        if (duplicate1 != item)
                        {
                            ComboxDateList.Add(item);
                        }

                        duplicate1 = item;
                    }
                }
                else
                {
                    MessageBox.Show("物件を選択してください。", "選択", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            });

            //var query = from s in DataProvider.Ins.DB.RentalManagementDB
            //            join p in DataProvider.Ins.DB.RentalPaymentDB
            //                on s.HouseNo equals p.HouseNo
            //            join sa in DataProvider.Ins.DB.RentalContactDB
            //                on s.HouseNo equals sa.HouseNo
            //            join notPay in DataProvider.Ins.DB.NotPaymentDB
            //                on s.HouseNo equals notPay.HouseNo
            //            //where sa.HouseNo == "10"
            //            orderby s.HouseNo descending
            //            select new
            //            {
            //                s.HouseName,
            //                s.Rent,
            //                sa.RentName,
            //                sa.HouseNo,
            //                p.Year,
            //                p.MoneyMonth1,
            //                p.MoneyMonth2,
            //                p.MoneyMonth3,
            //                p.MoneyMonth4,
            //                p.MoneyMonth5,
            //                p.MoneyMonth6,
            //                p.MoneyMonth7,
            //                p.MoneyMonth8,
            //                p.MoneyMonth9,
            //                p.MoneyMonth10,
            //                p.MoneyMonth11,
            //                p.MoneyMonth12,
            //                notPay.NotPayment
            //            };

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
                            rent.HouseName,
                            rent.Rent,
                            s.RenterName,
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


            // var res = DataProvider.Ins.DB.RentalManagementDB
            //     .Join(DataProvider.Ins.DB.RentalContactDB,
            //      s => s.HouseNo,
            //      c => c.HouseNo,
            //      (s, c) => new { s, c })
            ////.Where(sc => sc.c.HouseNo == "1")
            //.Select(sc => sc.c);

            // var categorizedProducts = DataProvider.Ins.DB.RentalManagementDB
            //     .Join(DataProvider.Ins.DB.RentalContactDB,
            //     p => p.HouseNo,
            //     pc => pc.HouseNo,
            //     (p, pc) => new { p, pc })
            //     .Join(DataProvider.Ins.DB.RentalPaymentDB,
            //     ppc => ppc.pc.HouseNo,
            //     c => c.HouseNo,
            //     (ppc, c) => new { ppc, c })
            //     .Select(m => new
            //     {
            //         HouseName = m.ppc.p.HouseNo, // or m.ppc.pc.ProdId
            //         HouseNo = m.c.HouseNo,
            //         Year = m.c.Year
            //         // other assignments
            //     })
            //     .OrderBy(p => p.HouseNo);

            //var lists = DataProvider.Ins.DB.RentalManagementDB
            //    .Join(DataProvider.Ins.DB.RentalContactDB, a => a.HouseNo, b => b.HouseNo, (a, b) => new
            //    {
            //        a.HouseNo,
            //        a.HouseName,
            //        a.Rent
            //    })
            //    .Join(DataProvider.Ins.DB.RentalPaymentDB, ab => ab.HouseNo, c => c.HouseNo, (ab, c) => new
            //    {
            //        ab.HouseNo,
            //        c.MoneyMonth1,
            //        c.MoneyMonth2,
            //        c.Year
            //    });

            //ComboxDateList.Add(yearPaymentDate);

            //List = new ObservableCollection<object>(query.ToList());

            //List = new ObservableCollection<object>(res.ToList());

            SearchButton = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                DateTime dTimePaymentDateFresh = DateTime.Parse(PaymentYear);
                string yearPaymentDateFresh = dTimePaymentDateFresh.Year.ToString();
                string monthPaymentDateFresh = dTimePaymentDateFresh.Month.ToString();
                string dayPaymentDateFresh = dTimePaymentDateFresh.Day.ToString();

                //List = new ObservableCollection<object>(query.Where(y => y.Year == ComboxStatusDate).ToList());
                //List = new ObservableCollection<object>(res.ToList());
                List = new ObservableCollection<object>(query.Where(s => s.HouseNo.ToString().Contains(Search) || s.RenterName.Contains(Search)).ToList());
            });

            NotPaymentButton = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                DateTime dTimePaymentDateFresh = DateTime.Parse(PaymentYear);
                string yearPaymentDateFresh = dTimePaymentDateFresh.Year.ToString();
                string monthPaymentDateFresh = dTimePaymentDateFresh.Month.ToString();
                string dayPaymentDateFresh = dTimePaymentDateFresh.Day.ToString();

                //List = new ObservableCollection<object>(query.Where(y => y.Year == ComboxStatusDate).ToList());
                //List = new ObservableCollection<object>(res.ToList());
                List = new ObservableCollection<object>(query.Where(np => np.NotPayment != "" && np.NotPayment != null).ToList());
            });

            FreshList = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                DateTime dTimePaymentDateFresh = DateTime.Parse(PaymentYear);
                string yearPaymentDateFresh = dTimePaymentDateFresh.Year.ToString();
                string monthPaymentDateFresh = dTimePaymentDateFresh.Month.ToString();
                string dayPaymentDateFresh = dTimePaymentDateFresh.Day.ToString();

                //List = new ObservableCollection<object>(query.Where(y => y.Year == ComboxStatusDate).ToList());
                //List = new ObservableCollection<object>(res.ToList());
                if (ComboxStatus == "未入金")
                {
                    List = new ObservableCollection<object>(query.Where(y => y.Year == ComboxStatusDate && y.NotPayment != "" && y.NotPayment != null).ToList());
                }
                else if (ComboxStatus == "入金完了")
                {
                    List = new ObservableCollection<object>(query.Where(y => y.Year == ComboxStatusDate && (y.NotPayment == "" || y.NotPayment == null)).ToList());
                }
                else
                {
                    List = new ObservableCollection<object>(query.Where(y => y.Year == ComboxStatusDate).ToList());
                }
            });

            ComboxStatusChoose.Add("未入金");
            ComboxStatusChoose.Add("入金完了");
            ComboxStatusChoose.Add("すべて");
            ComboxStatus = "すべて";
            FreshStatus = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                DateTime dTimePaymentDateFresh = DateTime.Parse(PaymentYear);
                string yearPaymentDateFresh = dTimePaymentDateFresh.Year.ToString();
                string monthPaymentDateFresh = dTimePaymentDateFresh.Month.ToString();
                string dayPaymentDateFresh = dTimePaymentDateFresh.Day.ToString();

                if (ComboxStatus == "未入金")
                {
                    List = new ObservableCollection<object>(query.Where(y => y.Year == ComboxStatusDate && y.NotPayment != "" && y.NotPayment != null).ToList());
                }
                else if (ComboxStatus == "入金完了")
                {
                    List = new ObservableCollection<object>(query.Where(y => y.Year == ComboxStatusDate && (y.NotPayment == "" || y.NotPayment == null)).ToList());
                }
                else
                {
                    List = new ObservableCollection<object>(query.Where(y => y.Year == ComboxStatusDate).ToList());
                }
            });

            PaymentListPrintsButton = new RelayCommand<object>((p) => { return true; }, (p) => { printsButton(); });
        }

        private void printsButton()
        {
            if (List.Count != 0) // if List.Count = 0 then Search Result not had 
            {
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                string filePath = "";
                SaveFileDialog dialog = new SaveFileDialog();

                dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = dialog.FileName;
                }

                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("回線（パス）には正しくないです。", "回線とパス", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                try
                {
                    using (ExcelPackage pa = new ExcelPackage())
                    {
                        pa.Workbook.Properties.Author = "マツキ不動産入金";
                        pa.Workbook.Properties.Title = "入金詳細";
                        ExcelWorksheet ws = pa.Workbook.Worksheets.Add("入金一覧");
                        ws.Name = "入金詳細";
                        ws.Cells.Style.Font.Size = 11;
                        ws.Cells.Style.Font.Name = "Calibri";

                        string[] arrColumnHeader = {
                                                        "物件番号",
                                                        "物件名",
                                                        "賃貸人名",
                                                        "家賃",
                                                        "未入金",
                                                        "1月",
                                                        "2月",
                                                        "3月",
                                                        "4月",
                                                        "5月",
                                                        "6月",
                                                        "7月",
                                                        "8月",
                                                        "9月",
                                                        "10月",
                                                        "11月",
                                                        "12月",
                                                        "年間"
                                                        };
                        var countColHeader = arrColumnHeader.Count();

                        ws.Cells[1, 1].Value = "入金一覧";
                        ws.Cells[1, 1, 1, countColHeader].Merge = true;
                        ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                        ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        int colIndex = 1;
                        int rowIndex = 2;

                        foreach (var item in arrColumnHeader)
                        {
                            var cell = ws.Cells[rowIndex, colIndex];
                            var fill = cell.Style.Fill;
                            fill.PatternType = ExcelFillStyle.Solid;
                            fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                            var border = cell.Style.Border;
                            border.Bottom.Style =
                            border.Top.Style =
                            border.Left.Style =
                            border.Right.Style = ExcelBorderStyle.Thin;

                            cell.Value = item;
                            colIndex++;
                        }

                        foreach (object item in List)
                        {
                            string output = JsonConvert.SerializeObject(item);
                            colIndex = 1;
                            rowIndex++;
                            JObject jsonObj = JObject.Parse(output);

                            ws.Cells[rowIndex, colIndex++].Value = jsonObj["HouseNo"].ToString();
                            ws.Cells[rowIndex, colIndex++].Value = jsonObj["HouseName"].ToString();
                            ws.Cells[rowIndex, colIndex++].Value = jsonObj["RentName"].ToString();
                            ws.Cells[rowIndex, colIndex++].Value = jsonObj["Rent"].ToString();
                            ws.Cells[rowIndex, colIndex++].Value = jsonObj["NotPayment"].ToString();
                            ws.Cells[rowIndex, colIndex++].Value = jsonObj["MoneyMonth1"].ToString();
                            ws.Cells[rowIndex, colIndex++].Value = jsonObj["MoneyMonth2"].ToString();
                            ws.Cells[rowIndex, colIndex++].Value = jsonObj["MoneyMonth3"].ToString();
                            ws.Cells[rowIndex, colIndex++].Value = jsonObj["MoneyMonth4"].ToString();
                            ws.Cells[rowIndex, colIndex++].Value = jsonObj["MoneyMonth5"].ToString();
                            ws.Cells[rowIndex, colIndex++].Value = jsonObj["MoneyMonth6"].ToString();
                            ws.Cells[rowIndex, colIndex++].Value = jsonObj["MoneyMonth7"].ToString();
                            ws.Cells[rowIndex, colIndex++].Value = jsonObj["MoneyMonth8"].ToString();
                            ws.Cells[rowIndex, colIndex++].Value = jsonObj["MoneyMonth9"].ToString();
                            ws.Cells[rowIndex, colIndex++].Value = jsonObj["MoneyMonth10"].ToString();
                            ws.Cells[rowIndex, colIndex++].Value = jsonObj["MoneyMonth11"].ToString();
                            ws.Cells[rowIndex, colIndex++].Value = jsonObj["MoneyMonth12"].ToString();
                            ws.Cells[rowIndex, colIndex++].Value = jsonObj["Year"].ToString();
                        }

                        Byte[] bin = pa.GetAsByteArray();
                        File.WriteAllBytes(filePath, bin);
                    }
                    MessageBox.Show("一覧表示からリスト印刷出来ました❣", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception EE)
                {
                    MessageBox.Show("ファイルが開いているために閉じて保存してください！　" + EE, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("一覧表示がなかったです。検索のは検索してください❕", "検索しなかった", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}
