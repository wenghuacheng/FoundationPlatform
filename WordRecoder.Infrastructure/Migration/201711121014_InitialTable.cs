using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;

namespace WordRecoder.Infrastructure.Migration
{
    public class _201711121014_InitialTable : IMigration
    {
        public long Version => 201711121014;

        public void Execute(IDbConnection db)
        {
            //创建migration表
            db.Execute("Create table Migration(Id int primary key AUTO_INCREMENT,Version bigint not null)");
            //创建单词库
            db.Execute("Create table Word (" +
                "Id int primary key AUTO_INCREMENT," +
                "Name VARCHAR(32) NOT NULL," +
                "Mean VARCHAR(100) NULL," +
                "MnemonicWord VARCHAR(100) NULL," +
                "HelpMsg VARCHAR(100) NULL)");
            //创建单词词根关联表
            db.Execute("Create table WordRootRelation (" +
                "Id int primary key AUTO_INCREMENT," +
                "WordId int NOT NULL," +
                "RootId int NOT NULL)");
            //创建单词同义词关联表
            db.Execute("Create table WordSynonymRelation (" +
                "Id int primary key AUTO_INCREMENT," +
                "WordId int NOT NULL," +
                "SynonymId int NOT NULL)");
            //创建单词反义词关联表
            db.Execute("Create table WordAntonymRelation (" +
                "Id int primary key AUTO_INCREMENT," +
                "WordId int NOT NULL," +
                "AntonymId int NOT NULL)");
            //创建词根
            db.Execute("Create table Root (" +
                "Id int primary key AUTO_INCREMENT," +
                "Name VARCHAR(100) NOT NULL," +
                "Derivative VARCHAR(100) NULL," +
                "Type int NOT NULL," +
                "Mean VARCHAR(100) NULL," +
                "ChineseMean VARCHAR(100) NULL," +
                "Remark VARCHAR(128) NULL)");
        }
    }
}
