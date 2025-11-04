using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Aggregation
{
    public class Lecturer : Person
    {
        public override string OutputToCSV(string path)
        {
            string contents = $"{DateTime.Now.ToString()} [Lecturer]: {FirstName} {LastName}";
            System.IO.File.AppendAllText(path, contents);
            return contents;
        }
    }
}
