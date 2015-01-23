using System.Linq;
using BloggerLite.DataAccess.Context.Interfaces;
using BloggerLite.DataAccess.Queries.Interfaces;
using BloggerLite.Entities;

namespace BloggerLite.DataAccess.Queries.Tags
{
    public class GetTagByTagIdQuery : ISingleEntityQuery<Tag>
    {
        public int TagId { get; set; }

        public GetTagByTagIdQuery(int tagId)
        {
            TagId = tagId;
        }

        public Tag Find(IBlogContext repo)
        {
            return repo.SetOf<Tag>().FirstOrDefault(t => t.TagId == TagId);
        }
    }
}
