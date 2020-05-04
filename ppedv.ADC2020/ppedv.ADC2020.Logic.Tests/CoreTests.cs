using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.ADC2020.Model;
using ppedv.ADC2020.Model.Contracts;

namespace ppedv.ADC2020.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void Core_GetAllKundenDieSeitXTagenNichtMehrGebuchtHaben_50_Tage_results_2_Kunde()
        {
            var core = new Core(new TestRepo());

            var result = core.GetAllKundenDieSeitXTagenNichtMehrGebuchtHaben(50, DateTime.Now);

            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void Core_GetAllKundenDieSeitXTagenNichtMehrGebuchtHaben_50_Tage_results_2_Kunde_MOQ()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.Query<Kunde>()).Returns(() => 
            {
                var k1 = new Kunde() { Name = "Fred" };
                k1.Vermietungen.Add(new Vermietung() { Ende = DateTime.Now.AddDays(-115) });
                var k2 = new Kunde() { Name = "Wilma" };
                k2.Vermietungen.Add(new Vermietung() { Ende = DateTime.Now.AddDays(-145) });
                var k3 = new Kunde() { Name = "Barney" };
                k3.Vermietungen.Add(new Vermietung() { Ende = DateTime.Now.AddDays(-45) });
                return new[] { k1, k2, k3 }.AsQueryable();
            });

            var core = new Core(mock.Object);

            var result = core.GetAllKundenDieSeitXTagenNichtMehrGebuchtHaben(50, DateTime.Now);

            Assert.AreEqual(2, result.Count());
        }


        [TestMethod]
        public void Core_GetAllKundenDieSeitXTagenNichtMehrGebuchtHaben_50_Tage_results_0_Kunde()
        {

        }

        [TestMethod]
        public void Core_GetAllKundenDieSeitXTagenNichtMehrGebuchtHaben_Tage_zero_or_negative_throws_ArgumentsEx()
        {
            var core = new Core(null);

            Assert.ThrowsException<ArgumentException>(() => core.GetAllKundenDieSeitXTagenNichtMehrGebuchtHaben(0, DateTime.Now));
            Assert.ThrowsException<ArgumentException>(() => core.GetAllKundenDieSeitXTagenNichtMehrGebuchtHaben(-1, DateTime.Now));
            Assert.ThrowsException<ArgumentException>(() => core.GetAllKundenDieSeitXTagenNichtMehrGebuchtHaben(-5, DateTime.Now));
        }
    }


    public class TestRepo : IRepository
    {
        public void Add<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(int id) where T : Entity
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            if (typeof(T) == typeof(Kunde))
            {
                var k1 = new Kunde() { Name = "Fred" };
                k1.Vermietungen.Add(new Vermietung() { Ende = DateTime.Now.AddDays(-115) });
                var k2 = new Kunde() { Name = "Wilma" };
                k2.Vermietungen.Add(new Vermietung() { Ende = DateTime.Now.AddDays(-145) });
                var k3 = new Kunde() { Name = "Barney" };
                k3.Vermietungen.Add(new Vermietung() { Ende = DateTime.Now.AddDays(-45) });
                return new[] { k1, k2, k3 }.AsQueryable().Cast<T>();
            }
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}
