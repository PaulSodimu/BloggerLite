using System.Collections.Generic;
using BloggerLite.DataAccess.Context.Interfaces;

namespace BloggerLite.DataAccess.Queries.Interfaces
{
    public interface IEntityQuery<T>
    {
        /// <summary>
        /// Returns an Enumerable collection of T
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        IEnumerable<T> Find(IBlogContext repository);
    }
}
