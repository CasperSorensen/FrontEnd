using System;

namespace FrontEndApp.Models
{
  public class Order
  {
    public long Id { get; set; }
    public string customer_name { get; set; }
    public string customer_address { get; set; }
    public string customer_zipcode { get; set; }
    public int product { get; set; }
    public int product_quantity { get; set; }
  }
}