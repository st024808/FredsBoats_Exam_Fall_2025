using Microsoft.EntityFrameworkCore;
using FredsBoats.Web.Models;

namespace FredsBoats.Web.Data
{
    public class FredsBoatsContext : DbContext
    {
        public FredsBoatsContext(DbContextOptions<FredsBoatsContext> options)
            : base(options)
        {
        }

        public DbSet<Boat> Boats { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BoatColour> BoatColours { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<CustReservation> CustReservations { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}