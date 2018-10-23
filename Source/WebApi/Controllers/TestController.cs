using Drm.Data.Entities;
using Drm.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Drm.WebApi.Controllers
{
    [Route("api/[Controller]")]
    public class TestController : Controller
    {
        private readonly IDrmRepository<Test> _testRepository;

        public TestController(IDrmRepository<Test> testRepository)
        {
            _testRepository = testRepository;
        }
        [HttpGet]
        public IEnumerable<Test> Get()
        {
            return _testRepository.GetAll();
        }
    }
}
