using Microsoft.AspNetCore.Mvc.RazorPages;//PageModel
using Packt.Shared; //Employee
using System.Linq; //ToArray()
using System.Collections.Generic; // IEnumerable<T>

namespace PacktFeatures.Pages
{
    public class CustomersModel : PageModel
    {
        private Northwind db;

        public CustomersModel(Northwind injectContext)
        {
            db = injectContext;
        }

        public IDictionary<string, List<Customer>> CustomersByCountry {get; set;}


        public void OnGet()
        {
            //do a link expression that gets you customers in a list by grouped by their country. 
            CustomersByCountry = db.Customers.AsEnumerable()
                                             .GroupBy(c => c.Country.Distinct())                                            
                                             .ToDictionary(c => c.ToString(), y => y.ToList());
        }

    }
}
