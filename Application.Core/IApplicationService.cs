using Domain.Core.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core
{
    /// <summary>
    /// 应用服务层基础接口
    /// </summary>
    public interface IApplicationService : ITransientDependency
    {
    }
}
