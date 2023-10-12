using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DisasterAlleviationFoundationPOE.Pages
{
    public class NewDonationsModel : PageModel
    {
        public bool ContainsData = false;
        public string donorname = "";
        public string donationdate = "";
        public string donationamount = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            ContainsData = true;
            donorname = Request.Form["donorname"];
            donationdate = Request.Form["donationdate"];
            donationamount = Request.Form["doantionamount"];
        }
    }
}
