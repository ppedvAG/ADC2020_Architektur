﻿using System.Collections.Generic;

namespace ppedv.ADC2020.Model
{
    public class Standort : Entity
    {
        public string Bezeichnung { get; set; }
        public virtual ICollection<Auto> Autos { get; set; } = new HashSet<Auto>();
    }
}
