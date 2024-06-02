using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Griffin : Monster
    {
        public bool HasFeatherlyWings { get; set; }
        public bool HasSharpTalons { get; set; }
        public bool HasSharpBeak { get; set; }

        public Griffin(string name, int hitChance, int block, int life, int damage, string description, bool hasFeatherlyWings, bool hasSharpTalons, bool hasSharpBeak) : base(name, hitChance, block, life, damage, description)
        {
            HasFeatherlyWings = hasFeatherlyWings;
            HasSharpTalons = hasSharpTalons;
            HasSharpBeak = hasSharpBeak;
        }
        public override string ToString()
        {
            return base.ToString() + (HasFeatherlyWings ? "\nThose wings look recently molted" : "\nIts feathers look worn") + (HasSharpTalons ? "\nThose talons look razor sharp" : "\nIt looks like its time to sharpen those talons man") + (HasSharpBeak ? "\nThat beak looks primed and ready to eat some meat" : "\nMan that beak looks like its gonna take some time to eat something");
        }
        public override int CalcHitChance()
        {
            int calculatedHitChance = HitChance;
            if (HasSharpBeak == true) 
            {
                calculatedHitChance += calculatedHitChance + 2;
            }
            return calculatedHitChance;
        }
        public override int CalcBlock()
        {
            int calculatedBlock = Block;
            if(HasFeatherlyWings == true)
            {
                calculatedBlock += calculatedBlock + 1;
            }
            return calculatedBlock;
        }
        public override int CalcDamage()
        {
            int calculatedDamage = Damage;
            if (HasSharpTalons  == true)
            {
                calculatedDamage += calculatedDamage + 3;
            }
            return calculatedDamage;
        }
    }
}
