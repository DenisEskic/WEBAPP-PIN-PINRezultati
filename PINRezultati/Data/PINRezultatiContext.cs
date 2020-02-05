using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PINRezultati.Models.Rezultati;

namespace PINRezultati.Models
{
    public class PINRezultatiContext : DbContext
    {
        public PINRezultatiContext (DbContextOptions<PINRezultatiContext> options)
            : base(options)
        {
        }
        //COMMENT
        public DbSet<PINRezultati.Models.Rezultati.Rezultati> Rezultati { get; set; }
    }
}
