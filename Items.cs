using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Items
    {
        public static void takeItem(Location location)
        {
            string item = "";
            foreach (var i in location.items)
            {
                item = i;
                Chloe.inventory.Add(i);
            }
            location.items.Remove(item);
        }

        public static void showInventory()
        {
            foreach (var i in Chloe.inventory)
            {
                Console.WriteLine("Inventar: " + i);
            }
        }

        public static void dropItem(Location location)
        {
            showInventory();
            Console.WriteLine("Welches Item möchtest du fallen lassen?: ");
            string drop = Console.ReadLine();
            string item = "";
            foreach (var i in Chloe.inventory)
            {
                if (drop == i)
                {
                    item = drop;
                    Console.WriteLine("test");
                    location.items.Add(item);
                }
            }
            if (item != drop)
            {
                Console.WriteLine("Falsche Eingabe");
            }
            Chloe.inventory.Remove(item);
        }
    }

}


