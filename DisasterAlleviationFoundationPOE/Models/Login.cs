using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviationFoundationPOE.Models
{
    public class Login
    {
        [Key]
        public string username { get; set; }
        public string userpassword { get; set; }
    }
}
