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
        public List<Post> load()
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
