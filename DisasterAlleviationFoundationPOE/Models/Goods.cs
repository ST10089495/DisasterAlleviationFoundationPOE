using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviationFoundationPOE.Models
{
    public class Goods
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
