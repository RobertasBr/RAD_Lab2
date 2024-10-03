using Microsoft.EntityFrameworkCore;

namespace RAD_Lab2
{
    class AdDb : DbContext
    {
        public AdDb(DbContextOptions<AdDb> options)
            : base(options) { }

        public DbSet<Ad> Ads => Set<Ad>();
    }
}
