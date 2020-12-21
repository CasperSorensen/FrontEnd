using System;
using System.Threading.Tasks;
using Xunit;
using FrontEndApp.Repositories;

namespace FrontEndApp.Unittests
{
  public class RepositoryTests
  {
    [Fact, Trait("Priority", "1"), Trait("Category", "IntegrationTests")]
    public async Task GetAllOrdersTest_NotEmptyListOrNull()
    {
      OrdersRespository or = new OrdersRespository();
      var result = await or.GetAllOrders();
      Assert.NotNull(result);
    }

    [Fact, Trait("Priority", "1"), Trait("Category", "IntegrationTests")]
    public async Task GetAllProductsTest_NotEmptyListOrNull()
    {
      ProductsRespository pr = new ProductsRespository();
      var result = await pr.GetAllProducts();
      Assert.NotNull(result);
      Assert.NotEmpty(result);
    }
  }
}
