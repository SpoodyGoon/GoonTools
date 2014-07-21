using BookmarkSharp.DataAccess.Utility;
using BookmarkSharp.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BookmarkSharp.DataAccess.CRUD
{
    public class Update
    {
        public static void UpdateBookmark(Bookmark bookmark)
        {
            using (SqlConnection connection = new SqlConnection(DataUtility.DefaultConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_BookmarkAddUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;
                command.Parameters.AddWithValue("@BookmarkID", bookmark.BookmarkID);
                if (bookmark.FolderID != null)
                {
                    command.Parameters.AddWithValue("@FolderID", bookmark.FolderID);
                }

                if (!string.IsNullOrEmpty(bookmark.Comment))
                {
                    command.Parameters.AddWithValue("@Comment", bookmark.Comment);
                }

                if (bookmark.BookmarkStatus != null)
                {
                    command.Parameters.AddWithValue("@StatusID", bookmark.BookmarkStatus);
                }

                command.Parameters.AddWithValue("@Title", bookmark.Title);
                command.Parameters.AddWithValue("@URL", bookmark.URL);
                command.Parameters.AddWithValue("@Position", bookmark.Position);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }


        public static void UpdateFolder(BookmarkFolder folder)
        {
            using (SqlConnection connection = new SqlConnection(DataUtility.DefaultConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_BookmarkFolderAddUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;
                command.Parameters.AddWithValue("@FolderID", folder.FolderID);
                command.Parameters.AddWithValue("@FolderName", folder.FolderName);
                command.Parameters.AddWithValue("@Depth", folder.Depth);
                command.Parameters.AddWithValue("@Position", folder.Position);

                if (!string.IsNullOrEmpty(folder.Comment))
                {
                    command.Parameters.AddWithValue("@Comment", folder.Comment);
                }

                if (folder.FolderStatus != null)
                {
                    command.Parameters.AddWithValue("@StatusID", folder.FolderStatus);
                }
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void UpdateTag(BookmarkTag tag)
        {
            using (SqlConnection connection = new SqlConnection(DataUtility.DefaultConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_TagAddUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;
                command.Parameters.AddWithValue("@TagID", tag.TagID);
                command.Parameters.AddWithValue("@TagName ", tag.TagName);
                command.Parameters.AddWithValue("@BitMask", tag.BitMask);
                command.Parameters.AddWithValue("@Position", tag.Position);
                if (!string.IsNullOrEmpty(tag.Comment))
                {
                    command.Parameters.AddWithValue("@Comment", tag.Comment);
                }

                if (tag.TagStatus != null)
                {
                    command.Parameters.AddWithValue("@StatusID", tag.TagStatus);
                }

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void UpdateConfig(BookmarkSharpConfig config)
        {
            using (SqlConnection connection = new SqlConnection(DataUtility.DefaultConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_BookmarkConfigAddUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;
                if (config.DefaultSortBy != null)
                {
                    command.Parameters.AddWithValue("@DefaultSortBy", config.DefaultSortBy);
                }

                command.Parameters.AddWithValue("@ConfigID", config.ConfigID);
                command.Parameters.AddWithValue("@FullName", config.FullName);
                command.Parameters.AddWithValue("@UserName", config.UserName);
                command.Parameters.AddWithValue("@Password", config.Password);
                command.Parameters.AddWithValue("@IsActive", (int)(config.IsActive ? 1 : 0));
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void UpdateConfig(int bookmarkID, BookmarkTagAction bookmarkTagAction, List<BookmarkTag> tagList)
        {
            string tagXML = string.Empty;
            using (SqlConnection connection = new SqlConnection(DataUtility.DefaultConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_BookmarkTagRelationManager", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;

                if (tagList.Count > 0)
                {
                    command.Parameters.AddWithValue("@Tags", DataUtility.TagXMLCreate(tagList));
                }

                command.Parameters.AddWithValue("@BookmarkID", bookmarkID);
                command.Parameters.AddWithValue("@RelationAction", bookmarkTagAction.ToString());
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}