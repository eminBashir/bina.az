using DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<TEntity> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
        public async Task Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
     
    }
}
