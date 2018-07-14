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
            if(_words == enemy.Name)
            {
                for(;;)
                {
                    int i = RandomNumber.getAttackRandomNumber();
                    Console.WriteLine("Wähle weise: ");
                    string Input = Console.ReadLine().ToLower();
                    if(Input == "q" || Input == "quit")
                    {
                        Environment.Exit(0);
                    }
                    else if(Input != arr[0] && Input != arr[1] && Input != arr[2])
                    {
                        Console.WriteLine("Wrong Input.");
                    }
                    else if(Input == arr[i])
                    {
                        Console.WriteLine("Draw");
                    }
                    else if((Input == arr[0]) && (arr[1] == arr[i]) || (Input == arr[1]) && (arr[2] == arr[i]) || (Input == arr[2]) && (arr[0] == arr[i]))
                    {
                        enemy.Health  = enemy.Health - 33;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(Input.ToUpper() + " schlägt " + arr[i].ToUpper());
                        Console.ResetColor();
                    }
                    else
                    {
                        avatar.Health   = avatar.Health - 33;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(Input.ToUpper() + " verliert gegen " + arr[i].ToUpper());
                        Console.ResetColor();
                    }
                    Console.WriteLine("Enemy Health: " + enemy.Health );
                    Console.WriteLine("Max health : " + avatar.Health  );
                    if (enemy.Health == 1)
                    {
                        enemy.Life = false;
                        Console.WriteLine("Du hast den Wachmann besiegt.");
                        LootEnemy(location, enemy);
                        break;
                    }
                    else if (avatar.Health == 1)
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
            foreach(var i in enemy.Loot)
            {
                location.Items.Add(i);
            }
            // enemy.Loot.Remove(items);
            
            
            // Console.WriteLine("In Davids Taschen befinden sich");
            // foreach(var i in enemy.Loot)
            // {
            //     Console.WriteLine(i.title);
            // }
            // Console.WriteLine("Was möchten sie Looten?: ");
            // string Input = Console.ReadLine();
            // Items findItem = enemy.Loot.Find(x => x.title.Contains(Input));
            // if (findItem != null)
            // {
            //     avatar.Inventory.Add(findItem);
            //     enemy.Loot.Remove(findItem);
            // }

            

            // Items showLoot = enemy.Loot.Find(x => x.title == "Zentralschlüssel");
            // Console.WriteLine("Loot enemy");
            // Console.WriteLine(showLoot.title);
            // Console.WriteLine();
            // avatar.Inventory.Add(showLoot);

        }
    }
}