using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class GameChar
    {
        public static List <string> inventory = new List <string>();
        public static int health; 
    }

    class Max : GameChar
    {
        // public static string currentRoom;
        private static int _currentRoom;

        public static void setMaxRoom(Location location)
        {
            _currentRoom = location.roomNumber;
            Console.WriteLine(_currentRoom);
        }
    } 

    class Security : GameChar
    {
        public static int randomRoom;
        public static string currentRoom;
        public static bool Key = true;
    }
}
