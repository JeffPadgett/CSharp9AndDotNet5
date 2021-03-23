using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Packt.Shared;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindWeb.Pages
{
    public class SupplierModel : PageModel
    {
        private Northwind db;

        public SupplierModel(Northwind InjectedContext)
        {
            db = InjectedContext;
        }
        public IEnumerable<string> SuppliersCompanyName { get; set; }

        [BindProperty]
        public Supplier Supplier { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - Suppliers";

            SuppliersCompanyName = db.Suppliers.Select(s => s.CompanyName);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(Supplier);
                db.SaveChanges();
                return RedirectToPage("/suppliers");
            }
            return Page();
        }
    }
}