using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Codebook.Models;
using System.Data.Entity;

namespace Codebook.Controllers
{
    public class CodebookController : Controller
    {
        CodebookEntities1 dbContext = new CodebookEntities1();
        // GET: Codebook
       
        public ActionResult Index(User loginUser)
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Login");
            var codes = dbContext.Codes.Include(c => c.User).Where(c => c.UserId == loginUser.Id).ToList();
            return View(codes);
        }
    }
}