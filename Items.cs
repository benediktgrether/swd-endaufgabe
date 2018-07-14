using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Items
    {
        public string Description;
        public string Title;
        public bool Used;
        public bool Bomb;

        public Items(string _title, string _description, bool _used, bool _bomb)
        {
            Title = _title;
            Description = _description;
            Used = _used;
            Bomb = _bomb;
        }
        
        public static void takeItem(string _words, Location location, Avatar avatar)
        {
            Items _findItem = location.Items.Find(x => x.Title.Contains(_words));
            // Items findSpecialItem = location.items.Find(x => x.title.Contains());
            if(_findItem != null)
            {
                Console.WriteLine("Find:" + _findItem.Title);
                avatar.Inventory.Add(_findItem);
                location.Items.Remove(_findItem);
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
                Console.WriteLine("Inventar: " + i.Title);
            }
        }

        public static void dropItem(string _words, Location location, Avatar avatar)
        {
            showInventory(avatar);
            Items findItem = avatar.Inventory.Find(x => x.Title.Contains(_words));
            // Items findSpecialItem = location.items.Find(x => x.title.Contains());
            if(findItem != null)
            {
                Console.WriteLine("Find:" + findItem.Title);
                location.Items.Add(findItem);
                avatar.Inventory.Remove(findItem);
            }
            else
            {
                Console.WriteLine("Nothing find");
            }
        }

        public static void itemFinish(Location location, Avatar avatar)
        {
            Items findItem = avatar.Inventory.Find(x => x.Title.Contains("fileRachel"));
            if(avatar.Inventory.Exists(x => x.Title == "fileRachel"))
            {
                Console.WriteLine("Du hast die Richtige Akte gefunden");
                Console.WriteLine(findItem.Description);
            }
        }
    }
}


