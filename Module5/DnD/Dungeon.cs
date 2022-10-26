using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DnD
{
    public class Dungeon
    { 
        public static void Main(string[] argc)
        {
            // Introduction
            Console.Title = "DUNGEON OF DOOM!";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nWelcome to the Dungeon of Doom!\n------------------------------\n");
            Console.WriteLine("Many have walked the path before you...\nmany have failed.\n");
            Console.ForegroundColor = ConsoleColor.White;

            bool playerOrMonsterDead = false;
            bool characterCreated = false;
            Hero mainPlayer = new Hero();

            // Randomly generates 3-5 dungeon rooms:
            // each room is given a randomly generated monster (last room in dungeon is assigned a randomly generated villian)
            List<Room> dungeonRooms = GenerateDungeonRooms();


            // do-while loop that will continue until the user selects a valid option for character class. 
            do
            { 
                Console.WriteLine("Please select the class of character you'd like to be:\nB.) Barbarian\nW.) Warlock\nT.) Thief\n");
                ConsoleKey userChoice = Console.ReadKey(intercept: true).Key;

                switch (userChoice)
                {
                    // Barbarian
                    case ConsoleKey.B:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("A Barbarian, aye? Wise choice!");
                        Console.ForegroundColor = ConsoleColor.White;
                        mainPlayer = mainPlayer.GenerateBarbarian();
                        characterCreated = true;
                        break;
                    
                    // Warlock
                    case ConsoleKey.W:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("A Warlock, aye? Wise choice!");
                        Console.ForegroundColor = ConsoleColor.White;
                        mainPlayer = mainPlayer.GenerateWarlock();
                        characterCreated = true;
                        break;

                    // Thief
                    case ConsoleKey.T:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("A Thief, aye? Wise choice!");
                        Console.ForegroundColor = ConsoleColor.White;
                        mainPlayer = mainPlayer.GenerateThief();
                        characterCreated = true;
                        break;
                    
                    // If the user makes an innappropriate selection.
                    default:
                        Console.WriteLine("Please press B for Barbarian, W for Warlock, or T for Thief.");
                        break;
                }
            } while (!characterCreated);

            // Foreach loop that will loop through each room of the dugneon, until the villian is defeated (end of dungeon) or the user is defeated. 
            foreach(Room dungeonRoom in dungeonRooms)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\nYou find yourself in a {0}. You hear something off in the distance...", dungeonRoom.Description);
                try
                {
                    Console.WriteLine("You ready your weapon as a(an) {0} locks eyes with you.",dungeonRoom.Monster.Name);
                } catch { 
                    Console.WriteLine("You ready your weapon as a(an) {0} locks eyes with you.", dungeonRoom.MainVillian.Name);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nYou hear the {0} say, '{1}'!", dungeonRoom.MainVillian.Name, dungeonRoom.MainVillian.VillianMonologue(1));
                }
                Console.ForegroundColor = ConsoleColor.White;
                
                playerOrMonsterDead = false;
                do
                {
                    Console.WriteLine("\nPlease choose an action:\nA.) Attack\nR.) Run Away\nP.) Player Info\nM.) Monster Info\nE.) Exit\n");
                    ConsoleKey userSelection = Console.ReadKey(intercept: true).Key;

                    switch(userSelection)
                    {
                        // If the user chooses to attack (A):
                        case ConsoleKey.A:

                            // Check to see if user's attack misses.
                            if (mainPlayer.DetermineIfMissedAttack())
                            {
                                // If user's attack hits, check to see if the rooom has a monster or a villian.
                                if (dungeonRoom.Monster != null) 
                                {
                                    // If room has a monster, determine if the monster blocks the user's attack.
                                    if (dungeonRoom.Monster.DetermineIfAttackBlocked())
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("The {0} blocked your attack!", dungeonRoom.Monster.Name);
                                        Console.ForegroundColor = ConsoleColor.White;
                                    } else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        int damageDealt = mainPlayer.DetermineDamage();
                                        dungeonRoom.Monster.Health -= damageDealt;
                                        Console.WriteLine("You did {0} to the {1}!", damageDealt, dungeonRoom.Monster.Name);
                                        Console.WriteLine("The {0} has {1} health remaining!", dungeonRoom.Monster.Name, dungeonRoom.Monster.Health);
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                } else {

                                    // If room has a villian, determine if the villian blocks the user's attack. 
                                    if (dungeonRoom.MainVillian.DetermineIfAttackBlocked())
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("The {0} blocked your attack!", dungeonRoom.MainVillian.Name);
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    else
                                    {
                                        int damageDealt = mainPlayer.DetermineDamage();
                                        dungeonRoom.MainVillian.Health -= damageDealt;
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("You did {0} to the {1}!", damageDealt, dungeonRoom.MainVillian.Name);
                                        Console.WriteLine("The {0} has {1} health remaining", dungeonRoom.MainVillian.Name, dungeonRoom.MainVillian.Health);
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                }
                            } else
                            {
                                // The user's attack misses. 
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Your attack missed!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            // Check the health of the monster or villian after the user's attack. 
                            if (dungeonRoom.Monster != null)
                            {
                                // Monster is dead. 
                                if (IsCharacterDead(dungeonRoom.Monster))
                                {
                                    MonsterDefeated(mainPlayer, dungeonRoom.Monster);
                                    playerOrMonsterDead = true;
                                }
                                else
                                {
                                    // User is dead.
                                    MonsterAttack(mainPlayer, dungeonRoom.Monster);
                                    if (IsCharacterDead(mainPlayer))
                                    {
                                        Console.WriteLine("\n*****  You Died!  *****");
                                        Environment.Exit(0);
                                    }
                                }
                            } else
                            {   
                                // Villian is dead. 
                                if (IsCharacterDead(dungeonRoom.MainVillian))
                                {
                                    VillianDefeated(mainPlayer, dungeonRoom.MainVillian);
                                    playerOrMonsterDead = true;
                                }
                                else
                                {
                                    // User is dead. 
                                    VillianAttack(mainPlayer, dungeonRoom.MainVillian);
                                    if (IsCharacterDead(mainPlayer))
                                    {
                                        Console.WriteLine("\n*****  You Died!  *****");
                                        Environment.Exit(0);
                                    }
                                }
                            }

                            break;
                        
                        // If the user chooses to run away (R):
                        case ConsoleKey.R:

                            // Ask user if they accept the 10% reduction in max health penalty for running away.
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Are you sure that you want to run away (Y/N)?\n\tYou will suffer a 10% max health penalty!");
                            ConsoleKey userChoice = Console.ReadKey(intercept: true).Key;
                            switch (userChoice)
                            {
                                // If user accepts the penalty (Y), reduces max health by 10%
                                case ConsoleKey.Y:
                                    int healthLost = Convert.ToInt32(mainPlayer.MaxHealth * .1);
                                    Console.WriteLine("You lost {0} max health!", healthLost);
                                    mainPlayer.MaxHealth -= healthLost;
                                    playerOrMonsterDead = true;
                                    break;
                                
                                // If user any key other than (Y), assume user doesn't accept the penalty. 
                                default:
                                    Console.WriteLine("\nI see that you have changed your mind!");
                                    break;
                            }
                            Console.ForegroundColor = ConsoleColor.White;

                            break;

                        // If the user would like to see the Player Stats (P):
                        case ConsoleKey.P:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            string isTwoHanded;
                            if (mainPlayer.WeaponHeld.IsTwoHanded == true)
                            {
                                isTwoHanded = "Two-Handed";
                            } else
                            {
                                isTwoHanded = "One-Handed";
                            }

                            // Display user's stats.
                            Console.WriteLine("\nYour Stats:\n\tMax Health: {0}" +
                                "\n\tHealth: {1}" +
                                "\n\tBlock (with shield bonus): {2}" +
                                "\n\tHit Chance (with weapon bonus): {3}",
                                mainPlayer.MaxHealth,
                                mainPlayer.Health,
                                mainPlayer.DetermineHeroBlockChance(),
                                mainPlayer.DetermineHitChance());

                            // Display user's weapons stats. 
                            Console.WriteLine("\nYour Weapon Stats:\n\tMin. Damage: {0}" +
                                "\n\tMax Damage: {1}" +
                                "\n\tBonus Hit Chance: {2} \n\t{3}",
                                mainPlayer.WeaponHeld.MinDamage,
                                mainPlayer.WeaponHeld.MaxDamage,
                                mainPlayer.WeaponHeld.BonusHitChance,
                                isTwoHanded);
                            Console.ForegroundColor = ConsoleColor.White;

                            break;

                        // If the user would like to see the monster's stats (M):
                        case ConsoleKey.M:

                            // If room has a monster, display monster's stats. Keep the weapons stats a mystery to user. 
                            if (dungeonRoom.Monster != null)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\nThe {0}'s Stats:\n\tMax Health: {1}" +
                                    "\n\tHealth: {2}" +
                                    "\n\tBlock: {3}" +
                                    "\n\tHit Chance: {4}",
                                    dungeonRoom.Monster.Name,
                                    dungeonRoom.Monster.MaxHealth,
                                    dungeonRoom.Monster.Health,
                                    dungeonRoom.Monster.Block,
                                    dungeonRoom.Monster.DetermineHitChance());
                                Console.ForegroundColor = ConsoleColor.White;
                            } else
                            {
                                // // If room has a villian, display villian's stats. Keep the weapons stats a mystery to user. 
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("\nThe {0}'s Stats:\n\tMin. Damage: {1}" +
                                    "\n\tMax Damage: {2}" +
                                    "\n\t Block: {3}" +
                                    "\n\tHit Chance: {4}",
                                    dungeonRoom.MainVillian.Name,
                                    dungeonRoom.MainVillian.MaxHealth,
                                    dungeonRoom.MainVillian.Health,
                                    dungeonRoom.MainVillian.Block,
                                    dungeonRoom.MainVillian.DetermineHitChance());
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;

                        // If the user would like to exit (E):
                        case ConsoleKey.E:
                            Environment.Exit(0);
                            break;
                    }
                } while (!playerOrMonsterDead);
            }
        }


        // Method to check to see if a Character has <= 0 health (ie. has been defeated).
        // Returns:
        //      true   - if dead
        //      false  - if alive
        static bool IsCharacterDead(Character character)
        {
            if (character.Health <= 0)
            {
                return true;
            } else
            {
                return false;
            }
        }


        // Method to randomly generate 3-5 rooms for the dungeon and adds them to a list
        // Returns:
        //      List<Room> of all Rooms for the dungeon
        static List<Room> GenerateDungeonRooms()
        {
            Random randomNum = new Random();

            // Randomly determines if there will be 3-5 rooms. (randomNum.Next(inclusive min. value, exclusive max. value))
            int numberOfRoomsInDungeon = randomNum.Next(3,6);
            List<Room> dungeonRooms = new List<Room>();

            // for loop that will generate and assign a monster for all rooms except for the last room. 
            // The last room will be assigned a Villian.
            for (int i = 1; i <= numberOfRoomsInDungeon; i++)
            { 
                Room newRoom = new Room();

                if (i == numberOfRoomsInDungeon)
                {
                    newRoom.MainVillian = newRoom.GenerateVillian();
                } else { 
                    newRoom.Monster = newRoom.GenerateMonster();
                }
                newRoom.Description = newRoom.RoomDescription();
                dungeonRooms.Add(newRoom);
            }
            return dungeonRooms;
        }


        // Method that takes in the user's hero and the monster assigned to the current room. 
        static void MonsterAttack(Hero mainPlayer, Character roomMonster)
        {
            bool attackHits = roomMonster.DetermineIfMissedAttack();

            // If monster's attack hits, proceed else notify user that monster's attack missed. 
            if (attackHits)
            {
                // If monster's attack hits, determine if the user blocks the monster's attack. 
                bool attackBlocked = mainPlayer.DetermineIfHeroBlocksAttack();

                // User block the monster's attack. 
                if (attackBlocked)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYou blocked the {0}'s attack!", roomMonster.Name);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    // User didn't block the monster's attack. 
                    int damageDoneToPlayer = roomMonster.DetermineDamage();
                    mainPlayer.Health -= damageDoneToPlayer;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThe {0} does {1} damage to you!", roomMonster.Name, damageDoneToPlayer);
                    Console.WriteLine("You have {0} health remaining.", mainPlayer.Health);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                // Monster's attack missed. 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThe {0}'s attack missed!", roomMonster.Name);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }


        // Method that takes in the user's hero and the villian assigned to the current room. 
        static void VillianAttack(Hero mainPlayer, Villian mainVillian)
        {
            bool attackHits = mainVillian.DetermineIfMissedAttack();

            // If villian's attack hits, proceed else notify user that villian's attack missed. 
            if (attackHits)
            {
                // If villian's attack hits, determine if the user blocks the villian's attack.
                bool attackBlocked = mainPlayer.DetermineIfHeroBlocksAttack();

                // User block the villian's attack.
                if (attackBlocked)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nYou blocked the {0}'s attack!", mainVillian.Name);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    // User didn't block the villian's attack.
                    int damageDoneToPlayer = mainVillian.DetermineDamage();
                    mainPlayer.Health -= damageDoneToPlayer;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThe {0} does {1} damage to you!", mainVillian.Name, damageDoneToPlayer);
                    Console.WriteLine("You have {0} health remaining.", mainPlayer.Health);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                // Villian's attack missed. 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThe {0}'s attack missed!", mainVillian.Name);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }


        // Method that takes in the user's hero and the monster assigned to the current room.  
        // Checks with the user if they would like to swap their current weapon for the 
        // monster's weapon, asks the user what stat they would like an 10% upgrade to (max
        // health, hit chance, or block), and calculates the score the user recieves for defeating
        // the monster. 
        static void MonsterDefeated(Hero mainPlayer, Character roomMonster)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n*****  Well Done!  *****");
            WeaponSwap(mainPlayer, roomMonster);
            Console.ForegroundColor = ConsoleColor.Magenta;
            StatUpgrades(mainPlayer);

            // Replenish user's health prior to next room.  
            mainPlayer.Health = mainPlayer.MaxHealth;

            // Add monster's score to user's score:
                // monster's score is (monster's total health * 1.(monster's block) * 1.(monster's hit chance))
                // For example, if the monster had 100 health, 5 block, and 6 hit chance (100 * 1.5 * 1.6) => 240 points would be assigned to the user. 
            mainPlayer.Score += Convert.ToInt32(roomMonster.MaxHealth * ((roomMonster.Block + 10) / 10) * (roomMonster.HitChance + 10) / 10);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nYour Total Score: {0}", mainPlayer.Score);
            Console.ForegroundColor = ConsoleColor.White;
        }


        // Method that takes in the user's hero and the villian assigned to the current room.  
        // Checks with the user if they would like to swap their current weapon for the 
        // villian's weapon, calculates the score the user recieves for defeating
        // the villian, and determines if the user has recieved a high score or not.  
        static void VillianDefeated(Hero mainPlayer, Villian mainVillian)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n*****  Victory!  *****");

            // Add villian's score to user's score:
                // villian's score is (villian's total health * 1.(villian's block) * 1.(villian's hit chance))
                // For example, if the villian had 100 health, 5 block, and 6 hit chance (100 * 1.5 * 1.6) => 240 points would be assigned to the user. 
            mainPlayer.Score += Convert.ToInt32(mainVillian.MaxHealth * ((mainVillian.Block + 10) / 10) * (mainVillian.HitChance + 10) / 10);
            Console.WriteLine("\nTotal Score: {0}", mainPlayer.Score);
            DetermineIfHighScore(mainPlayer);
            Console.ForegroundColor = ConsoleColor.White;

            // WeaponSwap(mainPlayer, mainVillian); so that player can have Villian's weapon for NewGame+?
            // Save Hero Object so that the player can return and do a NewGame+?
        }


        // Method that takes in the user's hero and the monster assigned to the current room.
        // Asks user if they would like to swap their current weapon for the monster they just
        // defeated. If user pressed (Y), the monster's weapon will be assigned to them and their
        // old weapon will be discarded. If the user presses (N), the user continues on the the 
        // next room in the dungeon. 
        static void WeaponSwap(Hero mainPlayer, Character roomMonster)
        {
            bool playerHasChosen = false;
            do
            {
                Console.WriteLine("\nWould you like to swap your weapon for {0} (Y/N)?", roomMonster.WeaponHeld.Name);

                // Display user's current weapon stats. 
                Console.WriteLine("\nYour current weapon:\n\tMin. Damage:{0}\n\tMax Damage:{1}\n\tBonus Hit Chance:{2}", mainPlayer.WeaponHeld.MinDamage, mainPlayer.WeaponHeld.MaxDamage, mainPlayer.WeaponHeld.BonusHitChance);

                // Display monster's weapon stats. 
                Console.WriteLine("\n{0}'s weapon:\n\tMin. Damage:{1}\n\tMax Damage:{2}\n\tBonus Hit Chance:{3}", roomMonster.Name, roomMonster.WeaponHeld.MinDamage, roomMonster.WeaponHeld.MaxDamage, roomMonster.WeaponHeld.BonusHitChance);
                ConsoleKey userSelection = Console.ReadKey(intercept: true).Key;

                switch (userSelection)
                {
                    // Yes 
                    case ConsoleKey.Y:
                        Console.WriteLine("\nYou swap your {0} for the {1}!", mainPlayer.WeaponHeld.Name, roomMonster.WeaponHeld.Name);
                        mainPlayer.WeaponHeld = roomMonster.WeaponHeld;
                        playerHasChosen = true;
                        break;

                    // No
                    case ConsoleKey.N:
                        Console.WriteLine("\nYou leave the {0} behind as you march on!", roomMonster.WeaponHeld.Name);
                        playerHasChosen = true;
                        break;

                    // Invalid response. 
                    default:
                        Console.WriteLine("\nPlease press Y for yes or N for no.");
                        break;
                }
            } while (!playerHasChosen);
        }


        // Method that takes in the user's hero.
        // Asks the user if they would like a 10% boost to their max health, hit chance, or block.
        // If the user selects max health (M), boost max health by .1
        // If the user selects hit chance (H), boost hit chance by 1. (ie. 10 hit chance is 100% hit chance => 1 is 10% boost in hit chance.)
        // If the user selects block (B), boost block by 1. (ie. 10 block is 100% block chance => 1 is 10% boost in block.)
        static void StatUpgrades(Hero mainPlayer)
        {
            bool playerHasChosen = false;
            do
            { 
                Console.WriteLine("\nWould you like a 10% boost in:\n\tM. Max Health\n\tH. Hit Chance\n\tB. Block");
                ConsoleKey userSelection = Console.ReadKey(intercept: true).Key;
                switch (userSelection)
                {
                    // User selects 10% boost to max health.
                    case ConsoleKey.M:
                        int upgradedMaxHealth = Convert.ToInt32(mainPlayer.MaxHealth * .1);
                        Console.WriteLine("\nYou have gained {0} max health!", upgradedMaxHealth);
                        mainPlayer.MaxHealth += upgradedMaxHealth;
                        playerHasChosen = true;
                        break;

                    // User selects 10% boost to hit chance.
                    case ConsoleKey.H:
                        Console.WriteLine("\nYou have gained 1 hit chance!");
                        mainPlayer.HitChance += 1;
                        playerHasChosen = true;
                        break;

                    // User selects 10% boost to block.
                    case ConsoleKey.B:
                        Console.WriteLine("\nYou have gained 1 block!");
                        mainPlayer.Block += 1;
                        playerHasChosen = true;
                        break;

                    // Invalid response. 
                    default:
                        Console.WriteLine("Please choose whether you would like to have a 10% boost to max health, hit chance, or block!");
                        break;
                }
            } while (!playerHasChosen);
        }


        // Method that takes in the user's hero. 
        // Reads the HighScores.txt file, parses out the high scores, and assigned them to the dictionary.
        // Then, compares the user's score to all the high scores. If the user has a high score, we add that 
        // score to the dictionary, sort the scores (ascending), reverse the scores so they are decending order, 
        // remove the lowest score, and writes the scores to HighScores.txt.
        static void DetermineIfHighScore(Hero mainPlayer)
        {
            Dictionary<int, string> highScores = new Dictionary<int, string>();

            // Reads lines from HighScores.txt and adds them to the dictionary
            // Key   - score
            // Value - name
            using (StreamReader fileReader = new StreamReader("HighScores.txt"))
            {
                while (!fileReader.EndOfStream)
                {
                    string line = fileReader.ReadLine();
                    string[] lineSegments = line.Split();
                    highScores.Add(Convert.ToInt32(lineSegments[0]), lineSegments[1]);
                }
                fileReader.Close();
            }
            
            // We add the date and time to the current score, so the user can determine 
            // which score is their newest score, should they open HighScores.txt
            DateTime currentDate = DateTime.Now;
            bool isHighScore = false;
            foreach (KeyValuePair<int, string> pair in highScores)
            {
                int score = pair.Key;
                if (mainPlayer.Score >= score)
                {
                    isHighScore = true;
                }
            }

            // If the user has a high score, we add that to the dictionary, sort the 
            // dictionary (ascending), reverse the order so that it is descending, 
            // and remove the lowest score from the list. 
            if (isHighScore == true)
            {
                Console.WriteLine("\nNew High Score!");
                highScores.Add(mainPlayer.Score, mainPlayer.Name + " " + currentDate);

                using(StreamWriter fileWriter = new StreamWriter("HighScores.txt"))
                { 
                    var scoreList = highScores.Keys.ToList();
                    scoreList.Sort();
                    scoreList.Reverse();
                    scoreList.RemoveAt(scoreList.Count - 1);

                    // Display the High Scores to the user. 
                    Console.WriteLine("\n----- High Scores -----\n");
                    foreach (var score in scoreList)
                    {
                        fileWriter.WriteLine("{0} {1}", score, highScores[score]);
                        Console.WriteLine("{0} {1}", score, highScores[score]);
                    }
                    fileWriter.Close();
                }      
            }
        } 
    }
}