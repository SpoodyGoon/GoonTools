using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookmarkSharp.DataModel
{
    public class Bookmark
    {
        public int BookmarkID { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public int Position { get; set; }
        public string Comment { get; set; }
        public ModelStatus BookmarkStatus { get; set; }
        public List<BookmarkTag> Tags { get; set; }
    }
}