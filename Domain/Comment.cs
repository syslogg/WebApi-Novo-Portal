using Domain.Base;

namespace Domain
{
    public class Comment : Entity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public int PostId { get; set; }

    }
}
