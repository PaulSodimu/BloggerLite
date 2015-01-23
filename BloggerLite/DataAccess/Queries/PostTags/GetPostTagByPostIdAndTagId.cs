using System.Linq;
using BloggerLite.DataAccess.Context.Interfaces;
using BloggerLite.DataAccess.Queries.Interfaces;
using BloggerLite.Entities;

namespace BloggerLite.DataAccess.Queries.PostTags
{
    public class GetPostTagByPostIdAndTagId : ISingleEntityQuery<PostTag>
    {
        public int PostId { get; set; }
        public int TagId { get; set; }

        public GetPostTagByPostIdAndTagId(int postId, int tagId)
        {
            PostId = postId;
            TagId = tagId;
        }

        public PostTag Find(IBlogContext repo)
        {

            return repo.SetOf<PostTag>().FirstOrDefault(p => p.PostId == PostId && p.TagId == TagId);
        }
    }
}
