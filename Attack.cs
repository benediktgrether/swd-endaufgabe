using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Attack
    {
        public static void EnemyAttack()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Attack");
            Console.ResetColor();
        }
    }
}