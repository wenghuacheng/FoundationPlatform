using Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Dapper.Test
{
    public class Test : IEntity<int>
    {
        public string name { get; set; }
        public int Id { get; set; }
    }
}
