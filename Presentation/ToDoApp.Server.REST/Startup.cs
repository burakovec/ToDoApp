using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using ToDoApp.Persistence;
using ToDoApp.Server.Common.Extensions;

namespace ToDoApp.Server.REST
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                //.AddJsonOptions(ops => ops.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve)
                .AddOData(conf =>
            {
                conf.EnableQueryFeatures();
            });
            services.AddDbContext<ToDoDataContext>(options => options.UseSqlServer(_configuration.GetConnectionString("ToDoDataConnection")));
            services.AddMediatR();
            services.AddSwagger();
            services.AddIocContainerServices();
            services.AddIdentity(_configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo API V1");
                });
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(builder => builder.WithOrigins("*")
                              .AllowAnyMethod()
                              .AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            InitializeDatabase(app);
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<ToDoDataContext>().Database.Migrate();
            }
        }
    }
}
