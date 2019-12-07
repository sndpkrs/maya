using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maya.Handler.Classes;
using Maya.Handler.Interfaces;
using Maya.Handlers.Classes;
using Maya.Handlers.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Maya
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IInitialIntentHandler, InitialIntentHandler>();
            services.AddTransient<IDefaultHandler, DefaultHandler>();
            services.AddTransient<IHelloHandler, HelloHandler>();
            services.AddTransient<IFamilyLawHandler, FamilyLawHandler>();
            services.AddTransient<IConsumerLawHandler, ConsumerLawHandler>();
            services.AddTransient<IDentalHandler, DentalHandler>();
            services.AddTransient<IDermatologyHandler, DermatologyHandler>();
            services.AddTransient<IConflictIntentHandler, ConflictIntentHandler>();
            services.AddTransient<ICancelMembershipHandler, CancelMembershipHandler>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Maya's Alexa API",
                    Description = "Alexa Api intercation",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Talking Dotnet", Email = "contact@talkingdotnet.com", Url = "www.talkingdotnet.com" }
                });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", p =>
                {
                    p.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Maya's Alexa API V1");
            });
            app.UseCors("AllowAll");
            app.UseMvc();
        }
    }
}
