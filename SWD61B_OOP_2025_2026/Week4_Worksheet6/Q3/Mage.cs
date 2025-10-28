using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_Worksheet6.Q3
{
  
    public class Mage : Character
    {
        public Mage(): base(300, 100, 75) { }

        public override void Attack(Character target)
        {
            this.Mana -= 100;
            target.Health -= (2 * Damage);
        }
    }
}
