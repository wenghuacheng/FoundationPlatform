﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using Repository.Dapper;
using System;
using System.Linq;

namespace Repository.Test
{
    [TestClass]
    public class DapperRepositoryTest
    {
        private DapperRepositoryBase<Test, int> repository;
        IDapperUnitOfWork unitOfWork;

        public DapperRepositoryTest()
        {
            var connection = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;user id=root;password=123456;database=Test");

            unitOfWork = new UnitOfWork(connection);
            repository = new DapperRepositoryBase<Test, int>(unitOfWork);
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
            var count = repository.Count(p => p.name == "12345" || p.Id == 21);
            Assert.AreEqual<int>(count, 1);
        }

        [TestMethod]
        public void Dapper_Delete_Test()
        {
            try
            {
                var item = repository.FirstOrDefault(p => p.name == "12345" && p.Id != 2);
                repository.Delete(item, null);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Dapper_FirstOrDefault_Test()
        {
            try
            {
                var item = repository.FirstOrDefault(p => p.Id == 21);
                Assert.IsNotNull(item);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

        }

        [TestMethod]
        public void Dapper_Get_Test()
        {
            var item = repository.Get(1);
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

        [TestMethod]
        public void Dapper_Update_Test()
        {
            repository.Update(new Test() { Id = 2, name = "11111" });
            var item = repository.FirstOrDefault(2);
            Assert.AreEqual<string>(item.name, "11111");
        }

        [TestMethod]
        public void Dapper_UnitOfWorkTestSuccess()
        {
            try
            {
                this.unitOfWork.RegisterNew(new Test() { name = "00" }, repository);
                this.unitOfWork.RegisterNew(new Test() { name = "11" }, repository);
                this.unitOfWork.RegisterNew(new Test() { name = "22" }, repository);
                this.unitOfWork.SaveChange();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [TestMethod]
        public void Dapper_UnitOfWorkTestFail()
        {
            try
            {
                this.unitOfWork.RegisterNew(new Test() { name = "0" }, repository);
                this.unitOfWork.RegisterNew(new Test() { name = "1" }, repository);
                this.unitOfWork.RegisterNew(new Test(), repository);
                this.unitOfWork.SaveChange();
                Assert.Fail();
            }
            catch (Exception ex)
            {
                //Assert.IsInstanceOfType(ex, typeof(MySql.Data.MySqlClient.MySqlException));
            }
        }

        [TestMethod]
        public void Dapper_CreateRepository()
        {
            try
            {
                var repostory = this.unitOfWork.Repository<Test, int>();
                Assert.IsNotNull(repository);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

        }
    }
}
