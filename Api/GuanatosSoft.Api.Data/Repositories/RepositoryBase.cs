using GuanatosSoft.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GuanatosSoft.Api.Data.Repositories
{
    public abstract class RepositoryBase<T> where T : class
    {
        private guanatossoftdbContext dbContext;
        protected DbSet<T> dbSet;

        public RepositoryBase(guanatossoftdbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        // CRUD Operatins
    }
}
