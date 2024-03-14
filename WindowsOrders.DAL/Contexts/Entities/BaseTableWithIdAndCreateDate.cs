using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsOrders.DAL.Contexts.Entities
{
    public abstract class BaseTableWithIdAndCreateDate : BaseTableWithId
    {
        [Column("create_date", TypeName = "datetime")]
        public DateTime createDate { get; set; } = DateTime.Now;
    }
}
