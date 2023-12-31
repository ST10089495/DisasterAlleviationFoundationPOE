using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundationPOE.Pages.NewDisaster
{
    public class CreateModel : PageModel
    {
        public DisasterInfo disasterInfo = new DisasterInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public Task OnGetAsync()
        {
            return Task.CompletedTask;
        }

        public async void OnPost()
        {
            disasterInfo.DESCRIPTION = Request.Form["description"];
            disasterInfo.REQAIDTYPE = Request.Form["reqaidtype"];
            disasterInfo.DISASTERLOC = Request.Form["disasterlocation"];
            disasterInfo.DISASTERSTARTDATE = Request.Form["disasterstartdate"];
            disasterInfo.DISASTERENDDATE = Request.Form["disasterenddate"];
            disasterInfo.ALLOCATEMONEY = Request.Form["allocatemoney"];
            disasterInfo.ALLOCATEGOODS = Request.Form["allocategoods"];

            if (disasterInfo.DESCRIPTION.Length == 0 || disasterInfo.REQAIDTYPE.Length == 0 ||
                disasterInfo.DISASTERLOC.Length == 0 || disasterInfo.DISASTERSTARTDATE.Length == 0 ||
                disasterInfo.DISASTERENDDATE.Length == 0 || disasterInfo.ALLOCATEMONEY.Length == 0 ||
                disasterInfo.ALLOCATEGOODS.Length == 0)
            {
                errorMessage = "Please fill in all the fields";
                return;


            }

            try
            {
                String connectionString = "Server=tcp:disasteralleviationpoe.database.windows.net,1433;Initial Catalog=disasteralleviation;Persist Security Info=False;User ID=ST10089495;Password=Earl4225!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                 using (SqlConnection connection = new SqlConnection(connectionString))
                {
                   await connection.OpenAsync();
                    String sql = "INSERT INTO NEWDISASTER" +
                        "(DESCRIPTION, REQAIDTYPE, DISASTERLOC, DISASTERSTARTDATE, DISASTERENDDATE, ALLOCATEMONEY, ALLOCATEGOODS) VALUES" +
                        "(@description, @reqaidtype, @disasterlocation, @disasterstartdate, @disasterenddate, @allocatemoney, @allocategoods);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@description", disasterInfo.DESCRIPTION);
                        command.Parameters.AddWithValue("@reqaidtype", disasterInfo.REQAIDTYPE);
                        command.Parameters.AddWithValue("@disasterlocation", disasterInfo.DISASTERLOC);
                        command.Parameters.AddWithValue("@disasterstartdate", disasterInfo.DISASTERSTARTDATE);
                        command.Parameters.AddWithValue("@disasterenddate", disasterInfo.DISASTERENDDATE);
                        command.Parameters.AddWithValue("@allocatemoney", disasterInfo.ALLOCATEMONEY);
                        command.Parameters.AddWithValue("@allocategoods", disasterInfo.ALLOCATEGOODS);

                        command.ExecuteNonQuery();
                    }
                }


            }

            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            disasterInfo.DESCRIPTION = ""; disasterInfo.REQAIDTYPE = ""; disasterInfo.DISASTERLOC = ""; disasterInfo.DISASTERSTARTDATE = "";
            disasterInfo.DISASTERENDDATE = ""; disasterInfo.ALLOCATEMONEY = ""; disasterInfo.ALLOCATEGOODS = "";
            successMessage = "Disaster successfully added";

            Response.Redirect("/NewDisaster/Index");

        }
    }
}