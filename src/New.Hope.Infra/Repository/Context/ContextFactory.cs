using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace New.Hope.Infra.Repository
{
    public class ContextFactory : IContextFactory
    {
        private readonly IConfiguration _configuration;
        public ContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private DbContext _context;

        public DbContext GetContext()
        {
            var bagulho = new DbContextOptionsBuilder<PhotoAdminContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;

            return _context ?? (_context = new PhotoAdminContext(bagulho));

            /*
            var connectionString = _configuration.GetConnectionString("PhotoAdminContext");

            var options = new DbContextOptionsBuilder<PhotoAdminContext>()
                .UseSqlServer(connectionString)
                .Options;

            return _context ?? (_context = new PhotoAdminContext(options));*/
        }
    }
}