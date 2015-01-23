using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BloggerLite.Entities
{
    public class Post
    {
        public int PostId { get; set; }

        [Required(ErrorMessage = "Please enter a title for the post")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please add some content")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Please enter the name of the author")]
        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool NotEditable { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public int Views { get; set; }

        public virtual ICollection<PostTag> PostTags { get; set; }
    }
}
