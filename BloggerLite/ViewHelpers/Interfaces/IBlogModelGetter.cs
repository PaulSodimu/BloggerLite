using System.Collections.Generic;
using BloggerLite.Entities;
using BloggerLite.Models;

namespace BloggerLite.ViewHelpers.Interfaces
{
    public interface IBlogModelGetter
    {
        BlogViewModel Get(List<Post> posts);
    }
}
