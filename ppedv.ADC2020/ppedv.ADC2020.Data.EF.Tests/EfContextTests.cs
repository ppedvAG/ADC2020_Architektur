using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ppedv.ADC2020.Data.EF.Tests
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void EfContext_can_create_DB()
        {
            var con = new EfContext();

            if (con.Database.Exists())
                con.Database.Delete();

            Assert.IsFalse(con.Database.Exists());
            con.Database.Create();
            Assert.IsTrue(con.Database.Exists());
        }
    }
}
