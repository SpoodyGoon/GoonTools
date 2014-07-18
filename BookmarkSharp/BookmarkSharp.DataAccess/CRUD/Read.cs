using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using BookmarkSharp.DataModel;
using System.Text;

namespace BookmarkSharp.DataAccess.CRUD
{
    public class Read
    {
        public static Bookmark FindBookmark(int bookmarkID)
        {
            Bookmark bookmark = new Bookmark();
            ModelStatus outModelStatus;
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = new SqlCommand("sp_BookmarksGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;
                command.Parameters.AddWithValue("@BookmarkID", bookmarkID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    bookmark.BookmarkID = Convert.ToInt32(reader["BookmarkID"]);
                    bookmark.Title = reader["Title"].ToString();
                    bookmark.URL = reader["URL"].ToString();
                    bookmark.Position = Convert.ToInt32(reader["Position"]);
                    bookmark.Comment = reader["Comment"].ToString();
                    if (Enum.TryParse<ModelStatus>(reader["StatusName"].ToString(), out outModelStatus))
                    {
                        bookmark.BookmarkStatus = outModelStatus;
                    }
                }
                reader.Close();
                connection.Close();
            }
            return bookmark;
        }

        public static List<Bookmark> FindActiveBookmarks()
        {
            List<Bookmark> bookmarks = new List<Bookmark>();
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = new SqlCommand("sp_BookmarksGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;
                command.Parameters.AddWithValue("@StatusID", "1");
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                }
                reader.Close();
                connection.Close();
            }
            return bookmarks;
        }

        public static List<Bookmark> FindBookmarks(BookmarkFolder folder)
        {
            List<Bookmark> bookmarks = new List<Bookmark>();
            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand command = new SqlCommand("sp_BookmarksGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;
                command.Parameters.AddWithValue("@FolderID", folder.FolderID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                }
                reader.Close();
                connection.Close();
            }
            return bookmarks;
        }

        private const string TagXMLFormat = "<Tags>{0}</Tags>";
        private const string TagIDXMLFormat = "<TagID>{0}</TagID>";
        public static List<Bookmark> FindBookmarks(List<BookmarkTag> tags)
        {
            List<Bookmark> bookmarks = new List<Bookmark>();

            if (tags.Count > 0)
            {
                StringBuilder tagsStringBuilder = new StringBuilder();
                foreach (var tag in tags)
                {
                    tagsStringBuilder.Append(string.Format(TagIDXMLFormat, tag.TagID.ToString()));
                }

                using (SqlConnection connection = new SqlConnection())
                {
                    SqlCommand command = new SqlCommand("sp_BookmarksByTagsGet", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 300;
                    command.Parameters.AddWithValue("@Tags", string.Format(TagXMLFormat, tagsStringBuilder.ToString()));
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            return bookmarks;
        }

    }
}