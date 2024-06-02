using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public abstract class Character
    {
        //FIELDS
        private int _life;
        private string _name;
        private int _hitChance;
        private int _block;
        

        //PROPERTIES
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int HitChance
        {
            get { return _hitChance; }
            set { _hitChance = value; }
        }
        public int Block
        {
            get { return _block; }
            set { _block = value; }
        }
        public int Life
        {
            get { return _life; }
            set { _life = value; }
        }
        


        //CONSTRUCTORS
        public Character(string name, int hitChance, int block, int life)
        {
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
        }
        public Character() { }

        //METHODS
        public override string ToString()
        {
            return string.Format(
                $"Name: {Name}\n" +
                $"Hitchance: {HitChance}\n" +
                $"Block: {Block}\n" +
                $"HP: {Life}\n"
                );
        }

        //Because we intend to use Character as a base class for
        //other, more specific classes (Player & Monster), we want 
        //those classes to have their own versions of the below
        //methods. We can override these methods in those classes 
        //(just like we do with the ToString()), but only if we
        //add the "virtual" modifier to the method signature.

        public virtual int CalcBlock()
        {
            return Block;
        }

        public virtual int CalcHitChance()
        {
            return HitChance;
        }

        public virtual int CalcDamage()
        {
            return 0;
        }
        public virtual int CalcLife()
        {
            return Life;
        }
    }
}

