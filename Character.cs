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

    }

    class Avatar : GameChar
    {
        public static Dictionary<string, GameChar> Characters;
        public Avatar(string _name, int _health, int _currentRoom)
        {
            Name = _name;
            Health = _health;
            CurrentRoom = _currentRoom;

        }
        public static Avatar setupAvatar()
        {
            Avatar max = new Avatar(
                "Max", 3, 0
            );
            Characters = new Dictionary<string, GameChar>();
            Characters["Max"] = max;
            return max;
        }
        public static int AvatarMove(Location location, Avatar avatar, Enemy enemy)
        {
            // CurrentRoom = characters["Max"].CurrentRoom;
            Avatar.Characters["Max"].CurrentRoom = location.RoomNumber;
            ConsoleOutput.DescribeLocation(location);
            Enemy.EnemyMoveRandomRoom(location, avatar, enemy);
            
            return Avatar.Characters["Max"].CurrentRoom;
        }
    }

    class Enemy : GameChar
    {
        private int counter;
        public bool Life;
        public string JobTitle; 
        public static Dictionary<string, GameChar> Characters;

        public Enemy(string _name, int _health, int _currentRoom, bool _life, string _jobTitel)
        {
            Name = _name;
            Health = _health;
            CurrentRoom = _currentRoom;
            Life = _life;
            JobTitle = _jobTitel;
        }

        public static Enemy SetupEnemy()
        {
            Enemy david = new Enemy(
                "David", 3, 5, true, "Wachmann"
            );
            Items centralKey = new Items
            (
                "zentralschlüssel", "Zentralschlüssel", "Zentralschlüssel der Zugang zu allen Räumen bietet.", true, false
            );
            Items mobilePhone = new Items
            (
                "handy", "Handy", "Davids Handy", true , false
            );
            Items carKey = new Items
            (
                "autoschlüssel", "Autoschlüssel", "David fährt einen Blauen Ford Mustang Boss 429 (1969)", false, false
            );
            david.Inventory.AddRange(new List<Items>
            {
                centralKey, mobilePhone, carKey
            });

            Characters = new Dictionary<string, GameChar>();
            Characters["David"] = david;
            return david;
        }
        public static int EnemyMoveRandomRoom(Location location, Avatar avatar, Enemy enemy)
        {
            int _randomNumber = RandomNumber.GetEnemyRandomRoom();
            if(enemy.Life == true)
            {
                if(Controls.ControlCounter > 5)
                {
                    if(enemy.counter == 0)
                    {
                        Enemy.Characters["David"].CurrentRoom = 2;
                        Console.WriteLine("Die Tür des Sicherheitsbüro öffnet sich und der Wachman tritt heraus.\nEr befindet sich nun im Seitengang, und macht einen zufälligen Rundgang durch die Schule.");
                    }
                    else
                    {
                        Enemy.Characters["David"].CurrentRoom = _randomNumber;
                        if(Enemy.Characters["David"].CurrentRoom == Avatar.Characters["Max"].CurrentRoom)
                        {
                            Attack.EnemyCurrentRoom(avatar, enemy);
                        }
                    }
                    return enemy.counter ++;
                }
            }
            return enemy.counter = 0;
        }
    }
}
