using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kpi.Models
{
    public partial class Objetivo
    {
        public Objetivo()
        {
            Subobjetivos = new HashSet<Subobjetivos>();
        }

        public int IdObjetivo { get; set; }
        public string NombreObjetivo { get; set; }
        public float PorcentajeObjetivo { get; set; }

        public virtual ICollection<Subobjetivos> Subobjetivos { get; set; }
    }
}
