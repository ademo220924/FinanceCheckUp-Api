using FinanceCheckUp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Menu.UserEdit
{
    public class MizanUserEditRequestInitialModel
    {
        public long UserID;
        public HhvnUsers CurrentUser;
        public IEnumerable<Company> mreqListCompany;
        public List<UserType> mreqListUserType;
        public IEnumerable<City> mreqListCitiy;
        public IEnumerable<YearResult> myearResult;

        public HhvnUsers mrequest;

        public string mreqListCitiystr { get; set; }
    }
}
