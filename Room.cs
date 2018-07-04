using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Room
    {
        public static List<String> items = new List<String>();
        public static string description;

        public static bool roomOpen;

        public Room north;
        public Room east;
        public Room south;
        public Room west;

        public Room(string _name)
        {
            string roomName = _name;
            
            // Debug Code
            Console.WriteLine(roomName);
        } 
    }
}