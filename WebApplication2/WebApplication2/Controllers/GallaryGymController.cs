using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using Microsoft.AspNetCore.Cors;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("GymPolicy")]
    public class GallaryGymController : ControllerBase
    {
        private readonly IHostingEnvironment hosting;
        private readonly AdminsGymDbContext dbContext;

        public GallaryGymController(AdminsGymDbContext context,IHostingEnvironment hos)
        {
            dbContext = context;
            hosting = hos;
        }

        [HttpGet("playersHasImage")]
        public async Task<IEnumerable<Players>> GetPlayersHasUploadImage() {

            //var players = await dbContext.Players.ToListAsync();
            var players = await (from p in dbContext.Players join g in dbContext.gallarygym on p.IDPlayer equals g.playerID group p by p.IDPlayer into p select p.First()).ToListAsync();
           
            return players;
        }

        // GET: api/GallaryGym/5
        [HttpGet("GetGallaryGymImage/{id}")]
        public async Task<IEnumerable<gallaryDevelop>> GetGallaryGymImage(int id)
        {
            var gallaryGym = await (from p in dbContext.Players
                                 join g in dbContext.gallarygym.Where(x => x.FileType == 1) on p.IDPlayer equals g.playerID
                                 select new gallaryDevelop { ID = g.gallaryID, playerID = g.playerID, fullPath = FilesAndObjectOperation.linkApi + g.imagePath, playerName = p.FullName }).Where(x => x.playerID == id).ToListAsync();

            return gallaryGym;
        }


        [HttpGet("GetGallaryGymVideo/{id}")]
        public async Task<IEnumerable<gallaryDevelop>> GetGallaryGymVideo(int id)
        {
            var gallaryGym = await (from p in dbContext.Players
                                    join g in dbContext.gallarygym.Where(x => x.FileType == 2) on p.IDPlayer equals g.playerID
                                    select new gallaryDevelop { ID = g.gallaryID, playerID = g.playerID, fullPath = FilesAndObjectOperation.linkApi + g.imagePath, playerName = p.FullName }).Where(x => x.playerID == id).ToListAsync();

            return gallaryGym;
        }

        // PUT: api/GallaryGym/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGallaryGym(int id, GallaryGym gallaryGym)
        {
            if (id != gallaryGym.gallaryID)
            {
                return BadRequest();
            }

            dbContext.Entry(gallaryGym).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GallaryGymExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GallaryGym
        [HttpPost]
        public async Task<ActionResult<GallaryGym>> PostGallaryGym(GallaryGym gallary)
        {
                dbContext.gallarygym.Add(gallary);
                await dbContext.SaveChangesAsync();

            return CreatedAtAction("GetGallaryGym", new { id = gallary.gallaryID }, gallary);
        }

        [HttpPost("upload"),RequestFormLimits(MultipartBodyLengthLimit = 209715200),RequestSizeLimit(209715200)]
        public IActionResult Upload()
        {
            try
            {
                var File = Request.Form.Files[0];
                var FolderName = Path.Combine(hosting.WebRootPath,"Resources", "Images");
                var PathToSave = Path.Combine(Directory.GetCurrentDirectory(), FolderName);

                if (File.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(File.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(PathToSave, fileName);
                    var dbPath = Path.Combine(FolderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        File.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception cx)
            {
                return StatusCode(500, cx.Message);
            }
        }

        // DELETE: api/GallaryGym/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GallaryGym>> DeleteGallaryGym(int id)
        {
            var gallaryGym = await dbContext.gallarygym.FindAsync(id);
            if (gallaryGym == null)
            {
                return NotFound();
            }

            var imageArr = gallaryGym.imagePath.Split('/');
            var imageName = imageArr[imageArr.Length - 1].ToString();
            FilesAndObjectOperation.DeleteFile(imageName);

            dbContext.gallarygym.Remove(gallaryGym);
            await dbContext.SaveChangesAsync();

            return gallaryGym;
        }

        private bool GallaryGymExists(int id)
        {
            return dbContext.gallarygym.Any(e => e.gallaryID == id);
        }
    }

    public class gallaryDevelop {
        public int ID { get; set; }
        public int playerID { get; set; }
        public string fullPath { get; set; }
        public string playerName { get; set; }
    }
}
