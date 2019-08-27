using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Coresb.Models
{
    public class CoresbContext : DbContext
    {
        public CoresbContext (DbContextOptions<CoresbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}
