using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PsAngular.Migrations;

namespace PsAngular.Models
{
    public partial class PsContext : DbContext
    {
        public PsContext() : base("name=PsDbConnection") {
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<PsContext, Configuration>());
            Database.SetInitializer<PsContext>(new CreateDatabaseIfNotExists<PsContext>());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designation { get; set; }
    }
}