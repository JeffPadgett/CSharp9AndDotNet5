using System;
using System.Collections.Generic;

namespace Packt.Shared
{
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            //Compare the Name Lengths...
            int result = x.Name.Length.CompareTo(y.Name.Length);

            // ....if thye are equal...
            if (result == 0)
            {
                // ... Then compare by the names...
                return x.Name.CompareTo(y.Name);
            }
            else
            {
                // .... otherewise compare by the lengths.
                return result;
            }
        }
    }

}