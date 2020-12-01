using System.Collections.Generic;

namespace Database_SEP3.Persistence.Model.Post
{
    public class PostList
    {
        public List<PostModel> Posts { get; set; }

        public PostList()
        {
            Posts = new List<PostModel>();
        }

        public PostModel GetPost(int index)
        {
            return Posts[index];
        }

        public void AddPost(PostModel post)
        {
            Posts.Add(post);
        }

        public void RemovePost(PostModel post)
        {
            Posts.Remove(post);
        }

        public int Size()
        {
            return Posts.Count;
        }

        public override string ToString()
        {
            string s = "";
            foreach (var VARIABLE in Posts)
            {
                s += VARIABLE.ToString();
            }

            return s;
        }
    }
}