using EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.MVVM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.Contexts
{
    class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<CustomerEntity> Customers { get; set; } = null!;
        public DbSet<CaseEntity> Cases { get; set; } = null!;
        public DbSet<CaseStatusEntity> CaseStatus { get; set; } = null!;
        public DbSet<SeverityLevelEntity> SeverityLevel { get; set; } = null!;
    }
}
