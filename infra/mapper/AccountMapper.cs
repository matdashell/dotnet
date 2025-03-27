
namespace lojaDoDot.infra.mapper
{
    public class AccountMapper
    {
        internal static Openapi.AccountResponse AccountApiToAccountResponse(AccountApi.AccountResponse accountResponse)
        {
            return new Openapi.AccountResponse
            {
                Id = accountResponse.Id,
                Balance = accountResponse.Balance
            };
        }
    }
}