using System.Collections.Generic;
using BloggerLite.Entities;

namespace BloggerLite.Models
{
    public class BlogViewModel
    {
        public List<Post> BlogPosts { get; set; } 
        public List<Post> RecentPosts { get; set; } 
        public List<KeyValuePair<string, int>> PopularTags { get; set; }
    }
}
