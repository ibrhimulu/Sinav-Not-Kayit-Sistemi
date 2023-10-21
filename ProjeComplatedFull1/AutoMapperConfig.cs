using AutoMapper;
using ProjeComplatedFull1.Entities;
using ProjeComplatedFull1.Models;

namespace ProjeComplatedFull1
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
