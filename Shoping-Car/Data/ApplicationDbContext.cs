using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;

namespace Shop.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Car> Cars { get; set; }

        public DbSet<Registrations> Registrations { get; set; }

        public DbSet<UserCar> UsersCars { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserCar>()
                .HasKey(x => new { x.UserId, x.CarId });


            builder.Entity<Registrations>()
                .HasData(new Registrations()
                {
                    Id = 1,
                    Registration = "Yes"
                },
                new Registrations()
                {
                    Id = 2,
                    Registration = "No"
                });

            base.OnModelCreating(builder);
        }
    }
}