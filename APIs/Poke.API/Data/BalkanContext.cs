using Microsoft.EntityFrameworkCore;
using Poke.API.Entities;

namespace Poke.API.Data
{
    public class BalkanContext : DbContext
    {
        public BalkanContext()
        {
        }

        public BalkanContext(DbContextOptions<BalkanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(builder =>
            {
                builder.ToTable("EMPLOYEE");
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id)
                    .HasColumnName("EMP_ID")
                    .ValueGeneratedNever();
                builder.Property(e => e.StartDate)
                    .HasColumnName("START_DATE");
                builder.Property(e => e.EndDate)
                    .HasColumnName("END_DATE");
                builder.Property(e => e.FirstName)
                    .HasColumnName("FIRST_NAME");
                builder.Property(e => e.LastName)
                    .HasColumnName("LAST_NAME");
                builder.Property(e => e.Title)
                    .HasColumnName("TITLE");
            });
        }
    }
}