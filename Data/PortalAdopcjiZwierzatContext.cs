using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortalAdopcjiZwierzat.Models.Zwierzeta;

namespace PortalAdopcjiZwierzat.Data
{
    public class PortalAdopcjiZwierzatContext : DbContext
    {
        public PortalAdopcjiZwierzatContext (DbContextOptions<PortalAdopcjiZwierzatContext> options)
            : base(options)
        {
        }

        public DbSet<PortalAdopcjiZwierzat.Models.Zwierzeta.Zwierze> Zwierze { get; set; } = default!;
    }
}
