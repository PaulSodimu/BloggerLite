using System.Collections.Generic;
using BloggerLite.DataAccess.Context;
using BloggerLite.DataAccess.Context.Interfaces;
using BloggerLite.DataAccess.Queries.Tags;
using BloggerLite.Entities;
using BloggerLite.Helpers;
using BloggerLite.Helpers.Interfaces;
using BloggerLite.Service.Interfaces;

namespace BloggerLite.Service
{
    public class TagService : ITagService
    {
        private readonly IBlogContext _ctx;
        private readonly INewFactory<Tag> _tagFactory;
        private readonly IPostTagService _postTagService;


        public TagService()
            : this(new BlogContext(), new NewFactory<Tag>(), new PostTagService()) { }

        public TagService(IBlogContext ctx, INewFactory<Tag> tagFactory, IPostTagService postTagService)
        {
            _ctx = ctx;
            _tagFactory = tagFactory;
            _postTagService = postTagService;
        }

        public bool DoesTagExist(string tagName)
        {
            return GetTagByName(tagName) != null;
        }

        public bool AddTag(string tagName)
        {
            if (DoesTagExist(tagName))
            {
                return false;
            }

            var tagToAdd = _tagFactory.Get();
            tagToAdd.Name = FormatTagName(tagName);

            _ctx.Add(tagToAdd, true);
             
            return DoesTagExist(tagToAdd.Name);
        }

        public bool DeleteTag(string tagName)
        {
            var tagToDelete = GetTagByName(tagName);

            if (tagToDelete != null)
            {
                _ctx.Remove(tagToDelete, true);
                return DoesTagExist(tagName);
            }

            return false;
        }

        public string FormatTagName(string tagName)
        {
            return tagName.Trim();
        }

        public Tag GetTagByName(string tagName)
        {
            var name = FormatTagName(tagName);
            return _ctx.Find(new GetTagByTagNameQuery(name));
        }

        public Tag GetTagById(int tagId)
        {
            return _ctx.Find(new GetTagByTagIdQuery(tagId));
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return  _ctx.Find(new GetAllTagsQuery())  ;
        }

        public Dictionary<string, int> GetPopularTags()
        {
            var popularTags = new Dictionary<string, int>();
            
            var holding = new Dictionary<int, int>();

            var postTags = _postTagService.GetAll();


            foreach (var postTag in postTags)
            {
                if(holding.ContainsKey(postTag.TagId))
                {
                    holding[postTag.TagId]++;
                }
                else
                {
                    holding.Add(postTag.TagId, 1);
                }
            }

            foreach (KeyValuePair<int, int> keyValuePair in holding)
            {
                var tag = GetTagById(keyValuePair.Key);

                popularTags.Add(tag.Name, keyValuePair.Value);
            }


            return popularTags;
        }
    }
}
