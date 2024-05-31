using Microsoft.EntityFrameworkCore;
using Ticketier_WebApi.Core.Entities;

namespace Ticketier_WebApi.Core.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
