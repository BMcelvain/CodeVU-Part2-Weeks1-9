using System;

namespace DnD
{
    public class Character
    {
        // Fields
        private string _name;
        private int _hitChance;
        private int _maxHealth;
        private int _health;
        private int _block;
        private int _score;
        private Weapon _weaponHeld;

        // Properties
        public string Name { get { return _name; } set { _name = value; } }
        public int HitChance { get { return _hitChance; } set { _hitChance = value; } }
        public int MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }
        public int Health
        {
            get { return _health; }
            set
            {
                if(value <= _maxHealth)
                {
                    _health = value;
                }
                else
                {
                    _health = 1;
                }
            }
        }
        public int Block { get { return _block; } set { _block = value; } }
        public int Score {  get { return _score; } set { _score = value; } }
        public Weapon WeaponHeld { get { return _weaponHeld; } set { _weaponHeld = value; } }


        // Constructors
        public Character () { }
        
        public Character (string name, int hitChance, int maxHealth, int health, int block, Weapon weaponHeld, int score = 0)
        {
            Name = name;
            HitChance = hitChance;
            MaxHealth = maxHealth;
            Health = health;
            Block = block;
            WeaponHeld = weaponHeld;
            Score = score;
        }


        // Methods

        // Method that gives the user's hero a starting weapon and stat
        // based on their selection of class (Barbarian).
        public Hero GenerateBarbarian()
        {
            Weapon greatAxe = new Weapon
            {
                Name = "Great Axe",
                MaxDamage = 10,
                MinDamage = 5,
                IsTwoHanded = false,
                BonusHitChance = 3
            };

            Shield greatShield = new Shield
            {
                Name = "Great Shield",
                BonusBlockChance = 3
            };

            Hero mainPlayer = new Hero
            {
                Name = "Brett",
                HitChance = 4,
                MaxHealth = 100,
                Health = 100,
                Block = 2,
                WeaponHeld = greatAxe,
                ShieldHeld = greatShield
            };

            return mainPlayer;
        }


        // Method that gives the user's hero a starting weapon and stat
        // based on their selection of class (Warlock).
        public Hero GenerateWarlock()
        {
            Weapon elderStaff = new Weapon
            {
                Name = "Elder Staff",
                MaxDamage = 25,
                MinDamage = 10,
                IsTwoHanded = true,
                BonusHitChance = 0
            };

            Hero mainPlayer = new Hero
            {
                Name = "Brett",
                HitChance = 6,
                MaxHealth = 75,
                Health = 75,
                Block = 2,
                WeaponHeld = elderStaff
            };

            return mainPlayer;
        }


        // Method that gives the user's hero a starting weapon and stat
        // based on their selection of class (Thief).
        public Hero GenerateThief()
        {
            Weapon goldenDagger = new Weapon
            {
                Name = "Golden Dagger",
                MaxDamage = 10,
                MinDamage = 1,
                IsTwoHanded = false,
                BonusHitChance = 4
            };

            Hero mainPlayer = new Hero
            {
                Name = "Brett",
                HitChance = 4,
                MaxHealth = 125,
                Health = 125,
                Block = 3,
                WeaponHeld = goldenDagger
            };

            return mainPlayer;
        }


        // Method that returns a Character's hit chance + bonus hit chance from their equipped weapon.
        public int DetermineHitChance()
        {
            return (this.HitChance + this.WeaponHeld.BonusHitChance);
        }


        // Method that returns a random number between the min and the max damage of the Character's weapon.
        // This value is the amount of damage done by a Character. 
        public int DetermineDamage()
        {
            Random randomNum = new Random();

            return randomNum.Next(this.WeaponHeld.MinDamage, (this.WeaponHeld.MaxDamage) + 1); 
        }


        // Method that compares the Character's (hit chance + weapon bonus hit chance) against a random d10 roll.
        // If the Character's hit chance is >= the d10 roll, the Character's lands the 
        // attack (return true).
        // Else, the attack misses (return false).
        public bool DetermineIfMissedAttack()
        {
            Random randomNum = new Random();
            int d10RollForHit = randomNum.Next(1,11);
            //Console.WriteLine(this.HitChance + this.WeaponHeld.BonusHitChance);
            //Console.WriteLine(d10RollForHit);
            if ((this.HitChance + this.WeaponHeld.BonusHitChance) >= d10RollForHit)
            {
                return true;
            } else
            {
                return false;
            }
        }


        // Method that compares the Character's block chance against a random d10 roll. 
        // If the Character's block chance is >= the d10 roll, the Character blocks the 
        // attack (return true).
        // Else, the attack does damage (return false).
        public bool DetermineIfAttackBlocked()
        {
            Random randomNum = new Random();
            int d10RollForBlock = randomNum.Next(1,11);
            if (this.Block >= d10RollForBlock)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}