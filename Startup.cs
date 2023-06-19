using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WebIssueManagementApp.Data;
using WebIssueManagementApp.Interface;
using WebIssueManagementApp.Services;

namespace WebIssueManagementApp
{

  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      Console.WriteLine("DB_HOST: " + UtilsService.GetLocalIPAddress());

      string connection = string.Format(Configuration.GetConnectionString("connection_sql"),
        Configuration["DB_HOST"] ?? UtilsService.GetLocalIPAddress(), 
        Configuration["DB_PORT"] ?? "1433", //porta default do sql server
        Configuration["DB_USER"], 
        Configuration["DB_PASSWORD"]);

      services.AddDbContext<ManagementIssueContext>(
                options => options.UseSqlServer(connection));

      services.Configure<RouteOptions>(options =>
      {
        options.LowercaseUrls = true;
      });

      services.AddAuthentication("CookieAuthentication")
        .AddCookie("CookieAuthentication", config =>
        {
          config.Cookie.Name = "UserLoginCookie";
          config.LoginPath = "/login";
        });

      services.AddTransient<IUnitOfWork, UnitOfWork>();

      services.AddControllersWithViews().AddMvcOptions(options =>
      {
        options.MaxModelValidationErrors = 10;
        options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(_ => "The field is required.");
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }
      //Inicializar banco de dados
      app.Migrate();

      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthentication();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
