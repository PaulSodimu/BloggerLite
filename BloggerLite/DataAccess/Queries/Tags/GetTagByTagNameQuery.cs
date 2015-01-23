using System.Linq;
using BloggerLite.DataAccess.Context.Interfaces;
using BloggerLite.DataAccess.Queries.Interfaces;
using BloggerLite.Entities;

namespace BloggerLite.DataAccess.Queries.Tags
{
    public class GetTagByTagNameQuery : ISingleEntityQuery<Tag>
    {
        public string TagName { get; set; }

        public GetTagByTagNameQuery(string tagName)
        {
            TagName = tagName;
        }

        public Tag Find(IBlogContext repo)
        {
            return repo.SetOf<Tag>().FirstOrDefault(t => t.Name == TagName);
        }
    }
}
