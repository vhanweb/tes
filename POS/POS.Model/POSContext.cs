using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    public class POSContext : DbContext
    {
        public POSContext()
            : base("POSConnection")
        {
            // ini untuk menonaktifkan Generat Database
            Database.SetInitializer<POSContext>(null);
        }

        public DbSet<AdjusmentStock> TAdjusmentStock { get; set; }
        public DbSet<AdjusmentStockDetail> TAdjusmentStockDetail { get; set; }
        public DbSet<Payment> TPayment { get; set; }
        public DbSet<PaymentDetail> TPaymentDetail { get; set; }
        public DbSet<PurchaseOrder> TPurchaseOrder { get; set; }
        public DbSet<PurchaseOrderDetail> TPurchaseOrderDetail { get; set; }
        public DbSet<PurchaseOrderHistory> TPurchaseOrderHistory { get; set; }
        public DbSet<TransferStock> TTransferStock { get; set; }
        public DbSet<TransferStockDetail> TTransferStockDetail { get; set; }
        public DbSet<Categories> TCategories { get; set; }
        public DbSet<Customers> TCustomers { get; set; }
        public DbSet<District> TDistrict { get; set; }
        public DbSet<Employee> TEmployee { get; set; }
        public DbSet<EmployeeOutlet> TEmployeeOutlet { get; set; }
        public DbSet<Items> TItems { get; set; }
        public DbSet<ItemsIventory> TItemsIventory { get; set; }
        public DbSet<ItemsVariant> TItemsVariant { get; set; }
        public DbSet<Outlet> TOutlet { get; set; }
        public DbSet<PaymentOption> TPaymentOption { get; set; }
        public DbSet<Province> TProvince { get; set; }
        public DbSet<PurchaseOrderStatus> TPurchaseOrderStatus { get; set; }
        public DbSet<Region> TRegion { get; set; }
        public DbSet<Role> TRole { get; set; }
        public DbSet<Suppliers> TSuppliers { get; set; }

        
    }

}
