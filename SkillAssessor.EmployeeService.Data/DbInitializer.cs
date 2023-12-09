using Microsoft.EntityFrameworkCore;

namespace SkillAssessor.EmployeeService.Data;

public static class DbInitializer
{
    public static async Task Initialize<T>(T context) where T : DbContext
    {
        await context.Database.MigrateAsync();
    }
}