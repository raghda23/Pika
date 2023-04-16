using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pikia.Core.Entities.Indentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikia.Repository.Identity
{
    public class AppIdentiyDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentiyDbContext(DbContextOptions<AppIdentiyDbContext> options) : base(options)
        {

        }
    }
}
