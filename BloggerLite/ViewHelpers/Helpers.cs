using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloggerLite.ViewHelpers
{
    public static class Helpers
    {
        public static bool IsAction(this HtmlHelper htmlHelper, string actionName)
        {
            return HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString() == actionName;
        }

        public static bool IsController(this HtmlHelper htmlHelper, string controllerName)
        {
            return HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString() ==
                   controllerName;
        }

        public static string CleanTitle(this HtmlHelper htmlHelper, string title)
        {
            var charsToRemove = new string[] { ":", ".", "#" };
            foreach (var c in charsToRemove)
            {
                title = title.Replace(c, string.Empty);
            }

            title = title.Replace(' ', '-');

            return title;
        }

        public static string GetSnippet(this HtmlHelper htmlHelper, string content)
        {
            var snippetLength = int.Parse(ConfigurationManager.AppSettings["SnippetLength"].ToString());
            var snippet = "";

            if (content.Contains("<Snip />"))
            {
                snippet = content.Split(new string[] { "<Snip />" }, StringSplitOptions.None)[0];
            }
            else
            {
                snippet = string.Join(" ", content.Split().Take(snippetLength));
            }


            return snippet;
        }

        public static int CalculateReadTime(this HtmlHelper htmlHelper, string content)
        {
            var readTime = 0;

            var words = content.Split().Count();

            readTime = words / 200;

            if (readTime == 0) readTime = 1;

            return readTime;
        }


    }
}
