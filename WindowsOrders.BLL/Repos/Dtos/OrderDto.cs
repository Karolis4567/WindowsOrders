
namespace WindowsOrders.BLL.Repos.Dtos
{
    public class OrderDto
    {
        public int id { get; set; }
        public string name { get; set; }    
        public int stateId { get; set; }
        public string stateName { get; set; }
        public string stateCode { get; set; }
        public DateTime createDate { get; set; }
        public IEnumerable<OrderWindowDto> windows { get; set; }   
       
    }

    public class OrderWindowDto
    { 
        public int id { get; set; }
        public bool isNew { get; set; } 
        public string name { get; set; }    
        public int quantity { get; set; }
        public IEnumerable<OrderWindowItemDto> items { get; set; }
    }

    public class OrderWindowItemDto
    {
        public int id { get; set; }
        public bool isNew { get; set; }
        public int order { get; set; }
        public int typeId { get; set;  }
        public string typeName { get; set; }    
        public int width { get; set; } 
        public int height { get; set; } 
    }
}
