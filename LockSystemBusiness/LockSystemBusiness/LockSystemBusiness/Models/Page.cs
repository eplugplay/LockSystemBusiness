using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LockSystemBusiness.Models
{
    public class Page
    {
        public Page() { }
        public Page(string pageData)
        {
            PageData = pageData;
        }
        public string PageData { get; set; }
    }
}