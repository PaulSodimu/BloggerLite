using System.Collections.Generic;
using System.Linq;
using BloggerLite.Entities;
using BloggerLite.Models;
using BloggerLite.Service;
using BloggerLite.Service.Interfaces;
using BloggerLite.ViewHelpers.Interfaces;

namespace BloggerLite.ViewHelpers
{
    public class BlogModelGetter : IBlogModelGetter
    {
        private readonly ITagService _tagService;
        private readonly IPostService _postService;


        public BlogModelGetter()
            : this(new TagService(), new PostService()) { }

        public BlogModelGetter(ITagService tagService, IPostService postService)
        {
            _tagService = tagService;
            _postService = postService;
        }

        public BlogViewModel Get(List<Post> posts)
        {
            var model = new BlogViewModel { BlogPosts = posts };

            var allPosts = _postService.GetAllPosts();

            model.RecentPosts = allPosts.OrderByDescending(p => p.PostId).Take(10).ToList();
            model.PopularTags = _tagService.GetPopularTags().OrderByDescending(t => t.Value).ToList();

            return model;
        }
    }
}