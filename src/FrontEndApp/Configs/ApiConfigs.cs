using System;

namespace FrontEndApp.Configs
{
  public class ApiConfigs : IApiConfigs
  {
    public string Products_Base_Url { get; set; }
    public string Orders_Base_Url { get; set; }

    public ApiConfigs(string products_api_url, string orders_api_url)
    {
      this.Products_Base_Url = products_api_url;
      this.Orders_Base_Url = orders_api_url;

    }
  }
}