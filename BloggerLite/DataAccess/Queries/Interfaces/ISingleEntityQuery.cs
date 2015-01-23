using BloggerLite.DataAccess.Context.Interfaces;

namespace BloggerLite.DataAccess.Queries.Interfaces
{
    public interface ISingleEntityQuery<T>
    {
        /// <summary>
        /// Returns a single instance of T
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        T Find(IBlogContext repository);
    }
}
