using Domain.Core;
using Domain.Core.Entities.DbAttributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace WordRecoder.Domain.Entities
{
    public class WordRootRelation : IEntity<int>
    {
        [Id]
        public int Id { get; set; }

        public int RootId { get; set; }

        public int WordId { get; set; }
    }
}
