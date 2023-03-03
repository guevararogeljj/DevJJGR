using System;
using DevJJGR.Middlewares;

namespace DevJJGR.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorEventHandlerMiddleware>();
        }
    }
}

