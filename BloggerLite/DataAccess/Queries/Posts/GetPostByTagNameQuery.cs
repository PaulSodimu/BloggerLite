using System.Collections.Generic;
using System.Linq;
using BloggerLite.DataAccess.Context.Interfaces;
using BloggerLite.DataAccess.Queries.Interfaces;
using BloggerLite.Entities;

namespace BloggerLite.DataAccess.Queries.Posts
{
    public class GetPostByTagNameQuery : IEntityQuery<Post>
    {
        public string TagName { get; set; } 

        public GetPostByTagNameQuery(string tagName)
        {
            TagName = tagName;
        }

        public IEnumerable<Post> Find(IBlogContext repo)
        {
            var posts =   new List<Post>();

            foreach (var post in repo.Find(new GetAllPostsQuery()))
            {

                var tagNames = post.Tags == null ? "" : post.Tags.Aggregate("", (current, tag) => current + tag.Name);
                if(tagNames.Contains(TagName))
                {
                    posts.Add(post);
                }
            }

            return posts;
        }
    }
}
