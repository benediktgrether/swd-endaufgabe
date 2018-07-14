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

        public List<Items> Items = new List<Items>();
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
            #region Object Rooms
            Location aula = new Location
            (
                0,
                "Aula",
                "Du befindest dich gerade in der Aula",
                true, true
            );

            Location wc = new Location
            (
                1,
                "WC",
                "Du Befindest dich in der Toilette", true ,true
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
            Location security = new Location
            (
                4,
                "Security", 
                "Du befindest dich im Security", false, false
            );
            Location sekretariat = new Location
            (
                5,
                "Sekretariat", 
                "Du befindest dich im Sekretariat", true, true
            );
            Location bueroRektor = new Location
            (
                6,
                "Büro Rektor", 
                "Du befindest dich im Büro des Rektors", false , false
            );
            Location exit = new Location
            (
                7, 
                "Exit", 
                "Game Finsihed", 
                false, 
                false
            );
            #endregion

            #region Object Items
            Items soda = new Items
            (
                "Soda", "xxx", true, true
            ); 

            Items anleitung = new Items
            (
                "Anleitung", 
                "Hier ist eine Anleitung zum Bauen einer Bombe.\nDu benötigtst dafür\nZucker\nSoda Can\nPanzertape\nNatriumchlorat\n", 
                true, false
            );

            Items klebeband = new Items
            (
                "Klebeband", "xxx", true, true
            );

            Items sodiumChlorate = new Items
            (
                "Natriumchlorid", "Natriumchlorid (Kochsalz) ist das Natriumsalz der Salzsäure mit der chemischen Formel NaCl.", true , true
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
            #endregion

            aula.North= wc;
            aula.East= sekretariat;
            aula.West = seitengang;
            aula.South= exit;
            aula.Items.Add(soda);

            wc.South= aula;
            wc.Items.Add(anleitung);

            seitengang.North= chemielabor;
            seitengang.East= aula;
            seitengang.South= security;

            chemielabor.South= seitengang;
            chemielabor.Items.AddRange(new List<Items>
            {
                klebeband, sodiumChlorate
            });

            security.North= seitengang;

            sekretariat.West = aula;
            sekretariat.East= bueroRektor;
            sekretariat.Items.AddRange(new List<Items>
            {
                suggar, money, key
            });

            bueroRektor.West = sekretariat;
            bueroRektor.Items.AddRange(new List<Items>
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("_______________________________________________________________________________________________________________________");
            Console.WriteLine(location.Description);

            foreach(var i in location.Items)
            {
                Console.WriteLine(i.Title);
            }
            Console.WriteLine("_______________________________________________________________________________________________________________________");
            Console.ResetColor();
        }

        public static void NeighborRoom(Location location)
        {
            Console.WriteLine("");
        }

        // public static bool SetDirection(Location location, Avatar avatar)
        // {
        //     CheckFinished(avatar);
        //     if(location.Open == false && location.GameFinished == false)
        //     {
        //         if(Avatar.Characters["Max"].Inventory.Exists(x => x.Title == "Zentralschlüssel"))
        //         {
        //             return Location.rooms["Büro Rektor"].Open = true;
        //         }
        //         if(Avatar.Characters["Max"].CurrentRoom != 0)
        //         {
        //             Console.WriteLine("Das Zimmer ist verschlossen. Finde einen weg hinein.");
        //         }
        //         return location.Open = false;
        //     }
        //     return location.Open = true;
        // }
        // public static bool CheckFinished(Avatar avatar)
        // {
        //     // if(location.GameFinished == false)
        //     if(Location.rooms["Exit"].GameFinished == false)
        //     {
        //         if((Avatar.Characters["Max"].Inventory.Exists(x => x.Title == "Akte1")) && (Avatar.Characters["Max"].CurrentRoom == Location.rooms["Aula"].RoomNumber))
        //         {
        //             Console.WriteLine("Herzlichen Glückwunsch, du hast die Akte über Rachel gefunden. Das Spiel wird nun beendet.");
        //             Environment.Exit(0);
        //         }
        //         if(Avatar.Characters["Max"].CurrentRoom == Location.rooms["Exit"].RoomNumber)
        //         {
        //             Console.WriteLine("Du kannst hier noch nicht lang gehen.\nFinde die richtige Schulakte");
        //         }
        //         return false;
        //     }
        //     return true;
        // }

        public static bool UsedItems(string _words)
        {  
            List<Items> needForBomb = new List<Items>();
            Items findItem = Avatar.Characters["Max"].Inventory.Find(x => x.Title.Contains(_words));
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
                        return Location.rooms["Büro Rektor"].Open = true;
                        
                    }
                }
            }
            return false;
        }
    }
    
}


