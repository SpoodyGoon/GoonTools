using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookmarkSharp.DataAccess.DataModel
{
    public class BookmarkFolder
    {
        public int BookmarkFolderID { get; set; }
        public int Depth { get; set; }
        public string FolderName { get; set; }
        public string Comment { get; set; }
    }
}
