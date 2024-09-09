

using ani_server.Models;
using Microsoft.EntityFrameworkCore;

namespace ani_server.DataBaseContext
{
    public partial class AniSaveDbContext : DbContext
    {
        public AniSaveDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Anime> Animes { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<UserMaster> UserMasters { get; set; }
        public virtual DbSet<WatchListItems> WatchListItems { get; set; }
    }
}