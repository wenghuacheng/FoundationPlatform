using DapperExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository.Dapper.Test
{
    [TestClass]
    public class DapperRepositoryTest
    {
        private DapperRepositoryBase<Test, int> repository = new DapperRepositoryBase<Test, int>(null);

        public DapperRepositoryTest()
        {
            //repository.Connection = new MySql.Data.MySqlClient.MySqlConnection("server=192.168.1.105;user id=root;password=123456;database=WORDREPOSITORY");

        }

        [TestMethod]
        public void Dapper_insert_Test()
        {
            try
            {
                repository.Insert(new Test() { name = "12345" });
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Dapper_count_Test()
        {
            var count = repository.Count(p => p.Id == 2 && p.name == "12345" || p.Id == 1);
            Assert.AreEqual<int>(count, 1);
        }

        [TestMethod]
        public void Dapper_Delete_Test()
        {
            try
            {
                var item = repository.FirstOrDefault(p => p.name == "12345" && p.Id != 2);
                repository.Delete(item);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Dapper_FirstOrDefault_Test()
        {
            var item = repository.FirstOrDefault(p => p.Id == 2);
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void Dapper_Get_Test()
        {
            var item = repository.Get(2);
            Assert.IsNotNull(item);
        }

        [TestMethod]
        public void Dapper_Execute_Test()
        {
            var count = repository.Execute("select count(id) from Test where id=2");
            Assert.AreEqual<int>(count, 1);
        }

        [TestMethod]
        public void Dapper_GetAll_Test()
        {
            var items = repository.GetAll();
            Assert.IsNotNull(items);
            Assert.AreNotEqual<int>(items.Count(), 0);
        }

        [TestMethod]
        public void Dapper_GetAllPaged_Test()
        {
            var items = repository.GetAllPaged(p => p.Id >= 0, 1, 10);
            Assert.IsNotNull(items);
            Assert.AreNotEqual<int>(items.Count(), 0);
        }

        [TestMethod]
        public void Dapper_InsertAndGetId_Test()
        {
            var id = repository.InsertAndGetId(new Test() { name = "11111" });
            Assert.AreNotEqual<int>(id, 1);
        }

        public void Dapper_Update_Test()
        {
            repository.Update(new Test() { Id = 2, name = "11111" });
            var item = repository.FirstOrDefault(2);
            Assert.AreEqual<string>(item.name, "11111");
        }
    }
}
