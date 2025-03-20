using AutoMapper;
using lojaDoDot.infra.data.entity;
using Openapi;

namespace lojaDoDot.infra.mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<(UserCreateRequest request, AccountApi.AccountResponse account), UserEntity>()
            .ForMember(to => to.Name, opt => opt.MapFrom(from => from.request.Name))
            .ForMember(to => to.Type, opt => opt.MapFrom(from => from.request.Type))
            .ForMember(to => to.Document, opt => opt.MapFrom(from => from.request.Document))
            .ForMember(to => to.AccountId, opt => opt.MapFrom(from => from.account.Id));

            CreateMap<(UserEntity UserEntity, AccountResponse account), UserResponse>()
            .ForMember(to => to, opt => opt.MapFrom(from => from.UserEntity))
            .ForMember(to => to.Account, opt => opt.MapFrom(from => from.account));
        }
    }
}