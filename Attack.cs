using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Attack
    {
        public static void EnemyAttack()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Die Tür öffnet sich und der Wachman steht nun bei dir im Raum. Was willst du machen?");
            Console.ResetColor();
            Console.WriteLine("attack (a) ore give up(g)");
            while(Controls.input != "q")
            {
                Controls.giveInput();
                switch(Controls.input)
                {
                    case "attack":
                    case "a":
                        AttackNow();
                    break;
                    case "g":
                    case "give up":
                        Console.WriteLine("You given up");
                        Environment.Exit(1);
                    break;
                }
            }
        }
        public static void AttackNow(){
            Max.health1 = 100;
            Security.health2 = 100;
            string []arr = new string[]{"Schere","Stein","Papier"};
            for(int i = 0; i == RandomNumber.getAttackRandomNumber(); i++)
            {
                if(Controls.input == arr[i])
                {
                    
                }
            }
            
        }
    }
}