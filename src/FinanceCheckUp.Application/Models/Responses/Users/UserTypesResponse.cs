using FinanceCheckUp.Domain.Entities;

namespace FinanceCheckUp.Application.Models.Responses.Users;

public class UserTypesResponse
{
    public List<UserType> UserTypes { get; set; }
}