using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundationPOE.Pages.NewGoodsDonations
{
    public class IndexModel : PageModel
    {
        public List<GoodsDonationsInfo> listgoods = new List<GoodsDonationsInfo>();
        public async Task OnGetAsync()
        {
            try
            {
                String connectionString = "Server = tcp:disasteralleviationpoe.database.windows.net,1433; Initial Catalog = disasteralleviation; Persist Security Info = False; User ID = ST10089495; Password = Earl4225!; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    String sql = "SELECT * FROM NEWGOODSDONATIONS";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                GoodsDonationsInfo goodsdonationInfo = new GoodsDonationsInfo();
                                goodsdonationInfo.ID = "" + reader.GetInt32(0);
                                goodsdonationInfo.DESCRIPTION = reader.GetString(1);
                                goodsdonationInfo.CATEGORY = reader.GetString(2);
                                goodsdonationInfo.NUMBEROFITEMS = reader.GetString(3);
                                goodsdonationInfo.DATE = reader.GetString(4);


                                listgoods.Add(goodsdonationInfo);
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

    public class GoodsDonationsInfo
    {
        public string ID;
        public string DESCRIPTION;
        public string CATEGORY;
        public string NUMBEROFITEMS;
        public string DATE;





    }
}