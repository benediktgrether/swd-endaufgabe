using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Controls
    {
        public static void gameControls()
        {
            Console.WriteLine("Willkommen in der Blackwall Academy\nDu befindest dich gerade im Eingangsbereich der Schule. Du sollst in das Büro der Rektors einbrechen. Viel erfolg dabei");
            // Console.WriteLine(Location.items);
            Location currentLocation = Location.MapSetUp();
            string input = "";

            while (input != "q")
            {
                Location.DescribeLocation(currentLocation);
                // Location.DescribeLocation(currentLocation.north);
                Console.Write("Was willst du tun : ");
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
                         takeItem(currentLocation);
                        break;
                    case "drop":
                    case "d":
                        dropItem(currentLocation);
                        break;
                    case "inventory":
                    case "i":
                        showInventory();
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
        public static void takeItem(Location location)
        {
            string item ="";
            foreach(var i in location.items)
            {
                item = i;
                Chloe.inventory.Add(i);
            }
                location.items.Remove(item);
        }

        public static void showInventory()
        {
            foreach(var i in Chloe.inventory)
            {
                Console.WriteLine("Inventar: " + i);
            }
        }

        public static void dropItem(Location location)
        {
            showInventory();
            Console.WriteLine("Welches Item möchtest du fallen lassen?: ");
            string drop = Console.ReadLine();
            string item ="";
            foreach(var i in Chloe.inventory)
            {
                if (drop == i)
                {
                    item = drop;
                    Console.WriteLine("test");
                    location.items.Add(item);
                }
            }
                Chloe.inventory.Remove(item);
        }
    }

}