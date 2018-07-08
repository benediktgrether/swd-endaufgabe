using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class GameChar
    {
        public static List <string> inventory = new List <string>();
        public static int health; 
        public static int counter = 0;
    }

    class Max : GameChar
    {
        // public static string currentRoom;
        public static int _currentRoom;

        public static int setMaxRoom(Location location)
        {
            _currentRoom = location.roomNumber;
            Console.WriteLine(_currentRoom);
            Security.randomRoom(location);
            return _currentRoom;
        }
    } 

    class Security : GameChar
    {
        // public static int randomRoom;
        private static string _currentRoomName;
        private static int _currentRoom;
        public static bool Key = true;

        public static int randomRoom(Location location)
        {
            Random rnd = new Random();
            int enemyRandomRoom = rnd.Next(0, 6);
            if(Controls.controlcounter > 2)
            {
                if (counter == 0)
                {
                    Console.WriteLine("Die Tür des Security Raum öffnet sich und der Wachman tritt heraus. Er befindet sich nun im Seitengang");
                }
                else
                {    
                    _currentRoom = enemyRandomRoom;
                    Console.WriteLine("Security is in Room :" + _currentRoom);

                    if (_currentRoom == Max._currentRoom)
                    {
                        Attack.EnemyAttack();
                    } 

                }
                return counter ++; 
            }
            return counter = 0 ;
        }
    }
}
