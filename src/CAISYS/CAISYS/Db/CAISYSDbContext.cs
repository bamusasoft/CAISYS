using CAISYS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAISYS.Db
{
    public class CaisysDbContext : IdentityDbContext
    {
        public CaisysDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<AccountChart> AccountCharts { get; set; }

        public virtual DbSet<Journal> Journals { get; set; }

        public virtual DbSet<GeneralLedger> GeneralLedgers { get; set; }
    }
}
