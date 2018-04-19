using System.Collections.Generic;
using WordRecoder.Domain.ValueObjects;
using Domain.Core;
using Domain.Core.Entities.DbAttributes;

namespace WordRecoder.Domain.Entities
{
    public class Root : IEntity<int>
    {

        [Id]
        public int Id { get; set; }

        /// <summary>
        /// 基础词根
        /// </summary>
        public string Name { get; set; }


        public string Derivative { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public RootType Type { get; set; }

        /// <summary>
        /// 含义
        /// </summary>
        public string Mean { get; set; }

        /// <summary>
        /// 中文含义
        /// </summary>
        public string ChineseMean { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
