
namespace BookmarkSharp.DataModel
{
    public class BookmarkTag
    {
        public int TagID { get; set; }
        public string TagName { get; set; }
        public int BitMask { get; set; }
        public int Position { get; set; }
        public string Comment { get; set; }
        public ModelStatus TagStatus { get; set; }
    }
}
