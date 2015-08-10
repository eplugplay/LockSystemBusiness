using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;


namespace LockSystemBusiness.Models
{
    public class Image
    {
        public Image(string folder, string path, string desc, int hidden, string feature)
        {
            Folder = folder;
            Path = path;
            Description = desc;
            Hidden = hidden;
            Feature = feature.Replace("\n", "");
        }
        public string Folder { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
        public int Hidden { get; set; }
        public string Feature { get; set; }
    }

    public class ImageCategory
    {
        public string Name { get; set; }
        public string ID { get; set; }
    }

    public class ImageDetails
    {
        public string ImageFileName { get; set; }
        public string ImageDescription { get; set; }
        public string ImageFolder { get; set; }
        public int ImageHidden { get; set; }
        public string ImageFeature { get; set; }
    }
}