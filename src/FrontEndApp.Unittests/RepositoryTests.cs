using System;
using System.Threading.Tasks;
using Xunit;
using FrontEndApp.Repositories;
using FrontEndApp.Configs;

namespace FrontEndApp.Unittests
{
  public class RepositoryTests
  {
    private OrdersRepository _ordersRepository { get; set; }
    private ProductsRepository _productsRepository { get; set; }

    public RepositoryTests()
    {
      var emptyApiConfig = new ApiConfigs("empty_url", "empty_url");

      this._ordersRepository = new OrdersRepository(emptyApiConfig);
      this._productsRepository = new ProductsRepository(emptyApiConfig);
    }

    [Fact, Trait("Priority", "1"), Trait("Category", "UnitTests")]
    public void OrdersRepository_DummyOrderListNotNull()
    {
      Assert.NotNull(this._ordersRepository.GetDummyOrderList());
    }

    [Fact, Trait("Priority", "1"), Trait("Category", "UnitTests")]
    public void OrdersRepository_DummyOrderListNotEmpty()
    {
      Assert.NotEmpty(this._ordersRepository.GetDummyOrderList());
    }

    [Fact, Trait("Priority", "1"), Trait("Category", "UnitTests")]
    public void ProductsRepository_DummyProductsListNotNull()
    {
      Assert.NotNull(this._productsRepository.GetDummyProductList());
    }

    [Fact, Trait("Priority", "1"), Trait("Category", "UnitTests")]
    public void ProductsRepository_DummyProductsListNotEmpty()
    {
      Assert.NotEmpty(this._productsRepository.GetDummyProductList());
    }
  }
}
