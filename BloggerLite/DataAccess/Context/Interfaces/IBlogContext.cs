using System.Collections.Generic;
using System.Data.Entity;
using BloggerLite.DataAccess.Queries.Interfaces;

namespace BloggerLite.DataAccess.Context.Interfaces
{
    public interface IBlogContext
    {
        int SaveChanges();
        void Dispose();

        T Find<T>(ISingleEntityQuery<T> query) where T : class;

        IEnumerable<T> Find<T>(IEntityQuery<T> query) where T : class;

        T Add<T>(T item, bool commit) where T : class;

        void Remove<T>(T item, bool commit = false) where T : class;

        IDbSet<T> SetOf<T>() where T : class;
    }
}
