using System;

namespace ppedv.ADC2020.Model
{
    public class Vermietung : Entity
    {
        public DateTime Start { get; set; }
        public DateTime Ende { get; set; }
        public virtual Kunde Kunde { get; set; }
        public virtual Auto Auto { get; set; }
        public virtual Standort StartStandort { get; set; }
        public virtual Standort EndeStandort { get; set; }
    }
}
