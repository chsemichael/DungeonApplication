using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Dragon : Monster
    {
        public bool HasSpicyBreath { get; set; } //Hit Chance
        public bool IsScaly { get; set; } // Block
        public bool HasBigWings { get; set; } // Life
        public bool HasSharpClaws { get; set; } //Damage

        public Dragon (string name, int hitChance, int block, int life, int damage, string description, bool hasSpicyBreath, bool isScaly, bool hasBigWings, bool hasSharpClaws) : base(name, hitChance, block, life, damage, description)
        {
            HasSpicyBreath = hasSpicyBreath;
            IsScaly = isScaly;
            HasBigWings = hasBigWings;
            HasSharpClaws = hasSharpClaws;
        }
        public override string ToString()
        {
            return base.ToString() + (HasSpicyBreath ? "\nThat breath is pure fire" : "\nThankfully its breath isn't Firey") + (IsScaly ? "\nCoated in a natural armor" : "\nIt's body is nice and smooth") + (HasBigWings ? "\nIt's wings make chicago look calm" : "\nAWWWWWWWW look at those tiny little wings") + (HasSharpClaws ? "\nThose claws look like they can cut me in half without touching me" : "\nHis claws are duller than a pencil after I took the A.C.T");
        }
        public override int CalcHitChance()
        {
            int calculatedHitChance = HitChance;
            if (HasSpicyBreath == true) 
            {
                calculatedHitChance += calculatedHitChance + 2;
            }
            return calculatedHitChance;
        }
        public override int CalcBlock()
        {
            int calculatedBlock = Block;
            if (IsScaly == true)
            {
                calculatedBlock += calculatedBlock + 4;
            }
            return calculatedBlock;
        }
        public override int CalcDamage()
        {
            int calculatedDamage = Damage;
            if (HasSharpClaws == true)
            {
                calculatedDamage += calculatedDamage + 2;
            }
            return calculatedDamage;
        }
        public override int CalcLife()
        {
            int calculatedLife = Life;
            if(HasBigWings == true)
            {
                calculatedLife += calculatedLife + 2;
            }
            return calculatedLife;
        }
        


    }
}
