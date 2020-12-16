using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FrontEndApp.Models;
using FrontEndApp.Repositories;

namespace FrontEndApp.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    public IActionResult FrontPage()
    {
      return View();
    }

    public async Task<IActionResult> Orders()
    {
      OrdersRespository or = new OrdersRespository();
      var orders = await or.GetAllOrders();
      return View(orders);
    }

    public async Task<IActionResult> Products()
    {
      ProductsRespository pr = new ProductsRespository();
      var products = await pr.GetAllProducts();
      return View(products);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
