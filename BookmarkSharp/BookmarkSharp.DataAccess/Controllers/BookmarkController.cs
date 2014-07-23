using BookmarkSharp.DataModel;
using System.Collections.Generic;
using System.Web.Http;

namespace BookmarkSharp.DataAccess.Controllers
{
    public class BookmarkController : ApiController
    {
        // GET api/bookmarks
        [HttpGet]
        [ActionName("Get")]
        public IEnumerable<Bookmark> Get()
        {
            return CRUD.Read.FindActiveBookmarks();
        }

        // GET api/bookmarks/5
        [HttpGet]
        [ActionName("Get")]
        public Bookmark Get(int id)
        {
            return CRUD.Read.FindBookmark(id);
        }

        // POST api/bookmark
        [HttpPost]
        public void Post([FromBody]Bookmark bookmark)
        {

        }

        // PUT api/research/5
        [HttpPost]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/bookmark/5
        [HttpPost]
        public void Delete(int bookmarkID)
        {
            CRUD.Delete.DeleteBookmark(bookmarkID);
        }
    }
}
