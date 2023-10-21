using AutoMapper;
using $safeprojectname$.Entities;
using $safeprojectname$.Models;

namespace $safeprojectname$
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, CreateUserModel>().ReverseMap();
            CreateMap<User, EditUserModel>().ReverseMap();

            CreateMap<Dersler, DersModel>().ReverseMap();
            CreateMap<Dersler, CreateDersModel>().ReverseMap();
            CreateMap<Dersler, EditDersModel>().ReverseMap();

            CreateMap<Notlar, NotModel>().ReverseMap();
            CreateMap<Notlar, CreateNotModel>().ReverseMap();
            CreateMap<Notlar, EditNotModel>().ReverseMap();
        }
    }
}
