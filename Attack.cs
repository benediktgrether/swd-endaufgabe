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
            int maxhealth = Max.setMaxHealth(100);
            int securityhealth = Security.setSecurityHealth(100);
            string []arr = new string[]{"schere","papier","stein"};
            Console.WriteLine("Dieser Kampf basiert auf Schere,Papier,Stein.");
            for(;;)
            {
                int i = RandomNumber.getAttackRandomNumber();
                Console.WriteLine("Randomnumber: " +i);
                Console.WriteLine("Wähle weise: ");
                string input = Console.ReadLine().ToLower();
                    if(input == arr[i])
                    {
                        Console.WriteLine("Draw");
                    }
                    else if(input == arr[0] && arr[1] == arr[i])
                    {
                        securityhealth  = securityhealth  - 33;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(input.ToUpper() + " schlägt " + arr[1].ToUpper());
                        Console.ResetColor();
                    }
                    else if(input == arr[1] && arr[2] == arr[i])
                    {
                        securityhealth  = securityhealth  - 33;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(input.ToUpper() + " schlägt " + arr[2].ToUpper());
                        Console.ResetColor();
                    }
                    else if(input == arr[2] && arr[0] == arr[i])
                    {
                        securityhealth  = securityhealth  - 33;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Stein schlägt " + arr[0].ToUpper());
                        Console.ResetColor();
                    }
                    else
                    {
                        maxhealth   = maxhealth   - 33;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(input.ToUpper() + " verliert gegen " + arr[i].ToUpper());
                        Console.ResetColor();
                    }
                    Console.WriteLine("Enemy Health: " + securityhealth );
                    Console.WriteLine("Max health : " + maxhealth  );
            }
        }
    }
}