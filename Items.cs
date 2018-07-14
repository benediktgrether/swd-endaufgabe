using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Items
    {
        public string description;
        public string title;
        public bool used;
        public bool bomb;

        public Items(string _title, string _description, bool _used, bool _bomb)
        {
            title = _title;
            description = _description;
            used = _used;
            bomb = _bomb;
        }
        
        public static void takeItem(string _words, Location location, Avatar avatar)
        {
            Items findItem = location.items.Find(x => x.title.Contains(_words));
            // Items findSpecialItem = location.items.Find(x => x.title.Contains());
            if(findItem != null)
            {
                Console.WriteLine("Find:" + findItem.title);
                avatar.Inventory.Add(findItem);
                location.items.Remove(findItem);
            }
            else
            {
                Console.WriteLine("Nothing find");
            }
            itemFinish(location, avatar);
        }

        public static void showInventory(Avatar avatar)
        {
            foreach (var i in avatar.Inventory)
            {
                Console.WriteLine("Inventar: " + i.title);
            }
        }

        public static void dropItem(string _words, Location location, Avatar avatar)
        {
            showInventory(avatar);
            Items findItem = avatar.Inventory.Find(x => x.title.Contains(_words));
            // Items findSpecialItem = location.items.Find(x => x.title.Contains());
            if(findItem != null)
            {
                Console.WriteLine("Find:" + findItem.title);
                location.items.Add(findItem);
                avatar.Inventory.Remove(findItem);
            }
            else
            {
                Console.WriteLine("Nothing find");
            }
        }

        public static void itemFinish(Location location, Avatar avatar)
        {
            Items findItem = avatar.Inventory.Find(x => x.title.Contains("fileRachel"));
            if(avatar.Inventory.Exists(x => x.title == "fileRachel"))
            {
                Console.WriteLine("Du hast die Richtige Akte gefunden");
                Console.WriteLine(findItem.description);
            }
        }
    }
}


