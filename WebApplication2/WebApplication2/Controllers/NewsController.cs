using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("GymPolicy")]
    public class NewsController : ControllerBase 
    {
        private readonly AdminsGymDbContext dbContext;

        private readonly IHostingEnvironment hosting;

        public NewsController(AdminsGymDbContext context, IHostingEnvironment hos)
        {
            dbContext = context;
            hosting = hos;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsDataDevelop>>> GetNews()
        {
            var news = await (from a in dbContext.News select new NewsDataDevelop { ID = a.IDNews, Content = a.contentNews, DateNews = a.PublishNews.ToString("dd/MM/yyyy"), ImageUrl = FilesAndObjectOperation.linkApi + a.imageNews, showNews = a.isShow, showValue = a.ShowNewsType.typeValue }).ToListAsync();

            return news;
        }



        // GET: api/News
        [HttpGet("{show}")]
        public async Task<ActionResult<IEnumerable<NewsDataDevelop>>> GetNews(int show)
        {
            var news = await (from a in dbContext.News select new NewsDataDevelop { ID = a.IDNews, Content = a.contentNews, DateNews = a.PublishNews.ToString("dd/MM/yyyy"), ImageUrl = FilesAndObjectOperation.linkApi + a.imageNews, showNews = a.isShow,showValue = a.ShowNewsType.typeValue}).Where(x => x.showNews == show).ToListAsync();

            return news;
        }

        // GET: api/News/5
        [HttpGet("onenews/{id}")]
        public async Task<IEnumerable<NewsDataDevelop>> GetOneNews(int id)
        {
            var news = await (from a in dbContext.News select new NewsDataDevelop { ID = a.IDNews, Content = a.contentNews, DateNews = a.PublishNews.ToString("dd/MM/yyyy"), ImageUrl = FilesAndObjectOperation.linkApi + a.imageNews}).Where(x => x.ID == id).ToListAsync();

            if (news == null)
            {
                return null;
            }

            return news;
        }

        // PUT: api/News/5
        [HttpPut("{id}")]
        public async Task<IActionResult> News([FromRoute]int id, [FromBody] News news)
        {
            //if (id != news.IDNews)
            //{
            //    return BadRequest(ModelState);
            //}

            News newsQuery = await dbContext.News.FindAsync(id);

            if (newsQuery == null)
            {
                return BadRequest();
            }

            if (news.imageNews != "")
            {
                if (newsQuery.imageNews != news.imageNews)
                {
                    var imageArr = newsQuery.imageNews.Split('/');
                    var imageName = imageArr[imageArr.Length - 1].ToString();
                    FilesAndObjectOperation.DeleteFile(imageName);
                }
            }
            else {
                if (news.imageNews == "")
                {
                    news.imageNews = newsQuery.imageNews;
                }
            }

            dbContext.News.Remove(newsQuery);
            await dbContext.SaveChangesAsync();


            newsQuery = new News()
            {
                contentNews = news.contentNews,
                PublishNews = newsQuery.PublishNews,
                imageNews = news.imageNews,
                isShow = news.isShow
            };

            dbContext.News.Add(newsQuery);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction("GetNews", new { id = news.IDNews }, news);
        }

        // POST: api/News
        [HttpPost]
        public async Task<ActionResult<News>> PostNews(News news)
        {
            dbContext.News.Add(news);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction("GetNews", new { id = news.IDNews }, news);
        }

        [HttpPost("uploadNewsImage"), DisableRequestSizeLimit]
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
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/News/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<News>> DeleteNews(int id)
        {
            var news = await dbContext.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }

            dbContext.News.Remove(news);
            await dbContext.SaveChangesAsync();

            return news;
        }

        private bool NewsExists(int id)
        {
            return dbContext.News.Any(e => e.IDNews == id);
        }
    }

    public class NewsDataDevelop {
        public int ID { get; set; }
        public string Content { get; set; }
        public string DateNews { get; set; }
        public string ImageUrl { get; set; }
        public int showNews { get; set; }
        public string showValue { get; set; }
    }
}
