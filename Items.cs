using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Items
    {
        public string InteractionName;
        public string Description;
        public string Title;
        public bool Used;
        public bool Bomb;

        public Items(string _interactionName, string _title, string _description, bool _used, bool _bomb)
        {
            InteractionName = _interactionName;
            Title = _title;
            Description = _description;
            Used = _used;
            Bomb = _bomb;
        }
        public static void TakeItem(string _words, Location location, Avatar avatar)
        {
            Items _findItem = location.Items.Find(x => x.InteractionName.Contains(_words.ToLower()));
            if(_findItem != null && _findItem.Used == true)
            {
                Console.WriteLine("Du hast " + _findItem.Title + " zu deinem Inventar hinzugefügt.\n-----------------");
                avatar.Inventory.Add(_findItem);
                location.Items.Remove(_findItem);
            }
            else if( _findItem.Used == false)
            {
                Console.WriteLine("Du kannst das Objekt nicht in deinem Inventar hinzufügen!\n-----------------");
            }
            else
            {
                Console.WriteLine("Falsche eingabe");
            }
            FindFile(_words);
        }
        public static void FindFile(string _words)
        {
            if (Avatar.Characters["Max"].CurrentRoom == Location.rooms["Büro Schulleiter"].RoomNumber)
            {
                Items findItem =  Avatar.Characters["Max"].Inventory.Find(x => x.InteractionName.Contains(_words.ToLower()));          
                if (Avatar.Characters["Max"].Inventory.Find(x => x.Title.Contains(_words)) == Avatar.Characters["Max"].Inventory.Find(x => x.Title.Contains("Akte1")))
                { 
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("-----------------\nDu hast die Richtige Akte gefunden\n-----------------");
                    Console.ResetColor();
                    Console.WriteLine(findItem.Description);
                }
                else
                {
                    Console.WriteLine(findItem.Description);  
                }
            }
        }
        public static void ShowInventory(Avatar avatar)
        {
            Console.WriteLine("In deinem Inventar befindet sich folgende Items: ");
            foreach (var i in avatar.Inventory)
            {
                Console.Write(i.Title + " | ");
            }
            Console.WriteLine("\n-----------------");
        }

        public static void DropItem(string _words, Location location)
        {
            Items findItem = Avatar.Characters["Max"].Inventory.Find(x => x.InteractionName.Contains(_words.ToLower()));
            if(findItem != null)
            {
                Console.WriteLine("Du hast " + findItem.Title + " aus deinem Inventar entfernt.\n-----------------");
                location.Items.Add(findItem);
                Avatar.Characters["Max"].Inventory.Remove(findItem);
            }
            else
            {
                Console.WriteLine("Nothing find");
            }
        }
        public static bool UseItem(string _words)
        {  
            List<Items> needForBomb = new List<Items>();
            Items findItem = Avatar.Characters["Max"].Inventory.Find(x => x.InteractionName.Contains(_words.ToLower()));
            if(findItem != null)
            {
                if (Avatar.Characters["Max"].CurrentRoom == Location.rooms["Sekretariat"].RoomNumber)
                {
                    foreach(var i in Avatar.Characters["Max"].Inventory)
                    {
                        if(i.Bomb == true)
                        {
                            needForBomb.Add(i);
                        }
                    }
                    foreach(var i in needForBomb)
                    {
                        if (i.Bomb == findItem.Bomb)
                        {
                            Avatar.Characters["Max"].Inventory.Remove(findItem);
                        }
                    }
                    int _sizeOfList = needForBomb.Count;
                    if(_sizeOfList == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("-----------------\nBombe Explodiert\n-----------------"); 
                        Console.ResetColor();
                        Console.WriteLine("Die Tür ist nun offen und du kannst rein gehen.");
                        return Location.rooms["Büro Schulleiter"].Open = true;   
                    }
                }
                else
                {
                    Console.WriteLine("used (u) kann nur im Sektretariat angewendet werden.\n-----------------");
                }
            }
            return false;
        }
        public static void GetInformation(string _words)
        {
            Items findItem = Avatar.Characters["Max"].Inventory.Find(x => x.InteractionName.Contains(_words.ToLower()));
            Console.WriteLine(findItem.Title + "\n" + findItem.Description);
        }
        public static void DropLoot(string _words, Location location)
        {
            Console.WriteLine("Der Gegener hat einige Items droppen lassen\n-----------------");
            foreach(var i in Enemy.Characters[_words].Inventory)
            {
                location.Items.Add(i);
            }
        }
    }
}


