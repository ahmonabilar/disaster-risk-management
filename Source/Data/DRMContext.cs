using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drm.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Drm.Data
{
  public class DRMContext : IdentityDbContext<DrmUser, DrmRole, int>
  {
    public DRMContext(DbContextOptions<DRMContext> options) : base (options)
    {

    }
    public DbSet<Test> Tests { get; set; }
  }
}
