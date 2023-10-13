using System;
using DisasterAlleviationFoundationPOE.Data;
using DisasterAlleviationFoundationPOE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundationPOE.Pages.Allocations
{
    public class AllocationsModel : PageModel
    {
       

        [BindProperty]
        public int SelectedDisasterId { get; set; } 
        [BindProperty]
        public int GoodId { get; set; }
        [BindProperty]
        public int AllocationType { get; set; }
        [BindProperty]
        public int Quantity { get; set; }
        [BindProperty]
        public int Disaster { get; set; }

        
        public List<AllocationsInfo> listallocation = new List<AllocationsInfo>();
        

        public async Task OnGetAsync()

        {
            try
            {
                String connectionString = "Server=tcp:disasteralleviationpoe.database.windows.net,1433;Initial Catalog=disasteralleviation;Persist Security Info=False;User ID=ST10089495;Password=Earl4225!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    await connection.OpenAsync();
                    String sql = "SELECT * FROM NEWDISASTER, NEWGOODSDONATIONS, MONETARYDONATIONS";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                AllocationsInfo allocationsInfo = new AllocationsInfo();
                                allocationsInfo.ID = "" + reader.GetInt32(0);
                                allocationsInfo.DESCRIPTION = reader.GetString(1);
                                allocationsInfo.AMOUNT = reader.GetString(18);
                                allocationsInfo.NUMBEROFITEMS = reader.GetString(12);
                                allocationsInfo.ALLOCATEMONEY = reader.GetString(6);
                                allocationsInfo.ALLOCATEGOODS = reader.GetString(7);
                              

                                listallocation.Add(allocationsInfo);
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

        public IActionResult OnPostProcessAllocation()
        {
            
            return RedirectToPage("Allocations");
        }
    }

   

    public class AllocationsInfo
    {
        public string ID;
        public string DESCRIPTION;
        public string AMOUNT;
        public string NUMBEROFITEMS;
        public string ALLOCATEMONEY;
        public string ALLOCATEGOODS;
       

    }
}
