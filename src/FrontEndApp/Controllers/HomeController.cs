using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FrontEndApp.Models;
using FrontEndApp.Repositories;
using FrontEndApp.Configs;

namespace FrontEndApp.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly IOrdersRepository _ordersrepo;
    private readonly IProductsRepository _productssrepo;


    public HomeController(ILogger<HomeController> logger, IOrdersRepository ordersRepository, IProductsRepository productsRepository)
    {
      this._logger = logger;
      this._ordersrepo = ordersRepository;
      this._productssrepo = productsRepository;
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
      var orders = await this._ordersrepo.GetAllOrders();
      if (orders == null)
      {
        orders = new List<Order>() { new Order { customer_name = "no data" } };
      }
      return View(orders);
    }

    public async Task<IActionResult> Products()
    {
      var products = await this._productssrepo.GetAllProducts();
      if (products == null)
      {
        products = new List<Product>() { new Product { product_name = "no data" } };
      }
      return View(products);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
