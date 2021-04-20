using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using OrderInChallenge.Commands.Order.Create;
using OrderInChallenge.DataAccess;
using OrderInChallenge.DataAccess.Abstractions;
using OrderInChallenge.DataAccess.Seeder;
using OrderInChallenge.DataAccess.Seeder.Abstractions;
using OrderInChallenge.DataAccess.Services;
using OrderInChallenge.Queries.Restaurants.GetAll;
using OrderInChallenge.Queries.Restaurants.Search;

namespace OrderInChallenge.Api
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
            services.AddMediatR(typeof(SearchRestaurantsQuery));
            services.AddMediatR(typeof(GetAllRestaurantsQuery));
            services.AddMediatR(typeof(CreateOrderCommand));

            services.AddControllersWithViews();
            ConventionRegistry.Register("Camel Case", new ConventionPack { new CamelCaseElementNameConvention() }, _ => true);
            services.AddSingleton<IMongoClient>(s => new MongoClient(Configuration.GetConnectionString("MongoDb")));
            services.AddSingleton(s => new AppDbContext(s.GetRequiredService<IMongoClient>(), Configuration["DbName"]));
            services.AddTransient<IRestaurantsService, RestaurantsService>();
            services.AddTransient<IOrdersService, OrdersService>();
            services.AddTransient<IDbInitializer, DbInitializer>();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
