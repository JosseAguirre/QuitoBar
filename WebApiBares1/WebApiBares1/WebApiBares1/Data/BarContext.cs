using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBares1.Data
{
    public class BarContext : DbContext
    {
        public BarContext(DbContextOptions<BarContext>options): base(options)
        {
        }
        public DbSet<Bar> QuitoBares { get; set; }
    }
}
