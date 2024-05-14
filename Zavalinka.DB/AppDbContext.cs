using Microsoft.EntityFrameworkCore;
using Zavalinka.DB.Entities;

namespace Zavalinka.DB
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RestoringCodeEntity> RestoringCodes { get; set; }
        
        public DbSet<AnswerEntity> Answer { get; set; }
        public DbSet<GameEntity> Game { get; set; }
        public DbSet<RoundEntity> Round { get; set; }
        public DbSet<TeamEntity> Team { get; set; }
        public DbSet<ThemeEntity> Theme { get; set; }
        public DbSet<ThemeRoundEntity> ThemeRound { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserEntity>(user =>
            {
                user.Property(u => u.Firstname).IsRequired().HasMaxLength(50);
                user.Property(u => u.Name).IsRequired().HasMaxLength(50);
                user.Property(u => u.Firstname).HasMaxLength(30);
                user.Property(u => u.Age).IsRequired();
                user.Property(u => u.Email).IsRequired().HasMaxLength(50);
                user.Property(u => u.Password).IsRequired().HasMaxLength(100);
                user.Property(u => u.UserName).IsRequired().HasMaxLength(50);
                user.Property(u => u.DateCreated).IsRequired();
            });

            builder.Entity<RestoringCodeEntity>(code =>
            {
                code.Property(c => c.Code).IsRequired().HasMaxLength(6);
                code.Property(c => c.Expiration).IsRequired();
                code.Property(u => u.DateCreated).IsRequired();
                code.Property(u => u.Email).IsRequired().HasMaxLength(50);
            });
        }
    }
}