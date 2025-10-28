using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_Worksheet6.Q3
{
    //a class can inherit from ANOTHER CLASS but can inherit from MULTIPLE INTERFACES

    public class Priest:Character, IHeal
    {
        public Priest():base(200, 125, 100)
        { }

        public override void Attack(Character target)
        {
            target.Health -= this.Damage;
            this.Health += Convert.ToInt32((0.1 * this.Damage));
        }

        public void Heal(Character target)
        {
            this.Mana -= 100;
            target.Health += 150;
        }
    }
}
