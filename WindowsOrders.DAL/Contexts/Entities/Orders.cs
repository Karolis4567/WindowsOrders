using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsOrders.DAL.Contexts.Entities
{
    [Table("ORDERS")]
    public class Orders : BaseTableWithIdAndCreateDate
    {
        [Column("states_id")]
        public int statesId { get; set; }
        public States states { get; set; }

        [Column("name", TypeName = "Nvarchar(100)")]
        public string name { get; set; }

        public ICollection<OrdersWindows> ordersWindows { get; set; }
    }
}
