using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DungeonLibrary
{
    public class Weapon
    {

        //FIELDS
        private int _damage;
    private string _name;
    private int _bonusHitChance;
    private bool _isTwoHanded;
    private WeaponType _type;

    //PROPERTIES
    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public int BonusHitChance
    {
        get { return _bonusHitChance; }
        set { _bonusHitChance = value; }
    }
    public bool IsTwoHanded
    {
        get { return _isTwoHanded; }
        set { _isTwoHanded = value; }
    }
    


    public WeaponType Type
    {
        get { return _type; }
        set { _type = value; }
    }

    //CONSTRUCTORS
    public Weapon( int damage, string name, int bonusHitChance,
        bool isTwohanded, WeaponType type)
    {
        //ANY properties with business rules based off of OTHER properties
        //MUST come AFTER those other properties are set. In this case, our 
        //MinDamage has business rules that reference MaxDamage, so we 
        //MUST set MaxDamage FIRST.
        Damage = damage;
        Name = name;
        BonusHitChance = bonusHitChance;
        IsTwoHanded = isTwohanded;
        Type = type;
    }
        public Weapon() { }

        //METHODS
        public override string ToString()
        {
            return string.Format(
                $"Weapon Type: {Type}\n" +
                $"Weapon Name: {Name}\n" +
                $"Damage: {Damage}\n" +
                $"Bonus Hit Chance: {BonusHitChance}%\n" +
                $"Is Two Handed: {(IsTwoHanded ? "Yes" : "No")}\n"
                );
    }
}

}
