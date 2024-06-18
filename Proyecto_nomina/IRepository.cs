using NominaAPI.Http.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_nomina
{
    public interface IRepository<T>
    {
        Task<Response<IEnumerable<T>>> GetAllAsync();
        Task<Response<T>> GetByIdAsync(int id);
        Task<Response<T>> CreateAsync(object dto);
        Task<bool> UpdateAsync(int id, object dto);
        Task<bool> DeleteAsync(int id);
    }
}
