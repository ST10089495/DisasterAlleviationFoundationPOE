using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviationFoundationPOE.Models
{
    public class NewDonations
    {
        [Key]
        public string DonorName { get; set; }
        public string Description { get; set; }
        public int DonationAmount { get; set; }
        public DateTime DateOfDonation { get; set; }
        public string DateOfGoodsDonation { get; set; }
    }
}
