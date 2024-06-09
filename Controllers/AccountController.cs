using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorld.Controllers
{

    /*
     
    camel case 
    
    Pascal case 
     
     */
    public class AccountController : Controller
    {
        // GET: Account/Index
        public ActionResult Account() 
        {
            return View();
        }
    }
}