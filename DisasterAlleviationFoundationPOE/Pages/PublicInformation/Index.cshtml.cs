using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DisasterAlleviationFoundationPOE.Data;
using DisasterAlleviationFoundationPOE.Models;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundationPOE.Pages.PublicInformation
{
    public class IndexModel : PageModel
    {
        public List<DisasterInfo> listdisasters = new List<DisasterInfo>();
        public List<GoodsDonationsInfo> listgoods = new List<GoodsDonationsInfo>();
        public List<MonetaryInfo> listmonetary = new List<MonetaryInfo>();


        public async Task OnGetAsync()
        {
            try
            {
                String connectionString = "Server = tcp:disasteralleviationpoe.database.windows.net,1433; Initial Catalog = disasteralleviation; Persist Security Info = False; User ID = ST10089495; Password = Earl4225!; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30; ";
  

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    String sql = "SELECT * FROM NEWDISASTER";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                DisasterInfo disasterInfo = new DisasterInfo();
                                disasterInfo.ID = "" + reader.GetInt32(0);
                                disasterInfo.DESCRIPTION = reader.GetString(1);
                                disasterInfo.REQAIDTYPE = reader.GetString(2);
                                disasterInfo.DISASTERLOC = reader.GetString(3);
                                disasterInfo.DISASTERSTARTDATE = reader.GetString(4);
                                disasterInfo.DISASTERENDDATE = reader.GetString(5);
                                disasterInfo.ALLOCATEMONEY = reader.GetString(6);
                                disasterInfo.ALLOCATEGOODS = reader.GetString(7);
                                disasterInfo.CREATED_AT = reader.GetDateTime(8).ToString();

                                listdisasters.Add(disasterInfo);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ToString());

            }
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
    public class DisasterInfo
    {
        public string ID;
        public string DESCRIPTION;
        public string REQAIDTYPE;
        public string DISASTERLOC;
        public string DISASTERSTARTDATE;
        public string DISASTERENDDATE;
        public string ALLOCATEMONEY;
        public string ALLOCATEGOODS;
        public string CREATED_AT;

    }
}


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




public class MonetaryInfo
{
    public string ID;
    public string DONORNAME;
    public string DATE;
    public string AMOUNT;





}