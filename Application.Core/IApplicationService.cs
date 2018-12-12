using Domain.Core;
using Domain.Core.Dependency;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Application.Core
{
    /// <summary>
    /// 应用服务层基础接口
    /// </summary>
    public interface IApplicationService<TEntity, TPrimaryKey> : ITransientDependency where TEntity : class, IEntity<TPrimaryKey>, new()
    {
        TDto Create<TDto>(TDto model);

        bool Delete(TPrimaryKey id);

        TDto Update<TDto>(TDto model);

        List<TDto> Get<TDto>();

        TDto Get<TDto>(TPrimaryKey key);

        List<TDto> Query<TDto>(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize);
    }
}
