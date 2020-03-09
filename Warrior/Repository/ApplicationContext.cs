using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warrior.Models;

namespace Warrior.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<Warrior.Models.Warrior> Warriors { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
    }
}
