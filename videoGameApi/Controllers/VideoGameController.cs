using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using videoGameApi.Data;
using videoGameApi.Models;

namespace videoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController(VideoGameDbContext context) : ControllerBase
    {
        public readonly VideoGameDbContext _Context = context;

        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGame()
        {

            return Ok(await _Context.VideoGames.ToListAsync());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<VideoGame>> GetVideoGameById(int id)
        {
            var game = await _Context.VideoGames.FindAsync(id);
            if (game is null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<VideoGame>> CreateVideoGame(VideoGame newGame)
        {
            if (newGame is null)
            {
                return BadRequest();
            }
            _Context.VideoGames.Add(newGame);
            await _Context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVideoGames(int id, VideoGame updatedGame)
        {
            var game = await _Context.VideoGames.FindAsync(id);
            if (game is null)
            {
                return NotFound();
            }
            game.Title = updatedGame.Title;
            game.Platform = updatedGame.Platform;
            game.Developer = updatedGame.Developer;
            game.Publisher = updatedGame.Publisher;

            await _Context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoGame(int id)
        {
            var game = await _Context.VideoGames.FindAsync(id);
            if (game is null)
            {
                return NotFound();
            }
            _Context?.VideoGames.Remove(game);
            await _Context.SaveChangesAsync();

            return NoContent();
        }

    }
}
