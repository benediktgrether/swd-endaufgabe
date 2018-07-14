using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class ItemsInteraction
    {
        public static void TakeItem(string _words, Location location, Avatar avatar)
        {
            Items _findItem = location.Items.Find(x => x.Title.Contains(_words));
            if(_findItem != null && _findItem.Used == true)
            {
                Console.WriteLine("Du hast " + _findItem.Title + " zu deinem Inventar hinzugefügt.");
                avatar.Inventory.Add(_findItem);
                location.Items.Remove(_findItem);
            }
            else if( _findItem.Used == false)
            {
                Console.WriteLine("Du kannst das Objekt nicht in deinem Inventar hinzufügen!");
            }
            else
            {
                Console.WriteLine("Falsche eingabe");
            }
            FindFile();
        } 
        public static void ShowInventory(Avatar avatar)
        {
            Console.WriteLine("In deinem Inventar befindet sich folgende Items: ");
            foreach (var i in avatar.Inventory)
            {
                Console.Write(i.Title + " | ");
            }
            Console.WriteLine();
        }

        public static void DropItem(string _words, Location location)
        {
            // ShowInventory(avatar);
            Items findItem = Avatar.Characters["Max"].Inventory.Find(x => x.Title.Contains(_words));
            if(findItem != null)
            {
                Console.WriteLine("Du hast " + findItem.Title + " aus deinem Inventar entfernt.");
                location.Items.Add(findItem);
                Avatar.Characters["Max"].Inventory.Remove(findItem);
            }
            else
            {
                Console.WriteLine("Nothing find");
            }
        }

        public static void FindFile()
        {
            // int counter = 0;
            // int i = 0;
            // if (counter == 0)
            // {
            //     i = RandomNumber.GetRandomFileNumber();
            //     counter ++;
            // }
            Items findItem =  Avatar.Characters["Max"].Inventory.Find(x => x.Title.Contains("Akte1"));
            if(Avatar.Characters["Max"].Inventory.Exists(x => x.Title == "Akte1"))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Du hast die Richtige Akte gefunden");
                Console.ResetColor();
                Console.WriteLine(findItem.Description);
                // Avatar.Characters["Max"].Inventory.Add(fileRach);
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

        public static bool UsedItems(string _words)
        {  
            List<Items> needForBomb = new List<Items>();
            Items findItem = Avatar.Characters["Max"].Inventory.Find(x => x.Title.Contains(_words));
            // Console.WriteLine(findItem.Title + "\n" + findItem.Description);
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
                    int sizeOfList = needForBomb.Count;
                    if(sizeOfList == 1)
                    {
                        Console.WriteLine("Bombe Explodiert"); 
                        return Location.rooms["Büro Schulleiter"].Open = true;   
                    }
                }
            }
            return false;
        }
        public static void GetInformation(string _words)
        {
            Items findItem = Avatar.Characters["Max"].Inventory.Find(x => x.Title.Contains(_words));
            Console.WriteLine(findItem.Title + "\n" + findItem.Description);
        }
    }

}