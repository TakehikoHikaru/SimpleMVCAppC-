using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCApp.Models;

namespace MVCApp.Data
{
    public class MVCAppContext : DbContext
    {
        public MVCAppContext (DbContextOptions<MVCAppContext> options)
            : base(options)
        {
        }

        public DbSet<MVCApp.Models.User> User { get; set; }

        public DbSet<MVCApp.Models.Email> Email { get; set; }

        public DbSet<MVCApp.Models.PersonalPhone> PersonalPhone { get; set; }

        public DbSet<MVCApp.Models.CommercialPhone> CommercialPhone { get; set; }
    }
}
