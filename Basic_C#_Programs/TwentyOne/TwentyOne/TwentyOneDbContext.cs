using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TwentyOne
{
    class TwentyOneDbContext : DbContext
    {
        public DbSet<TwentyOneGamePlaySession> TwentyOneGamePlaySessions { get; set; }
    }
}
