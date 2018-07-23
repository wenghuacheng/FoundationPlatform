using Domain.Core;
using Domain.Core.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core
{
    /// <summary>
    /// 应用服务层基础接口
    /// </summary>
    public interface IApplicationService<TEntity, TPrimaryKey> : ITransientDependency where TEntity : class, IEntity<TPrimaryKey>, new()
    {
        bool Create<TDto>(TDto model);

        bool Delete(TPrimaryKey id);

        bool Update<TDto>(TDto model);

        List<TDto> Get<TDto>();

        TDto Get<TDto>(TPrimaryKey key);
    }
}
