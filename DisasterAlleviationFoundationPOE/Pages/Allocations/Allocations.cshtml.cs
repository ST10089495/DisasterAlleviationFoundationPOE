using DisasterAlleviationFoundationPOE.Data;
using DisasterAlleviationFoundationPOE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DisasterAlleviationFoundationPOE.Pages.Allocations
{
    public class AllocationsModel : PageModel
    {
       private readonly DisasterContext _context;
        

        [BindProperty]
        public AllocationsViewModel ViewModel { get; set; }

        [BindProperty]
        public int SelectedDisasterId { get; set; } // Add this property

        public AllocationsModel(DisasterContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            // Load data from the database and populate the ViewModel
            ViewModel = new AllocationsViewModel
            {
                Disaster = _context.Disasters.Where(d => d.IsActive).ToList(),
                AvailableGoods = _context.Goods.ToList(),
                AllocateGoods = _context.AllocateGoods.ToList(),
                AllocateMoney = _context.AllocateMoney.ToList(),
                Purchases = _context.Purchases.ToList()
            };
        }

        public IActionResult OnPostProcessAllocation()
        {
            // Handle the allocation based on AllocationType and SelectedDisasterId
            // Reload data if needed
            // Redirect back to the Allocations page
            return RedirectToPage("Allocations");
        }
    }

    public class AllocationsViewModel
    {
        public List<Goods> AvailableGoods { get; internal set; }
        public object AllocateGoods { get; internal set; }
        public List<Disaster> Disaster { get; internal set; }
        public object AllocateMoney { get; internal set; }
        public object Purchases { get; internal set; }
    }
}
