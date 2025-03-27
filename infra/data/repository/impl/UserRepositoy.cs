using lojaDoDot.infra.data.entity;
using lojaDoDot.infra.mapper;
using Microsoft.EntityFrameworkCore;
using Openapi;

namespace lojaDoDot.infra.data.repository.impl
{
    public class UserRepository(
        AppDbContext _context
        ) : IUserRepository
    {
        public async Task<UserEntity> GetUserAsync(int userId)
        {
            return await _context.UserEntities
            .Where(u => u.Id == userId)
            .Select(u => u)
            .FirstAsync();
        }

        public async Task<UserEntity> PostUserAsync(UserCreateRequest request, AccountApi.AccountResponse account)
        {
            var userEntity = UserMapper.ToUserEntityByUserCreateAndAccountResponse(request, account);
            _context.UserEntities.Add(userEntity);
            await _context.SaveChangesAsync();
        
            return userEntity;
        }
    }
}