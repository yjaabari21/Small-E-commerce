using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Data;
using HelloWorld.Models;
using HelloWorld.Services;

namespace HelloWorld.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController()
        {
            _productService = new ProductService();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Product List";
            List<Product> entityList = _productService.GetAll().OrderByDescending(x => x.Id).ToList();
            return View(entityList);
        }

        public ActionResult Details(int? id)
        {
            if (id.HasValue == false)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Error 404 !");
            }
            Product entity = _productService.GetById(id);
            return View(entity);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Title = "Add Product";
            return View(ViewBag);
        }

        [HttpPost]
        public ActionResult Add(ProductModel model)
        {
            Product product = new Product();
            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            _productService.Add(product);
            RedirectToAction("Index");
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ViewBag.Title = "Edit Product";
            Product product = _productService.GetById(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(ProductModel model)
        {
            Product product = _productService.GetById(model.Id);
            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            _productService.Update(product);
            RedirectToAction("Index");
            return View();

        }

        [HttpGet]
        public ActionResult Delete(Product entity)
        {
            ViewBag.Title = "Delete Product";
            _productService.Delete(entity);
            RedirectToAction("Index");
            return View();
        }

        public JsonResult TestAjax()
        {
            return Json(new
            {
                UserName = "Yousef",
                Id = 1,
                Email = "test@test.com",

            }
            , JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetProd()
        {
            List<Product> products = _productService.GetAll().OrderByDescending(x => x.Id).ToList();

            List <ProductModel> models = new List<ProductModel>();
            foreach (Product product in products)
            {
                models.Add(new ProductModel
                {
                    Id = product.Id,
                    Name = product.Name,    
                    Description = product.Description,  
                    Price = product.Price,
                });
            }

            return Json(models, JsonRequestBehavior.AllowGet);
        }

    }
}