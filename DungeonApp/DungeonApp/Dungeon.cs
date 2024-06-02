using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DungeonLibrary;

namespace DungeonApp
{
   
    class Dungeon
       
    {
        static void Main(string[] args)
        {
            Console.Title = "Dungeon";

            #region Weapon - Block 5
            Weapon sword = new Weapon(20, "Great Sword", 30, true, WeaponType.Sword);
            Weapon knife = new Weapon(12, "Dagger", 40, false, WeaponType.Knife);
            Weapon bowAndArrow = new Weapon(30, "Hunting Bow", 20, true, WeaponType.Projectile);
            Weapon fireOrb = new Weapon(40, "Fire Orb", 49, true, WeaponType.Fire);
            Weapon iceOrb = new Weapon(40, "Ice Orb", 49, true, WeaponType.Ice);

            #endregion

            #region Variable to Track Score

            int score = 0;

            #endregion

            bool exit = false;
            
             
                Console.WriteLine("Would you like to take the plunge? Y or N\n");
                var start = Console.ReadKey(true).Key;
                if (Console.ReadKey(true).Key == ConsoleKey.N)
                {
                    exit = true;
                }
                Console.Clear();

                #region Build Player
                Console.WriteLine("Please enter your name: ");
                string name = Console.ReadLine();

                Console.Clear();

                Console.WriteLine($"Please Pick a Weapon: \n" +
                      $"S) Sword\n" +
                      $"K) Knife\n" +
                      $"B) Bow and Arrow\n" +
                      $"F) Fire Orb\n" +
                      $"I) Ice Orb\n"
                      );
                var pickWeapon = Console.ReadKey(true).Key;

            Weapon equippedWeapon = new Weapon();
                if (pickWeapon == ConsoleKey.S)
                {
                    equippedWeapon = sword;
                }
                else if (pickWeapon == ConsoleKey.K)
                {
                    equippedWeapon = knife;
                }
                else if (pickWeapon == ConsoleKey.B)
                {
                     equippedWeapon = bowAndArrow;
                }
                else if (pickWeapon == ConsoleKey.F)
                {
                     equippedWeapon = fireOrb;
                }
                else if (pickWeapon == ConsoleKey.I)
                {
                     equippedWeapon = iceOrb;
                }
                Console.Clear();

                Console.WriteLine($"Please choose a Race: \n" +
                    $"H) Human\n" +
                    $"E) Elf\n" +
                    $"O) Orc\n"
                    );
                var pickRace = Console.ReadKey(true).Key;
                Race chosenRace = new Race();
                if (pickRace == ConsoleKey.H)
                {
                    chosenRace = Race.Human;
                }
                else if (pickRace == ConsoleKey.E)
                {
                    chosenRace = Race.Elf;
                }
                else if (pickRace == ConsoleKey.O)
                {
                    chosenRace = Race.Orc;
                }
            Console.Clear();
           

            #endregion
            Player player = new Player(name, 50, 15, 100, chosenRace, equippedWeapon);
            Console.WriteLine("This is you: \n" + player + "\n press enter to continue");

            Console.Clear();

            do
            {
                Console.WriteLine(GetRoom());

                #region Monsters
                Dragon dragon1 = new Dragon(" Red Dragon", 20, 20, 25, 25, "Just a normal Red Dragon", true, false, false, false);
                Dragon dragon2 = new Dragon(" Elder Dragon", 20, 30, 30, 30, "Looks old", false, true, false, false);
                Dragon dragon3 = new Dragon(" Bone Dragon", 35, 35, 35, 35, "Boney", false, false, true, false);
                Dragon dragon4 = new Dragon(" Great Dragon", 40, 40, 40, 40, "The last of its kind", true, true, true, true);
                Griffin griffin1 = new Griffin(" Griffin", 20, 20, 20, 20, "A combination of a eagle and lion", true, false, false);
                Griffin griffin2 = new Griffin(" Griffin", 25, 25, 25, 25, "A combination of a eagle and lion", false, true, false);
                Griffin griffin3 = new Griffin(" Gorlock the Destroyer (Griffin)", 40, 50, 50, 35, "The destroyer of worlds, The conqueror of planets, Your worst nightmare", true, true, true);
                Mummy mummy1 = new Mummy(" Mummy", 35, 35, 35, 35, "Just a regular mummy", true);
                Mummy mummy2 = new Mummy(" King Tutankhamun (Mummy)", 40, 35, 50, 40, "Its King Tut... Or whats left of him anyway", false);
                Werewolf werewolf1 = new Werewolf(" Werewolf", 30, 30, 30, 30, "It looks like joe from the office", false);
                Werewolf werewolf2 = new Werewolf(" Werewolf", 40, 10, 55, 40, "This guy looks edgy", true);
                Zombie zombie1 = new Zombie(" Zombie", 20, 20, 20, 20, "Looks gross. Rotting flesh, Smelly breath", false);
                Zombie zombie2 = new Zombie(" Buff Zombie", 45, 50, 50, 35, "Is kinda built like the Undertanker", true);
                
                Monster[] monsters = {dragon1, dragon2, dragon3, dragon4, griffin1, griffin2, griffin3, mummy1, mummy2, werewolf1, werewolf2, zombie1, zombie2 };
                
                Random rand = new Random();
                int randomNbr = rand.Next(monsters.Length);
                Monster monster = monsters[randomNbr];
                
                Console.WriteLine("\nA monster appears!" + monster.Name);
                #endregion Monsters
                bool reload = false;
                do
                {
                    #region MENU
                    Console.Write("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run away\n" +
                        "P) Player Info\n" +
                        "M) Monster Info\n" +
                        "X) Exit\n");

                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                    Console.Clear();

                    switch (userChoice)
                    {
                        #region Combat
                        case ConsoleKey.A:
                            Combat.DoBattle(player, monster);
                            if (monster.Life <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}!\n",
                                    monster.Name);
                                Console.ResetColor();
                                reload = true;
                                score++;
                            }
                            #endregion COMBAT
                            break;
                        #region Run Away
                        case ConsoleKey.R:
                            Console.WriteLine("Run Away!!!");
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, player);
                            Console.WriteLine();
                            reload = true;
                            #endregion Run Away
                            break;

                        case ConsoleKey.P:
                            #region Player Info
                            Console.WriteLine("Player Info");
                            Console.WriteLine(player);
                            Console.WriteLine("Monsters defeated: " + score);
                            #endregion Player Info
                            break;

                        case ConsoleKey.M:
                            #region Monster Info
                            Console.WriteLine(monster);
                            #endregion Monster Info
                            break;

                        case ConsoleKey.X:
                        case ConsoleKey.E:
                            #region Exit
                            Console.WriteLine("No one likes a quitter...");
                            exit = true;
                            #endregion Exit
                            break;

                        default:
                            #region Default
                            Console.WriteLine("NOT A VALID INPUT. TRY AGAIN!");
                            #endregion Default
                            break;
                            #endregion MENU
                    }//END SWITCH

                    #region Check Player Life
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("Bro.... How do you die\a");

                        
                        exit = true;
                    }

                    #endregion Check Player Life
                } while (!exit && !reload);
            } while (!exit);
            #region Output Final Score
            Console.WriteLine("You defeated " + score + " monster" + ((score == 1) ? "." : "s."));
            #endregion Output Final Score
        }//End Main

        private static string GetRoom()
        {
            string[] rooms =
            {
                "The room is dark and musty... You look around a relize you're in a cave.",
                "You walk into the room. There is a bunch of people around but it smells awful. Relization hits... You're at a Smash Bros tournament.",
                "The room is cold, there is a draft like somebody forgot to close a window. The celings are tall and the walls are made out of stone. How nice. You're in a castle!",
                "You feel weird. The colors are vibrant and nothing looks real. Then it hits you. You've been digitized.",
                "Meow...... Meow???? Meow!? (You're a cat)",
                "You walk into a room. As you walk in the floor crumbles behind you. I guess there's no going back now. Then suddely the floor in front of you collapeses. Leving you on a little platform. And underneath you is a pool of Alligators.",
                "You walk into a forest. The fresh scent of rain lingers in the air. Where are you? In the distance you see a man standing. You approch the man. Its Jeff Bezozs. Welcome to the Amazon",
                "Ugh! Whats that awful smell. You're in Shreks swamp.",
                "There is nothing weird about this one. Its just a empty white room",
            };
            Random rand = new Random();

            int indexNbr = rand.Next(rooms.Length);

            string room = rooms[indexNbr];

            return room;
        }//End GetRoom()
    }//End Class
}//End Namespace

