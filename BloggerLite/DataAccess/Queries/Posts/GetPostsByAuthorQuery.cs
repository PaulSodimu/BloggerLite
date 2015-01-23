using System.Collections.Generic;
using System.Linq;
using BloggerLite.DataAccess.Context.Interfaces;
using BloggerLite.DataAccess.Queries.Interfaces;
using BloggerLite.Entities;

namespace BloggerLite.DataAccess.Queries.Posts
{
    public class GetPostsByAuthorQuery : IEntityQuery<Post>
    {
        public string AuthorName { get; set; }

        public GetPostsByAuthorQuery(string authorName)
        {
            AuthorName = authorName;
        }

        public IEnumerable<Post> Find(IBlogContext repo)
        {
            return repo.Find(new GetAllPostsQuery()).Where(post => string.Equals(post.Author, AuthorName)).ToList();
        }
    }
}
