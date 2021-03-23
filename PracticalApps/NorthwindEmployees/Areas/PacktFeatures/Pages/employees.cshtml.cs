using Microsoft.AspNetCore.Mvc.RazorPages;//PageModel
using Packt.Shared; //Employee
using System.Linq; //ToArray()
using System.Collections.Generic; // IEnumerable<T>

namespace PacktFeatures.Pages
{
    public class EmployeePageModel : PageModel
    {
        private Northwind db;

        public EmployeePageModel(Northwind injectContext)
        {
            db = injectContext;
        }

        public IEnumerable<Employee> Employees {get; set;}

        public void OnGet()
        {
            Employees = db.Employees.ToArray();
        }

    }
}
