using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Controls
    {
        public static int ControlCounter = 0;
        public static string Input = "";
        public static string[] words;


        public static void gameControls()
        {
            Console.WriteLine("Willkommen in der Blackwall Academy\nDu befindest dich gerade im Eingangsbereich der Schule.\nDu sollst in das Büro der Rektors einbrechen. Viel erfolg dabei");
            Location currentLocation = Location.MapSetUp();
            Avatar avatar = Avatar.setupAvatar();
            Enemy enemy = Enemy.setupEnemy();
            Location.DescribeLocation(currentLocation);
            // SplitInput();
            // while (words[0] != "q")
            for(;;)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                SplitInput();
                Console.ResetColor();

                switch (words[0])
                {
                    case "north":
                    case "n":
                        // testMethod(direction, avatar, enemy);
                        if (currentLocation.North!= null)
                        {
                            if(Location.setDirection(currentLocation.North, avatar) == false)
                            {
                                break;
                            }
                            else
                            {
                            currentLocation = currentLocation.North;
                            avatar.setMaxRoom(currentLocation, avatar, enemy);
                            ControlCounter ++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no way! Choose another one!");
                        }
                        break;
                    case "east":
                    case "e":
                        if (currentLocation.East!= null)
                        {
                            if(Location.setDirection(currentLocation.East, avatar) == false)
                            {
                                break;
                            }
                            else
                            {
                                currentLocation = currentLocation.East;
                                avatar.setMaxRoom(currentLocation, avatar, enemy);
                                ControlCounter ++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no way! Choose another one!");
                        }
                        break;
                    case "south":
                    case "s":
                        if (currentLocation.South!= null)
                        {
                            if(Location.setDirection(currentLocation.South, avatar) == false)
                            {
                                break;
                            }
                            else
                            {
                            currentLocation = currentLocation.South;
                            avatar.setMaxRoom(currentLocation, avatar, enemy);
                            ControlCounter ++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no way! Choose another one!");
                        }
                        break;
                    case "west":
                    case "w":
                        if (currentLocation.West != null)
                        {
                            if(Location.setDirection(currentLocation.West, avatar) == false)
                            {
                                break;
                            }
                            else
                            {
                            currentLocation = currentLocation.West;
                            avatar.setMaxRoom(currentLocation, avatar, enemy);
                            ControlCounter ++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no way! Choose another one!");
                        }
                        break;
                    case "take":
                    case "t":
                        try
                        {
                            if(words[1] != "")
                            {
                                Items.takeItem(words[1],currentLocation, avatar);
                            }
                            else
                            {
                                // Items.takeItem(words[1],currentLocation, avatar);
                                Console.WriteLine("Bitte Eintragen was Sie gerne aufnehmen möchten. Mit look(l) können Sie sich umschauen.Mit take <item> können Sie etwas aufnehmen.");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Bitte Eintragen was Sie gerne aufnehmen möchten. Mit look(l) können Sie sich umschauen.Mit take <item> können Sie etwas aufnehmen.");
                        }
                        break;
                    case "drop":
                    case "d":
                        try
                        {
                            if(words[1] != "")
                            {
                                Items.dropItem(words[1],currentLocation, avatar);
                            }
                            else
                            {
                                Console.WriteLine("Bitte Eintragen was Sie gerne aufnehmen möchten. Mit look(l) können Sie sich umschauen.");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Falsche Eingabe");
                        }
                        break;
                    case "inventory":
                    case "i":
                        Items.showInventory(avatar);
                        break;
                    case "look":
                    case "l":
                        // Location.ShowRoomInformation(currentLocation);
                        Location.DescribeLocation(currentLocation);
                        break;
                    case "used":
                    case "u":
                    try{
                        if(words[1] != "")
                        {
                            Location.usedItems(currentLocation, avatar, words[1]);
                        }
                        else 
                        {
                            Console.WriteLine("Bitte Eintragen was Sie gerne benützen wollen. Mit i können Sie schauen was in Ihrem Inventar drin ist.");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Falsche Eingabe");
                    }
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
                            Attack.AttackNow(words[1] ,currentLocation, avatar, enemy);
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

                    case "test":
                        Attack.LootEnemy(currentLocation, enemy);
                        break;
                }
            }

        }
            public static Array SplitInput()
            {
                string _input = Console.ReadLine();
                words = _input.Split(' ');
                return words;
            }

            // public Controls testMethod(Location Location, Avatar avatar, Enemy enemy)
            // {
            //     if (direction != null)
            //     {
            //         if(Location.setDirection(direction, avatar) == false)
            //         {
            //             return;
            //         }
            //         else
            //         {
            //         Controls.currentLocation = direction;
            //         avatar.setMaxRoom(direction, avatar, enemy);
            //         // ControlCounter ++;
            //         }
            //     }

            // }

    }

}