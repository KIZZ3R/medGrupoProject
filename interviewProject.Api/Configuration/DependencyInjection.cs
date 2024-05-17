using InterviewProject.Service.Service.Interface;
using InterviewProject.Service.Service;
using Microsoft.EntityFrameworkCore;
using InterviewProject.Data.Data;
using InterviewProject.Data.Repository;
using InterviewProject.Data.Repository.Interface;

namespace InterviewProject.Api.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InterviewProjectDb>(options =>
                                                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection repositories)
        {
            repositories.AddScoped<IContactsRepository, ContactsRepository>();
            return repositories;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IContactService, ContactService>();
            return services;
        }
    }
}
