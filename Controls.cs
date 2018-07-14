using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Controls
    {
        public static int ControlCounter = 0;
        public static string Input = "";
        public static string[] words;


        public static void GameControls()
        {
            Console.WriteLine("Willkommen in der Blackwall Academy\nDu befindest dich gerade im Eingangsbereich der Schule.\nDu sollst in das Büro der Rektors einbrechen. Viel erfolg dabei");
            Location currentLocation = Location.MapSetUp();
            Avatar avatar = Avatar.setupAvatar();
            Enemy enemy = Enemy.SetupEnemy();
            Location.DescribeLocation(currentLocation);
            // SplitInput();
            // while (words[0] != "q")
            for(;;)
            {
                // Console.BackgroundColor = ConsoleColor.DarkGray;
                SplitInput();
                // Console.ResetColor();

                switch (words[0])
                {
                    case "north":
                    case "n":
                        // testMethod(direction, avatar, enemy);
                        if (currentLocation.North!= null)
                        {
                            if(Move.SetDirection(currentLocation.North, avatar) == false)
                            {
                                break;
                            }
                            else
                            {
                            currentLocation = currentLocation.North;
                            Move.SetMaxRoom(currentLocation, avatar, enemy);
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
                            if(Move.SetDirection(currentLocation.East, avatar) == false)
                            {
                                break;
                            }
                            else
                            {
                                currentLocation = currentLocation.East;
                                Move.SetMaxRoom(currentLocation, avatar, enemy);
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
                            if(Move.SetDirection(currentLocation.South, avatar) == false)
                            {
                                break;
                            }
                            else
                            {
                            currentLocation = currentLocation.South;
                            Move.SetMaxRoom(currentLocation, avatar, enemy);
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
                            if(Move.SetDirection(currentLocation.West, avatar) == false)
                            {
                                break;
                            }
                            else
                            {
                            currentLocation = currentLocation.West;
                            Move.SetMaxRoom(currentLocation, avatar, enemy);
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
                                ItemsInteraction.TakeItem(words[1],currentLocation, avatar);
                            }
                            else
                            {
                                // Items.TakeItem(words[1],currentLocation, avatar);
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
                                ItemsInteraction.DropItem(words[1],currentLocation, avatar);
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
                    case "Inventory":
                    case "i":
                        ItemsInteraction.ShowInventory(avatar);
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
                            Location.UsedItems(words[1]);
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
                        Console.WriteLine("help(h), look(l), Inventory(i), take(t) item, drop(d) item, quit(q)");
                        break;
                    case "quit":
                    case "q":
                        Environment.Exit(0);
                        break;
                    case "attack":
                    case "a":
                        if(enemy.CurrentRoom == avatar.CurrentRoom)
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
                        ItemsInteraction.LootEnemy(words[1], currentLocation, enemy);
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
    }

}