using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("GymPolicy")]
    public class LoginController : ControllerBase
    {
        private readonly AdminsGymDbContext dbContext;

        public LoginController(AdminsGymDbContext context)
        {
            dbContext = context;
        }

        [HttpPost]
        public ActionResult<Users> PostLogin([FromBody] Users user)
        {
            if (user.Mail == "" || user.Password == "")
            {
                return null;
            }

            Users users = dbContext.Users.Where(p => p.Mail == user.Mail && p.Password == user.Password).FirstOrDefault();
            return users;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {

            var users = await (from u in dbContext.Users select new Users { Iduser = u.Iduser, FullName = u.FullName, Mail = u.Mail, Password = u.Password, Mobile1 = u.Mobile1, Mobile2 = u.Mobile2, Privilage = u.Privilage, IsHidden = u.IsHidden, CreateBy = u.CreateBy}).Where(x => x.Privilage == 2 || x.Privilage == 3).ToListAsync();

            return users;

            //return await dbContext.Users.Where(x => x.Privilage == 2 || x.Privilage == 3).ToList

        }
    }

    public class UsersLogin {
        public int IDUser { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public int Privilage { get; set; }
        public string IsHidden { get; set; }
        public string CreatedBy { get; set; }
    }
}