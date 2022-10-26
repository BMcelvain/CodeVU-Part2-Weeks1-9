using System;

namespace DnD
{
    public class Weapon
    {
        // Fields
        private string _name;
        private int _minDamage;
        private int _maxDamage;
        private bool _isTwoHanded;
        private int _bonusHitChance;

        // Properties
        public string Name { get { return _name; } set { _name = value; } }
        public int MinDamage 
        { 
            get { return _minDamage; }
            set 
            { 
                if(value > 0 & value < MaxDamage)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            } 
        }
        public int MaxDamage { get { return _maxDamage; } set { _maxDamage = value; } }
        public bool IsTwoHanded { get { return _isTwoHanded; } set { _isTwoHanded = value;  } }
        public int BonusHitChance { get { return _bonusHitChance;  } set { _bonusHitChance = value;  } }

        // Constructors
        public Weapon() { }

        public Weapon (string name, int maxDamage, int minDamage, bool isTwoHanded, int bonusHitChance)
        {
            Name = name;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            IsTwoHanded = isTwoHanded;
            BonusHitChance = bonusHitChance;
        }
    }
}