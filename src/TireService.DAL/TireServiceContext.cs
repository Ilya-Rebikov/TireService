namespace TireService.DAL
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// TireServiceContext instance represents a session with database.
    /// </summary>
    internal class TireServiceContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TireServiceContext"/> class.
        /// </summary>
        /// <param name="options">DbContextOptions object for TicketManagementContext.</param>
        public TireServiceContext(DbContextOptions<TireServiceContext> options)
            : base(options)
        {
        }

        ///// <summary>
        ///// Gets or sets .
        ///// </summary>
        // public DbSet<smth> Areas { get; set; }
    }
}
