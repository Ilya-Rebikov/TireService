namespace TireService.DAL.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using TireService.DAL.Interfaces;

    /// <summary>
    /// Entity framework repository.
    /// </summary>
    /// <typeparam name="T">Entity.</typeparam>
    internal class BaseRepository<T> : IRepository<T>
        where T : class, IDalModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
        /// </summary>
        /// <param name="dbContext">Object of DbContext.</param>
        public BaseRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        /// <summary>
        /// Gets or privatly sets object of DbContext.
        /// </summary>
        protected DbContext DbContext { get; private set; }

        /// <inheritdoc/>
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await DbContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(e => e.Id == id);
        }

        /// <inheritdoc/>
        public virtual IQueryable<T> GetAll()
        {
            return DbContext.Set<T>().AsNoTracking();
        }

        /// <inheritdoc/>
        public virtual async Task<T> CreateAsync(T obj)
        {
            var temp = DbContext.Entry(obj);
            temp.State = EntityState.Added;
            await DbContext.Set<T>().AddAsync(obj);
            await DbContext.SaveChangesAsync();
            temp.State = EntityState.Detached;
            return temp.Entity;
        }

        /// <inheritdoc/>
        public virtual async Task<T> UpdateAsync(T obj)
        {
            var temp = DbContext.Entry(obj);
            temp.State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
            temp.State = EntityState.Detached;
            return temp.Entity;
        }

        /// <inheritdoc/>
        public virtual async Task<T> DeleteAsync(T obj)
        {
            var temp = DbContext.Entry(obj);
            temp.State = EntityState.Deleted;
            DbContext.Set<T>().Remove(obj);
            await DbContext.SaveChangesAsync();
            temp.State = EntityState.Detached;
            return temp.Entity;
        }
    }
}
