using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviationFoundationPOE.Models
{
    public class Registration
    {
        [Key]
        public string userregusername { get; set; }
        public string userregpassword { get; set; }
    }
}
