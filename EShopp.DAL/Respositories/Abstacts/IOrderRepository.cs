using EShopp.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EShopp.DAL.Respositories.Abstacts;

public interface IOrderRepository : IGenericRepository<Order>{
    Task<IEnumerable<Order>> GetAllWithProductAsync();
}
