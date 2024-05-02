using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using PassIn.Api.Extensions;
using PassIn.Api.Filters;
using PassIn.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace PassIn.Api
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public IConfiguration configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        {
            _ = app.UseRouting();
            // _ = app.UseHttpsRedirection();
            _= app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if (env.IsDevelopment())
            {
                _ = app.UseSwagger();
                _ = app.UseSwaggerUI();;
            }
            
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<IPassInDBContext, PassInDbContext>(op => 
                op.UseSqlite(configuration.GetConnectionString("SqLiteDbConnection")));
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddServicesAndRegistration();
           
        }
    }
}
