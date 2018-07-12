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
            Items findItem = location.items.Find(x => x.title.Contains(_words));
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
        }

        public static void showInventory(Avatar avatar)
        {
            foreach (var i in avatar.inventory)
            {
                Console.WriteLine("Inventar: " + i.title);
            }
        }

        public static void dropItem(string _words, Location location, Avatar avatar)
        {
            showInventory(avatar);
            Items findItem = avatar.inventory.Find(x => x.title.Contains(_words));
            // Items findSpecialItem = location.items.Find(x => x.title.Contains());
            if(findItem != null)
            {
                Console.WriteLine("Find:" + findItem.title);
                location.items.Add(findItem);
                avatar.inventory.Remove(findItem);
            }
            else
            {
                Console.WriteLine("Nothing find");
            }
        }
    }
}


