using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data;


namespace LockSystemBusiness.Models
{
    public class PageModel:List<Page>
    {
        public PageModel(string pagename)
        {
            DataTable dt = uti.GetPageData(pagename);
            var pageData = from page in dt.AsEnumerable() select new Page(page.Field<string>("pagedata"));
            this.AddRange(pageData);
        }
    }
}