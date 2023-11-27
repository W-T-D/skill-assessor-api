using Microsoft.EntityFrameworkCore;
using SkillAssessor.EmployeeService.Entity.Employees;
using SkillAssessor.EmployeeService.Entity.InterviewRequests;
using SkillAssessor.EmployeeService.Entity.SkillLevels;

namespace SkillAssessor.EmployeeService.Data;

public sealed class EmployeeDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    
    public DbSet<InterviewRequest> InterviewRequests { get; set; }
    
    public DbSet<SkillLevel> SkillLevels { get; set; }
    
    
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(b =>
        {
            b.Property(e => e.DateOfBirth)
                .IsRequired();
            b.Property(e => e.Country)
                .IsRequired();
            b.Property(e => e.EmploymentDate)
                .IsRequired();
            b.HasMany(e => e.Skills);
            b.HasMany(e => e.InterviewRequests);
        });

        modelBuilder.Entity<SkillLevel>(b =>
        {
            b.Property(sl => sl.LevelNumber)
                .IsRequired();
            b.Property(sl => sl.SkillTitle)
                .IsRequired();
        });

        modelBuilder.Entity<InterviewRequest>(b =>
        {
            b.Property(ir => ir.InterviewDate)
                .IsRequired();
            b.HasOne(ir => ir.Employee);
            b.HasOne(ir => ir.SkillLevel);
            b.HasMany(ir => ir.Interviewers);
        });
    }
}