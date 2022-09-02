using FrontToBack.DAL;
using FrontToBack.Models;
using FrontToBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FrontToBack.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _sql;
        public HomeController(AppDbContext sql)
        {
            _sql = sql; 
        }
        public IActionResult Index()
        {
            ProductAndLatestPr productAndLatestPr = new ProductAndLatestPr();
            productAndLatestPr.Products = _sql.Products.Take(6).ToList();
            productAndLatestPr.LatestProducts = _sql.Products.OrderByDescending(x => x.Id).Take(4).ToList();
            return View(productAndLatestPr);
            
        }
    }
}
