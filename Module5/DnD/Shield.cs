using System;

namespace DnD
{
    public class Shield : Weapon
    {
        // Fields
        private int _bonusBlockChance;

        // Properties
        public int BonusBlockChance { get { return _bonusBlockChance; } set { _bonusBlockChance = value; } }

        //Constructors
        public Shield() { }

        // Shield will do no damage, will only be one-handed, and will not have a bonus to hit chance.
        // Therefore, only need the name and the bonus to block chance. 
        public Shield(string name, int bonusBlockChance)
        {
            Name = name;
            MaxDamage = 0;
            MinDamage = 0;
            IsTwoHanded = false;
            BonusHitChance = 0;
            BonusBlockChance = bonusBlockChance;
        }
    }
}