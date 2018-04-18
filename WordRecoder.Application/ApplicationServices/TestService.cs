using System;
using System.Collections.Generic;
using System.Text;
using WordRecoder.Application.IApplicationServices;

namespace WordRecoder.Application.ApplicationServices
{
    public class TestService : ITestService
    {
        public string GetString()
        {
            return "abc";
        }
    }
}
