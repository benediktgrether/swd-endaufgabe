using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class GameChar
    {
        public static List <string> inventory = new List <string>();
        public static int health; 
    }

    class Chloe : GameChar
    {
        // public static string currentRoom;
    } 

    class Security : GameChar
    {
        public static int randomRoom;
        public static string currentRoom;
        public static bool Key = true;
    }
}