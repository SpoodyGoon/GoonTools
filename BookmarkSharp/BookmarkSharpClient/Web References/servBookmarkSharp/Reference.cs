//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace www.brdstudio.net_BookmarkSharp
{
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("SharpDevelop", "3.0.0.3314")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BookmarkSharpSoap", Namespace="http://tempuri.org/")]
    public partial class BookmarkSharp : System.Web.Services.Protocols.SoapHttpClientProtocol
    {
        
        /// <remarks/>
        public BookmarkSharp()
        {
            this.Url = "http://www.brdstudio.net/BookmarkSharp/BookmarkSharp.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Login", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void Login(string strPassword)
        {
            this.Invoke("Login", new object[] {
                        strPassword});
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginLogin(string strPassword, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("Login", new object[] {
                        strPassword}, callback, asyncState);
        }
        
        /// <remarks/>
        public void EndLogin(System.IAsyncResult asyncResult)
        {
            this.EndInvoke(asyncResult);
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/LastUpdateGet", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet LastUpdateGet()
        {
            object[] results = this.Invoke("LastUpdateGet", new object[0]);
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginLastUpdateGet(System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("LastUpdateGet", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public System.Data.DataSet EndLastUpdateGet(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AddBookMark", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string AddBookMark(Bookmark bk)
        {
            object[] results = this.Invoke("AddBookMark", new object[] {
                        bk});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginAddBookMark(Bookmark bk, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("AddBookMark", new object[] {
                        bk}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndAddBookMark(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetBookMarks", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetBookMarks()
        {
            object[] results = this.Invoke("GetBookMarks", new object[0]);
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetBookMarks(System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetBookMarks", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public System.Data.DataSet EndGetBookMarks(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetTags", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetTags()
        {
            object[] results = this.Invoke("GetTags", new object[0]);
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetTags(System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetTags", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public System.Data.DataSet EndGetTags(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ImportDataTable", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool ImportDataTable(System.Data.DataTable dt)
        {
            object[] results = this.Invoke("ImportDataTable", new object[] {
                        dt});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginImportDataTable(System.Data.DataTable dt, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("ImportDataTable", new object[] {
                        dt}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndImportDataTable(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("SharpDevelop", "3.0.0.3314")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Bookmark
    {
        
        /// <remarks/>
        public int intBookmarkID;
        
        /// <remarks/>
        public string strURL;
        
        /// <remarks/>
        public string strName;
        
        /// <remarks/>
        public string strPath;
        
        /// <remarks/>
        public int intParentID;
        
        /// <remarks/>
        public bool blnIsFolder;
    }
}