using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using hospital.Models;

using hospital.Models.Interfaces;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace hospital.Data
{
    
    public class HospitalDBContext : DbContext
    {
        private string configuration = "Server=DESKTOP-0DMVN62\\MILEN;Database=HospitalDB;Trusted_Connection=True;";
        //protected IConfigurationRoot configuration;
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Nurse> Nurses { get; set; }

        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<User> Users { get; set; }

        public HospitalDBContext(){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<EmployeeCustomers>().HasOne(x => x.Employee).WithMany(x => x.EmployeeCustomers).OnDelete(DeleteBehavior.Restrict);
            // modelBuilder.Entity<EmployeeCustomers>().HasOne(x => x.Customer).WithMany(x => x.EmployeeCustomers).OnDelete(DeleteBehavior.Cascade);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("HotelsDB": "server=DESKTOP-EETQ29P;database=HotelsDB;");
            
            //configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(configuration);
        }
        public override int SaveChanges()
        {

            return this.SaveChanges(true);
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyEntityChanges();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        private void ApplyEntityChanges()
        {
            var entries = this.ChangeTracker.Entries().Where(x => x.Entity is ICMDat && x.State == EntityState.Added || x.State == EntityState.Deleted || x.State == EntityState.Modified).ToList();

            foreach (var entry in entries)
            {
                var entity = (ICMDat)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.Now;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    entity.DeletedAt = DateTime.Now;

                }
                else
                {
                    entity.ModifiedAt = DateTime.Now;
                }
            }
        }
    }
}
