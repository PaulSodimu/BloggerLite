using System.Collections.Generic;
using BloggerLite.DataAccess.Context.Interfaces;
using BloggerLite.DataAccess.Queries.Interfaces;
using BloggerLite.Entities;

namespace BloggerLite.DataAccess.Queries.PostTags
{
    public class GetAllPostTagsQuery : IEntityQuery<PostTag>
    {
        public IEnumerable<PostTag> Find(IBlogContext repository)
        {
            return repository.SetOf<PostTag>();
        }
    }
}
