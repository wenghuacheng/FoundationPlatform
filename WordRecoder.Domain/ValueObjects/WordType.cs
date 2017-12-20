using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WordRecoder.Domain.ValueObjects
{
    /// <summary>
    /// 词性
    /// </summary>
    [Flags]
    public enum WordType
    {
        [Description("名词")]
        noun = 0,
        [Description("动词")]
        Verb = 2,
        [Description("形容词")]
        Adjective = 4,
        [Description("副词")]
        Adverb = 8
    }
}
