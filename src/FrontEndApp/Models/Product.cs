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

    public Product CreateDummyProduct()
    {
      var dummyproduct = new Product() { product_name = "dummyproduct", product_description = "dummy description", product_price = 0 };
      return dummyproduct;
    }
  }
}
