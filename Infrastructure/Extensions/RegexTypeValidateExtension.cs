using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Infrastructure.Extensions
{
    /// <summary>
    /// 类型验证
    /// </summary>
    public static class RegexTypeValidateExtension
    {
        #region IsDate(是否日期)
        /// <summary>
        /// 是否日期
        /// </summary>
        /// <param name="value">日期字符串</param>
        /// <param name="isRegex">是否正则验证</param>
        /// <returns></returns>
        public static bool IsDate(string value, bool isRegex = false)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            if (isRegex)
            {
                //考虑到4年一度的366天，还有特殊的2月的日期
                return
                    value.IsMatch(
                        @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-)) (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d$");
            }
            DateTime minValue;
            return DateTime.TryParse(value, out minValue);
        }

        /// <summary>
        /// 是否日期
        /// </summary>
        /// <param name="value">日期字符串</param>
        /// <param name="format">格式化字符串</param>
        /// <returns></returns>
        public static bool IsDate(string value, string format)
        {
            return IsDate(value, format, null, DateTimeStyles.None);
        }

        /// <summary>
        /// 是否日期
        /// </summary>
        /// <param name="value">日期字符串</param>
        /// <param name="format">格式化字符串</param>
        /// <param name="provider">格式化提供者</param>
        /// <param name="styles">日期格式</param>
        /// <returns></returns>
        public static bool IsDate(string value, string format, IFormatProvider provider, DateTimeStyles styles)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            DateTime minValue;
            return DateTime.TryParseExact(value, format, provider, styles, out minValue);
        }
        #endregion

        #region IsUrl(是否Url地址)
        /// <summary>
        /// 是否Url地址（统一资源定位）
        /// </summary>
        /// <param name="value">url地址</param>
        /// <returns></returns>
        public static bool IsUrl(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            return
                value.IsMatch(
                    @"^(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*$",
                    RegexOptions.IgnoreCase);
        }
        #endregion

        #region IsUri(是否Uri)
        /// <summary>
        /// 是否Uri（统一资源标识）
        /// </summary>
        /// <param name="value">uri</param>
        /// <returns></returns>
        public static bool IsUri(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            if (value.IndexOf(".", StringComparison.OrdinalIgnoreCase) == -1)
            {
                return false;
            }
            var schemes = new[]
            {
        "file",
        "ftp",
        "gopher",
        "http",
        "https",
        "ldap",
        "mailto",
        "net.pipe",
        "net.tcp",
        "news",
        "nntp",
        "telnet",
        "uuid"
    };

            bool hasValidSchema = false;
            foreach (string scheme in schemes)
            {
                if (hasValidSchema)
                {
                    continue;
                }
                if (value.StartsWith(scheme, StringComparison.OrdinalIgnoreCase))
                {
                    hasValidSchema = true;
                }
            }
            if (!hasValidSchema)
            {
                value = "http://" + value;
            }
            return Uri.IsWellFormedUriString(value, UriKind.Absolute);
        }
        #endregion

        #region IsMainDomain(是否主域名)
        /// <summary>
        /// 是否主域名或者www开头的域名
        /// </summary>
        /// <param name="value">url地址</param>
        /// <returns></returns>
        public static bool IsMainDomain(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            return
                value.IsMatch(
                    @"^http(s)?\://((www.)?[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*$");
        }
        #endregion

        #region IsGuid(是否Guid)
        /// <summary>
        /// 是否Guid
        /// </summary>
        /// <param name="guid">Guid字符串</param>
        /// <returns></returns>
        public static bool IsGuid(string guid)
        {
            if (guid.IsEmpty())
            {
                return false;
            }
            return guid.IsMatch(@"[A-F0-9]{8}(-[A-F0-9]{4}){3}-[A-F0-9]{12}|[A-F0-9]{32}", RegexOptions.IgnoreCase);
        }
        #endregion

        #region IsPositiveInteger(是否大于0的正整数)
        /// <summary>
        /// 是否大于0的正整数
        /// </summary>
        /// <param name="value">正整数</param>
        /// <returns></returns>
        public static bool IsPositiveInteger(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            return value.IsMatch(@"^[1-9]+\d*$");
        }
        #endregion

        #region IsInt32(是否Int32类型)
        /// <summary>
        /// 是否Int32类型
        /// </summary>
        /// <param name="value">整数</param>
        /// <returns></returns>
        public static bool IsInt32(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            return value.IsMatch(@"^[0-9]*$");
        }
        #endregion

        #region IsDouble(是否Double类型，如果带有.默认为1位0)
        /// <summary>
        /// 是否Double类型
        /// </summary>
        /// <param name="value">小数</param>
        /// <returns></returns>
        public static bool IsDouble(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            return value.IsMatch(@"^\d[.]?\d?$");
        }
        /// <summary>
        /// 是否Double类型
        /// </summary>
        /// <param name="value">小数</param>
        /// <param name="minValue">最小值</param>
        /// <param name="maxValue">最大值</param>
        /// <param name="digit">小数位数，如果是0则不检测</param>
        /// <returns></returns>
        public static bool IsDouble(string value, double minValue, double maxValue, int digit)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            string patten = string.Format(@"^\d[.]?\d{0}$", "{0,10}");
            if (digit > 0)
            {
                patten = string.Format(@"^\d[.]?\d{0}$", "{" + digit + "}");
            }
            if (value.IsMatch(patten))
            {
                double val = Convert.ToDouble(value);
                if (val >= minValue && val <= maxValue)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region IsInteger(是否整数)
        /// <summary>
        /// 是否整数
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>结果</returns>
        public static bool IsInteger(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            return value.IsMatch(@"^\-?[0-9]+$");
        }
        #endregion

        #region IsUnicode(是否Unicode字符串)
        /// <summary>
        /// 是否Unicode字符串
        /// </summary>
        /// <param name="value">unicode字符串</param>
        /// <returns>结果</returns>
        public static bool IsUnicode(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            return
                value.IsMatch(
                    @"^(http|https|ftp|rtsp|mms):(\/\/|\\\\)[A-Za-z0-9%\-_@]+\.[A-Za-z0-9%\-_@]+[A-Za-z0-9\.\/=\?%\-&_~`@:\+!;]*$");
        }
        #endregion

        #region IsDecimal(是否数字型)
        /// <summary>
        /// 是否数字型
        /// </summary>
        /// <param name="value">数字</param>
        /// <returns></returns>
        public static bool IsDecimal(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            return value.IsMatch(@"^([0-9])[0-9]*(\.\w*)?$");
        }
        #endregion

        #region IsMac(是否Mac地址)
        /// <summary>
        /// 是否Mac地址
        /// </summary>
        /// <param name="value">Mac地址</param>
        /// <returns></returns>
        public static bool IsMac(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            return value.IsMatch(@"^([0-9A-F]{2}-){5}[0-9A-F]{2}$") || value.IsMatch(@"^[0-9A-F]{12}$");
        }
        #endregion

        #region IsIpAddress(是否IP地址)
        /// <summary>
        /// 是否IP地址
        /// </summary>
        /// <param name="value">ip地址</param>
        /// <returns>结果</returns>
        public static bool IsIpAddress(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            return value.IsMatch(@"^(\d(25[0-5]|2[0-4][0-9]|1?[0-9]?[0-9])\d\.){3}\d(25[0-5]|2[0-4][0-9]|1?[0-9]?[0-9])\d$");
        }
        #endregion
    }
}
