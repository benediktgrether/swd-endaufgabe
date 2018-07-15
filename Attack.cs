using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Attack
    {
        public static void EnemyCurrentRoom(Avatar avatar, Enemy enemy)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Die Tür öffnet sich und David steht nun bei dir im Raum. Was willst du machen?");
            Console.ResetColor();
            Console.WriteLine("attack (a) <name>");
        }
        public static void AttackEnemy(string _words, Location location, Avatar avatar, Enemy enemy){
            string []arr = new string[]{"stein","schere","papier"};
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
                    
                    else if(Input != arr[0] && Input != arr[1] && Input != arr[2])
                    {
                        Console.WriteLine("Wrong Input.");
                    }
                    
                    else if(Input == arr[i])
                    {
                        ConsoleOutput.AttackDraw();
                    }
                    
                    else if((Input == arr[0]) && (arr[1] == arr[i]) || (Input == arr[1]) && (arr[2] == arr[i]) || (Input == arr[2]) && (arr[0] == arr[i]))
                    {
                        Enemy.Characters[_words].Health  = Enemy.Characters[_words].Health - 1;
                        ConsoleOutput.EnemyHit(Input, arr[i]);
                    }
                    
                    else
                    {
                        Avatar.Characters["Max"].Health = Avatar.Characters["Max"].Health - 1;
                        ConsoleOutput.AvatarHit(Input, arr[i]);
                    }
                    checkWin(_words, location, enemy);
                return;
                }
            }
            else
            {
                Console.WriteLine("Du hast einen Falschen Namen eingegeben");
            }
        }
        public static void checkWin(string _words,Location location, Enemy enemy)
        {
                                
            Console.WriteLine(Enemy.Characters[_words].Name + " Lebenspunkte: " + Enemy.Characters[_words].Health);
            Console.WriteLine(Avatar.Characters["Max"].Name + " Lebenspunkte: " + Avatar.Characters["Max"].Health);
            if (Enemy.Characters[_words].Health == 0)
            {
                enemy.Life = false;
                ConsoleOutput.AvatarWin();
                Items.DropLoot(_words, location);
                return;
            }
            else if (Avatar.Characters["Max"].Health == 0)
            {
                ConsoleOutput.AvatarLose();
                Environment.Exit(1);
            }

        }
    }
}