using InterviewProject.Data.Data;
using InterviewProject.Service.Service.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using InterviewProject.Data.Repository.Interface;
using InterviewProject.Data.Repository;
using InterviewProject.Service.Service;

namespace InterviewProject.Tests
{
    public class BaseTest
    {
        protected InterviewProjectDb _context = default!;
        protected IMapper _mapper = default!;
        protected IServiceProvider _serviceProvider = default!;
        private string DataBaseName = "DataBaseTest" + Guid.NewGuid();


        public BaseTest()
        {
            InitContainer();
            InitContext();
        }

        private void InitContext()
        {
            _context = _serviceProvider.GetRequiredService<InterviewProjectDb>();
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }

        private void InitContainer()
        {
            ServiceCollection serviceColection = new ServiceCollection();
            serviceColection.AddDbContext<InterviewProjectDb>(options => options.UseInMemoryDatabase(databaseName: DataBaseName));
            serviceColection.AddScoped<IContactsRepository, ContactsRepository>();
            serviceColection.AddScoped<IContactService, ContactService>();
            serviceColection.AddAutoMapper(typeof(InterviewProject.Api.Configuration.AutoMapperConfig));
            _serviceProvider = serviceColection.BuildServiceProvider();
        }
    }
}
