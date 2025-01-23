using Microsoft.EntityFrameworkCore;
using PetLover.Core;
using PetLover.Data.Context;
using PetLover.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetLover.Data.Repositories.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<T> CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Table.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await Table.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            Table.Update(entity);
        }
    }
}
