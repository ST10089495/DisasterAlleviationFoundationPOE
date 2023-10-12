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
       private readonly DisasterContext _context;


        //[BindProperty]
        //public AllocationsViewModel ViewModel { get; set; }

        [BindProperty]
        public int SelectedDisasterId { get; set; } // Add this property
        [BindProperty]
        public int GoodId { get; set; }
        [BindProperty]
        public int AllocationType { get; set; }
        [BindProperty]
        public int Quantity { get; set; }
        [BindProperty]
        public int Disaster { get; set; }

        public AllocationsModel(DisasterContext context)
        {
            _context = context;
        }
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

            //Load data from the database and populate the ViewModel
           //ViewModel = new AllocationsViewModel
           //{
           //    Disaster = _context.Disasters.Where(d => d.IsActive).ToList(),
           //    AvailableGoods = _context.Goods.ToList(),
           //    AllocateGoods = _context.AllocateGoods.ToList(),
           //    AllocateMoney = _context.AllocateMoney.ToList(),
           //    Purchases = _context.Purchases.ToList()
           //};
        }

        public IActionResult OnPostProcessAllocation()
        {
            // Handle the allocation based on AllocationType and SelectedDisasterId
            // Reload data if needed
            // Redirect back to the Allocations page
            return RedirectToPage("Allocations");
        }
    }

    //public class AllocationsViewModel
    //{
    //    public List<Goods> AvailableGoods { get; internal set; }
    //    public object AllocateGoods { get; internal set; }
    //    public List<Disaster> Disaster { get; internal set; }
    //    public object AllocateMoney { get; internal set; }
    //    public object Purchases { get; internal set; }
    //}

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
