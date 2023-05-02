using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class User
    {
        // Modeller örnektir düzenlenmeleri gerekmektedir.
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
        public int InvitedById { get; set; }
        public User InvitedBy { get; set; }
        public virtual ICollection<User> Children { get; set;}
    }

    public class Post
    {
        // Modeller örnektir düzenlenmeleri gerekmektedir.
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public User Author { get; set; }
        public ICollection<PostTag> PostTags { get; set; }
    }

    public class Tag
    {
        // Modeller örnektir düzenlenmeleri gerekmektedir.
        public int Id { get; set; }
        public string Names { get; set; }
        public ICollection<PostTag> PostTags { get; set; }
    }

    public class PostTag
    {
        // Modeller örnektir düzenlenmeleri gerekmektedir.
        public int PostId { get; set; }
        public int TagId { get; set; }
        public int Order { get; set; }
        public Post Post { get; set; }
        public Tag Tag { get; set; }
    }
}
