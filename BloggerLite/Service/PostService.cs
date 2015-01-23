using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using BloggerLite.DataAccess.Context;
using BloggerLite.DataAccess.Context.Interfaces;
using BloggerLite.DataAccess.Queries.Posts;
using BloggerLite.Entities;
using BloggerLite.Helpers;
using BloggerLite.Helpers.Interfaces;
using BloggerLite.Service.Interfaces;

namespace BloggerLite.Service
{
    public class PostService : IPostService
    {
        private readonly IBlogContext _repo;
        private readonly INewFactory<Post> _postOffice;
        private readonly ITagService _tagService;
        private readonly IPostTagService _postTagService;

        public PostService()
            : this(new BlogContext(), new NewFactory<Post>(), new TagService(),  new PostTagService()) { }
       
        public PostService(IBlogContext repo, INewFactory<Post> postOffice, ITagService tagService,  IPostTagService postTagService)
        {
            _repo = repo;
            _postOffice = postOffice;
            _tagService = tagService;
            _postTagService = postTagService;
        }

        public bool UpdatePost(int postId, string postTitle, string postContent, string postTags)
        {
            var postToUpdate = GetPost(postId);
            int result = 0;

            postToUpdate.Title = postTitle;
            postToUpdate.Content = postContent;

            
            

            AddTagsToPost(postToUpdate, postTags);

            //bug
            postToUpdate.Tags = new Collection<Tag>();

            result = _repo.SaveChanges();

            return result > 0;
        }

        public bool DeletePost(int postId)
        {
            var postToDelete = GetPost(postId);
            
            if (postToDelete != null)
            {
                foreach (var postTag in postToDelete.PostTags.ToList())
                {
                    _repo.Remove(postTag); 
                }
                
                postToDelete.Tags = null;

                _repo.Remove(postToDelete, true);
                return GetPost(postId) != null;
            }

            return false;
        }

        public void AddPost(string postTitle, string postAuthor, string postContent, string postTags)
        {
            var postToAdd = _postOffice.Get();
            
            postToAdd.Author = postAuthor;
            postToAdd.Content = postContent;
            postToAdd.CreatedOn = DateTime.Now;
            postToAdd.Title = postTitle;
            postToAdd.Tags = new List<Tag>();
            AddTagsToPost(_repo.Add(postToAdd, true), postTags);

            
        }

        public void AddTagsToPost(Post post , string tags)
        {
            var oldTags = post.Tags == null ? "" : post.Tags.Aggregate("", (current, tag) => current + tag.Name + " ");
            var tagsToAdd = string.IsNullOrEmpty(tags) ? new string[0]: tags.Split(',');
            var newTags = new ArrayList();

            foreach (var tag in tagsToAdd)
            {
                if (!oldTags.Contains(tag.Trim()))
                {
                    newTags.Add(tag.Trim());
                }
            } 

            foreach (var aTag in newTags)
            {
                if(string.IsNullOrEmpty(aTag.ToString()))
                {
                    continue;
                }

                if (!_tagService.DoesTagExist(aTag.ToString()))
                {
                    _tagService.AddTag(aTag.ToString());
                }

                var newTag = _tagService.GetTagByName(aTag.ToString().Trim());
                LinkTagToPost(post, newTag);
            }

            foreach (var tag in oldTags.Split(' '))
            {
                if (!String.IsNullOrEmpty(tag))
                {
                    if (!tagsToAdd.Contains(tag.Trim()))
                    {
                        DeleteTagFromPost(post, _tagService.GetTagByName(tag.Trim()));
                    }
                }
            }



        }
 
        public void DeleteTagFromPost(Post thePost, Tag theTag)
        {
            _postTagService.Delete(thePost.PostId, theTag.TagId);
        }

        public void LinkTagToPost(Post thePost, Tag theTag)
        {
            _postTagService.Add(thePost, theTag);
        }

        public Post GetPost(int postId)
        {
            var post = _repo.Find(new GetPostByIdQuery(postId));

            if (post == null)
            {
                return null;
            } 

            
            post.Tags = new List<Tag>();

            foreach (var postTag in post.PostTags)
            {
                var tagToAdd = _tagService.GetTagById(postTag.TagId);
                if (tagToAdd != null)
                {
                    post.Tags.Add(tagToAdd);   
                }
            }

            foreach (var tag in post.Tags)
            {
                if (tag.Name.Trim() == "Blog-Helper")
                {
                    post.NotEditable = true;
                    break;
                }
            }

            return post;
        }

        public List<Post> GetPostsByAuthor(string author)
        {
            return (List<Post>) _repo.Find(new GetPostsByAuthorQuery(author));
        }

        public List<Post> GetAllPosts()
        {
            return (List<Post>)_repo.Find(new GetAllPostsQuery());
        }

        public List<Post> GetPosts(int num)
        {
            return (List<Post>)_repo.Find(new GetPosts(num));
        }


        public List<Post> GetPostsByTag(string s)
        {
            return (List<Post>)_repo.Find(new GetPostByTagNameQuery(s));
        }

        public void IncrementViews(int i)
        {
            var post = GetPost(i);
            
            if (post == null)
            {
                return;
            }

            //PS
            //This line is needed to stop saving the tags to the database as we dont want that to happen. 
            //For more info comment it out, reload a blog view page and watch the tag table grow. EF Code first problem + my lack of coding skills :(
            post.Tags=new Collection<Tag>();

            post.Views++;
            _repo.SaveChanges();
        }

        public Post GetPostByTitle(string title)
        {
            return _repo.Find(new GetPostByTitleQuery(title));
        }
    }
}
