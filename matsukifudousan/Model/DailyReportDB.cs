//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはテンプレートから生成されました。
//
//     このファイルを手動で変更すると、アプリケーションで予期しない動作が発生する可能性があります。
//     このファイルに対する手動の変更は、コードが再生成されると上書きされます。
// </auto-generated>
//------------------------------------------------------------------------------

namespace matsukifudousan.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class DailyReportDB
    {
        public int DailyReportId { get; set; }
        public string Date { get; set; }
        public Nullable<int> HouseNo { get; set; }
        public string HouseName { get; set; }
        public Nullable<int> CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNameOther { get; set; }
        public string Comment { get; set; }
        public string TypeSelect { get; set; }
    }
}
