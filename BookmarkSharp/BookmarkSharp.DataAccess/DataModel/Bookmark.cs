using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookmarkSharp.DataAccess.DataModel
{
    public class Bookmark
    {
        public int BookmarkID { get; set; }
        public string BookmarkName { get; set; }
        public string URL { get; set; }
        public List<BookmarkTag> Tags { get; set; }
    }
}
