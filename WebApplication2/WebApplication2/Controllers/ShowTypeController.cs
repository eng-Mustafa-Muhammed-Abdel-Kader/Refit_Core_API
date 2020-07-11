using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("GymPolicy")]
    public class ShowTypeController : ControllerBase
    {
        private readonly AdminsGymDbContext dbContext;

        public ShowTypeController(AdminsGymDbContext context)
        {
            dbContext = context;
        }

        //api/ShowType
        [HttpGet]
        public async Task<IEnumerable<ShowNewsType>> GetShowNewsTypes()
        {
            return await dbContext.ShowNewsTypes.ToListAsync();
        }
    }
}