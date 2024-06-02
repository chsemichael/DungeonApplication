using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Zombie : Monster
    {
        public bool IsFleshEating { get; set; }

        public Zombie(string name, int hitChance, int block, int life, int damage, string description, bool isFleshEating) : base(name, hitChance, block, life, damage, description)
        {
            IsFleshEating = isFleshEating;
        }
        public override string ToString()
        {
            return base.ToString() + (IsFleshEating ? "\nThis one thirsts for my blood" : "\nThis must be one of them new age vegan Zombies");
        }
        public override int CalcBlock()
        {
            int calculatedBlock = Block;
            if (IsFleshEating == true)
            {
                calculatedBlock += calculatedBlock + 2;
            }
            return calculatedBlock;
        }
        public override int CalcDamage()
        {
            int calculatedDamage = Damage;
            if (IsFleshEating == true) 
            { 
                calculatedDamage += calculatedDamage + 3;
            }
            return calculatedDamage;
        }
    }
}
