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
                avatar.inventory.Add(findItem);
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
            foreach (var i in avatar.inventory)
            {
                Console.WriteLine("Inventar: " + i.title);
            }
        }

        public static void dropItem(string _words, Location location, Avatar avatar)
        {

            // To Do 
            // Überprüfen ob die Bombe gebaut werden kann. 
            // Schauen ob die Tür dann aufgeht. 
            // Wo soll die Items abgelegt werden ? 
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

        public static void itemFinish(Location location, Avatar avatar)
        {
            Items findItem = avatar.inventory.Find(x => x.title.Contains("fileRachel"));
            if(avatar.inventory.Exists(x => x.title == "fileRachel"))
            {
                Console.WriteLine("Du hast die Richtige Akte gefunden");
                Console.WriteLine(findItem.description);
            }
        }
    }
}


