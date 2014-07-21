using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookmarkSharp.DataModel;
using BookmarkSharp.DataAccess;

namespace BookmarkSharp.DataAccess.Controllers
{
    public class BookmarkController : ApiController
    {
        public BookmarkController()
        {
        }

        // GET api/bookmarks
        public IEnumerable<Bookmark> Get()
        {
            return CRUD.Read.FindActiveBookmarks();
        }

        // GET api/bookmarks/5
        public Bookmark Get(int bookmarkID)
        {
            return CRUD.Read.FindBookmark(bookmarkID);
        }

        // POST api/bookmark
        public void Post([FromBody]Bookmark bookmark)
        {

        }

        // PUT api/research/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/bookmark/5
        public void Delete(int bookmarkID)
        {
            CRUD.Delete.DeleteBookmark(bookmarkID);
        }
    }
}
