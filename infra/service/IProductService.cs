using lojaDoDot.infra.data.entity;
using Openapi;

namespace lojaDoDot.infra.service
{
    public interface IProductService
    {
        Task<ProductPageResponse> GetPageProductAsync(int page, int size);
        Task<ProductResponse> GetProductAsync(int productId);
        Task<ProductResponse> PostProductAsync(int userId, ProductCreateRequest body);
    }
}