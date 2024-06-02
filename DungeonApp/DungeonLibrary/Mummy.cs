using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Mummy : Monster
    {
        public bool HasCleanBandages { get; set; }

        public Mummy(string name, int hitChance, int block, int life, int damage, string description, bool hasClaenBandages) : base(name, hitChance, block, life, damage, description) 
        { 
            HasCleanBandages = hasClaenBandages;
        }
        public override string ToString()
        {
            return base.ToString() + (HasCleanBandages ? $"\nOh.... This looks like a recent mummy" : "\nOh no.... This is a ancient mummy");
        }
        public override int CalcDamage()
        {
            int calculatedDamage = Damage;
            if (HasCleanBandages == true) 
            { 
                calculatedDamage += calculatedDamage - 3;
            }
            else
            {
                calculatedDamage += calculatedDamage + 5;
            }
            return calculatedDamage;
        }
    }
}
