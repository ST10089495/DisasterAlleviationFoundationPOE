using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundationPOE.Pages.NewDisaster
{
    public class EditModel : PageModel
    {
        public DisasterInfo disasterinfo = new DisasterInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public async Task OnGetAsync()
        {
            String ID = Request.Query["ID"];

            try
            {
                String connectionString = "Server=tcp:disasteralleviationpoe.database.windows.net,1433;Initial Catalog=disasteralleviation;Persist Security Info=False;User ID=ST10089495;Password=Earl4225!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                 using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    String sql = "SELECT * FROM NEWDISASTER WHERE ID=@ID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", ID);
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                disasterinfo.ID = "" + reader.GetInt32(0);
                                disasterinfo.DESCRIPTION = reader.GetString(1);
                                disasterinfo.REQAIDTYPE = reader.GetString(2);
                                disasterinfo.DISASTERLOC = reader.GetString(3);
                                disasterinfo.DISASTERSTARTDATE = reader.GetString(4);
                                disasterinfo.DISASTERENDDATE = reader.GetString(5);
                                disasterinfo.ALLOCATEMONEY = reader.GetString(6);
                                disasterinfo.ALLOCATEGOODS = reader.GetString(7);

                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public async void OnPost()
        {
            disasterinfo.ID = Request.Form["ID"];
            disasterinfo.DESCRIPTION = Request.Form["description"];
            disasterinfo.REQAIDTYPE = Request.Form["reqaidtype"];
            disasterinfo.DISASTERLOC = Request.Form["disasterlocation"];
            disasterinfo.DISASTERSTARTDATE = Request.Form["disasterstartdate"];
            disasterinfo.DISASTERENDDATE = Request.Form["disasterenddate"];
            disasterinfo.ALLOCATEMONEY = Request.Form["allocatemoney"];
            disasterinfo.ALLOCATEGOODS = Request.Form["allocategoods"];

            if (disasterinfo.ID.Length == 0 || disasterinfo.DESCRIPTION.Length == 0 || disasterinfo.REQAIDTYPE.Length == 0 ||
                disasterinfo.DISASTERLOC.Length == 0 || disasterinfo.DISASTERSTARTDATE.Length == 0 || disasterinfo.DISASTERENDDATE.Length == 0
                || disasterinfo.ALLOCATEMONEY.Length == 0 || disasterinfo.ALLOCATEGOODS.Length == 0)
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
                    String sql = "UPDATE NEWDISASTER" +
                        "SET DESCRIPTION=@description, REQAIDTYPE=@reqaidtype, DISASTERLOC=@disasterlocation, DISASTERSTARTDATE=@disasterstartdate, DISASTERENDDATE=@disasterenddate, ALLOCATEMONEY=@allocatemoney, ALLOCATEGOODS=@allocategoods VALUES" +
                        "WHERE ID=@ID";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@description", disasterinfo.DESCRIPTION);
                        command.Parameters.AddWithValue("@reqaidtype", disasterinfo.REQAIDTYPE);
                        command.Parameters.AddWithValue("@disasterlocation", disasterinfo.DISASTERLOC);
                        command.Parameters.AddWithValue("@disasterstartdate", disasterinfo.DISASTERSTARTDATE);
                        command.Parameters.AddWithValue("@disasterenddate", disasterinfo.DISASTERENDDATE);
                        command.Parameters.AddWithValue("@allocatemoney", disasterinfo.ALLOCATEMONEY);
                        command.Parameters.AddWithValue("@allocategoods", disasterinfo.ALLOCATEGOODS);
                        command.Parameters.AddWithValue("@ID", disasterinfo.ID);

                        command.ExecuteNonQuery();
                    }
                }

            }

            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            Response.Redirect("/NewDisaster/Index");

        }
    }
}