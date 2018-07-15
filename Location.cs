using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Location
    {
        public string Title;
        public string Description;

        public int RoomNumber;

        public bool Open;

        public bool GameFinished;

        public Location North;
        public Location East;
        public Location South;
        public Location West;

        public List<Items> Items = new List<Items>();
        public static Dictionary<string, Location> rooms;

        public Location(int _roomNumber, string _title, string _description, bool _open, bool _GameFinished)
        {
            RoomNumber = _roomNumber;
            Title = _title;
            Description = _description;
            Open = _open;
            GameFinished = _GameFinished;

        }
        public static Location MapSetUp()
        {
            #region Object Rooms
            Location hallway = new Location
            (
                0,
                "Aula",
                "Du befindest dich gerade in der Aula der Blackwall Academy. Du siehst:",
                true, true
            );

            Location restroom = new Location
            (
                1,
                "WC",
                "Du Befindest dich in der Frauen Toilette. In dem Raum siehst du folgende Sachen:", true ,true
            );

            Location sidePassage = new Location
            (
                2,
                "Seitengang", 
                "Du befindest dich im linken Seitenflügel der Aula. Hier gibt es verbindungen zu den Unterrichtsräumen und zum Aufenthaltsraum der Wachmänner. Du siehst:", true, true
            );
            
            Location chemistryLab = new Location
            (
                3,
                "Chemielabor", 
                "Der Chemielabor der Blackwall Academy besitzt über die neusten Gerätschaften. Diese wurden von den Finanziellen Spenden der Familie Prescott gekauft. Du siehst: ", true, true
            );
            Location security = new Location
            (
                4,
                "Security", 
                "Du befindest dich im Security", false, false
            );
            Location office = new Location
            (
                5,
                "Sekretariat", 
                "Du befindest dich im Sekretariat. In dem Raum befindet sich die Tür zum Büro des Schulleiters.\nDu siehst:", true, true
            );
            Location principal = new Location
            (
                6,
                "Büro Schulleiter", 
                "Du befindest dich im Büro des Schulleiters.\nAuf dem Schreibtisch steht ein Computer.\nDu siehst: ", false , false
            );
            Location exit = new Location
            (
                7, 
                "Exit", 
                "Game Finsihed", 
                false, 
                false
            );
            #endregion

            #region Object Items
            Items soda = new Items
            (
                "Limonade", "Eine Limonade, umgangssprachlich auch kurz Limo, ist ein alkoholfreies, gesüßtes und meist mit Kohlensäure versetztes Erfrischungsgetränk mit Fruchtauszügen auf Basis von Wasser.\nIm ursprünglichen Wortsinn ist Limonade ein Getränk aus mit Wasser verdünntem Zitronensaft.\nZu den Limonaden gehören auch die coffeinhaltigen Colagetränke und die meisten Energy-Drinks. Oft werden Limonaden zudem mit anderen Getränken gemischt. Verwandt mit der Limonade ist die Brause, die aber auch künstliche oder naturidentische Aroma- und Farbstoffe enthalten darf.", true, true
            ); 

            Items paper = new Items
            (
                "Papier", 
                "Auf der vorderseite sieht man eine Zeichnung einer Bombe\nAuf der Rückseite steht diese Beschreibung\nUm eine Rohrbombe zu bauen benötigst du Folgende Zutaten.\n-Zucker\n-Limonade\n-Klebeband\n-Natriumchlorid\nSchütte den Zucker zusammen mit dem Natriumchlorid in die Limonade und befestige die Rohrbombe nun mit dem Klebeband an dem zu sprengenden Objekt\nPS: Ihr habt diese Information nicht von mir. \n- Science Guy", 
                true, false
            );

            Items ductTape = new Items
            (
                "Klebeband", "Klebeband ist eine Sammelbezeichnung für ein- oder beidseitig mit Haftklebstoffen beschichtete, streifenförmige Trägermaterialien, z. B. aus Kunststofffolien bzw. -schäumen, Papier, Metallfolien oder Textilgewebe.\nIn der industriellen Fertigung kommen auch sogenannte Transferklebebänder zum Einsatz: trägerfreie, dünne Haftklebstofffilme, die vor der Verarbeitung beidseitig mit gewachstem oder silikonisiertem Schutzpapier abgedeckt werden", true, true
            );

            Items sodiumChlorate = new Items
            (
                "Natriumchlorid", "Natriumchlorid (Kochsalz) ist das Natriumsalz der Salzsäure mit der chemischen Formel NaCl.\nNatriumchlorid bildet farblose Kristalle, die eine kubische Natriumchlorid-Struktur ausbilden. Sie sind, im Gegensatz zu vielen anderen Kristallen, nicht doppelbrechend. Hierbei ist jeder Natrium- sowie jeder Chlorkern oktaedrisch vom jeweils anderen Kern umgeben. Es ist sehr gut wasserlöslich. Natriumchlorid besitzt den typischen Salzgeschmack.", true , true
            );

            Items sugar = new Items
            (
                "Zucker", "Als Zucker wird neben verschiedenen anderen Zuckerarten ein süß schmeckendes, kristallines Lebensmittel bezeichnet, das aus Pflanzen gewonnen wird und hauptsächlich aus Saccharose besteht.",
                true, true
            );

            Items money = new Items
            (
                "1$", "Geldmünze mit dem Wert von 1$ die von der Federal Reserve System (Zentralbank-System der Vereinigten Staaten) herrausgegeben wird.", true , false
            );

            Items key = new Items
            (
                "Schlüssel", "Schlüssel zum Aufschließen eines Raumes\nVielleicht ist das der Schlüssel um in den Raum des Schulleiters zu kommen.", true , false
            );

            Items fileRachel = new Items
            (
                "Akte1", "-----------------\nRachel Amber - geboren am 22. Juli 1994 - \n-----------------\n(Notizzetel - Wird seit dem 22. April, 2013 vermisst)\n-----------------\nRachel Amber ist eine aufgeschlossen Schülerin. Sie hatte die letzten Jahre immer sehr gute Leistungen in allen Fächern. Ihre größte Stärke war das Schauspielen. Sie spielte die letzten Jahre immer die Hauptprotagonistin in unseren Sommerlichen Bühnenaufführung.\n-----------------\n1 Jahr vor ihrem verschwinden, veränderte sich Rachel als sie zusammen mit Chloe unterwegs war. Sie blieb öfters dem Unterricht fern und war eine Zeitlang in Behandlung.\n-----------------", true, false
            );

            Items fileChloe = new Items
            (
                "Akte2", "-----------------\nChloe Elizabeth Price - geboren am 11. März 1994 -\n-----------------\nChloe Elizabeth Price war zu beginn ihrer Schullaufbahn auf der Blackwell Academy eine ausgezeichnete Schülerin.\nNach dem Tod ihres Vaters - William Price - und der neuen Heirat ihrer Mutter mit unserem Wachmann David Madsen wurden ihre Schulischen Leistungen immer schlechter. Desweiteren blieb sie immer öfters der Schule fern. Nach dem letzten Fernbleiben zusammen mit Rachel Amber wurde Chloe Elizabeth Price von der Schule verwiesen\n-----------------", true, false
            );

            Items fileMax = new Items
            (
                "Akte3", "-----------------\nMaxine Caulfield - geboren 21. September 1995 -\n-----------------\nMaxine Caulfield ist zurück nach Arcadia Bay gezogen und hat sich in dem Kunstfach Fotografie eingeschrieben.\n-----------------", true, false
            );

            Items fileWarren = new Items
            (
                "Akte4", "-----------------\nWarren Graham - geboren am 20. November 1996 -\n-----------------\nWarren ist ein hochintelligenter Schüler der Blackwall Academy. Er hat schon einige Preise für unsere Schule bei nationalen Wissenschaftswettbewerben gewonnen.\n-----------------", true, false
            );

            Items fileKate = new Items
            (
                "Akte5", "-----------------\nKate Beverly Marsh - geboren am 12. September 1995 -\n-----------------\nKate Beverly Marsh wird wegen einem viralen Video zurzeit an unsere Schule gemobbt. Sie selber sagt über das geschehen aus das Sie keine erinnerung daran habe. Ein Drogentest im Krankenhaus hat ergeben das ihr Drogen verabreicht worden sind. Kate ist seit dem sehr introvertiert geworden.\n-----------------\nKate Beverly Marsh befindet sich nach einem Suizid versuch in psychologischer Behandlung.\n-----------------", true, false
            );
            #endregion

            #region not usable Object Items
            Items vendingMachine = new Items
            (
                "Getränke Automat", "",false , false
            );
            Items locker1 = new Items
            (
                "Spind Linkeseite", "", false, false
            );
            Items locker2 = new Items
            (
                "Spind Rechteseite", "", false, false
            );
            Items microscope = new Items
            (
                "Mikroskop", "", false, false
            );

            // Reagenzglässer, Brenner, Formelsammlung, Brief an Kate , Feuerlöscher, 
            Items testTubes = new Items
            (
                "Reagenzgläser", "", false, false
            );
            Items chemistryBurner = new Items
            (
                "Bunsenbrenner", "", false, false
            );
            Items formulary = new Items
            (
                "Formelsammlung", "", false, false
            );
            Items letterForKate = new Items
            (
                "Brief an Kate", "...", true, false
            );
            #endregion

            hallway.North= restroom;
            hallway.East= office;
            hallway.West = sidePassage;
            hallway.South= exit;
            hallway.Items.AddRange(new List<Items>
            {
                soda, vendingMachine
            });

            restroom.South= hallway;
            restroom.Items.Add(paper);

            sidePassage.North= chemistryLab;
            sidePassage.East= hallway;
            sidePassage.South= security;
            sidePassage.Items.AddRange(new List<Items>
            {
                locker1, locker2
            });

            chemistryLab.South= sidePassage;
            chemistryLab.Items.AddRange(new List<Items>
            {
                ductTape, sodiumChlorate, microscope, testTubes, chemistryBurner,  formulary, letterForKate
            });

            security.North= sidePassage;

            office.West = hallway;
            office.East= principal;
            office.Items.AddRange(new List<Items>
            {
                sugar, money, key
            });

            principal.West = office;
            principal.Items.AddRange(new List<Items>
            {
                fileRachel, fileKate, fileChloe, fileMax, fileWarren
            });

            exit.North= hallway;

            rooms = new Dictionary<string, Location>();
            rooms["hallway"] = hallway;
            rooms["WC"] = restroom;
            rooms["Seitengang"] = sidePassage;
            rooms["Chemielabor"] = chemistryLab;
            rooms["Sekretariat"] = office;
            rooms["Büro Schulleiter"] = principal;
            rooms["Exit"] = exit;

            return hallway;
        }
        public static void NeighborRoom(Location location)
        {
            Console.WriteLine("");
        }
    }
}


