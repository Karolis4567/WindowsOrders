using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsOrders.DAL.Contexts.Entities
{
    [Table("STATES")]
    public class States : BaseTableWithId
    {
        [Column("code", TypeName = "varchar(2)")]
        public string code { get; set; }
        
        [Column("name", TypeName = "varchar(30)")]
        public string name { get; set; }
    }
}
