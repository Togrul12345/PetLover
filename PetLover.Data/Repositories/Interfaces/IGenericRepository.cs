using PetLover.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetLover.Data.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T:BaseEntity,new()
    {
        Task<T> CreateAsync(T entity);
        void Update(T entity); 
        void Delete(T entity);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task SaveChangesAsync();
    }
}
