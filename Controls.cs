using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Controls
    {
        public static int controlcounter = 0;
        public static string input = "";

        public static void gameControls()
        {
            Console.WriteLine("Willkommen in der Blackwall Academy\nDu befindest dich gerade im Eingangsbereich der Schule.\nDu sollst in das Büro der Rektors einbrechen. Viel erfolg dabei");
            Location currentLocation = Location.MapSetUp();
            Avatar avatar = Avatar.setupAvatar();
            Enemy enemy = Enemy.setupEnemy();

            while (input != "q")
            {
                Location.DescribeLocation(currentLocation);
                Console.BackgroundColor = ConsoleColor.DarkGray;
                giveInput();
                Console.ResetColor();

                switch (input)
                {
                    case "north":
                    case "n":
                        if (currentLocation.north != null)
                        {
                            if(Location.setDirection(currentLocation.north, avatar) == false)
                            {
                                break;
                            }
                            else
                            {
                            currentLocation = currentLocation.north;
                            avatar.setMaxRoom(currentLocation, avatar, enemy);
                            controlcounter ++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no way! Choose another one!");
                        }
                        break;
                    case "east":
                    case "e":
                        if (currentLocation.east != null)
                        {
                            if(Location.setDirection(currentLocation.east, avatar) == false)
                            {
                                break;
                            }
                            else
                            {
                                // Location.setDirection(currentLocation.east);
                                currentLocation = currentLocation.east;
                                avatar.setMaxRoom(currentLocation, avatar, enemy);
                                controlcounter ++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no way! Choose another one!");
                        }
                        break;
                    case "south":
                    case "s":
                        if (currentLocation.south != null)
                        {
                            if(Location.setDirection(currentLocation.south, avatar) == false)
                            {
                                break;
                            }
                            else
                            {
                            currentLocation = currentLocation.south;
                            avatar.setMaxRoom(currentLocation, avatar, enemy);
                            controlcounter ++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no way! Choose another one!");
                        }
                        break;
                    case "west":
                    case "w":
                        if (currentLocation.west != null)
                        {
                            if(Location.setDirection(currentLocation.west, avatar) == false)
                            {
                                break;
                            }
                            else
                            {
                            currentLocation = currentLocation.west;
                            avatar.setMaxRoom(currentLocation, avatar, enemy);
                            controlcounter ++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no way! Choose another one!");
                        }
                        break;
                    case "take":
                    case "t":
                        Items.takeItem(currentLocation, avatar);
                        break;
                    case "drop":
                    case "d":
                        Items.dropItem(currentLocation, avatar);
                        break;
                    case "inventory":
                    case "i":
                        Items.showInventory(avatar);
                        break;
                    case "look":
                    case "l":
                        Location.showRoomInformation(currentLocation);
                        // Location.DescribeLocation(currentLocation);
                        break;
                    case "used":
                    case "u":
                        Location.usedItems();
                        break;
                    case "help":
                    case "h":
                        Console.WriteLine("help(h), look(l), inventory(i), take(t) item, drop(d) item, quit(q)");
                        break;
                    case "quit":
                    case "q":
                        Environment.Exit(0);
                        break;
                    case "attack":
                    case "a":
                        if(enemy.currentRoom == avatar.currentRoom)
                        {
                            Attack.AttackNow(avatar, enemy);
                        }
                        else
                        {
                            Console.WriteLine("You cant use this button. Use another one. If you don't know the Controls press c!");
                            break;
                        }
                        break;
                    default:
                        Console.WriteLine("You cant use this button. Use another one. If you don't know the Controls press c!");
                        break;
                }
            }

        }
            public static string giveInput()
            {
                Console.Write("Was willst du tun : ");
                return input = Console.ReadLine().ToLower();
            }

    }

}