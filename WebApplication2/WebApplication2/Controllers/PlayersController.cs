using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("GymPolicy")]
    public class PlayersController : ControllerBase
    {
        private readonly AdminsGymDbContext dbContext;

        public PlayersController(AdminsGymDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Players>> GetAllPlayers()
        {
            return await dbContext.Players.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Players>> GetOnePlayer(int id)
        {
            var player = await dbContext.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        [HttpPost]
        public async Task<ActionResult<Players>> AddPlayer(Players player)
        {
            dbContext.Players.Add(player);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction("GetOnePlayer", new { id = player.IDPlayer }, player);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Players>> EditPlayer(int id, Players player)
        {
            if (id != player.IDPlayer)
            {
                return BadRequest();
            }

            dbContext.Entry(player).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
                {
                    return NotFound();
                }
                else {
                    throw;
                }
            }
            return NoContent();
        }

        private bool PlayerExists(int id)
        {
            return dbContext.Players.Any(x => x.IDPlayer == id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Players>> RemovePlayer(int id)
        {
            var player = await dbContext.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            dbContext.Players.Remove(player);
            await dbContext.SaveChangesAsync();

            return player;
        }


    }

    class PlayerCoach
    {
        public int PlayerhID { get; set; }
        public string PlayerName { get; set; }

        public string Mail { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public bool IsIdeal { get; set; }


    }
}