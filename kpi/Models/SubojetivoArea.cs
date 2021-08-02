﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace kpi.Models
{
    public partial class SubojetivoArea
    {
        public int IdSubobjetivos { get; set; }
        public int IdArea { get; set; }

        public virtual Area IdAreaNavigation { get; set; }
    }
}
