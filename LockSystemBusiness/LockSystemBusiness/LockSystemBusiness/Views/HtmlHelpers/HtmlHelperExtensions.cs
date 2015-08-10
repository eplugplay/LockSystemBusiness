using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LockSystemBusiness.Models;

namespace LockSystemBusiness.HtmlHelpers
{
    public static class HtmlHelperExtensions
    {
        public static string ActivePage(this HtmlHelper helper, string controller, string action)
        {
            string classValue = "";
            string currentController = helper.ViewContext.Controller.ValueProvider.GetValue("controller").RawValue.ToString();
            string currentAction = helper.ViewContext.Controller.ValueProvider.GetValue("action").RawValue.ToString();

            if (currentController == controller && currentAction == action)
            {
                classValue = "selected";
            }

            return classValue;
        }

        public static string IsTabActive(this HtmlHelper helper, string tabname)
        {
            string toReturn = "";
            bool active = uti.GetPageActive(tabname);
            toReturn = active ? "display: block" : "display: none";
            return toReturn;
        }

        //public static string Role(this HtmlHelper helper)
        //{
        //    string display = "none";

        //    if (HttpContext.Current.Session["IsLoggedIn"] != null)
        //    {
        //        display = "inline";
        //    }

        //    return display;
        //}
    }
}