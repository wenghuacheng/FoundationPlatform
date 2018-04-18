using Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Test
{
    public class Test : IEntity<int>
    {
        public string name { get; set; }
        public int Id { get; set; }
    }
}
