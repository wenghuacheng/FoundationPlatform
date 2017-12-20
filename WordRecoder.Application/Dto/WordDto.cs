using System;
using System.Collections.Generic;
using System.Text;

namespace WordRecoder.Application.Dto
{
    public class WordDto
    {
        public WordDto()
        {
            RootRelations = new List<int>();
        }

        public int Id { get; set; }

        /// <summary>
        /// 单词
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 含义
        /// </summary>
        public string Mean { get; set; }

        /// <summary>
        /// 助记词
        /// </summary>
        public string MnemonicWord { get; set; }

        /// <summary>
        /// 帮助说明
        /// </summary>
        public string HelpMsg { get; set; }

        /// <summary>
        /// 关联词根
        /// </summary>
        public List<int> RootRelations { get; set; }

        
    }
}
