namespace EFDemo
{
    using System.Reflection;
    using Controllers;
    using Microsoft.EntityFrameworkCore;

    public class HoADbContext : DbContext
    {
        public DbSet<HoAMember> HoAMembers { get; set; }

        private string _db { get; set; }

        protected HoADbContext(DbSet<HoAMember> hoAMembers, string db)
        {
            HoAMembers = hoAMembers;
            _db = db;
        }

        public HoADbContext(string db)
        {
            _db = db;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_db}", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            modelBuilder.Entity<HoAMember>().ToTable("ClownCar");
            modelBuilder.Entity<HoAMember>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
