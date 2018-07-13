using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Attack
    {
        public static void EnemyAttack(Avatar avatar, Enemy enemy)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Die Tür öffnet sich und David steht nun bei dir im Raum. Was willst du machen?");
            Console.ResetColor();
            Console.WriteLine("attack (a) <name>");
        }
        public static void AttackNow(string _words, Location location, Avatar avatar, Enemy enemy){
            // int securityhealth = Security.setSecurityHealth(100);
            string []arr = new string[]{"stein","schere","papier"};
            Console.WriteLine("Dieser Kampf basiert auf Stein, Schere,Papier.");
            if(_words == enemy.name)
            {
                for(;;)
                {
                    int i = RandomNumber.getAttackRandomNumber();
                    Console.WriteLine("Wähle weise: ");
                    string input = Console.ReadLine().ToLower();
                    if(input == "q" || input == "quit")
                    {
                        Environment.Exit(0);
                    }
                    else if(input != arr[0] && input != arr[1] && input != arr[2])
                    {
                        Console.WriteLine("Wrong Input.");
                    }
                    else if(input == arr[i])
                    {
                        Console.WriteLine("Draw");
                    }
                    else if(input == arr[0] && arr[1] == arr[i] || input == arr[1] && arr[2] == arr[i] || input == arr[2] && arr[0] == arr[i])
                    {
                        enemy.health  = enemy.health - 33;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(input.ToUpper() + " schlägt " + arr[i].ToUpper());
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
                return;
            }
            else
            {
                Console.WriteLine("Du hast einen Falschen Namen eingegeben");
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