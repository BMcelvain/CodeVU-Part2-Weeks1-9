using System;
using System.Runtime.InteropServices;

namespace DnD
{
    public class Room
    {
        private string _description;
        private Character _monster;
        private Villian _villian;


        public string Description { get { return _description; } set { _description = value; } }
        public Character Monster { get { return _monster; } set { _monster = value; } }
        public Villian MainVillian { get { return _villian; } set { _villian = value; } }

        public Room() { }


        //
        //
        //
        static Weapon GenerateWeapon()
        {
            string[] weaponName = { "Forgotten Cleaver", "Holy Pincer", "Stone Breaker", " Winter's Bane", "Heart of Mountain", "Molten Greatsword", "Ice Shard", "Titan's Gladius", "Orge's Club", "Heaven's Bolt" };
            Random randomNum = new Random();

            // Randomly detemine if the weapon is two handed or not.
            bool twoHandedWeapon;
            int isTwoHanded = randomNum.Next(0, 2);
            if (isTwoHanded == 0)
            { twoHandedWeapon = false; }
            else { twoHandedWeapon = true; }

            Weapon newWeapon = new Weapon
            {
                Name = weaponName[randomNum.Next(0, weaponName.Length)],
                MaxDamage = randomNum.Next(2, 30),
                MinDamage = randomNum.Next(1, 10),
                IsTwoHanded = twoHandedWeapon,
                BonusHitChance = randomNum.Next(0, 6)
            };

            return newWeapon;
        }

        // Method that randomly generates a monster. 
        // It will choose a name for the monster assign stats at random. 
        public Character GenerateMonster()
        {
            // Array of monster names. 
            string[] monsterName = { "Arch Demon", "Titan", "Arch Angel", "Gold Dragon", "Black Dragon", "Dread Knight", "Battle Dwarf", "Elven Warrior", "Ancient Genie", "Behemoth" };
            Random randomNum = new Random();

            // Determine MaxHealth/Health of the monster at random.
            // Monster's max health/health will be 50-75.
            // randomNum.Next(inclusive min. value, exclusive max value).
            int healthTotal = randomNum.Next(50, 76);

            Character newMonster = new Character()
            {
                Name = monsterName[randomNum.Next(0, monsterName.Length)],

                // hit chance will be between 1-6 (ie. 10-60% hit chance)
                HitChance = randomNum.Next(1, 7),
                MaxHealth = healthTotal,
                Health = healthTotal,

                // block will be between 1-3 (ie. 10-30% block chance)
                Block = randomNum.Next(1, 4),

                // Randomly generate a weapon and assign it to the monster. 
                WeaponHeld = GenerateWeapon()
            };

            return newMonster;
        }


        // Method that randomly generates a villian. 
        // It will choose a name for the villian assign stats at random. 
        public Villian GenerateVillian()
        {
            // Array of villian names (same as monster name, but all of them begin with 'Grand')
            string[] monsterName = { "Grand Arch Demon", "Grand Titan", "Grand Arch Angel", "Grand Gold Dragon", "Grand Black Dragon", "Grand Dread Knight", "Grand Battle Dwarf", "Grand Elven Warrior", "Grand Ancient Genie", "Grand Behemoth" };

            Random randomNum = new Random();

            // Determine MaxHealth/Health of the villian at random.
            // Villian's max health/health will be 200-250.
            // randomNum.Next(inclusive min. value, exclusive max value).
            int healthTotal = randomNum.Next(200, 251);

            Villian newVillian = new Villian()
            {
                Name = monsterName[randomNum.Next(0, monsterName.Length)],

                // hit chance will be between 1-8 (ie. 10-80% hit chance)
                HitChance = randomNum.Next(1, 9),
                MaxHealth = healthTotal,
                Health = healthTotal,

                // block will be between 1-7 (ie. 10-70% block chance)
                Block = randomNum.Next(1, 8),

                // Randomly generate a weapon and assign it to the villian.
                WeaponHeld = GenerateWeapon()
            };

            return newVillian;
        }


        // Method that randomly determines the size, brightness, and style of a room that will be used for the fight.
        // Returns a string with all 3 descriptions combined. 
        public string RoomDescription()
        {
            string[] roomSize = { "small", "medium", "large" };
            string[] roomBrightness = { "nearly pitch black", "dimly lit", "well lit" };
            string[] roomStyle = { "sewer", "dungeon", "tunnel", "corridor" };
            Random randomNum = new Random();

            string size = roomSize[randomNum.Next(0, roomSize.Length)];
            string brightness = roomBrightness[randomNum.Next(0, roomBrightness.Length)];
            string style = roomStyle[randomNum.Next(0, roomStyle.Length)];

            string roomDescription = size + ' ' + brightness + ' ' + style;
            return roomDescription;
        }
    }
}