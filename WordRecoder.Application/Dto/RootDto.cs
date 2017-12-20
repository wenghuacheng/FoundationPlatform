using System;
using System.Collections.Generic;
using System.Text;
using WordRecoder.Domain.ValueObjects;

namespace WordRecoder.Application.Dto
{
    public class RootDto
    {

        public int Id { get; set; }

        /// <summary>
        /// 基础词根
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 派生词
        /// </summary>
        public List<string> Derivative { get; set; }

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
