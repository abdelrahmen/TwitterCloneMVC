namespace TwitterClone.Models
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        // DbSet for your custom entities
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Followers> Followers { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Followers>().HasKey(s => new {s.FollowerId, s.FollowingId});

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var  config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectionString = config.GetSection("ConnectionString").Value;
            optionsBuilder.UseSqlServer(connectionString);
            

        }
    }

}
