using Microsoft.AspNetCore.Mvc.RazorPages;//PageModel
using Packt.Shared; //Employee
using System.Linq; //ToArray()
using System.Collections.Generic; // IEnumerable<T>
using Microsoft.AspNetCore.Components.Forms;
using System;

namespace PacktFeatures.Pages
{
    public class CustomersModel : PageModel
    {
        private Northwind db;

        public CustomersModel(Northwind injectContext)
        {
            db = injectContext;
        }

        //public IDictionary<string, List<Customer>> CustomersByCountry {get; set;}

        public List<Customer> Customers { get; set; }
        
        // ex: /Customers?pageNum=1&pageSize=5&country=Germany
        public void OnGet(int pageNum = 1, int pageSize = 50, string country = default)
        {
            // Prepare the customers query
            var custListQ = db.Customers.AsQueryable();
            if(!string.IsNullOrWhiteSpace(country))
            {
                // Apply the Country Filter if the country parameter was specified
                custListQ = custListQ.Where(x => x.Country == country);
            }

            // Clamp paging information to acceptable values
            pageSize = Math.Clamp(pageSize, 5, 100);
            var totalRecs = custListQ.Count();
            var totalPages = (int)Math.Ceiling(totalRecs / (double)pageSize);  
            pageNum = Math.Clamp(pageNum, 1, totalPages);
            
            // Perform the query, making sure to sort before applying the paging
            Customers = custListQ
                .OrderBy(c => c.Country)
                .ThenBy(x => x.ContactName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            //do a link expression that gets you customers in a list by grouped by their country. 
            //CustomersByCountry = db.Customers.AsEnumerable()
            //                                 .GroupBy(c => c.Country.Distinct())                                            
            //                                 .ToDictionary(c => c.ToString(), y => y.ToList());
        }

    }
}
