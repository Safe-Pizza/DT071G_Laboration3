/**
 * Filnamn: Program.cs
 * Författare: Hanna Lindkvist
 * Datum: 2026-10-01
 * Kurs: DT071G
 * 
 * Beskrivning: Programmet är en gästbok som låter användaren skapa och ta bort inlägg. Inläggen sparas i en JSON-fil. 
 * Programmet använder en meny för att navigera mellan alternativen.
 * 
 * **/

namespace Laboration3
{
    class Program
    {
        static void Main(string[] args)
        {
            IPostStorage storage = new JsonPostStorage("C:\\Users\\hanna\\Desktop\\DT071G\\Laboration3\\Laboration3\\posts.json"); //Spara filnamn och sökväg i variabeln
            Guestbook guestbook = new Guestbook(storage); //Skapa en instans av klassen Guestbook med storage varibeln som parameter

            while (true) //Loop som körs tills användaren väljer att avsluta programmet
            {
                Console.Clear(); //Rensa konsolen
                Console.CursorVisible = false; //Göm markören

                //Programmets meny
                Console.WriteLine("H A N N A S  G Ä S T B O K");
                Console.WriteLine();

                Console.WriteLine("1. Skapa inlägg");
                Console.WriteLine("2. Ta bort inlägg");
                Console.WriteLine("X. Avsluta");
                Console.WriteLine();
                Console.WriteLine();

                //Loop för utskrift av alla inlägg i gästboken med index, författare och meddelande
                foreach (var item in guestbook.GetPosts().Select((post, index) => new { post.Author, post.Message, index }))
                {
                    Console.WriteLine($"[{item.index}] {item.Author} : {item.Message} ");
                }


                int inp = (int)Console.ReadKey(true).Key; //Lagra userinput i varibel

                //switch-stats som tar emot userinput 1, 2 eller X (88)
                switch (inp)
                {
                    //input 1 skapar nytt inlägg
                    case '1':
                    case (int)ConsoleKey.NumPad1:
                        Console.CursorVisible = true;
                        Console.Write("Ange namn: ");
                        string? author = Console.ReadLine();
                        if (!String.IsNullOrEmpty(author)) //Kontrollerar att author inte är null eller tomt
                        {
                            Console.Write("Skriv ditt inlägg: ");
                            string? message = Console.ReadLine();
                            if (!String.IsNullOrEmpty(message))
                            {
                                guestbook.AddPost(author, message);
                            }
                        }
                        break;
                        //input 2 ta bort inlägg med index som parameter
                    case '2':
                    case (int)ConsoleKey.NumPad2:
                        Console.CursorVisible = true;
                        Console.Write("Ange index på inlägg som ska tas bort: ");
                        string? index = Console.ReadLine();
                        if (!String.IsNullOrEmpty(index)) //Kontrollerar att index inte är null eller tomt
                        {
                            //Try och catch som hanterar borttagning av inlägg utifrån index samt felhantering om index inte är korrekt
                            try
                            {
                                int ind = Convert.ToInt32(index);
                                guestbook.DelPost(ind);

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"\nFel: {ex.Message}\nTryck på valfri tangent för att fortsätta...");
                                Console.ReadKey(true);
                            }
                        }
                            break;
                    //input X avslutar programmet
                    case 88:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}