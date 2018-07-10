using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class GameChar
    {
        public static List <string> inventory = new List <string>();
        public int health;
        public static int counter = 0;
    }

    class Max : GameChar
    {
        // public static string currentRoom;
        public static int _currentRoom;

        public static int setMaxRoom(Location location)
        {
            _currentRoom = location.roomNumber;
            Console.WriteLine("Ich bin gerade im " + _currentRoom + " Raum");
            Security.randomRoom(location);
            return _currentRoom;
        }

        public static int setMaxHealth(int health)
        {
            // avatar.health;
            return health;
        }
    } 

    class Security : GameChar
    {
        // public static int randomRoom;
        private static int _currentRoom;
        public static bool active = true;
        public static bool Key = true;
        
        public static int setSecurityHealth(int health)
        {
            return health;
        }
        public static int randomRoom(Location location)
        {
            if(active == true)
            { 
                Random rnd = new Random();
                int enemyRandomRoom = rnd.Next(0, 6);
                // In dem Raum wo er schon drin war, darf er nicht mehr rein.
                if(Controls.controlcounter > 2)
                {
                    if (counter == 0)
                    {
                        _currentRoom = 2;
                        Console.WriteLine("Die Tür des Sicherheitsbüro öffnet sich und der Wachman tritt heraus.\nEr befindet sich nun im Seitengang, und macht einen zufälligen Rundgang durch die Schule.");
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
            }
            return counter = 0 ;
        }
    }
}
