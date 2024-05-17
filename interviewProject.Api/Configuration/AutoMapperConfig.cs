using InterviewProject.Domain.Entities;
using InterviewProject.Service.DTO;
using InterviewProject.Service.ViewModel;
using AutoMapper;

namespace InterviewProject.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Contact, ViewModelContact>().ReverseMap();
            CreateMap<ContactDTO, ViewModelContact>().ReverseMap();
        }
    }
    
}
