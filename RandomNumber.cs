using System;

namespace swd_endaufgabe
{
    class RandomNumber
    {
        public static Random rnd = new Random();
        public static int GetEnemyRandomRoom()
        {
            int EnemyRandomRoom = rnd.Next(0, 6);
            return EnemyRandomRoom;
        }

        public static int GetAttackRandomNumber()
        {
            int AttackRandomNumber = rnd.Next(0,3);
            return AttackRandomNumber;
        }

        public static int GetRandomFileNumber()
        {
            int RandomFileNumber = rnd.Next(0,5);
            return RandomFileNumber;

        }
    }
}