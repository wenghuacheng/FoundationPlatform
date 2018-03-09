using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Dapper
{
    public interface IEntity<T> : IEntity
    {
        T Id { get; set; }
    }

    public interface IEntity
    {

    }
}
