using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Location
    {
        public string Title;
        public string Description;

        public int RoomNumber;

        public bool Open;

        public bool GameFinished;

        public Location North;
        public Location East;
        public Location South;
        public Location West;

        public List<Items> items = new List<Items>();
        public static Dictionary<string, Location> rooms;

        public Location(int _roomNumber, string _title, string _description, bool _open, bool _GameFinished)
        {
            RoomNumber = _roomNumber;
            Title = _title;
            Description = _description;
            Open = _open;
            GameFinished = _GameFinished;

        }
        public static Location MapSetUp()
        {
            Location aula = new Location
            (
                0,
                "Aula",
                "Du befindest dich gerade in der Aula",
                true, true
            );

            Items soda = new Items
            (
                "Soda", "xxx", true, true
            ); 

            Location wc = new Location
            (
                1,
                "WC",
                "Du Befindest dich in der Toilette", true ,true
            );
            Items anleitung = new Items
            (
                "Anleitung", 
                "Hier ist eine Anleitung zum Bauen einer Bombe.\nDu benötigtst dafür\nZucker\nSoda Can\nPanzertape\nNatriumchlorat\n", 
                true, false
            );

            Location seitengang = new Location
            (
                2,
                "Seitengang", 
                "Du befindest dich im Seitengang", true, true
            );
            
            Location chemielabor = new Location
            (
                3,
                "Chemielabor", 
                "Du befindest dich im Chemielabor", true, true
            );
            Items klebeband = new Items
            (
                "Klebeband", "xxx", true, true
            );
            Items sodiumChlorate = new Items
            (
                "Natriumchlorid", "Natriumchlorid (Kochsalz) ist das Natriumsalz der Salzsäure mit der chemischen Formel NaCl.", true , true
            );

            Location security = new Location
            (
                4,
                "Security", 
                "Du befindest dich im Security", true, true
            );
            Location sekretariat = new Location
            (
                5,
                "Sekretariat", 
                "Du befindest dich im Sekretariat", true, true
            );
            Items suggar = new Items
            (
                "Zucker", "Als Zucker wird neben verschiedenen anderen Zuckerarten ein süß schmeckendes, kristallines Lebensmittel bezeichnet, das aus Pflanzen gewonnen wird und hauptsächlich aus Saccharose besteht.",
                true, true
            );
            Items money = new Items
            (
                "1€", "Geldmünze mit dem Wert von 1 €", true , false
            );
            Items key = new Items
            (
                "Schlüssel", "Schlüssel", true , false
            );
            Location bueroRektor = new Location
            (
                6,
                "Büro Rektor", 
                "Du befindest dich im Büro des Rektors", false , false
            );
            Items fileRachel = new Items
            (
                "Akte1", "Akte über die Schullaufbahn von Rachel mit dem verweis das Sie vermisst wird.", true, false
            );
            Items fileChloe = new Items
            (
                "Akte2", "Akte über die Schullaufbahn von Chloe und ein vermerk das Sie von der Schule geflogen ist.", true, false
            );
            Items fileMax = new Items
            (
                "Akte3", "Akte über die Schullaufbahn von Max", true, false
            );
            Items fileWarren = new Items
            (
                "Akte4", "Akte über die Schullaufbahn von Warren und ein vermerk über seine besonderen Leistung im Chemiefach", true, false
            );
            Items fileKate = new Items
            (
                "Akte5", "Akte über die Schullaufbahn von Kate, mit dem verweis das sie gemobbt worden ist.", true, false
            );

            Location exit = new Location
            (
                7, 
                "Exit", 
                "Game Finsihed", 
                false, 
                false
            );


            aula.North= wc;
            aula.East= sekretariat;
            aula.West = seitengang;
            aula.South= exit;
            // Aula.items.AddRange(new List<string>
            // {"Soda", "Taschentücher"});
            aula.items.Add(soda);

            wc.South= aula;
            wc.items.Add(anleitung);

            seitengang.North= chemielabor;
            seitengang.East= aula;
            seitengang.South= security;

            chemielabor.South= seitengang;
            chemielabor.items.AddRange(new List<Items>
            {
                klebeband, sodiumChlorate
            });

            security.North= seitengang;

            sekretariat.West = aula;
            sekretariat.East= bueroRektor;
            sekretariat.items.AddRange(new List<Items>
            {
                suggar, money, key
            });

            bueroRektor.West = sekretariat;
            bueroRektor.items.AddRange(new List<Items>
            {
                fileRachel, fileKate, fileChloe, fileMax, fileWarren
            });

            exit.North= aula;

            rooms = new Dictionary<string, Location>();
            rooms["Aula"] = aula;
            rooms["WC"] = wc;
            rooms["Seitengang"] = seitengang;
            rooms["Chemielabor"] = chemielabor;
            rooms["Sekretariat"] = sekretariat;
            rooms["Büro Rektor"] = bueroRektor;
            rooms["Exit"] = exit;

            return aula;
        }



        public static void DescribeLocation(Location location)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("_______________________________________________________________________________________________________________________");
            Console.WriteLine(location.Description);

            foreach(var i in location.items)
            {
                Console.WriteLine(i.title);
            }
            Console.WriteLine("_______________________________________________________________________________________________________________________");
            Console.ResetColor();
        }

        public static void NeighborRoom(Location location)
        {
            Console.WriteLine("");
        }

        public static void ShowRoomInformation(Location location)
        {
            Console.WriteLine(location.Description);
            foreach(var i in location.items)
            {
                Console.WriteLine(i.title);
            }
        }
        public static bool setDirection(Location location, Avatar avatar)
        {
            CheckFinished(location, avatar);
            if(location.Open == false && location.GameFinished == false)
            {
                if(avatar.Inventory.Exists(x => x.title == "Zentralschlüssel"))
                {
                    return Location.rooms["Büro Rektor"].Open = true;
                }
                if(avatar.CurrentRoom != 0)
                {
                    Console.WriteLine("Das Zimmer ist verschlossen. Finde einen weg hinein.");
                }
                return location.Open = false;
            }
            return location.Open = true;
        }
        public static bool CheckFinished(Location location, Avatar avatar)
        {
            if(location.GameFinished == false)
            {
                if(avatar.Inventory.Exists(x => x.title == "Akte1"))
                {
                    Console.WriteLine("Herzlichen Glückwunsch, du hast die Akte über Rachel gefunden. Das Spiel wird nun beendet.");
                    Environment.Exit(0);
                }
                if(avatar.CurrentRoom == 0)
                {
                    Console.WriteLine("Du kannst hier noch nicht lang gehen.\nFinde die richtige Schulakte");
                }
                return false;
            }
            return true;
        }

        public static bool usedItems(Location location, Avatar avatar, string _words)
        {  
            List<Items> needForBomb = new List<Items>();
            Items findItem = avatar.Inventory.Find(x => x.title.Contains(_words));
            if(findItem != null)
            {
                if (avatar.CurrentRoom == 5)
                {
                    foreach(var i in avatar.Inventory)
                    {
                        if(i.bomb == true)
                        {
                            needForBomb.Add(i);
                        }
                    }
                    foreach(var i in needForBomb)
                    {
                        if (i.bomb == findItem.bomb)
                        {
                            avatar.Inventory.Remove(findItem);
                        }
                    }
                    int sizeOfList = needForBomb.Count;
                    Console.WriteLine(sizeOfList);
                    if(sizeOfList == 1)
                    {
                        Console.WriteLine("Boomb"); 
                        return Location.rooms["Büro Rektor"].Open = true;
                        
                    }
                }
            }
            return false;
        }
    }
    
}


