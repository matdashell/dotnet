using lojaDoDot.infra.data.entity;
using Openapi;

namespace lojaDoDot.infra.mapper
{
    public class ProductMapper
    {
        internal static ProductEntity ToEntityByRequestAndUser(UserEntity userEntity, ProductCreateRequest request)
        {
            return new ProductEntity
            {
                Name = request.Name,
                Description = request.Description,
                Value = request.Value,
                User = userEntity
            };
        }

        internal static ProductPageResponse ToProductPageResponseByData(List<Data> dataListResponse, int sizeCount, int totalCount, int page)
        {
            return new ProductPageResponse
            {
                Data = dataListResponse,
                Size = sizeCount,
                Page = page,
                Total = totalCount,
            };
        }

        internal static ProductResponse ToProductResponseByProductEntity(ProductEntity productEntity)
        {
            return new ProductResponse
            {
                Id = productEntity.Id,
                Name = productEntity.Name,
                Description = productEntity.Description,
                Value = productEntity.Value,
                Seller = UserMapper.ToSellerResponseByUserEntity(productEntity.User)
            };
        }
    }
}