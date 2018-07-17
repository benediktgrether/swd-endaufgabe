using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class WinConditions
    {

        public static bool CheckFinished(Avatar avatar)
        {
            if(Location.rooms["Exit"].GameFinished == false)
            {
                if((Avatar.Characters["Max"].Inventory.Exists(x => x.Title == "Akte1")) && (Avatar.Characters["Max"].CurrentRoom == Location.rooms["Aula"].RoomNumber))
                {
                    Console.WriteLine("Herzlichen Glückwunsch, du hast die Akte über Rachel gefunden. Das Spiel wird nun beendet.");
                    Environment.Exit(0);
                }
                if(Avatar.Characters["Max"].CurrentRoom == Location.rooms["Exit"].RoomNumber)
                {
                    Console.WriteLine("Du kannst hier noch nicht lang gehen.\nFinde die richtige Schulakte");
                }
                return false;
            }
            return true;
        }
    }
}