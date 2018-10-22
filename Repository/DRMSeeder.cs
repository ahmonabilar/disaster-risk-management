using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Repository
{
  public class DRMSeeder
  {
    private readonly DRMContext _ctx;
    private readonly IHostingEnvironment _hosting;

    public DRMSeeder(DRMContext ctx, IHostingEnvironment hosting)
    {
      _ctx = ctx;
      _hosting = hosting;
    }
    public void Seed()
    {
      _ctx.Database.EnsureCreated();

      var filePath = Path.Combine(_hosting.ContentRootPath, "testData.json");

      var json = File.ReadAllText(filePath);

      var jsonObj = JObject.Parse(json);

      var testJToken = jsonObj["Tests"];

      var testEnumerable = JsonConvert.DeserializeObject<IEnumerable<Test>>(testJToken.ToString());

      if (!_ctx.Tests.Any())
      {
        _ctx.Tests.AddRange(testEnumerable);

        _ctx.SaveChanges();
      }


    }
  }
}
