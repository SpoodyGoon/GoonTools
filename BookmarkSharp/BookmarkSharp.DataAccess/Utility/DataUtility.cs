using System;
using System.Text;
using System.Collections.Generic;
using BookmarkSharp.DataModel;

namespace BookmarkSharp.DataAccess.Utility
{
    public static class DataUtility
    {
        //public static ModelStatus ModelStatusParse(string statusName)
        //{
        //    ModelStatus outModelStatus;
        //    ModelStatus returnStatus = ModelStatus.None;
        //    if (Enum.TryParse<ModelStatus>(statusName, out outModelStatus))
        //    {
        //        returnStatus = outModelStatus;
        //    }
        //    return returnStatus;
        //}

        private const string TagXMLFormat = "<Tags>{0}</Tags>";
        private const string TagIDXMLFormat = "<TagID>{0}</TagID>";
        public static string TagXMLCreate(List<BookmarkTag> tags)
        {
            StringBuilder tagsStringBuilder = new StringBuilder();
            foreach (var tag in tags)
            {
                tagsStringBuilder.Append(string.Format(TagIDXMLFormat, tag.TagID.ToString()));
            }

            return string.Format(TagXMLFormat, tagsStringBuilder.ToString());
        }

        public static string DefaultConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["BSConn"].ConnectionString;
            }
        }
    }
}