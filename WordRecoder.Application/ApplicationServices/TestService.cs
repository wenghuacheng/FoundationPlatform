using Domain.Core.IRespository;
using System;
using System.Collections.Generic;
using System.Text;
using WordRecoder.Application.IApplicationServices;
using WordRecoder.Domain.Entities;

namespace WordRecoder.Application.ApplicationServices
{
    public class TestService : ITestService
    {
        private readonly IRepository<Root> rootRepositor;
        public TestService(IRepository<Root> rootRepositor)
        {
            this.rootRepositor = rootRepositor;
        }


        public void Modify(Root root)
        {
            int length = 2000;
            int cutLength = 20;
            int l = 2000 - 20 * 2;

            root.Remark = l.ToString();
            this.rootRepositor.Insert(root);

            
        }

        public int Add(int i,int j)
        {
            return i + j;
        }
    }
}
