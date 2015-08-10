using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Net;

namespace LockSystemBusiness.Models
{
    public static class FTP
    {
        public static void DeleteImage(string fromFolder, string fileName)
        {
            //string uri = "ftp://208.118.63.29/site2/" + "/" + fromFolder + "/" + fileName;
            //Uri serverUri = new Uri(uri);
            //if (serverUri.Scheme != Uri.UriSchemeFtp)
            //{
            //    return;
            //}
            FtpWebRequest reqFTP;
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://208.118.63.29/site2/" + fromFolder + "/" + fileName));
            reqFTP.Credentials = new NetworkCredential("eplugplay-001", ConfigurationManager.ConnectionStrings["ftp"].ToString());
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
            reqFTP.UseBinary = true;
            reqFTP.Proxy = null;
            reqFTP.UsePassive = false;
            FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
            response.Close();
        }

        public static void CopyImageTo(string toFolder, string fileName)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://208.118.63.29/site2/" + toFolder + "//" + fileName);
            request.KeepAlive = true;
            request.Proxy = null;
            request.UseBinary = true;
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential("eplugplay-001", ConfigurationManager.ConnectionStrings["ftp"].ToString());
            Stream ftpStream = request.GetRequestStream();
        }
    }
}