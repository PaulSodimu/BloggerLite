using System.Collections.Generic;
using BloggerLite.Entities;
using BloggerLite.Service.Interfaces;

namespace BloggerLite.Service
{
    public class PostFinder : IPostFinder
    {
        private readonly IPostService _postService;

        private string _searchMode;
        private string _searchText;

        public PostFinder()
            : this(new PostService()){}

        public PostFinder(IPostService postService)
        {
            _postService = postService;
        }


        public PostFinder PostsWith(string searchMode)
        {
            _searchMode = searchMode;
            return this;
        }

        public PostFinder Containing(string searchText)
        {
            _searchText = searchText;
            return this;
        }

        public List<Post> Find()
        {
            var allPosts = _postService.GetAllPosts();
            var matchingPosts = new List<Post>();
             

            foreach (var post in allPosts)
            { 
                var propertyValue =
                    post.GetType().GetProperty(_searchMode).GetValue(post, null).ToString();
                
                if (propertyValue.ToLower().Contains(_searchText.ToLower()))
                {
                    matchingPosts.Add(post);
                }
            }

            return matchingPosts;
        }

    }
}
