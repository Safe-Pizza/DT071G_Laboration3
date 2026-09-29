using System.Runtime.ConstrainedExecution;

namespace Laboration3
{
    class Program
    {
        static void Main(string[] args)
        {
            IPostStorage storage = new JsonPostStorage("C:\\Users\\hanna\\Desktop\\DT071G\\Laboration3\\Laboration3\\posts.json");
            Guestbook guestbook = new Guestbook(storage);

            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine("H A N N A S  G Ä S T B O K");
                Console.WriteLine();

                Console.WriteLine("1. Skapa inlägg");
                Console.WriteLine("2. Ta bort inlägg");
                Console.WriteLine("X. Avsluta");
                Console.WriteLine();
                Console.WriteLine();

                foreach (var item in guestbook.GetPosts().Select((post, index) => new { post.Author, post.Message, index }))
                {
                    Console.WriteLine($"[{item.index}] {item.Author} : {item.Message} ");
                }


                int inp = (int)Console.ReadKey(true).Key;

                switch (inp)
                {
                    case '1':
                        Console.CursorVisible = true;
                        Console.Write("Ange namn: ");
                        string? author = Console.ReadLine();
                        if (!String.IsNullOrEmpty(author))
                        {
                            Console.Write("Skriv ditt inlägg: ");
                            string? message = Console.ReadLine();
                            if (!String.IsNullOrEmpty(message))
                            {
                                guestbook.AddPost(author, message);
                            }
                        }
                        break;
                    case '2':
                        Console.CursorVisible = true;
                        Console.Write("Ange index på inlägg som ska tas bort: ");
                        string? index = Console.ReadLine();
                        if (!String.IsNullOrEmpty(index))
                        {
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
                    case 88:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}