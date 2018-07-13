using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Location
    {
        public string title;
        public string description;

        public int roomNumber;

        public bool open;

        public bool gameFinished;

        public Location north;
        public Location east;
        public Location south;
        public Location west;

        public List<Items> items = new List<Items>();
        public static Dictionary<string, Location> rooms;

        public Location(int _roomNumber, string _title, string _description, bool _open, bool _gameFinished)
        {
            roomNumber = _roomNumber;
            title = _title;
            description = _description;
            open = _open;
            gameFinished = _gameFinished;

        }
        public static Location MapSetUp()
        {
            Location Aula = new Location
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

            Location WC = new Location
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

            Location Seitengang = new Location
            (
                2,
                "Seitengang", 
                "Du befindest dich im Seitengang", true, true
            );
            
            Location Chemielabor = new Location
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

            Location Security = new Location
            (
                4,
                "Security", 
                "Du befindest dich im Security", true, true
            );
            Location Sekretariat = new Location
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
            Location BueroRektor = new Location
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

            Location Exit = new Location
            (
                7, 
                "Exit", 
                "Game Finsihed", 
                false, 
                false
            );


            Aula.north = WC;
            Aula.east = Sekretariat;
            Aula.west = Seitengang;
            Aula.south = Exit;
            // Aula.items.AddRange(new List<string>
            // {"Soda", "Taschentücher"});
            Aula.items.Add(soda);

            WC.south = Aula;
            WC.items.Add(anleitung);

            Seitengang.north = Chemielabor;
            Seitengang.east = Aula;
            Seitengang.south = Security;

            Chemielabor.south = Seitengang;
            Chemielabor.items.AddRange(new List<Items>
            {
                klebeband, sodiumChlorate
            });

            Security.north = Seitengang;

            Sekretariat.west = Aula;
            Sekretariat.east = BueroRektor;
            Sekretariat.items.AddRange(new List<Items>
            {
                suggar, money, key
            });

            BueroRektor.west = Sekretariat;
            BueroRektor.items.AddRange(new List<Items>
            {
                fileRachel, fileKate, fileChloe, fileMax, fileWarren
            });

            Exit.north = Aula;

            rooms = new Dictionary<string, Location>();
            rooms["Aula"] = Aula;
            rooms["WC"] = WC;
            rooms["Seitengang"] = Seitengang;
            rooms["Chemielabor"] = Chemielabor;
            rooms["Sekretariat"] = Sekretariat;
            rooms["Büro Rektor"] = BueroRektor;
            rooms["Exit"] = Exit;

            return Aula;
        }



        public static void DescribeLocation(Location location)
        {

            // Console.WriteLine();
            // Console.WriteLine(location.title + " " + location.roomNumber);
            // Console.WriteLine();
            // Console.WriteLine(location.description);
            // Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("___________________________________________________________");
            Console.WriteLine(location.description);

            // foreach(var i in location.items)
            // {
            //     Console.WriteLine(i);
            // }
            Console.WriteLine("___________________________________________________________");
            Console.ResetColor();
        }

        public static void NeighborRoom(Location location)
        {
            Console.WriteLine("");
        }

        public static void showRoomInformation(Location location)
        {
            Console.WriteLine(location.description);
            foreach(var i in location.items)
            {
                Console.WriteLine(i.title);
            }
        }
        public static bool setDirection(Location location, Avatar avatar)
        {
            isGameFinsihed(location, avatar);
            if(location.open == false && location.gameFinished == false)
            {
                if(avatar.inventory.Exists(x => x.title == "Zentralschlüssel"))
                {
                    return Location.rooms["Büro Rektor"].open = true;
                }
                if(avatar.currentRoom != 0)
                {
                    Console.WriteLine("Das Zimmer ist verschlossen. Finde einen weg hinein.");
                }
                return location.open = false;
            }
            return location.open = true;
        }
        public static bool isGameFinsihed(Location location, Avatar avatar)
        {
            if(location.gameFinished == false)
            {
                if(avatar.inventory.Exists(x => x.title == "Akte1"))
                {
                    Console.WriteLine("Herzlichen Glückwunsch, du hast die Akte über Rachel gefunden. Das Spiel wird nun beendet.");
                    Environment.Exit(0);
                }
                if(avatar.currentRoom == 0)
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
            Items findItem = avatar.inventory.Find(x => x.title.Contains(_words));
            if(findItem != null)
            {
                if (avatar.currentRoom == 5)
                {
                    foreach(var i in avatar.inventory)
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
                            avatar.inventory.Remove(findItem);
                        }
                    }
                    int sizeOfList = needForBomb.Count;
                    Console.WriteLine(sizeOfList);
                    if(sizeOfList == 1)
                    {
                        Console.WriteLine("Boomb"); 
                        return Location.rooms["Büro Rektor"].open = true;
                        
                    }
                }
            }
            return false;
        }
    }
    
}


