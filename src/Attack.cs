using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Attack
    {
        public static void EnemyCurrentRoom(Avatar avatar, Enemy enemy)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Der Wachmann David betritt das Zimmer in dem du dich gerade Befindest.");
            Console.ResetColor();
            Console.WriteLine("attack (a) <name>");
        }
        public static void AttackEnemy(string _words, Location location, Avatar avatar, Enemy enemy)
        {
            string []_arr = new string[]{"stein","schere","papier"};
            Console.WriteLine("Dieser Kampf basiert auf Stein, Schere,Papier.");
            if(_words.ToLower() == enemy.Name.ToLower())
            {
                for(;;)
                {
                    int i = RandomNumber.GetAttackRandomNumber();
                    Console.WriteLine("Wähle weise: ");
                    string Input = Console.ReadLine().ToLower();
                    
                    if(Input == "q" || Input == "quit")
                    {
                        Environment.Exit(0);
                    }
                    
                    else if(Input != _arr[0] && Input != _arr[1] && Input != _arr[2])
                    {
                        Console.WriteLine("Wrong Input.");
                    }
                    
                    else if(Input == _arr[i])
                    {
                        ConsoleOutput.AttackDraw();
                    }
                    
                    else if((Input == _arr[0]) && (_arr[1] == _arr[i]) || (Input == _arr[1]) && (_arr[2] == _arr[i]) || (Input == _arr[2]) && (_arr[0] == _arr[i]))
                    {
                        enemy.Health  = enemy.Health - 1;
                        ConsoleOutput.EnemyHit(Input, _arr[i]);
                    }
                    
                    else
                    {
                        Avatar.Characters["Max"].Health = Avatar.Characters["Max"].Health - 1;
                        ConsoleOutput.AvatarHit(Input, _arr[i]);
                    }
                    Console.WriteLine(enemy.Name + " Lebenspunkte: " + enemy.Health);
                    Console.WriteLine(Avatar.Characters["Max"].Name + " Lebenspunkte: " + Avatar.Characters["Max"].Health);
                    
                    if (enemy.Health == 0)
                    {
                        enemy.Life = false;
                        ConsoleOutput.AvatarWin();
                        Items.DropLoot(_words, location);
                        break;
                    }
                    else if (Avatar.Characters["Max"].Health == 0)
                    {
                        ConsoleOutput.AvatarLose();
                        Environment.Exit(1);
                    }
                }
            }
            else
            {
                Console.WriteLine("Du hast einen Falschen Namen eingegeben");
            }
        }
    }
}