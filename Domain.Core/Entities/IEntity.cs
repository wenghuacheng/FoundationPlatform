using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core
{
    public interface IEntity<T> : IEntity
    {
        T Id { get; set; }
    }

    public interface IEntity
    {

    }
}
