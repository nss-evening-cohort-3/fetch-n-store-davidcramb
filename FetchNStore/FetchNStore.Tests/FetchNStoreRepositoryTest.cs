using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FetchNStore.DAL;
using FetchNStore.Models;
using Moq;
using System.Data.Entity;
using System.Linq;

namespace FetchNStore.Tests
{
    [TestClass]
    public class FetchNStoreRepositoryTest
    {
        Mock<FetchNStoreContext> mock_context { get; set; }
        Mock<DbSet<URL>> mock_url_table {get;set;}
        List<URL> url_list { get; set; }
        FetchNStoreRepository repo { get; set; }

        public void ConnectMockToDataStore()
        {
            var queryable_list = url_list.AsQueryable();
            mock_url_table.As<IQueryable<URL>>().Setup(m => m.Provider).Returns(queryable_list.Provider);
            mock_url_table.As<IQueryable<URL>>().Setup(m => m.Expression).Returns(queryable_list.Expression);
            mock_url_table.As<IQueryable<URL>>().Setup(m => m.ElementType).Returns(queryable_list.ElementType);
            mock_url_table.As<IQueryable<URL>>().Setup(m => m.GetEnumerator()).Returns(() => queryable_list.GetEnumerator());
            mock_context.Setup(u => u.URL).Returns(mock_url_table.Object);

            mock_url_table.Setup(t => t.Add(It.IsAny<URL>())).Callback((URL u) => url_list.Add(u));
            mock_url_table.Setup(t => t.Remove(It.IsAny<URL>())).Callback((URL u) => url_list.Remove(u));
        }
        [TestInitialize]
        public void Intialize()
        {
            mock_context = new Mock<FetchNStoreContext>();
            mock_url_table = new Mock<DbSet<URL>>();
            url_list = new List<URL>();
            repo = new FetchNStoreRepository(mock_context.Object);
            ConnectMockToDataStore();
        }
        [TestCleanup]
        public void TearDown()
        {
            repo = null;
        }

        [TestMethod]
        public void EnsureInstanceOfRepo()
        {
            Assert.IsNotNull(repo);
        }
        [TestMethod]
        public void EnsureRepoHasContext()
        {
            FetchNStoreContext actual_context = repo.Context;
            Assert.IsInstanceOfType(actual_context, typeof(FetchNStoreContext));
        }
        [TestMethod]
        public void EnsureRepoIsEmpty()
        {
            List<URL> url_list = repo.GetURLs();
            int expected_count = 0;
            int actual_count = url_list.Count();
            
            Assert.AreEqual(expected_count, actual_count);
        }
        [TestMethod]
        public void EnsureCanAddURLs()
        {
            URL new_url = new URL { Method = "GET", URL_Address = "http://www.nashvillesoftwareschool.com", Response_Time = 55 };
            repo.AddURLToDataBase(new_url);
            List<URL> url_list = repo.GetURLs();
            int expected_count = 1;
            int actual_count = url_list.Count();
            Assert.AreEqual(expected_count, actual_count);
        }
        [TestMethod]
        public void MyTestMethod()
        {

        }

    }
}
