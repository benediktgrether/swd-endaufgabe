using System;

namespace swd_endaufgabe
{
    class RandomNumber
    {
        public static Random rnd = new Random();
        public static int GetEnemyRandomRoom()
        {
            int enemyRandomRoom = rnd.Next(0, 6);
            return enemyRandomRoom;
        }

        public static int getAttackRandomNumber()
        {
            int attackRandomNumber = rnd.Next(0,3);
            return attackRandomNumber;
        }
    }
}