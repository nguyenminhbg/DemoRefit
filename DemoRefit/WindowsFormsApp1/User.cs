using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp1
{
    public class User
    {

        [AliasAs("UserName")]
        public string UserName { set; get; }
        [AliasAs("FullName")]
        public string FullName { set; get; }
    }
}
