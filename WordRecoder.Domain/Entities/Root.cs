﻿using System;
using System.Collections.Generic;
using System.Text;
using WordRecoder.Domain.ValueObjects;
using WordRecoder.Domain.Entities.DbAttributes;

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

        [Ignore]
        /// <summary>
        /// 派生词
        /// </summary>
        public List<string> DerivativeList
        {
            get
            {
                List<string> result = new List<string>();
                if (!string.IsNullOrWhiteSpace(Derivative))
                {
                    result.AddRange(Derivative.Split(','));
                }
                return result;
            }
        }

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
