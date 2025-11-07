using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Association
{
    public class ChristmasPromotion : Promotion
    {
        public override double WorkOutTheFinalPrice(double price, int age, int qty)
        {
           if(age < 13)
            {
                return 0;
            }
            else
            {
                if(qty> 3)
                {
                    return .6 * price; //(1-.4)*price;
                }
                else
                {
                    return .8 * price;
                }
            }
        }
    }
}
