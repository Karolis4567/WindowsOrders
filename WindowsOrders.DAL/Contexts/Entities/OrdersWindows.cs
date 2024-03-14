using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsOrders.DAL.Contexts.Entities
{
    [Table("ORDERS_WINDOWS")]
    public class OrdersWindows : BaseTableWithIdAndCreateDate
    {
        [Column("orders_id")]
        public int ordersId { get; set; }

        [Column("name", TypeName = "Nvarchar(100)")]
        public string name { get; set; }
        
        [Column("quantity")]
        public int quantity { get; set; }
        public ICollection<OrdersWindowsItems> ordersWindowsItems { get; set; }
    }
}
