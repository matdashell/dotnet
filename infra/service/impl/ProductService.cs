using AutoMapper;
using lojaDoDot.infra.data.repository;
using Microsoft.VisualBasic;
using Openapi;

namespace lojaDoDot.infra.service.impl
{
    public class ProductService(
        IProductRepository _productRepository, 
        IUserRepository _userRepository,
        IMapper _mapper
        ) : IProductService
    {
        public async Task<ProductPageResponse> GetPageProductAsync(int page, int size)
        {
            return await _productRepository.GetPageProductAsync(page, size);
        }

        public async Task<ProductResponse> GetProductAsync(int productId)
        {
            var userEntity = await _productRepository.GetProductAsync(productId);
            return _mapper.Map<ProductResponse>(userEntity);
        }

        public async Task<ProductResponse> PostProductAsync(int userId, ProductCreateRequest body)
        {
            var userEntity = await _userRepository.GetUserAsync(userId);
            var productEntity = await _productRepository.PostProductAsync(userEntity, body);
            return _mapper.Map<ProductResponse>(productEntity);
        }
    }
}