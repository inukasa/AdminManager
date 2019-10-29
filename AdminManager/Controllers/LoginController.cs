using AdminManager.Context;
using AdminManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AdminManager.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLoginModels user, string returnURL)
        {
            if (IsValid(user))
            {
                FormsAuthentication.SetAuthCookie(user.username, false);
                return Redirect(returnURL);
            }
            else
            {
                return View(user);
            }
            
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }
        private bool IsValid(UserLoginModels user)
        {
            DBContext db = new DBContext();
            List<UserLoginModels> listUL = db.getAllUserLogin();
            bool flag = false;
            foreach(UserLoginModels element in listUL)
            {
                if(user.username == element.username && user.password == element.password)
                {
                    flag = true;
                }
            }
            return flag;
        }
    }
}