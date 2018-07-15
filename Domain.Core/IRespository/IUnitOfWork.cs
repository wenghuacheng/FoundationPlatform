using Domain.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Domain.Core
{
    public interface IUnitOfWork
    {
        void RegisterNew(IEntity entity, IUnitOfWorkRepository repository);

        void RegisterDelete(IEntity entity, IUnitOfWorkRepository repository);

        void RegisterUpdate(IEntity entity, IUnitOfWorkRepository repository);

        void SaveChange();
    }
}
