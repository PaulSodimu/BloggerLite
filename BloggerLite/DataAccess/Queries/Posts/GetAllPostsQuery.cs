using System.Collections.Generic;
using System.Linq;
using BloggerLite.DataAccess.Context.Interfaces;
using BloggerLite.DataAccess.Queries.Interfaces;
using BloggerLite.DataAccess.Queries.Tags;
using BloggerLite.Entities;

namespace BloggerLite.DataAccess.Queries.Posts
{
    public class GetAllPostsQuery : IEntityQuery<Post>
    {
        public IEnumerable<Post> Find(IBlogContext repo)
        {
            var posts = repo.SetOf<Post>().OrderByDescending(x => x.PostId).ToList();

            foreach (var post in posts)
            {
                post.Tags = new List<Tag>();

                foreach (var postTag in post.PostTags)
                {
                    post.Tags.Add(repo.Find(new GetTagByTagIdQuery(postTag.TagId)));
                }
            }

            return posts;
        }
    }
}
