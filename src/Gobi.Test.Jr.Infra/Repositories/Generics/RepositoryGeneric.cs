using Gobi.Test.Jr.Domain.Interfaces.Generics;
using Gobi.Test.Jr.Infra.Data;
using System.Data.Entity;

namespace Gobi.Test.Jr.Infra.Repositories.Generics
{
    public class RepositoryGeneric<T> : InterfaceGeneric<T> where T : class
    {

        private readonly Microsoft.EntityFrameworkCore.DbSet<T> _dbSet;
        private readonly Context _context;
        public RepositoryGeneric(Context context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task Add(T Objeto)
        {

           
                await _dbSet.AddAsync(Objeto);
            await _context.SaveChangesAsync();
             
        }

        public async Task Delete(T Objeto)
        {
            
               _dbSet.Remove(Objeto);
              await _context.SaveChangesAsync();
            }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async  Task Update(T Objeto)
        {
            _dbSet.Update(Objeto);
             //_context.Entry(Objeto).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;

           await _context.SaveChangesAsync();
        }
    }

        

      
             
}


