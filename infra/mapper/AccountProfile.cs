using AccountApi;
using AutoMapper;
using lojaDoDot.infra.data.entity;
using Openapi;

namespace lojaDoDot.infra.mapper
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<UserCreateRequest, AccountCreateRequest>()
            .ForMember(to => to.Document, opt => opt.MapFrom(from => from.Document));

            CreateMap<(AccountApi.AccountResponse accountResponse, UserEntity userEntity), UserResponse>()
            .ForMember(to => to.Id, opt => opt.MapFrom(from => from.userEntity.Id))
            .ForMember(to => to.Name, opt => opt.MapFrom(from => from.userEntity.Name))
            .ForMember(to => to.Type, opt => opt.MapFrom(from => from.userEntity.Type))
            .ForMember(to => to.CreatedAt, opt => opt.MapFrom(from => from.userEntity.CreatedAt))
            .ForMember(to => to.UpdatedAt, opt => opt.MapFrom(from => from.userEntity.UpdatedAt))
            .ForMember(to => to.Account, opt => opt.MapFrom(from => from.accountResponse));
        }
    }
}