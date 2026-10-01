/**
 * Filnamn: Guestbook.cs
 * Författare: Hanna Lindkvist
 * Datum: 2026-10-01
 * Kurs: DT071G
 * 
 * Beskrivning: Publik klass Guestbook som hanterar att lägga till och ta bort inlägg i gästboken.
 * Metoderna AddPost och DelPost uppdaterar listan med inlägg och sparar den i JSON-filen via IPostStorage och metoden GetPosts returnerar listan med inlägg.
 * 
 * **/

namespace Laboration3
{
    public class Guestbook 
    {
        //Privat readonly variabel av typ IPostStorage
        private readonly IPostStorage storage;

        private List<Post> posts;
        //Konstruktor som hämtar inlägg från JSON-fil, tar emot parameter storage av typ IPostStorage
        public Guestbook(IPostStorage storage)
        {
            this.storage = storage;
            posts = storage.Load();
        }
        //Metod för att lägga till inlägg i listan, tar emot två parametrar, author och message, och sparar i JSON-filen via IPostStorage
        public Post AddPost(string author, string message)
        {
            Post post = new Post();
            post.Author = author;
            post.Message = message;
            posts.Add(post);
            storage.Save(posts);

            return post;
        }
        //Metod som tar bort inlägg för listan med index som parameter och sparar i JSON-filen via IPostStorage
        public int DelPost(int index)
        {
            posts.RemoveAt(index);
            storage.Save(posts);
            return index;
        }
        //Metod som returnerar listan med inlägg
        public List<Post> GetPosts()
        {
            return posts;
        }
    }

}