using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Codebook.Models;
using System.Data.Entity;

namespace Codebook.Controllers
{
    public class LoginController : Controller
    {
        CodebookEntities1 dbContext = new CodebookEntities1();

        // Blank Login form
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            //var loginUser = dbContext.Users.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
            var loginUser = dbContext.Users
                .Include(u => u.User_Status_Code)
                .SingleOrDefault(u => u.Username == user.Username && u.Password == user.Password);

            if(loginUser == null)
            {
                ViewBag.ErrorMessage = "There is no such user";
                return View();
            } else
            {
                Session["UserId"] = user.Id.ToString();
                Session["Username"] = user.Username.ToString();
                TempData["LoginSuccessMessage"] = "<script>alert('Login successfully')</script>";
                return RedirectToAction("Index", "Codebook", loginUser);
            }
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                dbContext.Users.Add(user);
                int newRows = dbContext.SaveChanges();
                if(newRows > 0)
                {
                    ViewBag.InsertMessage = "<script>alert('OK')</script>";
                    ModelState.Clear();
                    return RedirectToAction("Login", "Login");
                } else
                {
                    ViewBag.InsertMessage = "<script>alert('NO')</script>";
                }
            }
            return View();
        }
    }
}