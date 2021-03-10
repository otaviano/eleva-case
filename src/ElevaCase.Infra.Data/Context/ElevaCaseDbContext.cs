using ElevaCase.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElevaCase.Infra.Data.Context
{
    public class ElevaCaseDbContext : DbContext
    {
        public DbSet<@Class> Classes { get; set; }
        public DbSet<School> Schools { get; set; }

        public ElevaCaseDbContext(DbContextOptions options) 
            : base(options) { }
    }
}
