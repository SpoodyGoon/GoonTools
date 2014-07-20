using BookmarkSharp.DataAccess.Utility;
using BookmarkSharp.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BookmarkSharp.DataAccess.CRUD
{
    public class Delete
    {
        public static void DeleteBookmark(int bookmarkID)
        {
            using (SqlConnection connection = new SqlConnection(DataUtility.DefaultConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_BookmarkRemove", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;
                command.Parameters.AddWithValue("@BookmarkID", bookmarkID);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }


        public static void DeleteFolder(int folderID)
        {
            using (SqlConnection connection = new SqlConnection(DataUtility.DefaultConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_BookmarkFolderRemove", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;
                command.Parameters.AddWithValue("@FolderID", folderID);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void DeleteTag(int tagID)
        {
            using (SqlConnection connection = new SqlConnection(DataUtility.DefaultConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_TagRemove", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;
                command.Parameters.AddWithValue("@TagID", tagID);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void DeleteConfig(int configID)
        {
            using (SqlConnection connection = new SqlConnection(DataUtility.DefaultConnectionString))
            {
                SqlCommand command = new SqlCommand("sp_BookmarkConfigRemove", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 300;
                command.Parameters.AddWithValue("@ConfigID", configID);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}