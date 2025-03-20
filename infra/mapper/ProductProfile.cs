using AutoMapper;
using lojaDoDot.infra.data.entity;
using Openapi;

namespace lojaDoDot.infra.mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, ProductResponse>()
            .ForMember(to => to.Seller, opt => opt.MapFrom(from => from.User));

            CreateMap<(UserEntity userEntity, ProductCreateRequest request), ProductEntity>()
            .ForMember(to => to.Name, opt => opt.MapFrom(from => from.request.Name))
            .ForMember(to => to.Description, opt => opt.MapFrom(from => from.request.Description))
            .ForMember(to => to.User, opt => opt.MapFrom(from => from.userEntity));

            CreateMap<(List<Data> dataListResponse, int size, int totalCount, int page), ProductPageResponse>()
            .ForMember(to => to.Page, opt => opt.MapFrom(from => from.page))
            .ForMember(to => to.Size, opt => opt.MapFrom(from => from.size))
            .ForMember(to => to.Total, opt => opt.MapFrom(from => from.totalCount))
            .ForMember(to => to.Data, opt => opt.MapFrom(from => from.dataListResponse));
        }
    }
}