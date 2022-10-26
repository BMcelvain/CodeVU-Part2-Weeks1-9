using System;

namespace DnD
{
    public class Villian : Character
    {
        // Constructors
        public Villian() { }

        public Villian(string name, int hitChance, int maxHealth, int health, int block, Weapon weaponHeld, int score = 0)
        {
            Name = name;
            HitChance = hitChance;
            MaxHealth = maxHealth;
            Health = health;
            Block = block;
            WeaponHeld = weaponHeld;
            Score = score;
        }

        // Method that randomly chooses what the Villian says during a given scenario.
        // (Int) Situation:
        //     1 = Introduction
        //     2 = Villian's Victory
        //     3 = Villian's Defeat
        //     4 = Player tried to run away
        public string VillianMonologue(int situation)
        {
            string[] intros = { "Hmmm... Very well.", "I'll enjoy the company, while it lasts.", "I'll make your death a swift one." };
            string[] victory = { "Put these foolish ambitions to rest.", "Twas nobly fought.", "Inevitable." };
            string[] defeat = { "I can finally rest.", "Thank you... friend!", "Hmmm... I see." };
            string[] runAway = { "You fool...", "They all try to run...", "I thought you'd be different..." };

            Random randomNum = new Random();
            switch (situation)
            {
                case 1:
                    return (intros[randomNum.Next(0, intros.Length)]);
                case 2:
                    return (victory[randomNum.Next(0, victory.Length)]);
                case 3:
                    return (defeat[randomNum.Next(0, defeat.Length)]);
                case 4:
                    return (runAway[randomNum.Next(0, runAway.Length)]);
                default:
                    return "";
            }
        }
    }
}