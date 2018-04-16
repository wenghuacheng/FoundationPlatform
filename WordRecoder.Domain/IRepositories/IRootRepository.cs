using Domain.Core.IRespository;
using System;
using System.Collections.Generic;
using System.Text;
using WordRecoder.Domain.Entities;

namespace WordRecoder.Domain.IRepositories
{
    public interface IRootRepository : IRepository<Root, int>
    {
        //int AddRoot(Root root);

        //void UpdateRoot(Root root);

        //List<Root> QueryRoot(int id, string name);
    }
}
