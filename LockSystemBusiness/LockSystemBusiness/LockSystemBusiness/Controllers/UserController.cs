using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Text;
using LockSystemBusiness.Models;
using System.IO;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace LockSystemBusiness.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Login(Models.User user)
        {
            if (ModelState.IsValid)
            {
                if (IsValid(user.Email, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "User Name or Password is Incorrect.");
                }
            }
            return View("Index", user);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Models.User user)
        {
            if (ModelState.IsValid)
            {
                //using (var db = new Models.MainDbEntitiesContainer())
                //{
                //    var crypto = new SimpleCrypto.PBKDF2();
                //    var encrpPass = crypto.Compute(user.Password);
                //    var sysUser = db.systemusers.CreateObject();

                //    sysUser.Email = user.Email;
                //    sysUser.Password = encrpPass;
                //    sysUser.PasswordSalt = crypto.Salt;
                //    sysUser.UserID = Guid.NewGuid().ToString();
                //    db.systemusers.AddObject(sysUser);
                //    if (db.systemusers.Any(u => u.Email == user.Email))
                //    {
                //        ModelState.AddModelError("Email", "Email Already Exists");
                //        return View(user);
                //    }
                //    db.SaveChanges();
                //}
            }
            return RedirectToAction("LogIn", "User");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            Session.Abandon();
            Session.Clear();
            // Clear authentication cookie
            HttpCookie rFormsCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            rFormsCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(rFormsCookie);
            // Clear session cookie 
            HttpCookie rSessionCookie = new HttpCookie("ASP.NET_SessionId", "");
            rSessionCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(rSessionCookie);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult LogOut(Models.User user)
        {
            return View();
        }

        private bool IsValid(string email, string password)
        {
            bool isValid = false;
            var crypto = new SimpleCrypto.PBKDF2();

            using (MySqlConnection cnn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MyBusinessCnn"].ToString()))
            {
                cnn.Open();
                using (var cmd = cnn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM systemusers WHERE email=@email";
                    cmd.Parameters.AddWithValue("email", email);
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    if (dt.Rows.Count != 0)
                    {
                        if (dt.Rows[0]["Password"].ToString() == crypto.Compute(password, dt.Rows[0]["PasswordSalt"].ToString()))
                        {
                            isValid = true;
                        }
                    }
                }
            }
            //using (var db = new Models.db_9ae46c_myblogEntities())
            //{
            //    try
            //    {
            //        var user = db.systemusers.FirstOrDefault(u => u.Email == email);

            //        if (user != null)
            //        {
            //            if (user.Password == crypto.Compute(password, user.PasswordSalt))
            //            {
            //                isValid = true;
            //            }
            //        }
            //    }
            //    catch
            //    {

            //    }
            //}
            return isValid;
        }
    }
}
