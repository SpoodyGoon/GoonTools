using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookmarkSharp.DataModel
{
    public class Bookmark
    {
        public int BookmarkID { get; set; }
        public string BookmarkName { get; set; }
        public string URL { get; set; }
        public List<BookmarkTag> Tags { get; set; }
    }
}
