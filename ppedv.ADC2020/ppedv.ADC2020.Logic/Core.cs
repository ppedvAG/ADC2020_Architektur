using ppedv.ADC2020.Data.EF;
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
    }
}
