using System;
using System.Collections.Generic;
using Poke.API.Entities;

namespace SocialMedia.Core.Entities
{
    public sealed class Post : BaseEntity
    {

        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }

    public class Comment : BaseEntity
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }

    public sealed class User : BaseEntity
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Posts = new HashSet<Post>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateBirthday { get; set; }
        public string Telephone { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
