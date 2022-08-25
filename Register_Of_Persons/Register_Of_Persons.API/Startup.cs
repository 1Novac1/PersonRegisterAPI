using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Register_Of_Persons.BLL;
using Register_Of_Persons.BLL.Interfaces;
using Register_Of_Persons.BLL.Models;
using Register_Of_Persons.BLL.Service;
using Register_Of_Persons.DAL.DatabaseContext;
using Register_Of_Persons.DAL.Entity;
using AutoMapper.Extensions.ExpressionMapping;
using Register_Of_Persons.DAL.Interfaces;
using Register_Of_Persons.DAL.Repo;

namespace Register_Of_Persons.API
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
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutomapperSettings());
                mc.AddExpressionMapping();
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<IRepository<Person>, PersonRepository>();
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IRepository<Skill>, SkillRepository>();
            services.AddTransient<ISkillService, SkillService>();
            services.AddTransient<IRepository<PersonSkill>, PersonSkillRepository>();
            services.AddTransient<IModelService<PersonSkillModel>, PersonSkillService>();
            services.AddTransient<CSVFileService, CSVFileService>();

            services.AddControllers();

            services.AddDbContext<MssqlDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RegisterOfPersonsDb")));

            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            });
        }
    }
}