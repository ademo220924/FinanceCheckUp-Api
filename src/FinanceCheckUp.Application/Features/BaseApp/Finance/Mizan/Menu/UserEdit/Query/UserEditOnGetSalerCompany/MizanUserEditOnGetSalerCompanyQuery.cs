using FinanceCheckUp.Domain.Common;
using DevExtreme.AspNet.Mvc;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.UserEdit;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.Menu.UserEdit;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.Menu.UserEdit.Query.UserEditOnGetSalerCompany;

public class MizanUserEditOnGetSalerCompanyQuery : IUserIdAssignable , IRequest<GenericResult<MizanUserEditOnGetSalerCompanyResponse>>
{
 
    [JsonIgnore] public  string UserId { get; set; }
    public MizanUserEditOnGetSalerCompanyRequest Request { get; set; }
    public MizanUserEditRequestInitialModel InitialModel { get; set; }
}
