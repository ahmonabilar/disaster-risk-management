using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository
{
    public class DRMContext : DbContext 
    {
        public DbSet<Test> Tests { get; set; }
    }
}
