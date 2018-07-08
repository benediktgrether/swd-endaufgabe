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
            if(location.items.Contains(value))
            {
                Max.inventory.Add(value);
                location.items.Remove(value);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Falsche Eingabe");
                Console.ResetColor();
            }
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
            if(Max.inventory.Contains(value))
            {
                location.items.Add(value);
                Max.inventory.Remove(value);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Falsche Eingabe");
                Console.ResetColor();
            }
        }
    }

}


