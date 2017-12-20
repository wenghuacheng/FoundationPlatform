using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WordRecoder.Domain.ValueObjects
{
    /// <summary>
    /// 词根类型
    /// </summary>
    public enum RootType
    {
        [Description("词素")]
        Morpheme,

        [Description("前缀")]
        Prefix,

        [Description("后缀")]
        Suffix
    }
}
