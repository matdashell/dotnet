using AccountApi;
using AutoMapper;
using lojaDoDot.infra.data.repository;
using Openapi;

namespace lojaDoDot.infra.service.impl
{
    public class UserService(
        IUserRepository _userRepository,
        ApiClient _accountApi,
        IMapper _mapper
        ) : IUserService
    {
        public async Task<UserResponse> GetUserAsync(int userId)
        {
            var userEntity = await _userRepository.GetUserAsync(userId);
            var accountResponse = await _accountApi.GetUserAccountAsync(
                userEntity.AccountId,
                userId
            );

            return _mapper.Map<UserResponse>((accountResponse, userEntity));
        }

        public async Task<UserResponse> PostUserAsync(UserCreateRequest userCreateRequest)
        {
            var accountCreateRequest = _mapper.Map<AccountCreateRequest>(userCreateRequest);
            var accountResponse = await _accountApi.PostAccountAsync(accountCreateRequest); 
            var userEntity = await _userRepository.PostUserAsync(userCreateRequest, accountResponse);
            
            return _mapper.Map<UserResponse>((userEntity, accountResponse));
        }
    }
}