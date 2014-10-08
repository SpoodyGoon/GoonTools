using System.Collections.Generic;
using System.Web.Http;
using BookmarkSharp.DataModel;

namespace BookmarkSharp.DataAccess.Controllers
{
    public class TagController : ApiController
    {
        // GET api/tag
        public IEnumerable<BookmarkTag> Get()
        {
            return CRUD.Read.FindTags(string.Empty, null);
        }

        // GET api/tag/5
        public BookmarkTag Get(int id)
        {
            return CRUD.Read.FindTag(id);
        }

        // POST api/tag
        public void Post(BookmarkTag tag)
        {
            if (tag.TagID == null)
            {
                CRUD.Create.CreateTag(ref tag);
            }
            else
            {
                CRUD.Update.UpdateTag(tag);
            }
        }

        // PUT api/tag/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/tag/5
        public void Delete(int id)
        {
            CRUD.Delete.DeleteTag(id);
        }
    }
}
