﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class matsukiEntities : DbContext
    {
        public matsukiEntities()
            : base("name=matsukiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ApartmentDB> ApartmentDB { get; set; }
        public virtual DbSet<ConstructionDB> ConstructionDB { get; set; }
        public virtual DbSet<ContractDetailsDB> ContractDetailsDB { get; set; }
        public virtual DbSet<CustomerDB> CustomerDB { get; set; }
        public virtual DbSet<DailyReportDB> DailyReportDB { get; set; }
        public virtual DbSet<DetachedDB> DetachedDB { get; set; }
        public virtual DbSet<ImageDB> ImageDB { get; set; }
        public virtual DbSet<LandDB> LandDB { get; set; }
        public virtual DbSet<NotPaymentDB> NotPaymentDB { get; set; }
        public virtual DbSet<RentalContactDB> RentalContactDB { get; set; }
        public virtual DbSet<RentalManagementDB> RentalManagementDB { get; set; }
        public virtual DbSet<RentalPaymentDB> RentalPaymentDB { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
