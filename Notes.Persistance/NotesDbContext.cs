using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Notes.Domain;
using Notes.Persistance.EntityTypeConfigurations;

namespace Notes.Persistance
{
    public class NotesDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public NotesDbContext()
        {

        }

        public NotesDbContext(DbContextOptions<NotesDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NoteConfiguration());
            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("NotesDb");
            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
