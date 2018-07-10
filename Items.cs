using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Items
    {
        
        public static void takeItem(Location location, Avatar avatar)
        {
            Console.WriteLine("Welches Item möchten Sie aufnehmen?: ");
            string value = Console.ReadLine();
            if(location.items.Contains(value))
            {
                avatar.inventory.Add(value);
                location.items.Remove(value);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Falsche Eingabe");
                Console.ResetColor();
            }
        }

        public static void showInventory(Avatar avatar)
        {
            foreach (var i in avatar.inventory)
            {
                Console.WriteLine("Inventar: " + i);
            }
        }

        public static void dropItem(Location location, Avatar avatar)
        {
            showInventory(avatar);
            Console.WriteLine("Welches Item möchtest du fallen lassen?: ");
            string value = Console.ReadLine();
            if(avatar.inventory.Contains(value))
            {
                location.items.Add(value);
                avatar.inventory.Remove(value);
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


