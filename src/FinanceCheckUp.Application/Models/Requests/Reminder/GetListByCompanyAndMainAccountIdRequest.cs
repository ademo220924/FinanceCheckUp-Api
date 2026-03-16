using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCheckUp.Application.Models.Requests.Reminder;

public class GetListByCompanyAndMainAccountIdRequest
{
    public long CompanyId { get; set; }
    public long AccountId { get; set; }
}
