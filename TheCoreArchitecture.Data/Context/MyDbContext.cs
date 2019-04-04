using Microsoft.EntityFrameworkCore;
using TheCoreArchitecture.Data.Entities;
using TheCoreArchitecture.Data.InitialDataInitializer;

namespace TheCoreArchitecture.Data.Context
{
    public partial class MyDbContext
    {
        private readonly IDataInitializer _dataInitializer;

        public MyDbContext(DbContextOptions<MyDbContext> options, IDataInitializer dataInitializer) : base(options)
        {
            _dataInitializer = dataInitializer;
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<City> Cities { get; set; }
    }
}
