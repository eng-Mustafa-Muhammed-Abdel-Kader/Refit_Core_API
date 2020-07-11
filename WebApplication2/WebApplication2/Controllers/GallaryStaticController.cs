using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("GymPolicy")]
    public class GallaryStaticController : ControllerBase
    {
        private readonly IHostingEnvironment hosting;

        private readonly AdminsGymDbContext dbContext;

        public GallaryStaticController(AdminsGymDbContext context,IHostingEnvironment hos)
        {
            dbContext = context;
            hosting = hos;
        }

        [HttpGet]
        public async Task<IEnumerable<GallaryStaticImage>> GetGallaryStaticImages()
        {
            return await dbContext.GallaryStaticImages.ToListAsync();
        }

        [HttpGet("GetStaticGallaryDevelops")]
        public async Task<IEnumerable<staticGallaryDevelop>> GetStaticGallaryDevelops() {
            var staticGallary = await (from s in dbContext.GallaryStaticImages.OrderByDescending(x => x.idGallary) select new staticGallaryDevelop { id = s.idGallary, source = FilesAndObjectOperation.linkApi + s.imageURL, alt = s.shortDescreption, title = s.Title }).Take(5).ToListAsync();

            return staticGallary;
        }

        [HttpPost("uploadStaticImage"), DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var File = Request.Form.Files[0];
                var FolderName = Path.Combine(hosting.WebRootPath,"Resources", "Images", "staticImage");
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
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<GallaryStaticImage>> PostGallaryStaticImages(GallaryStaticImage gallaryStaticImage)
        {
            dbContext.GallaryStaticImages.Add(gallaryStaticImage);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction("GetGallaryStaticImages", new { id = gallaryStaticImage.idGallary }, gallaryStaticImage);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GallaryStaticImage>> DeleteGallaryStaticImages(int id)
        {
            var gallaryStaticImage = await dbContext.GallaryStaticImages.FindAsync(id);
            if (gallaryStaticImage == null)
            {
                return NotFound();
            }

            var imageArr = gallaryStaticImage.imageURL.Split('/');
            var imageName = imageArr[imageArr.Length - 1].ToString();
            FilesAndObjectOperation.DeleteFile(imageName);

            dbContext.GallaryStaticImages.Remove(gallaryStaticImage);
            await dbContext.SaveChangesAsync();

            return gallaryStaticImage;
        }
    }

    public class staticGallaryDevelop {
        public int id { get; set; }
        public string source { get; set; }
        public string alt { get; set; }
        public string title { get; set; }
    }
}