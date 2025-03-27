using lojaDoDot.infra.data.entity;
using lojaDoDot.infra.mapper;
using Microsoft.EntityFrameworkCore;
using Openapi;

namespace lojaDoDot.infra.data.repository.impl
{
    public class ProductRepository(AppDbContext _context) : IProductRepository
    {
        public async Task<ProductPageResponse> GetPageProductAsync(int page, int size)
        {
            var dataListResponse = await _context.ProductEntities
            .Skip((page - 1) * size)
            .Take(size)
            .Select(p => new Data()
            {
                Id = p.Id,
                Name = p.Name,
                Value = p.Value
            })
            .ToListAsync();

            var sizeCount = dataListResponse.Count;

            var totalCount = await _context.ProductEntities
            .CountAsync();

            var ProductPageResponse = ProductMapper
                .ToProductPageResponseByData(dataListResponse, sizeCount, totalCount, page);

            return ProductPageResponse;
        }

        public async Task<ProductEntity> GetProductAsync(int productId)
        {
            return await _context.ProductEntities
            .Include(p => p.User)
            .Where(p => p.Id == productId)
            .Select(p => p)
            .SingleAsync();
        }

        public async Task<ProductEntity> PostProductAsync(UserEntity userEntity, ProductCreateRequest request)
        {
            var productEntity = ProductMapper.ToEntityByRequestAndUser(userEntity, request);
            _context.ProductEntities.Add(productEntity);
            await _context.SaveChangesAsync();

            return productEntity;
        }
    }
}