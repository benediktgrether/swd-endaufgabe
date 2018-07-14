using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class ItemsInteraction
    {
        public static void TakeItem(string _words, Location location, Avatar avatar)
        {
            Items _findItem = location.Items.Find(x => x.Title.Contains(_words));
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
            FindFile();
        } 
        public static void ShowInventory(Avatar avatar)
        {
            foreach (var i in avatar.Inventory)
            {
                Console.WriteLine("Inventar: " + i.Title);
            }
        }

        public static void DropItem(string _words, Location location, Avatar avatar)
        {
            ShowInventory(avatar);
            Items findItem = avatar.Inventory.Find(x => x.Title.Contains(_words));
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

        public static void FindFile()
        {
            Items findItem =  Avatar.Characters["Max"].Inventory.Find(x => x.Title.Contains("Akte1"));
            if(Avatar.Characters["Max"].Inventory.Exists(x => x.Title == "Akte1"))
            {
                Console.WriteLine("Du hast die Richtige Akte gefunden");
                Console.WriteLine(findItem.Description);
            }
        }
        public static void LootEnemy(string _words, Location location, Enemy enemy)
        {
            Console.WriteLine("Der Gegener hat einige Items droppen lassen");
            foreach(var i in Enemy.Characters[_words].Inventory)
            {
                location.Items.Add(i);
            }
        }
    }

}