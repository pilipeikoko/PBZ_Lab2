using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PBZ_Lab2.Web.Domain.Models;

namespace PBZ_Lab2.Web.Data
{
    public class PBZ_Lab2WebContext : DbContext
    {
        public PBZ_Lab2WebContext (DbContextOptions<PBZ_Lab2WebContext> options)
            : base(options)
        {
        }

        public DbSet<PBZ_Lab2.Web.Domain.Models.User> User { get; set; }

        public DbSet<PBZ_Lab2.Web.Domain.Models.Manager> Manager { get; set; }

        public DbSet<PBZ_Lab2.Web.Domain.Models.Vehicle> Vehicle { get; set; }


    }
}
