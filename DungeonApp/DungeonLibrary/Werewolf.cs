using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Werewolf : Monster
    {
        public bool IsFullMoon { get; set; }

        public Werewolf(string name, int hitChance, int block, int life, int damage, string description, bool isFullMoon) : base(name, hitChance, block, life, damage, description)
        {
            IsFullMoon = isFullMoon;
        }
        public override string ToString()
        {
            return base.ToString() + (IsFullMoon ? "\nThe moon is full... The Werewolf is as strong as ever" : "\nLooks like a sligtly less jacked Werewolf");
        }
        public override int CalcBlock()
        {
            int calculatedBlock = Block;
            if (IsFullMoon == true)
            {
                calculatedBlock += calculatedBlock + 5;
            }
            return calculatedBlock;
        }
        public override int CalcDamage()
        {
            int calculatedDamage = Damage;
            if (IsFullMoon == true) 
            {
                calculatedDamage += calculatedDamage + 9;
            }
            return calculatedDamage;
        }
        public override int CalcHitChance()
        {
            int calculatedHitChance = HitChance;
            if (IsFullMoon == true) 
            {
                calculatedHitChance += calculatedHitChance + 10;
            }
            return calculatedHitChance;
        }
        public override int CalcLife()
        {
            int calculatedLife = Life;
            if (IsFullMoon == true)
            {
                calculatedLife += calculatedLife + 5;
            }
            return calculatedLife;
        }
    }
}
