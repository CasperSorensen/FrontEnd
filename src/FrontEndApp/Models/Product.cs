using System;

namespace FrontEndApp.Models
{
  public class Product
  {
    public long Id { get; set; }
    public int product_id { get; set; }
    public string product_name { get; set; }
    public string product_description { get; set; }
    public int product_price { get; set; }
  }
}
