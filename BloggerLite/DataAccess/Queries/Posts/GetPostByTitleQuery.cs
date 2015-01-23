using System;
using System.Collections.Generic;
using System.Linq;
using BloggerLite.DataAccess.Context.Interfaces;
using BloggerLite.DataAccess.Queries.Interfaces;
using BloggerLite.DataAccess.Queries.Tags;
using BloggerLite.Entities;

namespace BloggerLite.DataAccess.Queries.Posts
{
    public class GetPostByTitleQuery : ISingleEntityQuery<Post>
    {
        public string PostTitle { get; set; }

        public GetPostByTitleQuery(string title)
        {
            PostTitle = title;
        }

        public Post Find(IBlogContext repository)
        {
            //TODO : Generalise this 
            var post = repository.SetOf<Post>().FirstOrDefault(p => p.Title.Replace(":", String.Empty).Replace("#", String.Empty) == PostTitle);

            if (post != null)
            {
                post.Tags = new List<Tag>();

                foreach (var postTag in post.PostTags)
                {
                    post.Tags.Add(repository.Find(new GetTagByTagIdQuery(postTag.TagId)));
                }
            }

            return post;
        } 
    }
}
