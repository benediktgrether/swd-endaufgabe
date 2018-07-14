using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class GameChar
    {
        public string name;
        public int health;
        public List<Items> inventory = new List<Items>();
        public int currentRoom;
        public Location room;
    }

    class Avatar : GameChar
    {
        //To Do - Methoden
        public static Dictionary<string, GameChar> characters;
        public Avatar(string _name, int _health, int _currentRoom, Location _room)
        {
            name = _name;
            health = _health;
            currentRoom = _currentRoom;
            room = _room;
        }
        public static Avatar setupAvatar()
        {
            Avatar max = new Avatar(
                "Max", 100, 0, Location.rooms["Aula"]
            );
            characters = new Dictionary<string, GameChar>();
            characters["Max"] = max;
            return max;
        }

        
        public int setMaxRoom(Location location, Avatar avatar, Enemy enemy)
        {
            // currentRoom = characters["Max"].currentRoom;
            currentRoom = location.RoomNumber;
            Location.DescribeLocation(location);
            enemy.randomRoom(location, avatar, enemy);
            
            return currentRoom;
        }
    }

    class Enemy : GameChar
    {
        private int counter;
        public bool life;
        public string title; 
        public List<Items> loot = new List<Items>(); // Liste Inventory verwenden

        public Enemy(string _name, int _health, int _currentRoom, bool _life, string _titel)
        {
            name = _name;
            health = _health;
            currentRoom = _currentRoom;
            life = _life;
            title = _titel;
        }

        public static Enemy setupEnemy()
        {
            Enemy david = new Enemy(
                "David", 100, 5, true, "Wachmann"
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
            david.loot.AddRange(new List<Items>
            {
                centralKey, mobilePhone, carKey
            });
            return david;
        }
        public int randomRoom(Location location, Avatar avatar, Enemy enemy)
        {

            int randomnumber = RandomNumber.getEnemyRandonRoom();
            if(life == true)
            {
                if(Controls.ControlCounter > 5)
                {
                    if(counter == 0)
                    {
                        currentRoom = 2;
                        Console.WriteLine("Die Tür des Sicherheitsbüro öffnet sich und der Wachman tritt heraus.\nEr befindet sich nun im Seitengang, und macht einen zufälligen Rundgang durch die Schule.");
                    }
                    else
                    {
                        currentRoom = randomnumber;
                        Console.WriteLine("Security is in Room :" + currentRoom);

                        if(currentRoom == avatar.currentRoom)
                        {
                            Attack.EnemyAttack(avatar, enemy);
                        }
                    }
                    return counter ++;
                }
            }
            return counter = 0;
        }
    }
}
