using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BookmarkSharp.DataModel
{
    public class BookmarkFolder
    {
        public int FolderID { get; set; }
        public int Depth { get; set; }
        public int Position { get; set; }
        public string FolderName { get; set; }
        public string Comment { get; set; }
        public int BookmarkID { get; set; }
        public ModelStatus FolderStatus { get; set; }
        public List<Bookmark> Bookmarks { set; get; }
    }
}
