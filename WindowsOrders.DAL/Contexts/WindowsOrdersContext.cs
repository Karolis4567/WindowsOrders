using Microsoft.EntityFrameworkCore;
using WindowsOrders.DAL.Contexts.Entities;

namespace WindowsOrders.DAL.Contexts
{
    public class WindowsOrdersContext : DbContext
    {
        public WindowsOrdersContext() { }
        public WindowsOrdersContext(DbContextOptions<WindowsOrdersContext> options) : base(options) { }
             

        public DbSet<States> States { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrdersWindows> OrdersWindows { get; set; }
        public DbSet<OrdersWindowsItems> OrdersWindowsItems { get; set; }
        public DbSet<OrdersWindowsItemsTypes> OrdersWindowsItemsTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Orders>()
              .HasMany(x => x.ordersWindows)
              .WithOne()
              .HasForeignKey(x => x.ordersId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OrdersWindows>()
               .HasMany(x => x.ordersWindowsItems)
               .WithOne()
               .HasForeignKey(x => x.ordersWindowsId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Orders>()
                .HasOne(x => x.states)
                .WithMany()
                .HasForeignKey(x => x.statesId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<OrdersWindowsItems>()
                .HasOne(x => x.types)
                .WithMany()
                .HasForeignKey(x => x.typeId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
