using BookmarkSharp.DataAccess.Utility;
using BookmarkSharp.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BookmarkSharp.DataAccess.CRUD
{
    public class Create
    {
        public static void CreateBookmark(ref Bookmark bookmark)
        {
            using (SqlConnection connection = new SqlConnection(DataUtility.DefaultConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_BookmarkAddUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;
                SqlParameter bookmarkIDParameter = new SqlParameter("@BookmarkID", SqlDbType.Int);
                bookmarkIDParameter.Direction = ParameterDirection.InputOutput;
                command.Parameters.Add(bookmarkIDParameter);

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
                bookmark.BookmarkID = Convert.ToInt32(bookmarkIDParameter.Value);
                connection.Close();
            }
        }


        public static void CreateFolder(ref BookmarkFolder folder)
        {
            using (SqlConnection connection = new SqlConnection(DataUtility.DefaultConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_BookmarkFolderAddUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;
                SqlParameter folderIDParameter = new SqlParameter("@FolderID", SqlDbType.Int);
                folderIDParameter.Direction = ParameterDirection.InputOutput;
                command.Parameters.Add(folderIDParameter);
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
                folder.FolderID = Convert.ToInt32(folderIDParameter.Value);
                connection.Close();
            }
        }

        public static void CreateTag(ref BookmarkTag tag)
        {
            using (SqlConnection connection = new SqlConnection(DataUtility.DefaultConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_TagAddUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;
                SqlParameter tagIDParameter = new SqlParameter("@TagID", SqlDbType.Int);
                tagIDParameter.Direction = ParameterDirection.InputOutput;
                command.Parameters.Add(tagIDParameter);
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
                tag.TagID = Convert.ToInt32(tagIDParameter.Value);
                connection.Close();
            }
        }

        public static void CreateConfig(ref BookmarkSharpConfig config)
        {
            using (SqlConnection connection = new SqlConnection(DataUtility.DefaultConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_BookmarkConfigAddUpdate", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;
                SqlParameter configIDParameter = new SqlParameter("@ConfigID", SqlDbType.Int);
                configIDParameter.Direction = ParameterDirection.InputOutput;
                command.Parameters.Add(configIDParameter);

                if (config.DefaultSortBy != null)
                {
                    command.Parameters.AddWithValue("@DefaultSortBy", config.DefaultSortBy);
                }

                command.Parameters.AddWithValue("@FullName", config.FullName);
                command.Parameters.AddWithValue("@UserName", config.UserName);
                command.Parameters.AddWithValue("@Password", config.Password);
                command.Parameters.AddWithValue("@IsActive", (int)(config.IsActive ? 1:0));
                connection.Open();
                command.ExecuteNonQuery();
                config.ConfigID = Convert.ToInt32(configIDParameter.Value);
                connection.Close();
            }
        }
    }
}