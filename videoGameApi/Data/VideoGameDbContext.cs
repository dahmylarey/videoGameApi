using Microsoft.EntityFrameworkCore;
using videoGameApi.Models;

namespace videoGameApi.Data
{
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
    {
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VideoGame>().HasData(new VideoGame
            {
                Id = 1,
                Title = "Spider-Man 2",
                Platform = "PS5",
                Developer = "Insomniac Games",
                Publisher = "Sony Interractive Entertainment"

            },
            new VideoGame
            {
                Id = 2,
                Title = "The league of Zelda: Breath of the wild",
                Platform = "Nintendo Switch",
                Developer = "Insomniac Games",
                Publisher = "Nintendo"

            },
            new VideoGame
            {
                Id = 3,
                Title = "Cyberpunk 2077",
                Platform = "PC",
                Developer = "CD Projekt Red",
                Publisher = "CD Projekt"

            });
        }

    }
}
