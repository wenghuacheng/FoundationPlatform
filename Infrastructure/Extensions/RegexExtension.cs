using System.Text.RegularExpressions;

namespace Infrastructure.Extensions
{
    /// <summary>
    /// 常用正则表达式扩展方法
    /// </summary>
    public static class RegexExtension
    {
        #region 邮箱验证
        /// <summary>
        /// 是否邮箱
        /// </summary>
        /// <param name="value">邮箱地址</param>
        /// <param name="isRestrict">是否按严格模式验证</param>
        /// <returns></returns>
        public static bool IsEmail(string value, bool isRestrict = false)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            string pattern = isRestrict
                ? @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$"
                : @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";

            return value.IsMatch(pattern, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 是否存在邮箱
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="isRestrict">是否按严格模式验证</param>
        /// <returns></returns>
        public static bool HasEmail(string value, bool isRestrict = false)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            string pattern = isRestrict
                ? @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$"
                : @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";
            return value.IsMatch(pattern, RegexOptions.IgnoreCase);
        }
        #endregion

        #region 手机号验证

        #region IsPhoneNumber(是否合法的手机号码)
        /// <summary>
        /// 是否合法的手机号码
        /// </summary>
        /// <param name="value">手机号码</param>
        /// <returns></returns>
        public static bool IsPhoneNumber(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            return value.IsMatch(@"^(0|86|17951)?(13[0-9]|15[012356789]|18[0-9]|14[57]|17[678])[0-9]{8}$");
        }
        #endregion

        #region IsMobileNumber(是否手机号码)
        /// <summary>
        /// 是否手机号码
        /// </summary>
        /// <param name="value">手机号码</param>
        /// <param name="isRestrict">是否按严格模式验证</param>
        /// <returns></returns>
        public static bool IsMobileNumberSimple(string value, bool isRestrict = false)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            string pattern = isRestrict ? @"^[1][3-8]\d{9}$" : @"^[1]\d{10}$";
            return value.IsMatch(pattern);
        }
        /// <summary>
        /// 是否手机号码
        /// </summary>
        /// <param name="value">手机号码</param>
        /// <returns></returns>
        public static bool IsMobileNumber(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            value = value.Trim().Replace("^", "").Replace("$", "");
            /**
             * 手机号码: 
             * 13[0-9], 14[5,7], 15[0, 1, 2, 3, 5, 6, 7, 8, 9], 17[6, 7, 8], 18[0-9], 170[0-9]
             * 移动号段: 134,135,136,137,138,139,150,151,152,157,158,159,182,183,184,187,188,147,178,1705
             * 联通号段: 130,131,132,155,156,185,186,145,176,1709
             * 电信号段: 133,153,180,181,189,177,1700
             */
            return value.IsMatch(@"^1(3[0-9]|4[57]|5[0-35-9]|8[0-9]|70)\d{8}$");
        }

        /// <summary>
        /// 是否存在手机号码
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="isRestrict">是否按严格模式验证</param>
        /// <returns></returns>
        public static bool HasMobileNumberSimple(string value, bool isRestrict = false)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            string pattern = isRestrict ? @"[1][3-8]\d{9}" : @"[1]\d{10}";
            return value.IsMatch(pattern);
        }
        #endregion

        #region IsChinaMobilePhone(是否中国移动号码)
        /// <summary>
        /// 是否中国移动号码
        /// </summary>
        /// <param name="value">手机号码</param>
        /// <returns></returns>
        public static bool IsChinaMobilePhone(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            /**
             * 中国移动：China Mobile
             * 134,135,136,137,138,139,150,151,152,157,158,159,182,183,184,187,188,147,178,1705
             */
            return value.IsMatch(@"(^1(3[4-9]|4[7]|5[0-27-9]|7[8]|8[2-478])\d{8}$)|(^1705\d{7}$)");
        }
        #endregion

        #region IsChinaUnicomPhone(是否中国联通号码)
        /// <summary>
        /// 是否中国联通号码
        /// </summary>
        /// <param name="value">手机号码</param>
        /// <returns></returns>
        public static bool IsChinaUnicomPhone(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            /**
             * 中国联通：China Unicom
             * 130,131,132,155,156,185,186,145,176,1709
             */
            return value.IsMatch(@"(^1(3[0-2]|4[5]|5[56]|7[6]|8[56])\d{8}$)|(^1709\d{7}$)");
        }
        #endregion

        #region IsChinaTelecomPhone(是否中国电信号码)
        /// <summary>
        /// 是否中国电信号码
        /// </summary>
        /// <param name="value">手机号码</param>
        /// <returns></returns>
        public static bool IsChinaTelecomPhone(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            /**
             * 中国电信：China Telecom
             * 133,153,180,181,189,177,1700
             */
            return value.IsMatch(@"(^1(33|53|77|8[019])\d{8}$)|(^1700\d{7}$)");
        }
        #endregion

        #endregion

        #region 身份证验证
        /// <summary>
        /// 是否身份证号码
        /// </summary>
        /// <param name="value">身份证</param>
        /// <returns></returns>
        public static bool IsIdCard(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            if (value.Length == 15)
            {
                return value.IsMatch(@"^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$");
            }
            return value.Length == 0x12 &&
                   value.IsMatch(@"^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])((\d{4})|\d{3}[Xx])$",
                       RegexOptions.IgnoreCase);
        }
        #endregion

        #region 邮政编码验证
        /// <summary>
        /// 是否邮政编码，6位数字
        /// </summary>
        /// <param name="value">邮政编码</param>
        /// <returns></returns>
        public static bool IsPostalCode(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            return value.IsMatch(@"^[1-9]\d{5}$", RegexOptions.IgnoreCase);
        }
        #endregion

        #region 中国固话验证
        /// <summary>
        /// 是否中国电话，格式：010-85849685
        /// </summary>
        /// <param name="value">电话</param>
        /// <returns></returns>
        public static bool IsTel(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            return value.IsMatch(@"^\d{3,4}-?\d{6,8}$", RegexOptions.IgnoreCase);
        }
        #endregion

        #region QQ号码验证
        /// <summary>
        /// 是否合法QQ号码
        /// </summary>
        /// <param name="value">QQ号码</param>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public static bool IsQQ(string value)
        {
            if (value.IsEmpty())
            {
                return false;
            }
            return value.IsMatch(@"^[1-9][0-9]{4,9}$");
        }
        #endregion
    }
}
