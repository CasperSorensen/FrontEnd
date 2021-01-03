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
  public class OrdersRepository : IOrdersRepository
  {
    public ApiConfigs _apiConfig { get; set; }

    public OrdersRepository(ApiConfigs apiconfig)
    {
      this._apiConfig = apiconfig;
    }

    public async Task<IEnumerable<Order>> GetAllOrders()
    {
      HttpClientHandler clientHandler = new HttpClientHandler();
      clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

      List<Order> orderList = new List<Order>();
      using (var httpClient = new HttpClient(clientHandler))
      {
        using (var response = await httpClient.GetAsync("http://orders_api_testing/orders"))
        {
          string apiResponse = await response.Content.ReadAsStringAsync();
          orderList = JsonConvert.DeserializeObject<List<Order>>(apiResponse);
        }
      }
      return orderList;
    }

  }
}