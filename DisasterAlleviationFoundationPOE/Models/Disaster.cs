using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviationFoundationPOE.Models
{
    public class Disaster
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal MoneyAllocated { get; set; }
        public bool IsResolved { get; internal set; }
        public bool IsActive { get; internal set; }
    }
}
