using System.Collections.Generic;
using BloggerLite.Entities;

namespace BloggerLite.Service.Interfaces
{
    public interface IPostFinder
    {
        /// <summary>
        /// Returns a post finder with searchMode set to specified value
        /// </summary>
        /// <param name="searchMode">The name of the post field to search. e.g. Author</param>
        /// <returns>Returns a post finder</returns>
        PostFinder PostsWith(string searchMode);

        PostFinder Containing(string searchText);

        /// <summary>
        /// Finds posts matc
        /// </summary>
        /// <returns></returns>
        List<Post> Find();
    }
}
