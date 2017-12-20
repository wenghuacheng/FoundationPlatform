using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;

namespace WordRecoder.Infrastructure.Migration
{
    public class _201711121013_InitialDatabase : IDbCreator
    {
        public long Version => 201711121014;

        public void Execute(IDbConnection db)
        {
            //创建数据库
            db.Execute("CREATE DATABASE WORDREPOSITORY;");
        }
    }
}
