using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BicycleAuth;
using DocsRepository.Models;
using System.Web.Security;


namespace DocsRepository.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        private IUsersRepository usersRepository;

        public AccountController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }
        //public ActionResult Index()
        //{
        //    return View();
        //}

        
        public ActionResult Register()
        {
           return View(new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (usersRepository.Register(model.Name, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("List", "Documents");
                }
                else
                {
                    ModelState.AddModelError("Name", "Пользователь с таким имеинем уже  существует");
                    return View();
                }
            }
            else return View();
            
        }

        public JsonResult ValidateName(string name)
        {
            User user = (usersRepository.Users.Where(u => u.Name.ToLower().Equals(name.ToLower()))).FirstOrDefault();
            if(user!=null)
                return Json("", JsonRequestBehavior.AllowGet);
            else
                return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LogIn()
        {
            return View(new LogInViewModel());
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(LogInViewModel model)
        {
            if (ModelState.IsValid)
            {

                if (usersRepository.LogInUser(model.Name, model.Password) != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("List", "Documents");
                }
                else
                    ModelState.AddModelError("", "Неудачная попытка входа");
            }
            return View();
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}