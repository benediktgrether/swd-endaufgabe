using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class ConsoleOutput
    {
        public static void GameDescription()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("_______________________________________________________________________________________________________________________");
            Console.WriteLine("Willkommen in der Blackwall Academy.\nEine berühmte Universität in Arcadia Bay.\nAn der Blackwall Academy wird in Richtung Kunst mit schwerpunkt Fotografie und in Richtung Naturwissenschaften unterrichtet.\nSeit Jahren erhält die Blackwell Academy finanzielle zuwendung der Prescott-Familie denen halb Arcadia Bay gehört.\nAußerdem gibt es seit Jahrzehnten den Vortex Club, wo nur die angesagtesten Schüler und reichen Schüler rein kommen.\nDer Vortex Club Veranstaltet immer wieder Partys bei der es letztes mal zu einem Zwischenfall kam. Eine Schülerin der Blackwell Academy wurde unter Drogen gesetzt und ein Dubioses Video mit ihr online gestellt, über das auch außerhalb von Arcadia Bay geredet wird.\nDas ist aber nicht das einzige traurige Ereignis aus der Blackwell Academy. Rachel Amber , Chloes beste Freundin wird seit dem Sommer vermisst.\nNun möchtest Chloe und du rausfinden was in der Schule vor sich geht und musst dafür in das Büro des Schulleiters gelangen.\nPass aber besser auf denn, Chloes Stiefvater der als Wachman an der Blackwell Academy arbeitet hat heute Nachtschicht und könnte dir zufällig über den Weg laufen.");
            Console.ResetColor();
        }

        public static void DescribeLocation(Location location)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("_______________________________________________________________________________________________________________________");
            Console.WriteLine(location.Description);

            foreach(var i in location.Items)
            {
                Console.WriteLine(i.Title);
            }
            Console.WriteLine("_______________________________________________________________________________________________________________________");
            Console.ResetColor();
        }

        public static void TakeWrongInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Bitte Eintragen was Sie gerne aufnehmen möchten. Mit look(l) können Sie sich umschauen.Mit take <item> können Sie etwas aufnehmen.");
            Console.ResetColor();
        }

        public static void DropWrongInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Bitte Eintragen was Sie gerne in den Raum legen möchten. Mit inventory(i) können Sie schauen was alles im Inventar vorhanden ist.\nMit drop(d) <item> können Sie das Item hier ablegen.");
            Console.ResetColor();
        }

        public static void UsedWrongInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Bitte Eintragen was Sie gerne benützen möchten. Mit inventory(i) können Sie schauen was alles im Inventar vorhanden ist.\nMit used(u) <item> können Sie das Item benützen.");
            Console.ResetColor();   
        }

        public static void AttackWrongInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("attack(a) ist noch nicht möglich");
            Console.ResetColor();   
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
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Du wurdest besiegt");
            Console.ResetColor();  
        }
    }
}