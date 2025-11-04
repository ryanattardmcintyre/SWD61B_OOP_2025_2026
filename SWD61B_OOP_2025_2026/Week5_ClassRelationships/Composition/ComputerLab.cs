using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Composition
{
    public class ComputerLab : Room
    {
        //composition relationship which was established between Room and Building
        //is reinforced in here as a derived class 
        public ComputerLab(Building b): base(b)
        { }

        public int NumberOfComputers { get; set; }


    }
}
