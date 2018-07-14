using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Move
    {
        public static bool SetDirection(Location location, Avatar avatar)
        {
            CheckFinished(avatar);
            if(location.Open == false && location.GameFinished == false)
            {
                if(Avatar.Characters["Max"].Inventory.Exists(x => x.Title == "Zentralschlüssel"))
                {
                    return Location.rooms["Büro Schulleiter"].Open = true;
                }
                if(Avatar.Characters["Max"].CurrentRoom != 0)
                {
                    Console.WriteLine("Das Zimmer ist verschlossen. Finde einen weg hinein.");
                }
                return location.Open = false;
            }
            return location.Open = true;
        }
        public static bool CheckFinished(Avatar avatar)
        {
            // if(location.GameFinished == false)
            if(Location.rooms["Exit"].GameFinished == false)
            {
                if((Avatar.Characters["Max"].Inventory.Exists(x => x.Title == "Akte1")) && (Avatar.Characters["Max"].CurrentRoom == Location.rooms["hallway"].RoomNumber))
                {
                    Console.WriteLine("Herzlichen Glückwunsch, du hast die Akte über Rachel gefunden. Das Spiel wird nun beendet.");
                    Environment.Exit(0);
                }
                if(Avatar.Characters["Max"].CurrentRoom == Location.rooms["Exit"].RoomNumber)
                {
                    Console.WriteLine("Du kannst hier noch nicht lang gehen.\nFinde die richtige Schulakte");
                }
                return false;
            }
            return true;
        }
        public static int SetMaxRoom(Location location, Avatar avatar, Enemy enemy)
        {
            // CurrentRoom = characters["Max"].CurrentRoom;
            Avatar.Characters["Max"].CurrentRoom = location.RoomNumber;
            ConsoleOutput.DescribeLocation(location);
            RandomRoom(location, avatar, enemy);
            
            return Avatar.Characters["Max"].CurrentRoom;
        }
        public static int RandomRoom(Location location, Avatar avatar, Enemy enemy)
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
                        Console.WriteLine("Security is in Room :" + Enemy.Characters["David"].CurrentRoom);

                        if(Enemy.Characters["David"].CurrentRoom == Avatar.Characters["Max"].CurrentRoom)
                        {
                            Attack.EnemyAttack(avatar, enemy);
                        }
                    }
                    return enemy.counter ++;
                }
            }
            return enemy.counter = 0;
        }
    }
}