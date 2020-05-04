using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.ADC2020.Model;

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


        [TestMethod]
        public void EfContext_can_CRUD_Auto()
        {
            var auto = new Auto()
            {
                Farbe = $"Blau_{Guid.NewGuid().ToString().Substring(0, 12)}",
                Hersteller = "Baudi",
                Modell = "B99"
            };

            var neueFarbe = $"Rot_{Guid.NewGuid().ToString().Substring(0, 13)}";

            using (var con = new EfContext())
            {
                con.Autos.Add(auto);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Autos.Find(auto.Id);

                Assert.IsNotNull(loaded);
                Assert.AreEqual(auto.Farbe, loaded.Farbe);

                //UPDATE
                loaded.Farbe = neueFarbe;
                con.SaveChanges();
            }

            //check UPDATE
            using (var con = new EfContext())
            {
                var loaded = con.Autos.Find(auto.Id);
                Assert.AreEqual(neueFarbe, loaded.Farbe);

                con.Autos.Remove(loaded);
                con.SaveChanges();
            }

            //check DELETE
            using (var con = new EfContext())
            {
                var loaded = con.Autos.Find(auto.Id);
                Assert.IsNull(loaded);
            }

        }
    }
}
