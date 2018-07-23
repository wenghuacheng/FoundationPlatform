using Application.Core;
using System;
using System.Collections.Generic;
using System.Text;
using WordRecoder.Domain.Entities;

namespace WordRecoder.Application.IApplicationServices
{
    public interface ITestService: IApplicationService
    {
        void Modify(Root root);
    }
}
