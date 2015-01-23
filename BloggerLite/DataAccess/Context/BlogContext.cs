using System.Collections.Generic;
using System.Data.Entity;
using BloggerLite.DataAccess.Context.Interfaces;
using BloggerLite.DataAccess.Queries.Interfaces;
using BloggerLite.Entities;

namespace BloggerLite.DataAccess.Context
{
    public class BlogContext : DbContext , IBlogContext
    {
        public IDbSet<Post> Posts { get; set; }
        public IDbSet<Tag> Tags { get; set; }
        public IDbSet<PostTag> PostTags { get; set; }

        public BlogContext()
        {
            Database.SetInitializer<BlogContext>(new BlogInitializer());

            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("Post");
            modelBuilder.Entity<Tag>().ToTable("Tag");
            modelBuilder.Entity<PostTag>().ToTable("PostTag");
            base.OnModelCreating(modelBuilder);
        }

        #region Methods
        public void Remove<T>(T item, bool commit = false) where T : class
        {
            this.Set<T>().Remove(item);
            if (commit)
            {
                SaveChanges();
            }
        }

        public T Find<T>(ISingleEntityQuery<T> query) where T : class
        {
            return query.Find(this);
        }

        public IEnumerable<T> Find<T>(IEntityQuery< T> query) where T : class
        {
            return query.Find(this);
        }

        public IDbSet<T> SetOf<T>() where T : class
        {
            return this.Set<T>();
        }

        public T Add<T>(T item, bool commit = false) where T : class
        {
            var aSet = this.Set<T>();

            aSet.Add(item);

            if (commit)
            {
                SaveChanges();
            }

            return item;
        } 
        #endregion
    }
    
}
