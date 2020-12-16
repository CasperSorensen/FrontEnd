using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FrontEndApp.Models;

namespace FrontEndApp.Repositories
{
  public interface IOrdersRepository
  {
    // api/[GET]
    public Task<IEnumerable<Order>> GetAllOrders();

    // // api/where/{id}/equals/{id} /[GET]
    // public Task<Order> GetOrder(long id);

    // // api/[POST]
    // public Task Create(Order Order);

    // // api/[PUT]
    // public Task<bool> Update(Order Order);

    // // api[DELETE]
    // public Task<bool> Delete(long id);

    // public Task<long> GetNextId();
  }

}