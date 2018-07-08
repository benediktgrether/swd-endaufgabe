using System;

namespace swd_endaufgabe
{
    class RandomNumber
    {
        Random rnd = new Random();
        int enemyRandomRoom = rnd.Next(0, 6);
    }
}