using MeetingRoom.core.Context;
using MeetingRoom.core.Interfaces;
using MeetingRoom.core.Repositories;
using MeetingRoom.core.services;
using MeetingRoom.services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace MeetingRoom.Api
{

    public class Startup
    {
        private string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //SERVICES
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IRoomsService, RoomsService>();
            services.AddTransient<IReservationsService, ReservationService>();
            services.AddTransient<IAdminService, AdminService>();
            services.AddDbContext<MeetingRoomAppContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default"),
                x => x.MigrationsAssembly("MeetingRoom.Data")));

            //TBD for more tables 
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "MeetingRoomApi", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews()
                         .AddNewtonsoftJson(options =>
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            services.AddCors(
                options =>
                {
                    options.AddPolicy(name: MyAllowSpecificOrigins,
                                      policy =>
                                      {
                                          policy.WithOrigins("http://localhost:3000/", "https://localhost:7216/").AllowAnyHeader       ().AllowAnyMethod();


                                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                                      });
                }
                );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();


            app.UseSwaggerUI(c =>
           {
               c.RoutePrefix = "";
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "Meeting Room App v1");
           });

        }
    }
}

