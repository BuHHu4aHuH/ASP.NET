namespace UserWebApp.Models.Domain
{
    using System.Data.Entity;

    /// <summary>
    /// The database context.
    /// </summary>
    public class DatabaseContext : DbContext
    {
        public DatabaseContext () : base("Milin") {

        }
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public DbSet<UserItem> Items { get; set; }

        /// <inheritdoc />
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserItem>().Property(e => e.Name).IsRequired().HasMaxLength(100);
        }
    }
}
