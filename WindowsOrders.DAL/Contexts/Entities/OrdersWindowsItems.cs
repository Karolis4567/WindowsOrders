using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace WindowsOrders.DAL.Contexts.Entities
{
    [Table("ORDERS_WINDOWS_ITEMS")]
    public class OrdersWindowsItems : BaseTableWithIdAndCreateDate
    {
        [Column("orders_windows_id")]
        public int ordersWindowsId { get; set; }    

        [Column("order")]
        public int order { get; set; }

        [Column("type_id")]
        public int typeId { get; set; }
       
        public OrdersWindowsItemsTypes types { get; set; }

        [Column("width")]
        public int width { get; set; }
        
        [Column("height")]
        public int height { get; set; } 

    }
}
