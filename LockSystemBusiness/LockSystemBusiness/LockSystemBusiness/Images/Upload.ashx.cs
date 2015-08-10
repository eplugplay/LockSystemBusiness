using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace LockSystemBusiness.Images
{
    /// <summary>
    /// Summary description for Upload
    /// </summary>
    public class Upload : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            HttpPostedFile uploads = context.Request.Files["upload"];
            string CKEditorFuncNum = context.Request["CKEditorFuncNum"];
            string file = Path.GetFileName(uploads.FileName);
            //uploads.SaveAs(context.Server.MapPath(".") + "\\Images\\" + file);
            string fullPath = context.Server.MapPath("/Images/") + file;
            FileInfo fileInfo = new FileInfo(fullPath);
            if (!fileInfo.Exists)
            {
                uploads.SaveAs(fullPath);
                //provide direct URL here
                string url = GetURL() + file;
                context.Response.Write("<script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + url + "\");</script>");
            }
            else
            {
                context.Response.Write("<script>alert('Image already exist please change the name.');</script>");
            }
            context.Response.End();
        }

        public string GetURL()
        {
            string url = "http://www.progressivelocks/images/";
            return url;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}