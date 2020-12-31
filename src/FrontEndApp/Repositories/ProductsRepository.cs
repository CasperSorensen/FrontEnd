using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using FrontEndApp.Models;
using Newtonsoft.Json;

namespace FrontEndApp.Repositories
{
  public class ProductsRespository : IProductsRepository
  {

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
      HttpClientHandler clientHandler = new HttpClientHandler();
      clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

      List<Product> ProductList = new List<Product>();
      using (var httpClient = new HttpClient(clientHandler))
      {
        // http://localhost:5005/Product
        using (var response = await httpClient.GetAsync("http://localhost:5005/products"))
        {
          string apiResponse = await response.Content.ReadAsStringAsync();
          ProductList = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
        }
      }
      return ProductList;
    }
  }
}