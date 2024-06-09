using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using HelloWorld.Data;
using HelloWorld.Models;
using HelloWorld.Services;

namespace HelloWorld.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService _postService;

        public PostsController()
        {
            _postService = new PostService();
        }

        // GET: Posts
        public ActionResult Index()
        {
            PostsModel model = new PostsModel();
            model.AdressModelList.Add
            (
                new AdressModel() 
                {
                    Country = "Austria",
                    CityName = "Bon",
                    PostalCode = 14275,
                }
            );
            model.AdressModelList.Add
            (
                 new AdressModel()
                {
                    Country = "Canada",
                    CityName = "Toronto",
                    PostalCode = 14332,
                }
            );
            model.AdressModelList.Add
            (
                new AdressModel()
                {
                    Country = "Germany",
                    CityName = "Dortmun",
                    PostalCode = 18751,
                }
            );
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            PostsModel model = new PostsModel();
            model.TypeModelList.Add(
                new TypeModel()
            {
                Name = "please fill Name correctly",
                UserName = "please fill User Name correctly",
                Post = "please fill Post correctly",
                Email = "please fill Email correctly",
            });
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(PostsModel model)
        {

            if (string.IsNullOrEmpty(model.Post) == true)
            {
                //ViewBag.msg = "please fill Post correctly";
                //ViewBag.msgName = "please fill Name correctly";
                //ViewBag.msgUserName = "please fill User Name correctly";
                //ViewBag.msgEmail = "please fill Email correctly";
                return View(model);
            }
            Posts posts = new Posts();
            posts.Name = model.Name;
            posts.UserName = model.UserName;
            posts.Posts1 = model.Post;
            posts.Date = DateTime.Now;
            _postService.Add(posts);
            RedirectToAction("Index");
            return View();
        }

        [HttpGet]
        public ActionResult Delete(Posts entity)
        {
            _postService.Delete(entity);
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Posts post = _postService.GetById(id);
            return View(post);
        }
        [HttpPost]
        public ActionResult Edit(PostsModel model)
        {
            Posts post = _postService.GetById(model.Id);
            post.Posts1 = model.Post;
            post.UserName = model.UserName;
            post.Name = model.Name;
            post.Date = DateTime.Now;
            _postService.Update(post);
            RedirectToAction("Index");
            return View();
        }
        public JsonResult GetPosts(int? pageNumber)
        {
            pageNumber = pageNumber ?? 1;
            int pageSize = 20;
            int skip = (pageNumber.Value - 1) * pageSize;

            var query = _postService.GetAll().AsQueryable()
                .OrderByDescending(a => a.ID)
                .Skip(skip).Take(pageSize);

            var dataList = query.ToList();

            List<PostsModel> models = new List<PostsModel>();
            foreach (Posts post in dataList)
            {
                models.Add(
                    new PostsModel
                    {
                        Id = post.ID,
                        Name = post.Name,
                        UserName = post.UserName,
                        Post = post.Posts1,
                        Email = post.Email,
                        Date = post.Date.ToString(),
                    });
            }
            return Json(new PostsModel
            {
                DataList = models,
                CurrentPage = pageNumber.Value,
                TotalPages = (int)Math.Ceiling((double)dataList.Count / pageSize)
            }, JsonRequestBehavior.AllowGet);
        }
    }
}