using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class GameChar
    {
        public string name;
        public int health;
        public List<string> inventory = new List<string>();
        public int currentRoom;
    }

    class Avatar : GameChar
    {
        //To Do - Methoden
        public Avatar(string _name, int _health, int _currentRoom)
        {
            name = _name;
            health = _health;
            currentRoom = _currentRoom;
        }
        public static Avatar setupAvatar()
        {
            Avatar max = new Avatar(
                "Max ", 100, 0
            );
            return max;
        }
        public int setMaxRoom(Location location, Avatar avatar, Enemy enemy)
        {
            // Avatar avatar = Avatar.setupAvatar();
            // Enemy enemy = Enemy.setupEnemy();
            // avatar.currentRoom = location.roomNumber;
            // currentRoom = location.roomNumber;
            currentRoom = location.roomNumber;
            // Console.WriteLine("Ich bin gerade im " + currentRoom + " Raum");
            enemy.randomRoom(location, avatar, enemy);
            // Security.randomRoom(location);
            
            return currentRoom;
        }
    }

    class Enemy : GameChar
    {
        private int counter;
        public bool life;
        public string title; 
        public List<string> loot = new List<string>();

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
            Enemy davide = new Enemy(
                "Davide", 100, 5, true, "Wachmann"
            );
            davide.loot.Add("key1234");
            return davide;
        }
        public int randomRoom(Location location, Avatar avatar, Enemy enemy)
        {

            int randomnumber = RandomNumber.getEnemyRandonRoom();
            if(life == true)
            {
                if(Controls.controlcounter > 2)
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
