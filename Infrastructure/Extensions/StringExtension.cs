using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Infrastructure.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        #region 正则表达式
        /// <summary>
        /// 确定所指定的正则表达式在指定的输入字符串中是否找到了匹配项
        /// </summary>
        /// <param name="value">要搜索匹配项的字符串</param>
        /// <param name="pattern">要匹配的正则表达式模式</param>
        /// <returns>如果正则表达式找到匹配项，则为 true；否则，为 false</returns>
        public static bool IsMatch(this string value, string pattern)
        {
            if (value == null)
            {
                return false;
            }
            return Regex.IsMatch(value, pattern);
        }
        /// <summary>
        /// 确定所指定的正则表达式在指定的输入字符串中找到匹配项
        /// </summary>
        /// <param name="value">要搜索匹配项的字符串</param>
        /// <param name="pattern">要匹配的正则表达式模式</param>
        /// <param name="options">规则</param>
        /// <returns>如果正则表达式找到匹配项，则为 true；否则，为 false</returns>
        public static bool IsMatch(this string value, string pattern, RegexOptions options)
        {
            if (value == null)
            {
                return false;
            }
            return Regex.IsMatch(value, pattern, options);
        }
        #endregion

        #region 中文验证
        /// <summary>
        /// 是否中文
        /// </summary>
        /// <param name="value">中文</param>
        /// <returns></returns>
        public static bool IsChinese(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            return value.IsMatch(@"^[\u4e00-\u9fa5]+$", RegexOptions.IgnoreCase);
        }
        /// <summary>
        /// 是否包含中文
        /// </summary>
        /// <param name="value">中文</param>
        /// <returns></returns>
        public static bool IsContainsChinese(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            return value.IsMatch(@"[\u4e00-\u9fa5]+", RegexOptions.IgnoreCase);
        }
        #endregion

        #region 数字验证
        /// <summary>
        /// 是否包含数字
        /// </summary>
        /// <param name="value">数字</param>
        /// <returns></returns>
        public static bool IsContainsNumber(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            return value.IsMatch(@"[0-9]+");
        }
        #endregion

        #region 是否正常字符，字母、数字、下划线的组合
        /// <summary>
        /// 是否正常字符，字母、数字、下划线的组合
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static bool IsNormalChar(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            return value.IsMatch(@"[\w\d_]+", RegexOptions.IgnoreCase);
        }
        #endregion

        #region 是否指定后缀
        /// <summary>
        /// 是否指定后缀
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="postfixs">后缀名数组</param>
        /// <returns></returns>
        public static bool IsPostfix(string value, string[] postfixs)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            string postfix = string.Join("|", postfixs);
            return value.IsMatch(string.Format(@".(?i:{0})$", postfix));
        }
        #endregion
    }
}
