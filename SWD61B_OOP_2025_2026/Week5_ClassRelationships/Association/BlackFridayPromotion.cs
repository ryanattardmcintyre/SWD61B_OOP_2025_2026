using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Association
{
    public class BlackFridayPromotion : Promotion
    {
        public BlackFridayPromotion() {
            PercentageDiscount = .30;
        }
        public override double WorkOutTheFinalPrice(double price, int age, int qty)
        {
            return PercentageDiscount * price;
        }
    }
}
