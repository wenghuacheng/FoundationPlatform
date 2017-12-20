using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WordRecoder.Infrastructure.Migration
{
    public interface IDbCreator
    {
        long Version { get; }

        void Execute(IDbConnection db);
    }
}
