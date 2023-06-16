using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebIssueManagementApp.Data;

namespace WebIssueManagementApp.Services
{
  public static class DbMigrationService
  {
    public static void Migrate(this IApplicationBuilder app)
    {
      using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
      {
        var context = serviceScope.ServiceProvider.GetRequiredService<ManagementIssueContext>();
        context.Database.Migrate();
      }
    }

  }
}
