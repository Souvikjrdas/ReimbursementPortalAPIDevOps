using Data_Access.Data.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class Repository <T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext db;
        internal DbSet<T> dbentity;

        public Repository(ApplicationDbContext _db)
        {
            db = _db;
            dbentity = db.Set<T>();
        }

        public void Add(T ob)
        {
            dbentity.Add(ob);   
        }

        public async Task<T?> GetAsync(int id)
        {
            return await dbentity.FindAsync(id);
        }

        public async Task<IEnumerable<T>?> GetAllAsync()
        {
            return await dbentity.ToArrayAsync();
        }

        public void Remove(T ob)
        {
           dbentity.Remove(ob);
        }
    }
}
