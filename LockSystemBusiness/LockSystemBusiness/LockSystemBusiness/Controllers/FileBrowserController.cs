using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using LockSystemBusiness.Models;

namespace LockSystemBusiness.Controllers
{
    public class FileBrowserController : Controller
    {
        //
        // GET: /FileBrowser/

        public ActionResult Index()
        {
            return View();
        }

        public string GetURL()
        {
            string url = "http://www.progressivelocks.com/Images/";
            return url;
        }

        [HttpPost]
        public ActionResult GetImages()
        {
            var directory = new System.IO.DirectoryInfo(Server.MapPath("/Images/"));
            string html = "<table>";
            int i = 0;
            foreach (var file in directory.GetFilesByExtensions(".png", ".gif", ".jpg"))
            {
                //if (file.Name == "Facebook.png" || file.Name == "down.gif" || file.Name == "github.png" || file.Name == "GitHubFooter.png" || file.Name == "leftedge.gif" || file.Name == "LinkedIn.png" || file.Name == "rightedge.gif" || file.Name == "turquoise-pattern.gif")
                //{
                //    continue;
                //}
                if (i % 20 == 0)
                {
                    html += "<tr><td><div class=\"thumbnail\"><img style=\"height:80px;width:80px;\" src=\"" + GetURL() + file.Name + "\"" + " alt=\"thumb\" title=\"" + GetURL() + file.Name + "\"/></div></td>";
                }
                else
                {
                    html += "<td><div class=\"thumbnail\"><img style=\"height:80px;width:80px;\" src=\"" + GetURL() + file.Name + "\"" + " alt=\"thumb\" title=\"" + GetURL() + file.Name + "\"/></div></td>";
                }

                if (i == file.Length - 1)
                {
                    html += "</table>";
                }
                i++;
            }

            return Content(html);
        }

        [HttpPost]
        public JsonResult DeleteImage(string fileName)
        {
            string path = Server.MapPath("/Images/") + fileName;
            try
            {
                FileInfo fileInfo = new FileInfo(path);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
            }
            catch(Exception e)
            {
                return Json("Failed to delete.");
            }
            return Json("Successfully deleted.");
        }
    }
}
