using System.Collections.Generic;
using System.Linq;
using BloggerLite.DataAccess.Context.Interfaces;
using BloggerLite.DataAccess.Queries.Interfaces;
using BloggerLite.DataAccess.Queries.Tags;
using BloggerLite.Entities;

namespace BloggerLite.DataAccess.Queries.Posts
{
    public class GetPostByIdQuery : ISingleEntityQuery<Post>
    {
        public int PostId { get; set; }

        public GetPostByIdQuery(int postId)
        {
            PostId = postId;
        }

        public Post Find(IBlogContext repo)
        {
            var post = repo.SetOf<Post>().FirstOrDefault(p => p.PostId == PostId);

            if (post != null)
            {
                post.Tags = new List<Tag>();

                foreach (var postTag in post.PostTags)
                {
                    post.Tags.Add(repo.Find(new GetTagByTagIdQuery(postTag.TagId)));
                }
            }
            
            return post;
        }
    }
}
