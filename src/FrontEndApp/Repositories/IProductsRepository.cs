using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FrontEndApp.Models;

namespace FrontEndApp.Repositories
{
  public interface IProductsRepository
  {
    // api/[GET]
    public Task<IEnumerable<Product>> GetAllProducts();

    // // api/where/{id}/equals/{id} /[GET]
    // public Task<Product> GetProduct(long id);

    // // api/[POST]
    // public Task Create(Product Product);

    // // api/[PUT]
    // public Task<bool> Update(Product Product);

    // // api[DELETE]
    // public Task<bool> Delete(long id);

    // public Task<long> GetNextId();
  }

}