using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundationPOE.Pages.MonetaryDonations
{
    public class IndexModel : PageModel
    {
        public List<MonetaryInfo> listmonetary = new List<MonetaryInfo>();
        public async Task OnGetAsync()
        {
            try
            {
                String connectionString = "Server = tcp:disasteralleviationpoe.database.windows.net,1433; Initial Catalog = disasteralleviation; Persist Security Info = False; User ID = ST10089495; Password = Earl4225!; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    String sql = "SELECT * FROM MONETARYDONATIONS";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                MonetaryInfo monetaryinfo = new MonetaryInfo();
                                monetaryinfo.ID = "" + reader.GetInt32(0);
                                monetaryinfo.DONORNAME = reader.GetString(1);
                                monetaryinfo.DATE = reader.GetString(2);
                                monetaryinfo.AMOUNT = reader.GetString(3);


                                listmonetary.Add(monetaryinfo);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ToString());

            }
        }
    }

    public class MonetaryInfo
    {
        public string ID;
        public string DONORNAME;
        public string DATE;
        public string AMOUNT;





    }


}