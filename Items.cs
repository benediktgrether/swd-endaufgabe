using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Items
    {
        public string description;
        public string title;
        public bool used;

        public Items(string _title, string _description, bool _used)
        {
            title = _title;
            description = _description;
            used = _used;
        }
        
        public static void takeItem(string _words, Location location, Avatar avatar)
        {
            Console.WriteLine("Welches Item möchten Sie aufnehmen?: ");
            string value = _words;
            Items findItem = location.items.Find(x => x.title.Contains(value));
            // Items findSpecialItem = location.items.Find(x => x.title.Contains());
            if(findItem != null)
            {
                Console.WriteLine("Find:" + findItem.title);
                avatar.inventory.Add(findItem);
                location.items.Remove(findItem);
            }
            else
            {
                Console.WriteLine("Nothing find");
            }

            // if(location.items.Contains(value))
            // {
            //     avatar.inventory.Add(value);
            //     location.items.Remove(value);
            // }
            // else
            // {
            //     Console.ForegroundColor = ConsoleColor.Red;
            //     Console.WriteLine("Falsche Eingabe");
            //     Console.ResetColor();
            // }
        }

        public static void showInventory(Avatar avatar)
        {
            foreach (var i in avatar.inventory)
            {
                Console.WriteLine("Inventar: " + i.title);
            }
        }

        public static void dropItem(Location location, Avatar avatar)
        {
            showInventory(avatar);
            Console.WriteLine("Welches Item möchtest du fallen lassen?: ");
            // string value = Console.ReadLine();
            // if(avatar.inventory.Contains(value))
            // {
            //     location.items.Add(value);
            //     avatar.inventory.Remove(value);
            // }
            // else
            // {
            //     Console.ForegroundColor = ConsoleColor.Red;
            //     Console.WriteLine("Falsche Eingabe");
            //     Console.ResetColor();
            // }
        }
    }

}


