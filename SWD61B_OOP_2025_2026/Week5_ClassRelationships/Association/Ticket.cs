using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week5_ClassRelationships.Aggregation;

/* Inheritance
 * --------------------------------------------------------------------------------------
 * Composition - Class A -> Class B is composition if Class A can be instantiated passing an
 *              an instance of Class B
 * Aggregation - Class A -> Class B is aggregation if Class A uses and stores instance of 
 *              Class B but is not composition
 * ASSOCIATION - Class A -> Class B is association if Class A uses ONLY an instance of Class
 *               B BUT IS NOT AGGREGATION (i.e. that it does not store Class B instance)
 */ 

namespace Week5_ClassRelationships.Association
{
    public class Ticket
    {
        public Ticket(Event myEvent, Person p) {
            Event = myEvent;
            Person = p;
        }
        public string Id { get; set; }

        public Person Person { get; set; }

        public Event Event {get; set;}

        public double Price { get; set; }

        public void Buy(Promotion p, Seat s, int qty)
        {
            
            Price = p.WorkOutTheFinalPrice(s.Price, Person.Age, qty);
        }
        public bool Active { get; set; }


    }
}
