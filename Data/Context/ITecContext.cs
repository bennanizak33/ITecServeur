using Microsoft.EntityFrameworkCore;

namespace ITec.Serveur.Context
{
    public class ITecContext : DbContext
    {
        public ITecContext(DbContextOptions<ITecContext> options)
        : base(options) { }

        //public DbSet<Entity> Entities { get; set; }     
    }
}