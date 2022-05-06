using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OceanicAirlines.APIModels;
using OceanicAirlines.Services;
using OceanicAirlines.Models;
using System.Collections;

namespace OceanicAirlines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController
    {
        [HttpPost(Name = "PostUser")]
        public IActionResult Post([FromBody] ApiUserRequest req)
        {
            User user = new User();
            using(var context = new DbOaDk1Context())
            {
                user = context.User.Where(u => u.Mail == req.Mail && u.Password == req.Password).FirstOrDefault(defaultValue: new User());
            }
            if (user.Mail == null || user.Mail == "")
            {
                 return new JsonResult(418);
            }
            else
            {
                return new JsonResult(200, user);
            }
        }
        [HttpPut(Name = "PutUser")]
        public IActionResult Put([FromBody] User req)
        {
            User user = new User();
            using (var context = new DbOaDk1Context())
            {
                context.User.Add(user);

                context.SaveChanges();
            }

                return new JsonResult(200);
        }
    }
}
