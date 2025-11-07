using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Association
{
    public abstract class Promotion
    {
        public double PercentageDiscount { get; set; } //e.g. 0.5
        public abstract double WorkOutTheFinalPrice(double price, int age, int qty);
    }
}
