using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Controls
    {
        public static void gameControls()
        {
            Console.WriteLine("Willkommen in der Blackwall Academy\nDu befindest dich gerade im Eingangsbereich der Schule. Du sollst in das Büro der Rektors einbrechen. Viel erfolg dabei");
            Location currentLocation = Location.MapSetUp();
            string input = "";

            while (input != "q")
            {
                Location.DescribeLocation(currentLocation);
                input = Console.ReadLine().ToLower();

                switch (input)
                {
                    case "north":
                    case "n":
                        if (currentLocation.north != null)
                        {
                            currentLocation = currentLocation.north;
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
                        }
                        else
                        {
                            Console.WriteLine("There is no way! Choose another one!");
                        }
                        break;
                    case "take":
                    case "t":
                        // takeItem();
                        break;
                    case "drop":
                    case "d":
                        // dropItem();
                        break;
                    case "inventory":
                    case "i":
                        // myInventory();
                        break;
                    case "look":
                    case "l":
                        Location.DescribeLocation(currentLocation);
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

            // if (input == "n" || input =="north")
            // {
            //     Console.WriteLine("Test");
            // }

        }
    }

}