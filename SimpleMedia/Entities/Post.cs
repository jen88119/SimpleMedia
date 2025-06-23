using System;
using System.Collections.Generic;

namespace SimpleMedia.Entities
{
    public partial class Post
    {
        public Post()
        {
            Comment = new HashSet<Comment>();
        }

        public int PostID { get; set; }
        public string UserID { get; set; } = null!;
        public string Content { get; set; } = null!;
        public byte[]? Image { get; set; }
        public DateTime LastMaintainDt { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Comment> Comment { get; set; }
    }
}
