using System;

namespace swd_endaufgabe
{
    class Location
    {
        public string title;
        public string description;

        public Location north;
        public Location east;
        public Location south;
        public Location west;

        public Location(string _title, string _description)
        {
            title = _title;
            description = _description;
        }
        public static Location MapSetUp()
        {
            Location Aula = new Location
            (
                "Aula",
                "Du befindest dich gerade in der Aula"
            );
            
            Location WC = new Location
            (
                "WC",
                "Du Befindest dich in der Toilette"
            );

            Location Seitengang = new Location
            (
                "Seitengang", 
                "Du befindest dich im Seitengang"
            );
            
            Location Chemielabor = new Location
            (
                "Chemielabor", 
                "Du befindest dich im Chemielabor"
            );
            Location Security = new Location
            (
                "Security", 
                "Du befindest dich im Security"
            );
            Location Sekretariat = new Location
            (
                "Sekretariat", 
                "Du befindest dich im Sekretariat"
            );
            Location BueroRektor = new Location
            (
                "Büro Rektor", 
                "Du befindest dich im Büro Rektor"
            );

            Aula.north = WC;
            Aula.east = Sekretariat;
            Aula.west = Seitengang;

            WC.south = Aula;

            Seitengang.north = Chemielabor;
            Seitengang.south = Security;

            Chemielabor.south = Seitengang;

            Security.north = Seitengang;

            Sekretariat.west = Aula;
            Sekretariat.east = BueroRektor;

            BueroRektor.west = Sekretariat;

            return Aula;
        }
        public static void DescribeLocation(Location location)
        {
            Console.WriteLine();
            Console.WriteLine(location.title);
            Console.WriteLine();
            Console.WriteLine(location.description);
        }
    }
}


