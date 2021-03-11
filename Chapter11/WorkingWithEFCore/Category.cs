using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Packt.Shared
{
    public class Category
    {
        // these properties map to columns in the database
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public string Description { get; set; }

        // defines a navigation property for related rows
        // People use IEnumerable<> for a list of objects that ony needs to be iterated through. 
        // ICollection<> for a list of objects that needs to be iterated though and modified.
        // List<> for objects that need to be iterated though, modified sorted. etc. 
        public virtual ICollection<Product> Products { get; set; }
        

        public Category()
        {
            // to enable developers to add products to a Category we must
            // initialize the navigation property to an empty collection
            this.Products = new HashSet<Product>();// Use Hashset over list becuase you can't insert duplicates in a hashset. Tables don't have dupe rows.

        }
    }
}