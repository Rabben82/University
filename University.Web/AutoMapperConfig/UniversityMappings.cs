using AutoMapper;

namespace University.Web.AutoMapperConfig
{
    public class UniversityMappings : Profile
    {
        public UniversityMappings()
        {
            CreateMap<Student, StudentCreateViewModel>()
                //.ForMember(
                //dest => dest.Street,
                //from => from.MapFrom(s => s.Avatar))
                .ReverseMap();

            CreateMap<Student, StudentIndexViewModel>();

        }
    }
}
