using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();

        Task<Product> GetById(int id);

        Task Add(Product model);

        Task Update(Product model);

        Task Delete(int id);

    }
}
