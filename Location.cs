using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Location
    {
        public string title;
        public string description;

        public int roomNumber;

        public Location north;
        public Location east;
        public Location south;
        public Location west;

        public List<string> items = new List<string>();

        public Location(int _roomNumber, string _title, string _description)
        {
            title = _title;
            description = _description;
            roomNumber = _roomNumber;
        }
        public static Location MapSetUp()
        {
            Location Aula = new Location
            (
                0,
                "Aula",
                "Du befindest dich gerade in der Aula"
            );
            
            Location WC = new Location
            (
                1,
                "WC",
                "Du Befindest dich in der Toilette"
            );

            Location Seitengang = new Location
            (
                2,
                "Seitengang", 
                "Du befindest dich im Seitengang"
            );
            
            Location Chemielabor = new Location
            (
                3,
                "Chemielabor", 
                "Du befindest dich im Chemielabor"
            );
            Location Security = new Location
            (
                4,
                "Security", 
                "Du befindest dich im Security"
            );
            Location Sekretariat = new Location
            (
                5,
                "Sekretariat", 
                "Du befindest dich im Sekretariat"
            );
            Location BueroRektor = new Location
            (
                6,
                "Büro Rektor", 
                "Du befindest dich im Büro des Rektors"
            );

            Aula.north = WC;
            Aula.east = Sekretariat;
            Aula.west = Seitengang;
            // Aula.items.AddRange(new List<string>
            // {"Soda", "Taschentücher"});
            Aula.items.Add("Soda");

            WC.south = Aula;
            WC.items.Add("Anleitung");

            Seitengang.north = Chemielabor;
            Seitengang.east = Aula;
            Seitengang.south = Security;

            Chemielabor.south = Seitengang;
            Chemielabor.items.AddRange(new List<string>
            {
                "Panzertape", "Sodium Chlorate"
            });

            Security.north = Seitengang;

            Sekretariat.west = Aula;
            Sekretariat.east = BueroRektor;
            Sekretariat.items.AddRange(new List<string>
            {
                "Zucker", "1€"
            });

            BueroRektor.west = Sekretariat;
            BueroRektor.items.AddRange(new List<string>
            {
                "Akte1", "Akte2", "Akte3", "Akte4", "Akte5"
            });

            return Aula;
        }



        public static void DescribeLocation(Location location)
        {
            Console.WriteLine();
            Console.WriteLine(location.title + " " + location.roomNumber);
            Console.WriteLine();
            Console.WriteLine(location.description);
            Console.WriteLine();

            foreach(var i in location.items)
            {
                Console.WriteLine(i);
            }
        }

        public static void NeighborRoom(Location location)
        {
            Console.WriteLine("");
        }
    }
}


