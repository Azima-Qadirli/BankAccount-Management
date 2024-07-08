using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_management
{
    public class AccountActivity
    {
        public Guid ID { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
