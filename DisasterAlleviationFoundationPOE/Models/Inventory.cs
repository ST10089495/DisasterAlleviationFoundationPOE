using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviationFoundationPOE.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }
        public int GoodId { get; set; }
        public int DisasterId { get; set; }
        public int Quantity { get; set; }
    }
}
