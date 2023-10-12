using DisasterAlleviationFoundationPOE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DisasterAlleviationFoundationPOE.Data.Controllers
{
    [Authorize]
    public class AllocationController : Controller
    {
        private readonly DisasterContext _context;

        public AllocationController(DisasterContext context)
        {
            _context = context;
        }

        public IActionResult AllocateMoney(int disasterId, decimal amount)
        {
            var disaster = _context.Disasters.Find(disasterId);
            if (disaster != null)
            {
                disaster.MoneyAllocated += amount;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult AllocateGoods(int disasterId, int goodId, int quantity)
        {
            var inventory = new Inventory
            {
                DisasterId = disasterId,
                GoodId = goodId,
                Quantity = quantity
            };
            _context.Inventories.Add(inventory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult CapturePurchase()
        {
            // Fetch a list of active disasters or goods as needed for your form.
            var activeDisasters = _context.Disasters.Where(d => !d.IsResolved).ToList();
            var availableGoods = _context.Goods.ToList();

            // You should also fetch the available money from a specific source, e.g., a budget record.
            decimal availableMoney = GetAvailableMoneyFromSource();

            var model = new CapturePurchaseViewModel
            {
                ActiveDisasters = activeDisasters,
                AvailableGoods = availableGoods,
                AvailableMoney = availableMoney
            };

            return View(model);
        }

        private decimal GetAvailableMoneyFromSource()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult CapturePurchase(CapturePurchaseViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if the selected disaster is active and available goods are in stock.
                var disaster = _context.Disasters.Find(model.DisasterId);
                var good = _context.Goods.Find(model.GoodId);

                if (disaster != null && !disaster.IsResolved && good != null)
                {
                    if (model.PurchaseQuantity <= model.AvailableMoney)
                    {
                        // Decrease available money.
                        model.AvailableMoney -= model.PurchaseQuantity;

                        // Increase the inventory for the selected good and disaster.
                        var inventory = _context.Inventories
                            .FirstOrDefault(i => i.DisasterId == model.DisasterId && i.GoodId == model.GoodId);

                        if (inventory != null)
                        {
                            inventory.Quantity += model.PurchaseQuantity;
                        }
                        else
                        {
                            // Create a new inventory record if it doesn't exist.
                            var newInventory = new Inventory
                            {
                                DisasterId = model.DisasterId,
                                GoodId = model.GoodId,
                                Quantity = model.PurchaseQuantity
                            };
                            _context.Inventories.Add(newInventory);
                        }

                        _context.SaveChanges();

                        return RedirectToAction("Index"); // Redirect to a suitable action after the purchase.
                    }
                    else
                    {
                        ModelState.AddModelError("PurchaseAmount", "Not enough available money for this purchase.");
                    }
                }
                else
                {
                    ModelState.AddModelError("DisasterId", "Invalid disaster selection or the disaster is resolved.");
                }
            }

            // If there are validation errors, redisplay the form with error messages.
            model.ActiveDisasters = _context.Disasters.Where(d => !d.IsResolved).ToList();
            model.AvailableGoods = _context.Goods.ToList();
            return View(model);
        }
    }

}
