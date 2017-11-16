using System.Collections.Generic;
using Domain.Base;

namespace Domain
{
    public class Post : Entity
    {
        public string Body { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public IList<Comment> Comments { get; set; }
        public Post()
        {
            Comments = new List<Comment>();
        }
    }
}
