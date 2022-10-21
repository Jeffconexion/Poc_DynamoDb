using Amazon.DynamoDBv2;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AppSampleDynamoDb
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public static IConfiguration Configuration { get; private set; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();

      //Obter as credenciais da AWS
      services.AddDefaultAWSOptions(Configuration.GetAWSOptions("AWS"));

      //Injetando o Dynamo
      services.AddAWSService<IAmazonDynamoDB>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        endpoints.MapGet("/", async context =>
              {
                await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
              });
      });
    }
  }
}
