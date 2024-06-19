using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Boxfusion.TechnicalAssessment.Authorization.Roles;
using Boxfusion.TechnicalAssessment.Authorization.Users;
using Boxfusion.TechnicalAssessment.MultiTenancy;
using Boxfusion.TechnicalAssessment.Domain.Skills;
using Boxfusion.TechnicalAssessment.Domain.Employees;
using Boxfusion.TechnicalAssessment.Domain.Addresses;

namespace Boxfusion.TechnicalAssessment.EntityFrameworkCore
{
    public class TechnicalAssessmentDbContext : AbpZeroDbContext<Tenant, Role, User, TechnicalAssessmentDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        
        public TechnicalAssessmentDbContext(DbContextOptions<TechnicalAssessmentDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(b =>
            {
                b.HasMany(e => e.Skills)
                  .WithOne(s => s.Employee)
                  .HasForeignKey(s => s.EmployeeId);
            });
        }

    }
}
