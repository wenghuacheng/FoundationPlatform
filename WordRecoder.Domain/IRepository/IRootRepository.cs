using System;
using System.Collections.Generic;
using System.Text;
using WordRecoder.Domain.Entities;

namespace WordRecoder.Domain.IRepository
{
    public interface IRootRepository
    {
        int AddRoot(Root root);

        void UpdateRoot(Root root);

        List<Root> QueryRoot(int id, string name);
    }
}
