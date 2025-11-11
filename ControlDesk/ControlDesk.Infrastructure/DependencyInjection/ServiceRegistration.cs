using ControlDesk.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ControlDesk.Infrastructure.Data;
using ControlDesk.Infrastructure.Repositories;
using ControlDesk.Application.Services;


namespace ControlDesk.Infrastructure.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ControlDeskContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ISecurityRepository, SecurityRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<TicketService>();
            services.AddScoped<SecurityService>();

            return services;
        }
    }
}
