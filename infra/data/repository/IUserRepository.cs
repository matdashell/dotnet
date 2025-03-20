using lojaDoDot.infra.data.entity;
using Openapi;

namespace lojaDoDot.infra.data.repository
{
    public interface IUserRepository
    {
        Task<UserEntity> GetUserAsync(int userId);

        Task<UserEntity> PostUserAsync(UserCreateRequest body, AccountApi.AccountResponse accountResponse);
    }
}