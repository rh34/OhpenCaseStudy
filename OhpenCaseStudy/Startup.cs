using System.IO;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OhpenCaseStudy.Domain.Factories;
using OhpenCaseStudy.Domain.Services;
using OhpenCaseStudy.Domain.SortAlgorithms;

namespace OhpenCaseStudy.Api
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ohpen - String Sort API", Version = "v1" });

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "OhpenCaseStudy.Api.xml");
                c.IncludeXmlComments(filePath);
                //c.DescribeAllEnumsAsStrings();
            });

            services.AddTransient<IStringSortService, StringSortService>();
            services.AddTransient<SortAlgorithmFactory>();
            services.AddTransient<AlphabeticalSorter>();
            services.AddTransient<WordSizeSorter>();

            services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            services.AddOptions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ohpen - String Sort API v1"));

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
            });
        }
    }
}
