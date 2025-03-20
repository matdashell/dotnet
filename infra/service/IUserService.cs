using Openapi;

namespace lojaDoDot.infra.service
{
    public interface IUserService
    {
        Task<UserResponse> GetUserAsync(int userId);

        Task<UserResponse> PostUserAsync(UserCreateRequest body);
    }
}