using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class GameChar
    {
        public string Name;
        public int Health;
        public List<Items> Inventory = new List<Items>();
        public int CurrentRoom;
        public Location Room;
    }

    class Avatar : GameChar
    {
        //To Do - Methoden
        public static Dictionary<string, GameChar> Characters;
        public Avatar(string _name, int _health, int _currentRoom, Location _room)
        {
            Name = _name;
            Health = _health;
            CurrentRoom = _currentRoom;
            Room = _room;
        }
        public static Avatar setupAvatar()
        {
            Avatar max = new Avatar(
                "Max", 3, 0, Location.rooms["Aula"]
            );
            Characters = new Dictionary<string, GameChar>();
            Characters["Max"] = max;
            return max;
        }

        
        // public int SetMaxRoom(Location location, Avatar avatar, Enemy enemy)
        // {
        //     // CurrentRoom = characters["Max"].CurrentRoom;
        //     CurrentRoom = location.RoomNumber;
        //     Location.DescribeLocation(location);
        //     enemy.RandomRoom(location, avatar, enemy);
            
        //     return CurrentRoom;
        // }
    }

    class Enemy : GameChar
    {
        public int counter;
        public bool Life;
        public string Title; 
        public static Dictionary<string, GameChar> Characters;

        public Enemy(string _name, int _health, int _currentRoom, bool _life, string _titel)
        {
            Name = _name;
            Health = _health;
            CurrentRoom = _currentRoom;
            Life = _life;
            Title = _titel;
        }

        public static Enemy SetupEnemy()
        {
            Enemy david = new Enemy(
                "David", 3, 5, true, "Wachmann"
            );
            Items centralKey = new Items
            (
                "Zentralschlüssel", "Zentralschlüssel der Zugang zu allen Räumen bietet.", true, false
            );
            Items mobilePhone = new Items
            (
                "Handy", "Davids Handy", true , false
            );
            Items carKey = new Items
            (
                "Autoschlüssel", "David fährt einen Blauen Ford Mustang Boss 429 (1969)", false, false
            );
            david.Inventory.AddRange(new List<Items>
            {
                centralKey, mobilePhone, carKey
            });

            Characters = new Dictionary<string, GameChar>();
            Characters["David"] = david;
            return david;
        }
        // public int RandomRoom(Location location, Avatar avatar, Enemy enemy)
        // {

        //     int _randomNumber = RandomNumber.GetEnemyRandomRoom();
        //     if(Life == true)
        //     {
        //         if(Controls.ControlCounter > 5)
        //         {
        //             if(counter == 0)
        //             {
        //                 CurrentRoom = 2;
        //                 Console.WriteLine("Die Tür des Sicherheitsbüro öffnet sich und der Wachman tritt heraus.\nEr befindet sich nun im Seitengang, und macht einen zufälligen Rundgang durch die Schule.");
        //             }
        //             else
        //             {
        //                 CurrentRoom = _randomNumber;
        //                 Console.WriteLine("Security is in Room :" + CurrentRoom);

        //                 if(CurrentRoom == avatar.CurrentRoom)
        //                 {
        //                     Attack.EnemyAttack(avatar, enemy);
        //                 }
        //             }
        //             return counter ++;
        //         }
        //     }
        //     return counter = 0;
        // }
    }
}
