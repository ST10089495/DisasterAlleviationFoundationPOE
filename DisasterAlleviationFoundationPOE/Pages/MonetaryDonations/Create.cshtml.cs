using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundationPOE.Pages.MonetaryDonations
{
    public class CreateModel : PageModel
    {
        public MonetaryInfo monetaryInfo = new MonetaryInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public Task OnGetAsync()
        {
            return Task.CompletedTask;
        }

        public async Task OnPostAsync()
        {
            monetaryInfo.DONORNAME = Request.Form["donorname"];
            monetaryInfo.DATE = Request.Form["date"];
            monetaryInfo.AMOUNT = Request.Form["amount"];


            if (monetaryInfo.DONORNAME.Length == 0 || monetaryInfo.DATE.Length == 0 ||
                monetaryInfo.AMOUNT.Length == 0)
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
                    String sql = "INSERT INTO MONETARYDONATIONS" +
                        "(DONORNAME, DATE, AMOUNT) VALUES" +
                        "(@donorname, @date, @amount);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@donorname", monetaryInfo.DONORNAME);
                        command.Parameters.AddWithValue("@date", monetaryInfo.DATE);
                        command.Parameters.AddWithValue("@amount", monetaryInfo.AMOUNT);


                        command.ExecuteNonQuery();
                    }
                }


            }

            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            monetaryInfo.DONORNAME = ""; monetaryInfo.DATE = ""; monetaryInfo.AMOUNT = "";
            successMessage = "Monetary donation successfully added";

            Response.Redirect("/MonetaryDonations/Index");

        }
    }
}