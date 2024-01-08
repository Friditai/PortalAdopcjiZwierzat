using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortalAdopcjiZwierzat.Models.Zwierzeta;

namespace PortalAdopcjiZwierzat.Data
{
    public class PortalAdopcjiZwierzatContext : IdentityDbContext<IdentityUser>
    {
        public PortalAdopcjiZwierzatContext (DbContextOptions<PortalAdopcjiZwierzatContext> options)
            : base(options)
        {
        }

        public DbSet<PortalAdopcjiZwierzat.Models.Zwierzeta.Zwierze> Zwierze { get; set; } = default!;
    }
}
