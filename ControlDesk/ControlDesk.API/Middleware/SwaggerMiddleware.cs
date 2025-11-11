namespace ControlDesk.API.Middleware;

public static class SwaggerMiddleware
{
    public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Company API V1");
        });

        return app;
    }
}
