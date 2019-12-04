using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UAdmin.Managers;
using UAdmin.NHibernate;

namespace user_administration_core
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
            services.AddControllers();
            services.AddSingleton<INhibernateHelper>(new NHibernateHelper(Configuration));
            services.AddSingleton(typeof(IEntityManager<>), typeof(EntityManager<>));
            services.AddMvc()
                .AddNewtonsoftJson(options =>
                {
                    //в связи с типом данных N-N у сущностей при серилазации - ошибка циклической зависимости.
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
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

            app.UseRouting();

            //Разрешаем всё т.к. локально к нам никто не доберется
            app.UseCors(v => 
                v.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .Build());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
