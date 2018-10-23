using Drm.Repository;
using Drm.Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drm.WebApi.Controllers
{
  [Route("api/[Controller]")]
  public class TestController : Controller
  {
    private readonly DRMContext _ctx;

    public TestController(DRMContext ctx)
    {
      _ctx = ctx;
    }
    [HttpGet]
    public IEnumerable<Test> Get()
    {
      return _ctx.Tests.ToList();
    }
  }
}
