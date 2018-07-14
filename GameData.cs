using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class GameData
    {
        // public static Location MapSetUp()
        // {

        //     // Items item = Items.CreateRoomItems();
        //     Location aula = new Location
        //     (
        //         0,
        //         "Aula",
        //         "Du befindest dich gerade in der Aula",
        //         true, true
        //     );

        //     // Items soda = new Items
        //     // (
        //     //     "Soda", "xxx", true, true
        //     // ); 

        //     Location wc = new Location
        //     (
        //         1,
        //         "WC",
        //         "Du Befindest dich in der Toilette", true ,true
        //     );
        //     Items anleitung = new Items
        //     (
        //         "Anleitung", 
        //         "Hier ist eine Anleitung zum Bauen einer Bombe.\nDu benötigtst dafür\nZucker\nSoda Can\nPanzertape\nNatriumchlorat\n", 
        //         true, false
        //     );

        //     Location seitengang = new Location
        //     (
        //         2,
        //         "Seitengang", 
        //         "Du befindest dich im Seitengang", true, true
        //     );
            
        //     Location chemielabor = new Location
        //     (
        //         3,
        //         "Chemielabor", 
        //         "Du befindest dich im Chemielabor", true, true
        //     );
        //     Items klebeband = new Items
        //     (
        //         "Klebeband", "xxx", true, true
        //     );
        //     Items sodiumChlorate = new Items
        //     (
        //         "Natriumchlorid", "Natriumchlorid (Kochsalz) ist das Natriumsalz der Salzsäure mit der chemischen Formel NaCl.", true , true
        //     );

        //     Location security = new Location
        //     (
        //         4,
        //         "Security", 
        //         "Du befindest dich im Security", true, true
        //     );
        //     Location sekretariat = new Location
        //     (
        //         5,
        //         "Sekretariat", 
        //         "Du befindest dich im Sekretariat", true, true
        //     );
        //     Items suggar = new Items
        //     (
        //         "Zucker", "Als Zucker wird neben verschiedenen anderen Zuckerarten ein süß schmeckendes, kristallines Lebensmittel bezeichnet, das aus Pflanzen gewonnen wird und hauptsächlich aus Saccharose besteht.",
        //         true, true
        //     );
        //     Items money = new Items
        //     (
        //         "1€", "Geldmünze mit dem Wert von 1 €", true , false
        //     );
        //     Items key = new Items
        //     (
        //         "Schlüssel", "Schlüssel", true , false
        //     );
        //     Location bueroRektor = new Location
        //     (
        //         6,
        //         "Büro Rektor", 
        //         "Du befindest dich im Büro des Rektors", false , false
        //     );
        //     Items fileRachel = new Items
        //     (
        //         "Akte1", "Akte über die Schullaufbahn von Rachel mit dem verweis das Sie vermisst wird.", true, false
        //     );
        //     Items fileChloe = new Items
        //     (
        //         "Akte2", "Akte über die Schullaufbahn von Chloe und ein vermerk das Sie von der Schule geflogen ist.", true, false
        //     );
        //     Items fileMax = new Items
        //     (
        //         "Akte3", "Akte über die Schullaufbahn von Max", true, false
        //     );
        //     Items fileWarren = new Items
        //     (
        //         "Akte4", "Akte über die Schullaufbahn von Warren und ein vermerk über seine besonderen Leistung im Chemiefach", true, false
        //     );
        //     Items fileKate = new Items
        //     (
        //         "Akte5", "Akte über die Schullaufbahn von Kate, mit dem verweis das sie gemobbt worden ist.", true, false
        //     );

        //     Location exit = new Location
        //     (
        //         7, 
        //         "Exit", 
        //         "Game Finsihed", 
        //         false, 
        //         false
        //     );


        //     aula.North= wc;
        //     aula.East= sekretariat;
        //     aula.West = seitengang;
        //     aula.South= exit;
        //     // Aula.items.AddRange(new List<string>
        //     // {"Soda", "Taschentücher"})
        //     // aula.Items.Add(soda);

        //     wc.South= aula;
        //     wc.Items.Add(anleitung);

        //     seitengang.North= chemielabor;
        //     seitengang.East= aula;
        //     seitengang.South= security;

        //     chemielabor.South= seitengang;
        //     chemielabor.Items.AddRange(new List<Items>
        //     {
        //         klebeband, sodiumChlorate
        //     });

        //     security.North= seitengang;

        //     sekretariat.West = aula;
        //     sekretariat.East= bueroRektor;
        //     sekretariat.Items.AddRange(new List<Items>
        //     {
        //         suggar, money, key
        //     });

        //     bueroRektor.West = sekretariat;
        //     bueroRektor.Items.AddRange(new List<Items>
        //     {
        //         fileRachel, fileKate, fileChloe, fileMax, fileWarren
        //     });

        //     exit.North= aula;

        //     rooms = new Dictionary<string, Location>();
        //     rooms["Aula"] = aula;
        //     rooms["WC"] = wc;
        //     rooms["Seitengang"] = seitengang;
        //     rooms["Chemielabor"] = chemielabor;
        //     rooms["Sekretariat"] = sekretariat;
        //     rooms["Büro Rektor"] = bueroRektor;
        //     rooms["Exit"] = exit;

        //     return aula;
        // }

        // public static Avatar setupAvatar()
        // {
        //     Avatar max = new Avatar(
        //         "Max", 100, 0, Location.rooms["Aula"]
        //     );
        //     return max;
        // }

        // public static Enemy SetupEnemy()
        // {
        //     Enemy david = new Enemy(
        //         "David", 100, 5, true, "Wachmann"
        //     );
        //     Items centralKey = new Items
        //     (
        //         "Zentralschlüssel", "Zentralschlüssel der Zugang zu allen Räumen bietet.", true, false
        //     );
        //     Items mobilePhone = new Items
        //     (
        //         "Handy", "Davids Handy", true , false
        //     );
        //     Items carKey = new Items
        //     (
        //         "Autoschlüssel", "David fährt einen Blauen Ford Mustang Boss 429 (1969)", false, false
        //     );
        //     david.Loot.AddRange(new List<Items>
        //     {
        //         centralKey, mobilePhone, carKey
        //     });

        //     return david;
        // }
    }
}