using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Attack
    {
        public static void EnemyAttack(Avatar avatar, Enemy enemy)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Die Tür öffnet sich und der Wachman steht nun bei dir im Raum. Was willst du machen?");
            Console.ResetColor();
            Console.WriteLine("attack (a)");
            // while(Controls.input != "q")
            // {
            //     Controls.giveInput();
            //     switch(Controls.input)
            //     {
            //         case "attack":
            //         case "a":
            //             AttackNow(avatar, enemy);
            //         break;
            //         case "g":
            //         case "give up":
            //             Console.WriteLine("You given up");
            //             Environment.Exit(1);
            //         break;
            //     }
            // }
        }
        public static void AttackNow(Location location, Avatar avatar, Enemy enemy){
            // int securityhealth = Security.setSecurityHealth(100);
            string []arr = new string[]{"schere","papier","stein"};
            Console.WriteLine("Dieser Kampf basiert auf Schere,Papier,Stein.");
            for(;;)
            {
                int i = RandomNumber.getAttackRandomNumber();
                // Console.WriteLine("Randomnumber: " +i);
                Console.WriteLine("Wähle weise: ");
                string input = Console.ReadLine().ToLower();
                if(input != arr[0] && input != arr[1] && input != arr[2])
                {
                    Console.WriteLine("Wrong Input.");
                }
                else if(input == arr[i])
                {
                    Console.WriteLine("Draw");
                }
                else if(input == arr[0] && arr[1] == arr[i])
                {
                    enemy.health  = enemy.health - 33;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(input.ToUpper() + " schlägt " + arr[1].ToUpper());
                    Console.ResetColor();
                }
                else if(input == arr[1] && arr[2] == arr[i])
                {
                    enemy.health  = enemy.health - 33;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(input.ToUpper() + " schlägt " + arr[2].ToUpper());
                    Console.ResetColor();
                }
                else if(input == arr[2] && arr[0] == arr[i])
                {
                    enemy.health  = enemy.health - 33;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Stein schlägt " + arr[0].ToUpper());
                    Console.ResetColor();
                }
                else
                {
                    avatar.health   = avatar.health - 33;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(input.ToUpper() + " verliert gegen " + arr[i].ToUpper());
                    Console.ResetColor();
                }
                Console.WriteLine("Enemy Health: " + enemy.health );
                Console.WriteLine("Max health : " + avatar.health  );
                if (enemy.health == 1)
                {
                    enemy.life = false;
                    Console.WriteLine("Du hast den Wachmann besiegt.");
                    LootEnemy(location, enemy);
                    break;
                }
                else if (avatar.health == 1)
                {
                    Console.WriteLine("Du wurdest besiegt");
                    Environment.Exit(1);
                }
            }
        }
        public static void LootEnemy(Location location, Enemy enemy)
        {
            Console.WriteLine("Der Gegener hat einige Items droppen lassen");
            foreach(var i in enemy.loot)
            {
                location.items.Add(i);
            }
            // enemy.loot.Remove(items);
            
            
            // Console.WriteLine("In Davids Taschen befinden sich");
            // foreach(var i in enemy.loot)
            // {
            //     Console.WriteLine(i.title);
            // }
            // Console.WriteLine("Was möchten sie Looten?: ");
            // string input = Console.ReadLine();
            // Items findItem = enemy.loot.Find(x => x.title.Contains(input));
            // if (findItem != null)
            // {
            //     avatar.inventory.Add(findItem);
            //     enemy.loot.Remove(findItem);
            // }

            

            // Items showLoot = enemy.loot.Find(x => x.title == "Zentralschlüssel");
            // Console.WriteLine("Loot enemy");
            // Console.WriteLine(showLoot.title);
            // Console.WriteLine();
            // avatar.inventory.Add(showLoot);

        }
    }
}