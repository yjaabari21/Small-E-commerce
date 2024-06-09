using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HelloWorld.Data;
using HelloWorld.Models;
using HelloWorld.Services;

namespace HelloWorld.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        #region ActionResults...

        // GET: User/Index
        [HttpGet]
        public ActionResult Index()
        {
            List<User> entityList = _userService.GetAll()
                .OrderByDescending(x => x.Id)
                .ToList();
            return View(entityList);
        }

        // GET: User/Details
        [HttpGet]
        public ActionResult Details(int? id)
        {
            ViewBag.Title = "User Details";
            if (id.HasValue == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "No user Id !");
            }
            User entity = _userService.GetById(id);
            return View(entity);
        }

        // GET: User/Edit?id=5
        [HttpGet]
        public ActionResult Edit(int? id) 
        {
            ViewBag.Title = "Edit User";
            ViewBag.Btn = "Edit User";
            User entity = _userService.GetById(id);
            return View(entity);
        }

        // GET: User/Edit?id=5
        [HttpGet]
        public ActionResult AddUser()
        {
            ViewBag.Title = "Add User";
            ViewBag.Btn = "Add User";
            return View();
        }

        // POST: User/Edit?id=5
        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            User entity = _userService.GetByEmail(model.Email);
            entity.Email = model.Email;
            entity.Mobile = model.Mobile;
            _userService.Update(entity);
            return RedirectToAction("Index");
        }


        // POST: User/Edit
        [HttpPost]
        public ActionResult AddUser(UserModel model)
        {
            User user = new User();
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Mobile = model.Mobile;
            _userService.Add(user);
            return RedirectToAction("Index");
        }

        // GET: User/Edit?id=5
        [HttpGet]
        public ActionResult Delete(UserModel model , int? id)
        {
            ViewBag.Title = "Delete User";
            ViewBag.Btn = "Delete User";
             return View(model);
        }
        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    _userService.Delete(id);
        //    return RedirectToAction("Index");
        //}
        public JsonResult GetUser()
        {
            List<User> users = _userService.GetAll().OrderByDescending(x => x.Id).ToList();
            List<UserModel> model = new List<UserModel>();
            foreach (User user in users)
            {
                model.Add(new UserModel 
                {  
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Mobile = user.Mobile,
                });
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Methods...



        #endregion
    }
}