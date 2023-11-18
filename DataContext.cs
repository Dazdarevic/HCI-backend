using Microsoft.EntityFrameworkCore;

namespace Auto_delovi_bekend
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<AutoDeo> autodelovi { get; set; }

    }
}
