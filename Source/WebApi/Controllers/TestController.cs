using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
  [Route("api/[Controller]")]
  public class TestController : Controller
  {
    [HttpGet]
    public IEnumerable<User> Get()
    {
      var users = new List<User>
      {
        new User { Id = 1, Username = "User1", Password = "Pass1" },
        new User { Id = 2, Username = "User2", Password = "Pass2" },
        new User { Id = 3, Username = "User3", Password = "Pass3" },
        new User { Id = 4, Username = "User4", Password = "Pass4" },
      };

      return users;
    }
  }

  public class User
  {
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
  }
}
