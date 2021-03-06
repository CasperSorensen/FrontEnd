using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using FrontEndApp.Models;
using Newtonsoft.Json;
using FrontEndApp.Configs;

namespace FrontEndApp.Repositories
{
  public class ProductsRepository : IProductsRepository
  {
    public ApiConfigs _apiConfig { get; set; }

    public ProductsRepository(ApiConfigs apiConfig)
    {
      this._apiConfig = apiConfig;
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
      Console.WriteLine(this._apiConfig.Orders_Base_Url);
      HttpClientHandler clientHandler = new HttpClientHandler();
      clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

      List<Product> ProductList = new List<Product>();
      using (var httpClient = new HttpClient(clientHandler))
      {
        using (var response = await httpClient.GetAsync(this._apiConfig.Products_Base_Url))
        {
          string apiResponse = await response.Content.ReadAsStringAsync();
          ProductList = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
        }
      }
      return ProductList;
    }

    public List<Product> GetDummyProductList()
    {
      var dummylist = new List<Product>();
      var dummyProduct = new Product();
      dummylist.Add(dummyProduct.CreateDummyProduct());
      return dummylist;
    }
  }
}