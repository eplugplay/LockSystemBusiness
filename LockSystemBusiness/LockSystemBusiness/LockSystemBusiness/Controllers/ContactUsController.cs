using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace LockSystemBusiness.Controllers
{
    public class ContactUsController : Controller
    {
        //
        // GET: /ContactUs/

        public ActionResult Index()
        {
            ResetSetCaptchaText();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult PostForm(string Name, string BusinessName, string Address, string City, string State, string Zip, string Phone, string Email, string Inquiry, string Captcha)
        {
            if (ModelState.IsValid)
            {
                if (Session["Captcha"].ToString() != Captcha)
                {
                    ResetSetCaptchaText();
                    return View("Index");
                }
                else
                {
                    string Msg = BuildMsg(Name, BusinessName, Address, City, State, Zip, Phone, Email, Inquiry);
                    bool EmailSent = false;
                    try
                    {
                        // send email
                        //EmailSent = Classes.Email.SendEmail("Steve.Yi@coastalflow.com", "Crawin for the Cure - CRAWFISH & GUMBO COOK-OFF ENTRY FORM", Msg);
                        if (EmailSent == true)
                        {
                            try
                            {
                                //EmailSent = Classes.Email.SendEmail(Email, "Crawin' for the cure Registration Form - CRAWFISH & GUMBO COOK-OFF ENTRY FORM", CustomerMsg());
                            }
                            catch
                            {
                                return Content("Failed");
                            }
                        }
                    }
                    catch
                    {
                        return Content("Failed");
                    }
                    return Content("Success");
                }
            }
            else
            {
                //ModelState.AddModelError("", "Email Address or Password is Incorrect.");
            }

            return View("Index");
        }

        public string BuildMsg(string Name, string BusinessName, string Address, string City, string State, string Zip, string Phone, string Email, string Inquiry)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name: " + Name);
            if (BusinessName != "")
            {
                sb.AppendLine("Business Name: " + BusinessName);
            }
            sb.AppendLine("Address: " + Address);
            sb.AppendLine("City: " + City);
            sb.AppendLine("State: " + State);
            sb.AppendLine("Zip: " + Zip);
            if (BusinessName != "")
            {
                sb.AppendLine("Phone: " + Phone);
            }
            sb.AppendLine("Email: " + Email);
            sb.AppendLine("Inquiry: " + Inquiry);
            return sb.ToString();
        }


        public string CustomerMsg()
        {
            return "Your inquiry as been received, thank you.";
        }

        [HttpPost]
        public JsonResult ResetSetCaptchaText()
        {
            Random oRandom = new Random();
            int iNumber = oRandom.Next(100000, 999999);
            Session["Captcha"] = iNumber.ToString();
            return Json(iNumber);
        }

        [HttpPost]
        public JsonResult ReturnSession()
        {
            return Json(Convert.ToInt32(Session["Captcha"]));
        }

    }
}
