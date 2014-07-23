using BookmarkSharp.DataAccess.Utility;
using BookmarkSharp.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BookmarkSharp.DataAccess.CRUD
{
    public class Read
    {
        #region Bookmarks

        public static Bookmark FindBookmark(int bookmarkID)
        {
            Bookmark bookmark = new Bookmark();
            using (SqlConnection connection = new SqlConnection(DataUtility.DefaultConnectionString))
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
                    bookmark.FolderID = Convert.ToInt32(reader["FolderID"]);
                    bookmark.Title = reader["Title"].ToString();
                    bookmark.URL = reader["URL"].ToString();
                    bookmark.Position = Convert.ToInt32(reader["Position"]);
                    bookmark.Comment = reader["Comment"].ToString();
                    bookmark.BookmarkStatus = DataUtility.ModelStatusParse(reader["StatusName"].ToString());
                }
                reader.Close();
                connection.Close();
            }
            return bookmark;
        }

        public static List<Bookmark> FindActiveBookmarks()
        {
            return FindBookmarks(null, null, null, 1);
        }

        public static List<Bookmark> FindBookmarks(Nullable<int> folderID, string title, string url, Nullable<int> statusID)
        {
            List<Bookmark> bookmarks = new List<Bookmark>();
            using (SqlConnection connection = new SqlConnection(DataUtility.DefaultConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_BookmarksGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;

                if (folderID != null)
                {
                    command.Parameters.AddWithValue("@FolderID", folderID);
                }

                if (!string.IsNullOrEmpty(title))
                {
                    command.Parameters.AddWithValue("@Title", title);
                }

                if (!string.IsNullOrEmpty(url))
                {
                    command.Parameters.AddWithValue("@URL", url);
                }

                if (statusID != null)
                {
                    command.Parameters.AddWithValue("@StatusID", statusID);
                }

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    bookmarks.Add(new Bookmark()
                    {
                        BookmarkID = Convert.ToInt32(reader["BookmarkID"]),
                        FolderID = Convert.ToInt32(reader["FolderID"]),
                        Title = reader["Title"].ToString(),
                        URL = reader["URL"].ToString(),
                        Position = Convert.ToInt32(reader["Position"]),
                        Comment = reader["Comment"].ToString(),
                        BookmarkStatus = DataUtility.ModelStatusParse(reader["StatusName"].ToString())
                    });

                }

                reader.Close();
                connection.Close();
            }

            return bookmarks;
        }

        public static List<Bookmark> FindBookmarks(List<BookmarkTag> tagList)
        {
            List<Bookmark> bookmarks = new List<Bookmark>();
            if (tagList.Count > 0)
            {
                string tagXML = DataUtility.TagXMLCreate(tagList);
                using (SqlConnection connection = new SqlConnection(DataUtility.DefaultConnectionString))
                {
                    SqlCommand command = new SqlCommand("sp_BookmarksByTagsGet", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 300;
                    command.Parameters.AddWithValue("@Tags", tagXML);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        bookmarks.Add(new Bookmark()
                        {
                            BookmarkID = Convert.ToInt32(reader["BookmarkID"]),
                            FolderID = Convert.ToInt32(reader["FolderID"]),
                            Title = reader["Title"].ToString(),
                            URL = reader["URL"].ToString(),
                            Position = Convert.ToInt32(reader["Position"]),
                            Comment = reader["Comment"].ToString(),
                            BookmarkStatus = DataUtility.ModelStatusParse(reader["StatusName"].ToString())
                        });
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            return bookmarks;
        }

        #endregion Bookmarks

        #region Folders

        public static BookmarkFolder FindFolder(int folderID)
        {
            BookmarkFolder folder = new BookmarkFolder();
            using (SqlConnection connection = new SqlConnection(DataUtility.DefaultConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_BookmarkFoldersGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;
                command.Parameters.AddWithValue("@FolderID", folderID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    folder.FolderID = Convert.ToInt32(reader["FolderID"]);
                    folder.FolderName = reader["FolderName"].ToString();
                    folder.Depth = Convert.ToInt32(reader["Depth"]);
                    folder.Position = Convert.ToInt32(reader["Position"]);
                    folder.Comment = reader["Comment"].ToString();
                    folder.FolderStatus = DataUtility.ModelStatusParse(reader["StatusName"].ToString());
                }
                reader.Close();
                connection.Close();
            }
            return folder;
        }
        public static List<BookmarkFolder> FindActiveFolders()
        {
            return FindFolders(null, null, 1);
        }

        public static List<BookmarkFolder> FindFolders(string folderName, Nullable<int> depth, Nullable<int> statusID)
        {
            List<BookmarkFolder> folders = new List<BookmarkFolder>();
            using (SqlConnection connection = new SqlConnection(DataUtility.DefaultConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_BookmarkFoldersGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;

                if (!string.IsNullOrEmpty(folderName))
                {
                    command.Parameters.AddWithValue("@FolderName", folderName);
                }

                if (depth != null)
                {
                    command.Parameters.AddWithValue("@Depth", depth);
                }

                if (statusID != null)
                {
                    command.Parameters.AddWithValue("@StatusID", statusID);
                }

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    folders.Add(new BookmarkFolder()
                    {
                        FolderID = Convert.ToInt32(reader["FolderID"]),
                        FolderName = reader["FolderName"].ToString(),
                        Depth = Convert.ToInt32(reader["Depth"]),
                        Position = Convert.ToInt32(reader["Position"]),
                        Comment = reader["Comment"].ToString(),
                        FolderStatus = DataUtility.ModelStatusParse(reader["StatusName"].ToString())
                    });
                }

                reader.Close();
                connection.Close();
            }
            return folders;
        }

        public static List<BookmarkFolder> FindFolders(List<BookmarkTag> tagList)
        {
            List<BookmarkFolder> folders = new List<BookmarkFolder>();
            if (tagList.Count > 0)
            {
                string tagXML = DataUtility.TagXMLCreate(tagList);
                using (SqlConnection connection = new SqlConnection(DataUtility.DefaultConnectionString))
                {
                    SqlCommand command = new SqlCommand("sp_FoldersByTagsGet", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 300;
                    command.Parameters.AddWithValue("@Tags", tagXML);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        folders.Add(new BookmarkFolder()
                        {
                            FolderID = Convert.ToInt32(reader["FolderID"]),
                            FolderName = reader["FolderName"].ToString(),
                            Depth = Convert.ToInt32(reader["Depth"]),
                            Position = Convert.ToInt32(reader["Position"]),
                            Comment = reader["Comment"].ToString(),
                            FolderStatus = DataUtility.ModelStatusParse(reader["StatusName"].ToString())
                        });
                    }

                    reader.Close();
                    connection.Close();
                }
            }

            return folders;
        }

        #endregion Folders

        #region Tags

        public static BookmarkTag FindTag(int tagID)
        {
            BookmarkTag tag = new BookmarkTag();
            using (SqlConnection connection = new SqlConnection(DataUtility.DefaultConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_BookmarkTagGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;
                command.Parameters.AddWithValue("@TagID", tagID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tag.TagID = Convert.ToInt32(reader["TagID"]);
                    tag.TagName = reader["TagName"].ToString();
                    tag.BitMask = Convert.ToInt32(reader["BitMask"]);
                    tag.Position = Convert.ToInt32(reader["Position"]);
                    tag.Comment = reader["Comment"].ToString();
                    tag.TagStatus = DataUtility.ModelStatusParse(reader["StatusName"].ToString());
                }

                reader.Close();
                connection.Close();
            }
            return tag;
        }

        public static List<BookmarkTag> FindTags(string tagName, Nullable<int> statusID)
        {
            List<BookmarkTag> tags = new List<BookmarkTag>();
            using (SqlConnection connection = new SqlConnection(DataUtility.DefaultConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_BookmarkTagGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;

                if (!string.IsNullOrEmpty(tagName))
                {
                    command.Parameters.AddWithValue("@TagName", tagName);
                }

                if (statusID != null)
                {
                    command.Parameters.AddWithValue("@StatusID", statusID);
                }

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    tags.Add(new BookmarkTag()
                    {
                        TagID = Convert.ToInt32(reader["TagID"]),
                        TagName = reader["TagName"].ToString(),
                        BitMask = Convert.ToInt32(reader["BitMask"]),
                        Position = Convert.ToInt32(reader["Position"]),
                        Comment = reader["Comment"].ToString(),
                        TagStatus = DataUtility.ModelStatusParse(reader["StatusName"].ToString())
                    });
                }

                reader.Close();
                connection.Close();
            }

            return tags;
        }

        #endregion Tags

        #region Configuration

        public static BookmarkSharpConfig FindConfig(int configID)
        {
            BookmarkSharpConfig config = new BookmarkSharpConfig();
            using (SqlConnection connection = new SqlConnection(DataUtility.DefaultConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_BookmarkConfigGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;
                command.Parameters.AddWithValue("@ConfigID", configID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    config.ConfigID = Convert.ToInt32(reader["ConfigID"]);
                    config.FullName = reader["FullName"].ToString();
                    config.UserName = reader["UserName"].ToString();
                    config.Password = reader["Password"].ToString();
                    config.DefaultSortBy = reader["DefaultSortBy"].ToString();
                    config.IsActive = Convert.ToBoolean(reader["IsActive"]);
                }

                reader.Close();
                connection.Close();
            }
            return config;
        }

        public static BookmarkSharpConfig FindConfig(string userName)
        {
            BookmarkSharpConfig config = new BookmarkSharpConfig();
            using (SqlConnection connection = new SqlConnection(DataUtility.DefaultConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_BookmarkConfigGet", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;
                command.Parameters.AddWithValue("@UserName", userName);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    config.ConfigID = Convert.ToInt32(reader["ConfigID"]);
                    config.FullName = reader["FullName"].ToString();
                    config.UserName = reader["UserName"].ToString();
                    config.Password = reader["Password"].ToString();
                    config.DefaultSortBy = reader["DefaultSortBy"].ToString();
                    config.IsActive = Convert.ToBoolean(reader["IsActive"]);
                }

                reader.Close();
                connection.Close();
            }
            return config;
        }

        #endregion Configuration
    }
}