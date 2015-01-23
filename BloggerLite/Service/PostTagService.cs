using System.Collections.Generic;
using BloggerLite.DataAccess.Context;
using BloggerLite.DataAccess.Context.Interfaces;
using BloggerLite.DataAccess.Queries.PostTags;
using BloggerLite.Entities;
using BloggerLite.Helpers;
using BloggerLite.Helpers.Interfaces;
using BloggerLite.Service.Interfaces;

namespace BloggerLite.Service
{
    public class PostTagService : IPostTagService
    {
        private readonly IBlogContext _repo;
        private readonly INewFactory<PostTag> _newFactory;

        public PostTagService()
            : this(new BlogContext(), new NewFactory<PostTag>()) { }

        public PostTagService(IBlogContext repo, INewFactory<PostTag> newFactory)
        {
            _repo = repo;
            _newFactory = newFactory;
        }

        public bool Add(Post aPost, Tag aTag)
        {
            var postTag = _newFactory.Get();
            
            postTag.TagId = aTag.TagId;
            postTag.PostId = aPost.PostId;

            return _repo.Add(postTag, true) != null;
        }

        public bool Delete(int postId, int tagId)
        {
            var postTagToDelete = _repo.Find(new GetPostTagByPostIdAndTagId(postId, tagId));

            if (postTagToDelete != null)
            {
                _repo.Remove(postTagToDelete, true);
            }

            return _repo.Find(new GetPostTagByPostIdAndTagId(postId, tagId)) == null;
        }

        public IEnumerable<PostTag> GetAll()
        {
            return _repo.Find(new GetAllPostTagsQuery());
        }
    }
}
