using System;

namespace Blog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
        public string Image { get; set; } = "";
        public DateTime Created { get; set; } = DateTime.Now;

        public string TruncatedBody
        {
            get
            {
                return this.Body.Length > 83 ? this.Body.Substring(0, 83) + "..." : this.Body;
            }
        }
    }
}
