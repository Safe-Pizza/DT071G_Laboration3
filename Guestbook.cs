using System;
using System.ComponentModel;

namespace Laboration3
{
    public class Guestbook 
    {
        private readonly IPostStorage storage;

        private List<Post> posts;
        public Guestbook(IPostStorage storage)
        {
            this.storage = storage;
            posts = storage.load();
        }
        public Post AddPost(string author, string message)
        {
            Post post = new Post();
            post.Author = author;
            post.Message = message;
            posts.Add(post);
            storage.Save(posts);

            return post;
        }

        public int DelPost(int index)
        {
            posts.RemoveAt(index);
            storage.Save(posts);
            return index;
        }

        public List<Post> GetPosts()
        {
            return posts;
        }
    }

}