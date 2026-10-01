/**
 * Filnamn: JsonPostStorage.cs
 * Författare: Hanna Lindkvist
 * Datum: 2026-10-01
 * Kurs: DT071G
 * 
 * Beskrivning: Publik klass som implementerrar interface IPostStorage. Initierar JsonPostStorage med filnamn som parameter.
 * Klassen laddar in och sparar Post-objekt i en JSON-fil. 
 * Klassen använder System.Text.Json för serialisering och deserialisering av Post-objekt.
 * 
 * **/

using System.Text.Json;

namespace Laboration3
{
public class JsonPostStorage : IPostStorage
    {
        private readonly string filename;

        public JsonPostStorage(string filename)
        {
            this.filename = filename;
        }
        public List<Post> Load()
        {
            if (!File.Exists(filename))
            {
                return new List<Post>();
            }
            string json = File.ReadAllText(filename);
            return JsonSerializer.Deserialize<List<Post>>(json) ?? new List<Post>();
        }
        public void Save(List<Post> posts)
        {
            string json = JsonSerializer.Serialize(posts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, json);
        }
    }
}
