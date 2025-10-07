using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1_IntroToClasses
{
    public class Book
    {
        //fields : use: the hold raw data
        private int stock; //private <data type> <name for the field in camel case>
        private double wholesalePrice;

        //properties
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PublishedYear { get; set; }
        public int Stock
        {
            get { return stock; //we are returning the value contained in the field 
            }
            set {
                if(value < 0) stock = 0;
                else stock = value;
                }
        }
        public double WholesalePrice
        {
            get
            {
                return wholesalePrice;
            }
            set
            {
                if (value > 0)
                    wholesalePrice = value;
                else wholesalePrice = 0;
            }
        }
        public double RetailPrice //removing the set makes the RetailPrice read-only
        {
            get
            {
                return wholesalePrice * 1.18 * 1.33;
            }

        }
        public string Author { get; set; }

    }
}
