using System;
using System.Collections.Generic;

namespace ppedv.ADC2020.Model
{
    public class Kunde : Entity
    {
        public string Name { get; set; }
        public DateTime GebDatum { get; set; }
        public virtual ICollection<Vermietung> Vermietungen { get; set; } = new HashSet<Vermietung>();
    }
}
