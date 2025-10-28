using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_Worksheet6.Q3
{
    
    public class Warrior:Character
    {
        public Warrior(): base(0, 300, 120)
        { }

        public override void Attack(Character target)
        {
            target.Health -= this.Damage;
        }
    }
}
