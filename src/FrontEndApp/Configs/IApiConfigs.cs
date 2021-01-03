using System;

namespace FrontEndApp.Configs
{
  public interface IApiConfigs
  {
    string Products_Base_Url { get; set; }
    string Orders_Base_Url { get; set; }
  }
}