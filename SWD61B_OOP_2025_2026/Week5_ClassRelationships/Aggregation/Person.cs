using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Aggregation
{
    public abstract class Person
    {
       public int Age { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }

       public string EmailAddress { get; set; }

       public string Mobile { get; set; }

       public string Id { get; set; }

       public abstract string OutputToCSV(string path);

    }
}
