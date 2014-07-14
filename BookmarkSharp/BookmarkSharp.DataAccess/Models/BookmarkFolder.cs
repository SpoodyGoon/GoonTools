using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BookmarkSharp.DataModel
{
    public class BookmarkFolder
    {
        [Key()]
        public int FolderID { get; set; }
        public int Depth { get; set; }
        public int Position { get; set; }
        [Required()]
        public string FolderName { get; set; }
        public string Comment { get; set; }
        [Required()]
        public int BookmarkID { get; set; }
        //public List<Bookmark> Bookmarks { set; get; }
    }
}
