using System;

namespace DnD
{
    public class Hero : Character
    {
        // Fields
        private Shield _shieldHeld;

        // Properties
        public Shield ShieldHeld { get { return _shieldHeld; } set { _shieldHeld = value; } }

        // Constructors
        public Hero() { }

        public Hero(string name, int hitChance, int maxHealth, int health, int block, Weapon weaponHeld, Shield shieldHeld)
        {
            Name = name;
            HitChance = hitChance;
            MaxHealth = maxHealth;
            Health = health;
            Block = block;
            WeaponHeld = weaponHeld;
            ShieldHeld = shieldHeld;
        }


        // Method that compares the Hero's block chance against a random d10 roll.
        // This method will check to see if a Hero has a shield equipped or not. 
        // If the Hero's block chance is >= the d10 roll, the Hero blocks the 
        // attack (return true).
        // Else, the attack does damage (return false). 
        public bool DetermineIfHeroBlocksAttack()
        {
            Random randomNum = new Random();
            int d10RollForBlock = randomNum.Next(1, 11);
            int blockChance;

            if (this.ShieldHeld != null)
            {
                blockChance = this.Block + this.ShieldHeld.BonusBlockChance;
            } else
            {
                blockChance = this.Block;
            }

            if (blockChance >= d10RollForBlock)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // Method that determines the block chance of the Hero. If the hero has a shield,
        // hero's block chance is block + bonuse block chance from the shield.
        // Else, block chance is just the hero's block.
        public int DetermineHeroBlockChance()
        {
            int blockChance;
            if (this.ShieldHeld != null)
            {
                blockChance = this.Block + this.ShieldHeld.BonusBlockChance;
            } else
            {
                blockChance = this.Block;
            }
            return blockChance;
        }
    }
}