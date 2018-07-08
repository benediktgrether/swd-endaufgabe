using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Controls
    {
        public static int controlcounter = 0;
        public static void gameControls()
        {
            Console.WriteLine("Willkommen in der Blackwall Academy\nDu befindest dich gerade im Eingangsbereich der Schule. Du sollst in das Büro der Rektors einbrechen. Viel erfolg dabei");
            Location currentLocation = Location.MapSetUp();
            string input = "";

            while (input != "q")
            {
                Location.DescribeLocation(currentLocation);
                Console.WriteLine("Counter: " + controlcounter);
                Console.Write("Was willst du tun : ");
                input = Console.ReadLine().ToLower();
                Security.randomRoom();

                switch (input)
                {
                    case "north":
                    case "n":
                        if (currentLocation.north != null)
                        {
                            currentLocation = currentLocation.north;
                            Max.setMaxRoom(currentLocation);
                            controlcounter ++;
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
                            currentLocation = currentLocation.east;
                            Max.setMaxRoom(currentLocation);
                            controlcounter ++;
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
                            currentLocation = currentLocation.south;
                            Max.setMaxRoom(currentLocation);
                            controlcounter ++;
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
                            currentLocation = currentLocation.west;
                            Max.setMaxRoom(currentLocation);
                            controlcounter ++;
                        }
                        else
                        {
                            Console.WriteLine("There is no way! Choose another one!");
                        }
                        break;
                    case "take":
                    case "t":
                        Items.takeItem(currentLocation);
                        break;
                    case "drop":
                    case "d":
                        Items.dropItem(currentLocation);
                        break;
                    case "inventory":
                    case "i":
                        Items.showInventory();
                        break;
                    case "look":
                    case "l":
                        // Location.DescribeLocation(currentLocation);
                        break;
                    case "commands":
                    case "c":
                        Console.WriteLine("commands(c), look(l), inventory(i), take(t) item, drop(d) item, quit(q)");
                        break;
                    case "quit":
                    case "q":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("You cant use this button. Use another one. If you don't know the Controls press c!");
                        break;
                }
            }
        }

    }

}