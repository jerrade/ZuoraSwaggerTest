using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuoraSwaggerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ZuoraService zuoraService = new ZuoraService("username", "password", "https://rest.apisandbox.zuora.com/v1");

            /* This works.  The "account" variable ends up storing the account record requested. */
            var account = zuoraService.GetAccount("4028e69733156f3c01331cd8249458f1");  // <----Use valid account id here
            Console.WriteLine(account);

            /* This doesn't work.  The "query" variable is null, even though the API returns data.  Put a breakpoint on line 1388 in ActionsApi.cs and inspect the localVarResponse variable. */
            var query = zuoraService.Query("select Id, CreatedDate from Account where Id = '4028e69733156f3c01331cd8249458f1'");
            Console.WriteLine(query);
        }
    }
}
