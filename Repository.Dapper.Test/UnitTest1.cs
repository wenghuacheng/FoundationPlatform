using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql;
using Dapper;
using DapperExtensions;
using MySql.Data.MySqlClient;

namespace Repository.Dapper.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;password=123456;database=WORDREPOSITORY"))
            {
                conn.Open();

                Test test = new Test() { id = 1, name = "1234" };
                conn.Insert<Test>(test);

                conn.Close();
            }
        }

        public class Test
        {
            public int id { get; set; }

            public string name { get; set; }
        }
    }
}
