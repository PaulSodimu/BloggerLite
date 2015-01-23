using System.Collections.Generic;
using BloggerLite.Entities;

namespace BloggerLite.Service.Interfaces
{
    public interface ITagService
    {
        /// <summary>
        /// This method checks if a tag with the specified name exists in the database.
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        bool DoesTagExist(string tagName);

        /// <summary>
        /// This method creates a new tag with the specified name.
        /// </summary>
        /// <param name="tagName">The name of the tag to create</param>
        bool AddTag(string tagName);

        /// <summary>
        /// This method deletes a tag with the specified name
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        bool DeleteTag(string tagName);

        /// <summary>
        /// Trims the new name for the tag and converts it to lower.
        /// </summary>
        /// <param name="tagName">The tag name to be formatted</param>
        /// <returns></returns>
        string FormatTagName(string tagName);

        /// <summary>
        /// Gets a tag that has the name specified.
        /// </summary>
        /// <param name="tagName"></param>
        /// <returns></returns>
        Tag GetTagByName(string tagName);

        /// <summary>
        /// Gets a tag that has the specified Id
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns></returns>
        Tag GetTagById(int tagId);

        /// <summary>
        /// Returns a collection of all tags that have been used.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Tag> GetAllTags();

        /// <summary>
        /// Returns a collection of popular tags and the number of poata they appear in 
        /// </summary>
        /// <returns></returns>
        Dictionary<string, int> GetPopularTags();

    }
}
