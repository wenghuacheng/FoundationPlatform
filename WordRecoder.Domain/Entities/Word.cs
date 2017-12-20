using System;
using System.Collections.Generic;
using System.Text;
using WordRecoder.Domain.Entities.DbAttributes;

namespace WordRecoder.Domain.Entities
{
    /// <summary>
    /// 单词
    /// </summary>
    public class Word : IEntity<int>
    {
        public Word()
        {
            Roots = new List<Root>();
            Synonym = new List<Word>();
            Antonym = new List<Word>();
        }

        [Id]
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

        [Ignore]
        /// <summary>
        /// 词根
        /// </summary>
        public List<Root> Roots { get; set; }

        /// <summary>
        /// 同义词
        /// </summary>
        [Ignore]
        public List<Word> Synonym { get; set; }

        /// <summary>
        /// 反义词
        /// </summary>
        [Ignore]
        public List<Word> Antonym { get; set; }

    }
}
