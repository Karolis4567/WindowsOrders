using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsOrders.DAL.Contexts.Entities
{
    [Table("ORDERS_WINDOWS_ITEMS_TYPES")]
    public class OrdersWindowsItemsTypes : BaseTableWithId
    {
        [Column("name", TypeName = "varchar(30)")]
        public string name { get; set; }
    }
}
