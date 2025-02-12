using Microsoft.EntityFrameworkCore;

namespace spinalproject.src.appointDbContext
{
    public class appointDbContext: DbContext
    {

        protected readonly IConfiguration Configuration;

        public appointDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ReportEntity> Reports { get; set; }
        public DbSet<AppointmentEntity> Appointments { get; set; }
    }
}
