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
            Console.WriteLine("Willkommen an der Blackwall Academy, der bekanntesten Universität in ganz Arcadia Bay!\nViele Wissensbegierte zieht es jedes Jahr an die Universität, denn an der Blackwall Academy werden Fächer in Richtung Kunst mit Schwerpunkt Fotografie, sowie in Richtung Naturwissenschaften gelehrt.\nFinanziellen Rückhalt erhält die Blackwell Academy durch die Prescott-Familie, denen zudem halb Arcadia Bay gehört.\nUnd schon etwas vom Vortex Club gehört? Nun, in dem Club, welches schon Jahrzehnte existiert hat, kommen nur die angesagtesten und reichsten Studenten von Blackwall.\nDer Vortex Club veranstaltet immer wieder Partys, bei der es beim letzten Mal zu einem Zwischenfall kam: Eine Schülerin der Blackwell Academy wurde unter Drogen gesetzt und ein dubioses Video mit ihr online gestellt. Über Wochen wurde - auch außerhalb von Arcadia Bay – darüber geredet.\nDoch das jüngste Ereignis aus Blackwall überschattet alles: Rachel Amber, Chloes beste Freundin wird seit dem Sommer vermisst.\nNun möchten Chloe und du gemeinsam herausfinden, was in der Acadamy vor sich geht. Eurer Ziel: In das Büro des Schulleiters gelangen!\nPass aber besser auf, denn Chloes Stiefvater, der als Wachmann an der Blackwell Academy arbeitet, hat heute Nachtschicht und könnte dir zufällig über den Weg laufen…");
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