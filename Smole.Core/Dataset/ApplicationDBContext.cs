using Microsoft.EntityFrameworkCore;

namespace Smole.Core
{
    /// <summary>
    /// Our DbContext for database
    /// </summary>
    public class ApplicationDBContext : DbContext
    {
        #region Public Properties

        /// <summary>
        /// All users in the app from db
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// All groups in the app from db
        /// </summary>
        public DbSet<Group> Groups { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Connection to DB
        /// </summary>
        /// <param name="options"> Encapsulates configuration parameters </param>
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        #endregion

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasAlternateKey(u => u.FirstName);
        //    modelBuilder.Entity<User>().Property(u => u.Age).HasDefaultValue(18);
        //    modelBuilder.Entity<User>().Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // many-to-many
            modelBuilder.Entity<UsersInGroups>()
                        .HasKey(t => new { t.UserId, t.GroupId });
            modelBuilder.Entity<UsersInGroups>()
                        .HasOne(sc => sc.User)
                        .WithMany(s => s.Groups)
                        .HasForeignKey(sc => sc.UserId);
            modelBuilder.Entity<UsersInGroups>()
                        .HasOne(sc => sc.Group)
                        .WithMany(c => c.Users)
                        .HasForeignKey(sc => sc.GroupId);
        }
    }
}
