using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PUCon.Models;
using System.Net.Sockets;

namespace PUCon.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly EventManagementContext _context;

        public UserController(EventManagementContext context)
        {
            _context = context;
        }




        //[HttpGet("Retrieving data from User Table")]
        //public ActionResult<IEnumerable<User>> Get()
        //{
        //    return _context.Users.ToList();  // returning tickets list 
        //}




        [HttpGet("All_UserDetails")]
        public async Task<IActionResult> GetUser() // passing obj of UserModel
        {
            var obj1 = await _context.Users.ToListAsync();

            return Ok(obj1);

        }









        [HttpPost("Register_the_User")]
        public ActionResult<string> AddUser([FromBody] UserModel obj)
        {
            try
            {
                User obj1 = new User();//creating new object
                obj1.Email = obj.Email;
                obj1.Password = obj.Password;
             




                _context.Users.Add(obj1);
                _context.SaveChanges();


                return Ok("User is succesfully registered");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); //we can also send own msg
            }


        }










        [HttpPost("LogIn_API")]

        public bool Method([FromBody] LoginModel item)
        {

            var item1 = _context.Users.Where(x => x.Email == item.Email).FirstOrDefault(); //will find that obj that has same email or null
            if (item1 != null)
            {

                var item2 = _context.Users.Where(x => x.Password == item.Password && x.Email == item.Email).FirstOrDefault();//will find that obj that has same password or null
                if (item2 != null)
                {
                    return true;

                }

                return false;

            }
            else

                return false;


        }







    }
}
