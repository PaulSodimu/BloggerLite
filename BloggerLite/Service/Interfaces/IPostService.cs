using System.Collections.Generic;
using BloggerLite.Entities;

namespace BloggerLite.Service.Interfaces
{
    public interface IPostService
    {
        /// <summary>
        /// Updates a post with the specified Id with the specified information 
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="postTitle"></param>
        /// <param name="postContent"></param>
        /// <param name="postTags"></param>
        /// <returns></returns>
        bool UpdatePost(int postId, string postTitle, string postContent, string postTags);

        /// <summary>
        /// Deletes a post with the matching id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        bool DeletePost(int postId);

        /// <summary>
        /// Adds a new post with the specified parameters
        /// </summary>
        /// <param name="postTitle"></param>
        /// <param name="postAuthor"></param>
        /// <param name="postContent"></param>
        /// <param name="postTags"></param>
        void AddPost(string postTitle, string postAuthor, string postContent, string postTags);

        /// <summary>
        /// Gets a post by its Id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        Post GetPost(int postId);

        /// <summary>
        /// Gets a List of posts by author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        List<Post> GetPostsByAuthor(string author);

        /// <summary>
        /// Returns a list of all posts.
        /// </summary>
        /// <returns></returns>
        List<Post> GetAllPosts();

        /// <summary>
        /// Returns a list
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        List<Post> GetPostsByTag(string s);

        /// <summary>
        /// Increase views for a post with the specified id
        /// </summary>
        /// <param name="i"></param>
        void IncrementViews (int i);

        /// <summary>
        /// Gets a post with the specified title
        /// </summary>
        /// <param name="title">The title of the post to get</param>
        /// <returns></returns>
        Post GetPostByTitle(string title);

        /// <summary>
        /// This method will return a specified number of posts with the newest post first
        /// </summary>
        /// <param name="numOfPosts">The number of posts to return</param>
        /// <returns>Returns a list of posts</returns>
        List<Post> GetPosts(int numOfPosts);
    }
}
