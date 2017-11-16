using Domain.Base;
using Domain.Enum;
using System.Collections.Generic;

namespace Domain
{
    public class Author : Entity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
		public string Biography { get; set; }
		public LevelAccess LevelAccess { get; set; }
        //public IList<Post> Posts { get; set; }

        public Author()
        {
            //Posts = new List<Post>();
        }
    }
}
