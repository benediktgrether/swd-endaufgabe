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
            Location hallway = new Location
            (
                0,
                "Aula",
                "Du befindest dich gerade in der Aula",
                true, true
            );

            Location restroom = new Location
            (
                1,
                "WC",
                "Du Befindest dich in der Toilette", true ,true
            );

            Location sidePassage = new Location
            (
                2,
                "Seitengang", 
                "Du befindest dich im Seitengang", true, true
            );
            
            Location chemistryLab = new Location
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
            Location office = new Location
            (
                5,
                "Sekretariat", 
                "Du befindest dich im Sekretariat", true, true
            );
            Location principal = new Location
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

            hallway.North= restroom;
            hallway.East= office;
            hallway.West = sidePassage;
            hallway.South= exit;
            hallway.Items.Add(soda);

            restroom.South= hallway;
            restroom.Items.Add(anleitung);

            sidePassage.North= chemistryLab;
            sidePassage.East= hallway;
            sidePassage.South= security;

            chemistryLab.South= sidePassage;
            chemistryLab.Items.AddRange(new List<Items>
            {
                klebeband, sodiumChlorate
            });

            security.North= sidePassage;

            office.West = hallway;
            office.East= principal;
            office.Items.AddRange(new List<Items>
            {
                suggar, money, key
            });

            principal.West = office;
            principal.Items.AddRange(new List<Items>
            {
                fileRachel, fileKate, fileChloe, fileMax, fileWarren
            });

            exit.North= hallway;

            rooms = new Dictionary<string, Location>();
            rooms["hallway"] = hallway;
            rooms["WC"] = restroom;
            rooms["Seitengang"] = sidePassage;
            rooms["Chemielabor"] = chemistryLab;
            rooms["Sekretariat"] = office;
            rooms["Büro Rektor"] = principal;
            rooms["Exit"] = exit;

            return hallway;
        }
        // public static void DescribeLocation(Location location)
        // {
        //     Console.ForegroundColor = ConsoleColor.Blue;
        //     Console.WriteLine("_______________________________________________________________________________________________________________________");
        //     Console.WriteLine(location.Description);

        //     foreach(var i in location.Items)
        //     {
        //         Console.WriteLine(i.Title);
        //     }
        //     Console.WriteLine("_______________________________________________________________________________________________________________________");
        //     Console.ResetColor();
        // }

        public static void NeighborRoom(Location location)
        {
            Console.WriteLine("");
        }

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


