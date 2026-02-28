using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VarerWebApi.Models;

namespace VarerWebApi.Data
{
    public class VarerWebApiContext : DbContext
    {
        public VarerWebApiContext (DbContextOptions<VarerWebApiContext> options)
            : base(options)
        {
        }

        public DbSet<VarerWebApi.Models.Vare> Vare { get; set; } = default!;
    }
}
