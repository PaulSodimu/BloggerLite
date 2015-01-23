using System;
using System.Collections.Generic;
using System.Data.Entity;
using BloggerLite.DataAccess.Context;
using BloggerLite.Entities;

namespace BloggerLite.DataAccess
{
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {


            var posts = new List<Post>
                            {
                                new Post()
                                    {
                                        Author = "Admin",
                                        Content = 
                                                  @"<p>You have successfully created your blog!!. Start adding your posts using the PostService class.</p>", 
                                        CreatedOn = DateTime.UtcNow,
                                        PostId = 1,
                                        Views = 1000,
                                        Title = "The First Post"
                                         
                                    } 
                            };

            posts.ForEach(p => context.Posts.Add(p));
        }
    }
}
