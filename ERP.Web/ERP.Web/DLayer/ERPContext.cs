using CLayer;
using Microsoft.EntityFrameworkCore;

namespace ERP.Web.DLayer
{
    public class ERPContext : DbContext
    {
        public ERPContext(DbContextOptions<ERPContext> options) : base(options)
        { }
        public DbSet<PurchaseOrderEntity> PurchaseOrder { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchaseOrderEntity>().ToTable("PurchaseOrder");
        }

    }



}
