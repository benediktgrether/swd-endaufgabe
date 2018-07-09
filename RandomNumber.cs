using System;

namespace swd_endaufgabe
{
    class RandomNumber
    {
        public static int getEnemyRandonRoom()
        {
            Random rnd = new Random();
            int enemyRandomRoom = rnd.Next(0, 6);
            return enemyRandomRoom;
        }
    }
}