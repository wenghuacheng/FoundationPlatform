using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WordRecoder.Infrastructure.Repository
{
    public class DbConnectionFactory
    {
        /// <summary>
        /// 用于建库的数据库链接
        /// </summary>
        /// <returns></returns>
        public static MySqlConnection GetMysqlConnection()
        {
            return new MySqlConnection("Data Source=localhost;Persist Security Info=yes;UserId=root; PWD=123456;");
        }

        public static MySqlConnection GetDatabaseMysqlConnection()
        {
            return new MySqlConnection("server=localhost;user id=root;password=123456;database=WORDREPOSITORY");
        }
    }
}
