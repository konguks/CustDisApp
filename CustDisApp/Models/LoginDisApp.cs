using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace CustDisApp.Models
{
    public class LoginDisApp
    {
        public struct request {
            public string custid { get; set; }

            public string pswd { get; set; }

        }
        
        public struct response
        {
            public string custid { get; set; }

            public string pswd { get; set; }

            public string respns { get; set; }
        }
        


    }

    public class request
    {
        public string custid { get; set; }

        public string pswd { get; set; }
    }

    public class response
    {
        public string custid { get; set; }

        public string pswd { get; set; }

        public string respns { get; set; }
    }
}
