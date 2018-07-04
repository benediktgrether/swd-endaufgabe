using System;

namespace swd_endaufgabe
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            Room r1 = new Room("Hallway");
            Room r2 = new Room("WC");
            Room r3 = new Room("Hallway Left");
            Room r4 = new Room("Chemielabor");
            Room r5 = new Room("Security");
            Room r6 = new Room("Sekretariat");
            Room r7 = new Room("Büro Rektor");

            // Room Hallway (Startpoint)
            r1.north = r2;
            r1.east = r6;
            r1.west = r3;
            Room.description = "Du befindest dich in der Aula";
            Room.items.Add("Soda");
            
            // Room 
            r2.south = r1;
            Room.description ="Du befindest dich in der Toilette";


            // Room Hallway Left
            r3.north = r4;
            r3.south = r5;
            Room.description="Du befindest dich im Linken Seitengang";

            // Chemielabor
            r4.south = r3;
            Room.description="Du befindest dich im Chemielabor";

            //Security 
            r5.north = r3;
            Room.description = "Du befindest dich im Security Raum";
            
            //Sekretariat
            r6.west = r1;
            r6.east = r7;
            Room.description = "Du befindest dich im Sekretariat";


            //Büro Rektor
            r7.west = r6;
            Room.description = "Du befindest dich im Büro des Rektors";
        }
    }
}
