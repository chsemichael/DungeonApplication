using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public abstract class Monster : Character
    {
        public int Damage { get; set; }
        public string Description { get; set; }

        public Monster(string name, int hitChance, int block, int life, int damage, string description) : base(name, hitChance, block, life)
        {
            Damage = damage;
            Description = description;
        }
        public override string ToString()
        {
            return string.Format(
                $"Name: {Name}\n" +
                $"Description: {Description}\n" +
                $"Damage: {Damage}\n" +
                $"Block: {Block}\n" +
                $"HP: {Life}\n" +
                $"Description: {Description}"
                );
        }
        public override int CalcDamage()
        {
            Random rand = new Random();
            return rand.Next(Damage + 1);
        }


    }
}
