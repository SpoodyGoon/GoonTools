using System;
using System.Collections.Generic;
using BookmarkSharp.DataAccess.Utility;

namespace BookmarkSharp.DataModel
{
    public class Bookmark
    {
        public int BookmarkID { get; set; }
        public Nullable<int> FolderID { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public int Position { get; set; }
        public string Comment { get; set; }
        public ModelStatus BookmarkStatus { get; set; }
        public string BookmarkStatusName
        {
            get { return this.BookmarkStatus.ToString(); }
            set
            {
                this.BookmarkStatus = DataUtility.ModelStatusParse(value);
            }
        }
        public List<BookmarkTag> Tags { get; set; }
    }
}