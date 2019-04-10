using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace TheCoreArchitecture.Api.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class UseServiceExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseRegisteredService(this IApplicationBuilder app)
        {
            app.UseCors(
                options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()
            );

            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.DocumentTitle = "My Api Documentation";
                c.DocExpansion(DocExpansion.None);
            });

            return app;
        }


    }
}
