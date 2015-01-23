using System.Collections.Generic;
using BloggerLite.Entities;

namespace BloggerLite.Service.Interfaces
{
    public interface IPostTagService
    {
        /// <summary>
        /// This method creates a new PostTag
        /// </summary>
        /// <param name="aPost"></param>
        /// <param name="aTag"></param>
        /// <returns></returns>
        bool Add(Post aPost, Tag aTag);

        /// <summary>
        /// Deletes a PostTag
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="tagId"></param>
        /// <returns></returns>
        bool Delete(int postId, int tagId);

        /// <summary>
        /// Gets all the postTags
        /// </summary>
        /// <returns></returns>
        IEnumerable<PostTag> GetAll();
    }
}
