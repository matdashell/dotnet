using lojaDoDot.infra.service;
using Openapi;

namespace lojaDoDot.infra.controller
{
    public class Presentation(IUserService _userService, IProductService _productService) : IController
    {

        public async Task<ProductPageResponse> GetPageProductAsync(int page, int size)
        {
            return await _productService.GetPageProductAsync(page, size);
        }

        public async Task<ProductResponse> GetProductAsync(int productId)
        {
            return await _productService.GetProductAsync(productId);
        }

        public async Task<UserResponse> GetUserAsync(int userId)
        {
            return await _userService.GetUserAsync(userId);
        }

        public async Task<ProductResponse> PostProductAsync(int userId, ProductCreateRequest body)
        {
            return await _productService.PostProductAsync(userId, body);
        }

        public async Task<UserResponse> PostUserAsync(UserCreateRequest body)
        {
            return await _userService.PostUserAsync(body);
        }
    }
}