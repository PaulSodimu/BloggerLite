using System.Collections.Generic;
using BloggerLite.DataAccess.Context.Interfaces;
using BloggerLite.DataAccess.Queries.Interfaces;
using BloggerLite.Entities;

namespace BloggerLite.DataAccess.Queries.Tags
{
    public class GetAllTagsQuery : IEntityQuery<Tag>
    {
        public IEnumerable<Tag> Find(IBlogContext repository)
        {
            return repository.SetOf<Tag>();
        }
    }
}
