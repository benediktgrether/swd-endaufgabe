using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class ConsoleOutput
    {
        public static void GameDescription()
        {
            Console.WriteLine("Willkommen in der Blackwall Academy\nDu befindest dich gerade im Eingangsbereich der Schule.\nDu sollst in das Büro der Rektors einbrechen. Viel erfolg dabei");
        }

        public static void AttackDraw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Draw");
            Console.ResetColor();
        }

        public static void EnemyHit(string Input, string arr)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Input.ToUpper() + " schlägt " + arr.ToUpper());
            Console.ResetColor();
        }

        public static void AvatarHit(string Input, string arr)
        {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(Input.ToUpper() + " verliert gegen " + arr.ToUpper());
        Console.ResetColor();
        }

        public static void AvatarWin()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("_______________________________________________________________________________________________________________________");
            Console.WriteLine("Du hast den Wachmann besiegt.");
            Console.WriteLine("_______________________________________________________________________________________________________________________");
            Console.ResetColor(); 
        }
        
        public static void AvatarLose()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Du wurdest besiegt");
            Console.ResetColor();  
        }
    }
}