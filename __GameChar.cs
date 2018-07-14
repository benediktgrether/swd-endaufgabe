// using System;
// using System.Collections.Generic;

// namespace swd_endaufgabe
// {
//     class GameChar
//     {
//         public static List <string> Inventory = new List <string>();
//         public int Health;
//         public static int counter = 0;
//     }

//     class Max : GameChar
//     {
//         // public static string CurrentRoom;
//         public static int _CurrentRoom;

//         public static int SetMaxRoom(Location location)
//         {
//             _CurrentRoom = location.roomNumber;
//             Console.WriteLine("Ich bin gerade im " + _CurrentRoom + " Raum");
//             Security.RandomRoom(location);
//             return _CurrentRoom;
//         }

//         public static int setMaxHealth(int health)
//         {
//             // avatar.Health;
//             return Health;
//         }
//     } 

//     class Security : GameChar
//     {
//         // public static int RandomRoom;
//         private static int _CurrentRoom;
//         public static bool active = true;
//         public static bool Key = true;
        
//         public Security(int _health)
//         {
//             health = _Health;
//         }
//         // public static int setSecurityHealth(int health)
//         // {
//         //     return Health;
//         // }

//         public static Security SetupGameChar()
//         {
//             Security test = new Security(100);
//             return test;
//         }

//         public static int RandomRoom(Location location)
//         {
//             if(active == true)
//             { 
//                 Random rnd = new Random();
//                 int enemyRandomRoom = rnd.Next(0, 6);
//                 // In dem Raum wo er schon drin war, darf er nicht mehr rein.
//                 if(Controls.ControlCounter > 2)
//                 {
//                     if (counter == 0)
//                     {
//                         _CurrentRoom = 2;
//                         Console.WriteLine("Die Tür des Sicherheitsbüro öffnet sich und der Wachman tritt heraus.\nEr befindet sich nun im Seitengang, und macht einen zufälligen Rundgang durch die Schule.");
//                     }
//                     else
//                     {    
//                         _CurrentRoom = enemyRandomRoom;
//                         Console.WriteLine("Security is in Room :" + _CurrentRoom);

//                         if (_CurrentRoom == Max._CurrentRoom)
//                         {
//                             Attack.EnemyAttack();
//                         } 

//                     }
//                     return counter ++; 
//                 }
//             }
//             return counter = 0 ;
//         }
//     }
// }
