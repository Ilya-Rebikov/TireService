namespace TireService.DAL.Interfaces
{
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Represent a repository pattern with CRUD operations.
    /// </summary>
    /// <typeparam name="T">DAL model.</typeparam>
    public interface IRepository<T>
        where T : IDalModel
    {
        /// <summary>
        /// Get all objects from database.
        /// </summary>
        /// <returns>All objects.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Get one object from database by his id.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>Object.</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Add new object to database.
        /// </summary>
        /// <param name="obj">Adding object.</param>
        /// <returns>Create object.</returns>
        Task<T> CreateAsync(T obj);

        /// <summary>
        /// Update one object in database.
        /// </summary>
        /// <param name="obj">Updating object.</param>
        /// <returns>Updated object.</returns>
        Task<T> UpdateAsync(T obj);

        /// <summary>
        /// Delete object from database.
        /// </summary>
        /// <param name="obj">Deleting object.</param>
        /// <returns>Deleted object.</returns>
        Task<T> DeleteAsync(T obj);
    }
}
