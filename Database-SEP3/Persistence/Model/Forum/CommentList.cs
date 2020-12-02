using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Database_SEP3.Persistence.Model.Comment
{
    public class CommentList
    {
        public List<CommentModel> Comments { get; set; }


        public CommentList()
        {
            Comments = new List<CommentModel>();
        }

        public CommentModel GetComment(int index)
        {
            return Comments[index];
        }

        public void AddComment(CommentModel comment)
        {
            Comments.Add(comment);
        }

        public void RemoveComment(CommentModel comment)
        {
            Comments.Remove(comment);
        }

        public int Size()
        {
            return Comments.Count;
        }
        
        public override string ToString()
        {
            string s = "";
            foreach (var VARIABLE in Comments)
            {
                s += VARIABLE.ToString();
            }

            return s;
        }
    }
}