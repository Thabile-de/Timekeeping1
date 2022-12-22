using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeKeeping1.Model;

namespace TimeKeeping1.Data
{
    public class TimeKeeping1Context : DbContext
    {
        public TimeKeeping1Context (DbContextOptions<TimeKeeping1Context> options)
            : base(options)
        {
        }

        public DbSet<TimeKeeping1.Model.Leave> Leave { get; set; } = default!;

        public DbSet<TimeKeeping1.Model.Schedule> Schedule { get; set; }

        public DbSet<TimeKeeping1.Model.TimeLog> TimeLog { get; set; }

        public DbSet<TimeKeeping1.Model.User> User { get; set; }
    }
}
