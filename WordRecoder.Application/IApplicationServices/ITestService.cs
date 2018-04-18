using Application.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace WordRecoder.Application.IApplicationServices
{
    public interface ITestService : IApplicationService
    {
        string GetString();
    }
}
