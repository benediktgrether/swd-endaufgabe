using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Controls
    {
        public static int ControlCounter = 0;
        public static string[] words;
        public static void GameControls()
        {
            ConsoleOutput.GameDescription();
            Location currentLocation = Location.MapSetUp();
            Avatar avatar = Avatar.setupAvatar();
            Enemy enemy = Enemy.SetupEnemy();
            ConsoleOutput.DescribeLocation(currentLocation);
            for(;;)
            {
                SplitInput();

                switch (words[0])
                {
                    case "north":
                    case "n":
                        // testMethod(direction, avatar, enemy);
                        if (currentLocation.North!= null)
                        {
                            if(Location.RoomOpen(currentLocation.North, avatar) == false)
                            {
                                break;
                            }
                            else
                            {
                            currentLocation = currentLocation.North;
                            Avatar.AvatarMove(currentLocation, avatar, enemy);
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
                            if(Location.RoomOpen(currentLocation.East, avatar) == false)
                            {
                                break;
                            }
                            else
                            {
                                currentLocation = currentLocation.East;
                                Avatar.AvatarMove(currentLocation, avatar, enemy);
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
                            if(Location.RoomOpen(currentLocation.South, avatar) == false)
                            {
                                break;
                            }
                            else
                            {
                            currentLocation = currentLocation.South;
                            Avatar.AvatarMove(currentLocation, avatar, enemy);
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
                            if(Location.RoomOpen(currentLocation.West, avatar) == false)
                            {
                                break;
                            }
                            else
                            {
                            currentLocation = currentLocation.West;
                            Avatar.AvatarMove(currentLocation, avatar, enemy);
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
                                Items.TakeItem(words[1],currentLocation, avatar);
                            }
                            else
                            {
                                ConsoleOutput.TakeWrongInput();
                            }
                        }
                        catch
                        {
                            ConsoleOutput.TakeWrongInput();
                        }
                        break;
                    case "drop":
                    case "d":
                        try
                        {
                            if(words[1] != "")
                            {
                                Items.DropItem(words[1],currentLocation);
                            }
                            else
                            {
                                ConsoleOutput.DropWrongInput();
                            }
                        }
                        catch
                        {
                            ConsoleOutput.DropWrongInput();
                        }
                        break;
                    case "Inventory":
                    case "i":
                            Items.ShowInventory(avatar);
                        break;
                    case "look":
                    case "l":
                        ConsoleOutput.DescribeLocation(currentLocation);
                        break;
                    case "used":
                    case "u":
                    try{
                        if(words[1] != "")
                        {
                            Items.UseItem(words[1]);
                        }
                        else 
                        {
                            ConsoleOutput.UsedWrongInput();
                        }
                    }
                    catch
                    {
                        ConsoleOutput.UsedWrongInput();
                    }
                        break;
                    case "help":
                    case "h":
                        Console.WriteLine("help(h), look(l), inventory(i), take(t) item, drop(d) item, used(u) item,getinformation(g), quit(q)");
                        break;
                    case "quit":
                    case "q":
                        Environment.Exit(0);
                        break;
                    case "attack":
                    case "a":
                        try
                        {
                            if(words[1] != "")
                            {
                                if(enemy.CurrentRoom == avatar.CurrentRoom)
                                {
                                    Attack.AttackEnemy(words[1] ,currentLocation, avatar, enemy);
                                }
                                else
                                {
                                    Console.WriteLine("You cant use this button. Use another one. If you don't know the Controls press c!");
                                    break;
                                }
                            }
                        }
                        catch
                        {
                            ConsoleOutput.AttackWrongInput();
                        }
                        break;
                        case "getinformation":
                        case "g":
                        try
                        {
                            if(words[1] != "")
                            {
                                Items.GetInformation(words[1]);
                            }
                            else
                            {
                                Console.WriteLine("Falsche eingabe");
                            }
                        }
                        catch
                        {

                        }
                        break;
                    default:
                        Console.WriteLine("You cant use this button. Use another one. If you don't know the Controls press c!");
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