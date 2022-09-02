using FrontToBack.DAL;
using FrontToBack.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FrontToBack.Controllers
{
    public class AdminController : Controller
    {

        private readonly AppDbContext _sql;
        public AdminController(AppDbContext sql)
        {
            _sql = sql;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetProducts()
        {
            return View(_sql.Products.ToList());
        }
        public IActionResult Product()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Product(Product product)
        {
            if (product.NewPrice >= product.OldPrice) return View();

            if (!System.IO.File.Exists("C:\\Users\\LENOVO\\Desktop\\FrontToBack\\FrontToBack\\FrontToBack\\wwwroot\\shop\\img\\" + product.ImgUrl)) return View();

            _sql.Products.Add(product);
            _sql.SaveChanges();
            return RedirectToAction(nameof(GetProducts));
        }

        public IActionResult Delete(int id)
        {
           Product p= _sql.Products.ToList().Find(x => x.Id == id);
            _sql.Products.Remove(p);
            _sql.SaveChanges();
            return RedirectToAction(nameof(GetProducts));
        }

        
    }
}
