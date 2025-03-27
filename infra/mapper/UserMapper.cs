using AccountApi;
using lojaDoDot.infra.data.entity;
using Openapi;

namespace lojaDoDot.infra.mapper
{
    public class UserMapper
    {
        internal static UserProductResponse ToSellerResponseByUserEntity(UserEntity user)
        {
            return new UserProductResponse
            {
                Id = user.Id,
                Name = user.Name
            };
        }

        internal static UserEntity ToUserEntityByUserCreateAndAccountResponse(UserCreateRequest request, AccountApi.AccountResponse account)
        {
            return new UserEntity
            {
                Name = request.Name,
                Document = request.Document,
                AccountId = account.Id,
                Type = (model.enumerated.UserType) request.Type
            };
        }

        internal static UserResponse ToUserResponseByUserEntityAndAccountResponse(
            UserEntity userEntity,
            AccountApi.AccountResponse accountResponse)
        {
            return new UserResponse
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Document = userEntity.Document,
                Account = AccountMapper.AccountApiToAccountResponse(accountResponse),
                Type = (UserResponseType) userEntity.Type,
                CreatedAt = userEntity.CreatedAt,
                UpdatedAt = userEntity.UpdatedAt
            };
        }

        internal static AccountCreateRequest UserCreateToAccountCreate(UserCreateRequest userCreateRequest)
        {
            return new AccountCreateRequest
            {
                Document = userCreateRequest.Document,
                InitialBalance = 500
            };
        }
    }
}