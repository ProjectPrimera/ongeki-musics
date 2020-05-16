using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInje
using Microsoft.Extensions.Hosting;

namespace OngekiMusics {
    public class Startup {
        public Startup(I
            Configuration
        }

        p

        // This method gets called by the runtime. U

            services.AddControllersWithViews()
#if DEBUG
            .AddRazorRuntimeCompilation()
#endif
            ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        p

                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandl
            }
            app.UseS

            a




                endpoints.MapContro

                    pattern: "{controller=H
            });
        }
    }
}



