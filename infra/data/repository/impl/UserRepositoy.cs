using AutoMapper;
using lojaDoDot.infra.data;
using lojaDoDot.infra.data.entity;
using Microsoft.EntityFrameworkCore;
using Openapi;

namespace lojaDoDot.infra.data.repository.impl
{
    public class UserRepositoy(
        AppDbContext _context,
        IMapper _mapper
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
            var userEntity = _mapper.Map<UserEntity>((request, account));
            _context.UserEntities.Add(userEntity);
            await _context.SaveChangesAsync();
        
            return userEntity;
        }
    }
}