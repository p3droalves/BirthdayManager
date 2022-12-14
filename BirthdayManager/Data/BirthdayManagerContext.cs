using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BirthdayManager.Models;

namespace BirthdayManager.Data
{
    public class BirthdayManagerContext : DbContext
    {
        public BirthdayManagerContext (DbContextOptions<BirthdayManagerContext> options)
            : base(options)
        {
            Database.EnsureCreated();   
        }

        public DbSet<BirthdayManager.Models.Friend> Friend { get; set; } = default!;
    }
}
