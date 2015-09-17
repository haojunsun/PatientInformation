using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientInformation.Core.Models;
using PatientInformation.Infrastructure;

namespace PatientInformation.Core.Repositories
{
    public class AppDbContext : DbContext, IDependencyPerRequest
    {
        public AppDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Article> Articles { get; set; }
    }
}
