using Microsoft.EntityFrameworkCore;
using ContemporaryAPI.Models;

namespace ContemporaryAPI.Data
{
    public class ContemporaryDbContext : DbContext
    {
        public ContemporaryDbContext(DbContextOptions<ContemporaryDbContext> options) : base(options) { }

        // Defines DbSet for all tables, please follow format below and replace "TeamMember" to match appropriate tables
        public DbSet<TeamInfo> TeamInfos { get; set; }

        public DbSet<BookGenres> BookGenres { get; set; }

        public DbSet<FavAnimals> FavAnimals { get; set; }

    }
}
