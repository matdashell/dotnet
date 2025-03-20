using lojaDoDot.infra.data.entity;
using Openapi;

namespace lojaDoDot.infra.data.repository
{
    public interface IProductRepository
    {
        Task<ProductPageResponse> GetPageProductAsync(int page, int size);
        Task<ProductEntity> GetProductAsync(int productId);
        Task<ProductEntity> PostProductAsync(UserEntity userEntity, ProductCreateRequest body);
    }
}