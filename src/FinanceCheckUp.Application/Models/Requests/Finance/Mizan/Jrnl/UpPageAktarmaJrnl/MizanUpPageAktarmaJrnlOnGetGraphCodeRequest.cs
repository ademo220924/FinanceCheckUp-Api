using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCheckUp.Application.Models.Requests.Finance.Mizan.Jrnl.UpPageAktarmaJrnl
{
    public class MizanUpPageAktarmaJrnlOnGetGraphCodeRequest
    {
        public int nyear {  get; set; }
        public string ncode { get; set; }
        public float nvalue { get; set; }
        public string ncodedc { get; set; }
    }
}
