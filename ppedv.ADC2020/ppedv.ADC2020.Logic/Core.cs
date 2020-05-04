﻿using Bogus;
using ppedv.ADC2020.Data.EF;
using ppedv.ADC2020.Model;
using ppedv.ADC2020.Model.Contracts;
using System;

namespace ppedv.ADC2020.Logic
{
    public class Core
    {
        public IRepository Repository { get; private set; }

        public Core(IRepository repo)
        {
            Repository = repo;
        }

        public Core() : this(new Data.EF.EfRepository())
        { }

        public void CreateDemoDaten()
        {
            var kundenFaker = new Faker<Kunde>()
                           .RuleFor(x => x.Name, x => x.Name.FullName())
                           .RuleFor(x => x.GebDatum, x => x.Date.Past(40));

            var k1 = kundenFaker.Generate();
            var k2 = kundenFaker.Generate();
            var k3 = kundenFaker.Generate();

            var standortFaker = new Faker<Standort>()
                                    .RuleFor(x => x.Bezeichnung, x => x.Address.City());

            var s1 = standortFaker.Generate();
            var s2 = standortFaker.Generate();

            var af = new Faker<Auto>();
            af.RuleFor(x => x.Farbe, f => f.Commerce.Color());
            af.RuleFor(x => x.Hersteller, f => f.Vehicle.Manufacturer());
            af.RuleFor(x => x.Modell, f => f.Vehicle.Model());

            var a1 = af.Generate();
            var a2 = af.Generate();
            var a3 = af.Generate();

            var vm1 = new Vermietung() { StartStandort = s1, EndeStandort = s2, Auto = a1, Kunde = k1, Start = DateTime.Now.AddDays(-15), Ende = DateTime.Now.AddDays(-11) };
            var vm2 = new Vermietung() { StartStandort = s1, EndeStandort = s1, Auto = a2, Kunde = k2, Start = DateTime.Now.AddDays(-95), Ende = DateTime.Now.AddDays(-87) };
            var vm3 = new Vermietung() { StartStandort = s2, EndeStandort = s2, Auto = a3, Kunde = k3, Start = DateTime.Now.AddDays(-45), Ende = DateTime.Now.AddDays(-31) };

            Repository.Add(vm1);
            Repository.Add(vm2);
            Repository.Add(vm3);

            Repository.Save();
        }
    }
}
