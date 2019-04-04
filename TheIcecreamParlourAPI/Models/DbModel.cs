using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheIcecreamParlourAPI.Models
{
    public class DbModel : DbContext
    {
        public DbModel (DbContextOptions<DbModel>options) : base(options)
        {
            
        }

        public DbSet<Icecream> icecream { get; set; }
    }
}
