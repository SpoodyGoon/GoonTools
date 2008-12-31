/*
 * Creato da SharpDevelop.
 * Utente: Pierpaolo Romanelli
 * Data: 27/04/2007
 * Ora: 14.42
 *  Original article: http://www.codeproject.com/KB/IP/ParseMozillaBookmarksToDT.aspx
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 * Modified By: Andrew York
 * Date: 8/11/08
 */

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data;
namespace ImportMozilla
{
	/// <summary>
	/// Description of clsMozilla.
	/// </summary>
	public class clsMozilla
	{
		private static string htmlEnt(string strString )
		{
			// Replace HTML entities
			
			string strTmp;
			strTmp = strString;
			
			strTmp = strString.Replace( "&amp;", "&");
			strTmp = strString.Replace( "&lt;", "<");
			strTmp = strString.Replace( "&gt;", ">");
			strTmp = strString.Replace( "&quot;", "\"");
			
			return strTmp;
		}
		
		private static string GetURLFromHref(string StrLine)
		{
			//Define ArrayList in which all URLs will be stored
			ArrayList lv_URLs = new ArrayList();

			//This Regular Expression finds URL/anchor combinations
			Regex lv_FindAllURLs = new Regex("href\\s*=\\s*(?:(?:\\\"(?<url>[^\\\"]*)\\\")|(?<url>[^\\s]* ))",RegexOptions.IgnoreCase);

			// get all the matches depending upon the regular expression
			MatchCollection mMatchCollection = lv_FindAllURLs.Matches(StrLine);

			foreach(Match mMatch in mMatchCollection)
			{
				string lv_URL = mMatch.Groups["URI"].Value.ToString();
				string lv_Anchor = mMatch.Groups["Name"].Value.ToString();				
				lv_URLs.Add(lv_URL);
			}
			string link=mMatchCollection[0].Groups[1].Value;
			return link;

		}
		
		private static string StripHTMLTags(string StrText){
			
			//On retire le code HTML
			return Regex.Replace(StrText,@"<(.|\n)*?>",string.Empty);			
		}
		
		private static string utfDecode(string data)
		{
			try
			{
				System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
				System.Text.Decoder utf8Decode = encoder.GetDecoder();
				
				byte[] todecode_byte = Convert.FromBase64String(data);
				int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
				char[] decoded_char = new char[charCount];
				utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
				string result = new String(decoded_char);
				return result;
			}
			catch(Exception e)
			{
				throw new Exception("Error in base64Decode" + e.Message);
			}
		}
		
		private static string First(string s, int charcount)
		{
			if (s == null) return String.Empty;
			return s.Substring(0, Math.Min(s.Length, charcount)).ToLower();
		}
		
		public static DataTable ReadBookmark(string BookmarkFile)
		{
			string strCurrentLine=null; // Current line
			bool blnStarted=true;
			bool blnDontReadThisLine=false; // True if nothing should be readed in the current loop
			
			int intHierarchy =0;// Current hierarchy
			ArrayList lngCurInFolder= new ArrayList();
			lngCurInFolder.Add("");
			lngCurInFolder.Add("");
			lngCurInFolder.Add("");
			lngCurInFolder.Add("");
			
			DataTable dt = new DataTable();
			dt.Columns.Add( new DataColumn("id", typeof(Int32)));
			dt.Columns.Add( new DataColumn("parent_id", typeof(Int32)));
			dt.Columns.Add(new DataColumn("Title", typeof(string)));
			dt.Columns.Add(new DataColumn("URL", typeof(string)));
			dt.Columns.Add( new DataColumn("PathDepth", typeof(Int32)));
			dt.Columns.Add(new DataColumn("IsFolder", typeof(bool)));
			DataRow dr ;
			
			string strBookmarkTit ;// Title of the new bookmark
			string strBookmarkUrl ;// Url of the new bookmark
			bool blnUtf8=false;         // Need to decode UTF8?
			int times=0;
			int StrID=1;//this is the id key of link or folder, useful to identify a folder or link
			int Last_parent_id = 0;//this is the relation with a folder. 0 means that it is alone
			int Before_parent_id = 0;//when close the folder, this store the prev id

			StreamReader StreamBookMarks = new StreamReader(BookmarkFile);
			
			while( !StreamBookMarks.EndOfStream   )
			{				
				if(blnDontReadThisLine ==false)
				{strCurrentLine = StreamBookMarks.ReadLine();times++;}
				else
					blnDontReadThisLine = false;
				
				// Remove tabulators and leading spaces
				strCurrentLine=  strCurrentLine.Replace( "\t", "").Trim();
				
				//Import if the file is OK
				if (blnStarted )
				{
					//import Bookmark/Folder

					if(First(strCurrentLine,7) == "<dt><h3")
					{
						// New folder
						
						strBookmarkTit = "";
						// Read title
						strBookmarkTit = htmlEnt(StripHTMLTags(strCurrentLine));
						
						if( blnUtf8==true) strBookmarkTit = utfDecode(strBookmarkTit);
						// Read description. (Goes to the line where the folder is opened (<DL>)
						// Line breaks are displayed as <BR>
						
						// Read line
						strCurrentLine = StreamBookMarks.ReadLine();
						times++;
						// Remove tabs and leading spaces
						strCurrentLine=  strCurrentLine.Replace( "\t", "").Trim();
						
						//Read until the folder is opened
						while(!(First(strCurrentLine,4)=="<dl>"||StreamBookMarks.EndOfStream==true))
						{
							// The description starts with <DD> -> remove this tag
							strCurrentLine = Regex.Replace(strCurrentLine,@"<dd>",string.Empty,RegexOptions.IgnoreCase);
							// Convert line breaks
							strCurrentLine = Regex.Replace(strCurrentLine,@"<br>","\n",RegexOptions.IgnoreCase);
							
							// Read line
							strCurrentLine = StreamBookMarks.ReadLine();
							times++;
							// Remove tabs and leading spaces
							strCurrentLine=  strCurrentLine.Replace( "\t", "").Trim();
							
							
						}
						
						//Add folder
						if(strBookmarkTit != "")
						{
							
							if (intHierarchy > lngCurInFolder.Count)
								lngCurInFolder.Add ("");
							
							//lngCurInFolder[intHierarchy] = 2;//array of id Hiearchy
							dr= dt.NewRow ();
							dr["id"] = StrID;
							dr["Title"] = strBookmarkTit;
							dr["URL"] = "";
							dr["IsFolder"] = true;
							dr["PathDepth"] = intHierarchy;
							dr["parent_id"] = Last_parent_id;
							dt.Rows.Add (dr);
							
							intHierarchy = intHierarchy + 1;
							Before_parent_id=Last_parent_id;//remember the prev id
							Last_parent_id=StrID;
							StrID++;
							
						}
						// End of folder import
						
					}
					else if(First(strCurrentLine,6) == "<dt><a")
					{
						// New bookmark
						
						strBookmarkTit = "";
						strBookmarkUrl = "";
						
						// Read title
						strBookmarkTit = htmlEnt(StripHTMLTags(strCurrentLine));
						
						if( blnUtf8 )strBookmarkTit = utfDecode(strBookmarkTit);
						// Read URL
						
						strBookmarkUrl = GetURLFromHref(strCurrentLine);
						
						//Read description. (Goes to the line where the next bookmark or
						//folder starts (<DT>) or the current folder is closed (</DL>)
						// Line breaks are written as <BR>
						strCurrentLine = StreamBookMarks.ReadLine();
						times++;
						// Remove tabs and leading spaces
						strCurrentLine=  strCurrentLine.Replace( "\t", "").Trim();
						
						//first letter 4 and 5 of row
						while(!((First(strCurrentLine,4) == "<dt>" || First(strCurrentLine,5)=="</dl>") || StreamBookMarks.EndOfStream==true))
						{
							
							//Description starts with <DD> -> remove this tag
							//strCurrentLine = strCurrentLine.Replace("<dd>", "");
							strCurrentLine = Regex.Replace(strCurrentLine,@"<dd>",string.Empty,RegexOptions.IgnoreCase);
							// Line breaks are written as <BR>
							//strCurrentLine = strCurrentLine.Replace("<br>", "\n");
							strCurrentLine = Regex.Replace(strCurrentLine,@"<br>","\n",RegexOptions.IgnoreCase);
							strCurrentLine = StreamBookMarks.ReadLine();
							times++;
							// Remove tabs and leading spaces
							strCurrentLine=  strCurrentLine.Replace( "\t", "").Trim();
						}
						
						//The next line must not be read, because we now read one line too far
						blnDontReadThisLine = true;
						
						if (strBookmarkTit != "")
						{
							dr= dt.NewRow ();
							dr["id"] = StrID;
							dr["Title"] = strBookmarkTit;
							dr["URL"] = strBookmarkUrl;
							dr["IsFolder"] = true;
							dr["PathDepth"] = intHierarchy;
							dr["parent_id"] = Last_parent_id;
							dt.Rows.Add (dr);
							StrID++;
						}
					}
					else if(First(strCurrentLine,5)=="</dl>")
					{
						//close folder
						intHierarchy = intHierarchy - 1;
						//update the prev id
						Last_parent_id=Before_parent_id;
						
						if (intHierarchy < 0)
							//Import can't continue, because we don't habe more folders
							//If we reach this, the bookmark file is most likely to be corrupt
							break;
					}					
					else if(First(strCurrentLine,"<META HTTP-EQUIV".Length).ToLower()== "<meta http-equiv")
					{
						if(strCurrentLine.IndexOf("charset=utf-8")!=-1)
							blnUtf8 = true;
					}
					
				}
			}
			
			StreamBookMarks.Close();
			return dt;
		}
		
		
	}
}
