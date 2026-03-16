using FinanceCheckUp.Domain.Common.Enums;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Domain.Entities.BgServer;
using FinanceCheckUp.Framework.Data;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.DataOperations.AccountGroupMatch;

public class AccountGroupMatchCommandHandle(
    IGenericRepository<TblmrevenueRasT, long> revenueRasTRepository,
    IGenericRepository<TblmsampleBlncoRasT, long> sampleBlncoRasTRepository,
    IGenericRepository<ReminderAccount, long> reminderAccountRepository,
    IGenericRepository<ReminderAccountGroup, long> reminderAccountGroupRepository)
    : IRequestHandler<AccountGroupMatchCommand, int>
{
    public async Task<int> Handle(AccountGroupMatchCommand request, CancellationToken cancellationToken)
    {
        var accountGroups = await reminderAccountGroupRepository.GetListAsync(cancellationToken: cancellationToken);
        var accounts = await reminderAccountRepository.GetListAsync(cancellationToken: cancellationToken);
        var revenue = await revenueRasTRepository.GetListAsync(c => c.Year == 2022, cancellationToken);
        var blnaco = await sampleBlncoRasTRepository.GetListAsync(c => c.Year == 2022, cancellationToken);

        foreach (var account in accounts)
        {
            try
            {
                switch (account.AccountType)
                {
                    case (int)AccountType.RevenueMainAccount:
                        {
                            var item = revenue.FirstOrDefault(c => c.AccountMainId.Trim() == account.StartValue.ToString().Trim());
                            if (item != null)
                            {
                                if (accountGroups != null)
                                    account.AccountGroupId = GetAccountGroupId(item.GroupName, accountGroups);
                            }
                            else
                            {

                            }

                            break;
                        }
                    case (int)AccountType.RevenueType:
                        {
                            var item = revenue.FirstOrDefault(c => c.TypeId == account.StartValue);
                            if (item != null)
                            {
                                account.AccountGroupId = GetAccountGroupId(item.GroupName, accountGroups);
                            }
                            else
                            {

                            }

                            break;
                        }
                    case (int)AccountType.BalanceMainAccount:
                        {
                            var item = blnaco.FirstOrDefault(c => c.AccountMainId.Trim() == account.StartValue.ToString().Trim());
                            if (item != null)
                            {
                                account.AccountGroupId = GetAccountGroupId(item.GroupName, accountGroups);
                            }
                            else
                            {

                            }

                            break;
                        }
                    case (int)AccountType.BalanceType:
                        {
                            var item = blnaco.FirstOrDefault(c => c.TypeId == account.StartValue);
                            if (item != null)
                            {
                                account.AccountGroupId = GetAccountGroupId(item.GroupName, accountGroups);
                            }
                            else
                            {

                            }

                            break;
                        }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }

        await reminderAccountRepository.UpdateRangeAsync(accounts, cancellationToken);

        return accountGroups?.Count ?? 0;
    }

    private static long GetAccountGroupId(string groupName, IEnumerable<ReminderAccountGroup>? accountGroups)
    {
        if (accountGroups == null)
            return 0;

        var accountGroup = accountGroups.FirstOrDefault(c => c.Name.Trim() == groupName.Trim());
        return accountGroup?.Id ?? 0;
    }
}