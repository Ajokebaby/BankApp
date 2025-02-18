using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Domain
{
    public  class CustomerInformation
    {
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
       
        public decimal Balance { get; set; }
    }
}
