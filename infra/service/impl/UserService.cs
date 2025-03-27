using AccountApi;
using lojaDoDot.infra.data.repository;
using lojaDoDot.infra.mapper;
using Openapi;

namespace lojaDoDot.infra.service.impl
{
    public class UserService(
        IUserRepository _userRepository,
        ApiClient _accountApi
        ) : IUserService
    {
        public async Task<UserResponse> GetUserAsync(int userId)
        {
            var userEntity = await _userRepository.GetUserAsync(userId);
            var accountResponse = await _accountApi.GetUserAccountAsync(
                userEntity.AccountId,
                userId
            );

            return UserMapper.ToUserResponseByUserEntityAndAccountResponse(userEntity, accountResponse);
        }

        public async Task<UserResponse> PostUserAsync(UserCreateRequest userCreateRequest)
        {
            var accountCreateRequest = UserMapper.UserCreateToAccountCreate(userCreateRequest);
            var accountResponse = await _accountApi.PostAccountAsync(accountCreateRequest);
            var userEntity = await _userRepository.PostUserAsync(userCreateRequest, accountResponse);

            return UserMapper.ToUserResponseByUserEntityAndAccountResponse(userEntity, accountResponse);
        }
    }
}