using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data;


namespace LockSystemBusiness.Models
{
    public class ImageModel:List<Image>
    {
        public ImageModel(string folder, bool hidden, string isAdmin = "")
        {
            //string directoryOfImage = HttpContext.Current.Server.MapPath("~/" + folder + "/");
            //XDocument imageData = XDocument.Load(directoryOfImage + @"/ImageMetaData.xml");
            //var images = from image in imageData.Descendants("image") select new Image(image.Element("filename").Value, image.Element("description").Value, image.Element("gender").Value);
            DataTable dt = new DataTable();
            if (isAdmin == "")
            {
                if (folder == "HomeScrollImages")
                {
                    dt = uti.GetRandomImagesInfo(folder, hidden);
                    var images = from image in dt.AsEnumerable() select new Image(image.Field<string>("folder"), image.Field<string>("filename"), image.Field<string>("description"), image.Field<int>("hidden"), image.Field<string>("feature"));
                    this.AddRange(images.ToList<Image>());
                }
                else
                {
                    dt = uti.GetImagesInfo(folder, hidden);
                    var images = from image in dt.AsEnumerable() orderby image.Field<string>("description") select new Image(image.Field<string>("folder"), image.Field<string>("filename"), image.Field<string>("description"), image.Field<int>("hidden"), image.Field<string>("feature"));
                    this.AddRange(images.ToList<Image>());
                }
            }
            else
            {
                dt = uti.GetImagesInfo(folder, hidden);
                var images = from image in dt.AsEnumerable() orderby image.Field<string>("description") select new Image(image.Field<string>("folder"), image.Field<string>("filename"), image.Field<string>("description"), image.Field<int>("hidden"), image.Field<string>("feature"));
                this.AddRange(images.ToList<Image>());
            }
        }
    }
}