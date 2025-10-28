using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_Worksheet6.Q3
{

    public abstract class Character : IAttack
    {
        public int Mana { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        protected Character(int mana, int health, int damage) {
            Mana = mana;
            Health = health;
            Damage = damage;
        }
        public abstract void Attack(Character target);
        
    }
}
