
using Microsoft.EntityFrameworkCore;
using New.Hope.Domain;

namespace New.Hope.Infra.Repository
{
    public class PhotoAdminContext : DbContext
    {
        private PhotoAdminContext()
        {

        }

        public PhotoAdminContext(DbContextOptions<PhotoAdminContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>(etd =>
            {
                etd.ToTable("Students");
                etd.HasKey(c => c.id).HasName("Id");
                etd.Property(c => c.id).UseIdentityColumn();
            });
        }

        public virtual DbSet<Student> ExamplePerson { get; set; }
    }
}