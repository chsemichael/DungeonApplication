using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public  class Player : Character
    {
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Player(string name, int hitChance, int block, int life, Race characterRace, Weapon equippedWeapon) : base (name, hitChance, block, life)
        {
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;

            
        }
        public Player() { }

        public override string ToString()
        {
            string description = "";

            switch (CharacterRace)
            {
                case Race.Orc:
                    description = "Orc";
                    break;
                case Race.Human:
                    description = "Human";
                    break;
                case Race.Elf:
                    description = "Elf";
                    break;
                case Race.Halfling:
                    description = "Halfling";
                    break;
                case Race.Gnome:
                    description = "Gnome";
                    break;
                case Race.Dwarf:
                    description = "Dwarf";
                    break;
                case Race.Dragonborn:
                    description = "DragonBorn";
                    break;
            }


            return string.Format(
                $"Name: {Name}\n"  +
                $"Race: {description}\n" +
                $"{EquippedWeapon}" +
                $"HP: {Life}\n"
                );
        }
        public override int CalcDamage()
        {
            Random rand = new Random();
            int damage = rand.Next(EquippedWeapon.Damage + 1);
            return damage;
        }
        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }
     

    }
}
