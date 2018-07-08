using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Items
    {
        public static void takeItem(Location location)
        {
            Console.WriteLine("Welches Item möchten Sie aufnehmen?: ");
            string value = Console.ReadLine();
            string item ="";
            foreach (var i in location.items)
            {
                if(value == i)
                {
                    item = value;
                    Max.inventory.Add(item);
                }
            }
            if (item != value)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Falsche Eingabe");
                Console.ResetColor();
            }
            location.items.Remove(item);
        }

        public static void showInventory()
        {
            foreach (var i in Max.inventory)
            {
                Console.WriteLine("Inventar: " + i);
            }
        }

        public static void dropItem(Location location)
        {
            showInventory();
            Console.WriteLine("Welches Item möchtest du fallen lassen?: ");
            string value = Console.ReadLine();
            string item = "";
            foreach (var i in Max.inventory)
            {
                if (value == i)
                {
                    item = value;
                    Console.WriteLine("test");
                    location.items.Add(item);
                }
            }
            if (item != value)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Falsche Eingabe");
                Console.ResetColor();
            }
            Max.inventory.Remove(item);
        }
    }

}


