//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookmarkSharp.DataAccess.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_Bookmark
    {
        public tb_Bookmark()
        {
            this.tb_Tag = new HashSet<tb_Tag>();
        }
    
        public int BookmarkID { get; set; }
        public int FolderID { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public int Position { get; set; }
        public string Comment { get; set; }
        public short StatusID { get; set; }
    
        public virtual tb_Folder tb_Folder { get; set; }
        public virtual ICollection<tb_Tag> tb_Tag { get; set; }
    }
}
