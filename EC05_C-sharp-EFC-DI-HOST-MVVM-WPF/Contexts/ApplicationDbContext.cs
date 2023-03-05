using EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.MVVM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC05_C_sharp_EFC_DI_HOST_MVVM_WPF.Contexts
{
    class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Elias\Downloads\EC-utbildning-webbutvecklare-NET\05-Datalagring\EC05-Databases\EC05_C-sharp-Case_mgmt\EC05_C-sharp-EFC-DI-HOST-MVVM-WPF\Contexts\sql_case_mgmt_db.mdf;Integrated Security=True;Connect Timeout=30";

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        

        public DbSet<CustomerEntity> Customers { get; set; } = null!;
        public DbSet<CaseEntity> Cases { get; set; } = null!;
        public DbSet<CaseStatusEntity> CaseStatus { get; set; } = null!;
        public DbSet<SeverityLevelEntity> SeverityLevel { get; set; } = null!;
    }
}
