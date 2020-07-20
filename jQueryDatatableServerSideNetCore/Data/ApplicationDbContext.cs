using jQueryDatatableServerSideNetCore.Models.DatabaseModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace jQueryDatatableServerSideNetCore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Camera>().HasKey(x => x.camera_id);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Camera> master_cameras { get; set; }
    }
}
