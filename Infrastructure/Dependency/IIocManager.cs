using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Dependency
{
    public interface IIocManager : IIocRegistrar, IIocResolver, IDisposable
    {
    }
}
