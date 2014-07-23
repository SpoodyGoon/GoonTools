using BookmarkSharp.DataModel;
using System.Collections.Generic;
using System.Web.Http;


namespace BookmarkSharp.DataAccess.Controllers
{
    public class FolderController : ApiController
    {
        // GET api/folder
        public IEnumerable<BookmarkFolder> Get()
        {
            return CRUD.Read.FindActiveFolders();
        }

        // GET api/folder/5
        public BookmarkFolder Get(int id)
        {
            return CRUD.Read.FindFolder(id);
        }

        // POST api/folder
        [HttpPost]
        public void Post([FromUri]BookmarkFolder folder)
        {
            BookmarkFolder f = new BookmarkFolder()
            {
                FolderName = "Test Folder",
                Position = 1,
                Depth = 0,
                Comment = "Text comment"
            };
            CRUD.Create.CreateFolder(ref folder);

        }

        // PUT api/folder/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/folder/5
        public void Delete(int id)
        {
        }
    }
}
