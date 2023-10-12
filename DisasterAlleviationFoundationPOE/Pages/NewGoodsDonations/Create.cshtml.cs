using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundationPOE.Pages.NewGoodsDonations
{
    public class CreateModel : PageModel
    {
        public GoodsDonationsInfo goodsDonationsInfo = new GoodsDonationsInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public Task OnGetAsync()
        {
            return Task.CompletedTask;
        }

        public async Task OnPostAsync()
        {
            goodsDonationsInfo.DESCRIPTION = Request.Form["description"];
            goodsDonationsInfo.CATEGORY = Request.Form["category"];
            goodsDonationsInfo.NUMBEROFITEMS = Request.Form["numberofitems"];
            goodsDonationsInfo.DATE = Request.Form["date"];


            if (goodsDonationsInfo.DESCRIPTION.Length == 0 || goodsDonationsInfo.CATEGORY.Length == 0 ||
               goodsDonationsInfo.NUMBEROFITEMS.Length == 0 || goodsDonationsInfo.DATE.Length == 0)
            {
                errorMessage = "Please fill in all the fields";
                return;


            }

            try
            {
                String connectionString = "Server = tcp:disasteralleviationpoe.database.windows.net,1433; Initial Catalog = disasteralleviation; Persist Security Info = False; User ID = ST10089495; Password = Earl4225!; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    String sql = "INSERT INTO NEWGOODSDONATIONS" +
                        "(DESCRIPTION, CATEGORY, NUMBEROFITEMS, DATE) VALUES" +
                        "(@description, @category, @numberofitems, @date);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@description", goodsDonationsInfo.DESCRIPTION);
                        command.Parameters.AddWithValue("@category", goodsDonationsInfo.CATEGORY);
                        command.Parameters.AddWithValue("@numberofitems", goodsDonationsInfo.NUMBEROFITEMS);
                        command.Parameters.AddWithValue("@date", goodsDonationsInfo.DATE);


                        command.ExecuteNonQuery();
                    }
                }


            }

            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            goodsDonationsInfo.DESCRIPTION = ""; goodsDonationsInfo.CATEGORY = ""; goodsDonationsInfo.NUMBEROFITEMS = ""; goodsDonationsInfo.DATE = "";
            successMessage = "Disaster successfully added";

            Response.Redirect("/NewGoodsDonations/Index");

        }
    }
}