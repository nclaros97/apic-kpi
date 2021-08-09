using kpi.Dtos.Objetivos;
using kpi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kpi.Services.Objetivos
{
    public class ObjetivosServices
    {
        private readonly kpiContext _context;
        public ObjetivosServices(kpiContext context) {
            _context = context;
        }

        public async Task<List<Objetivo>> GetObjetivos()
        {
            var objetivos = _context.Objetivo.Include(x => x.Subobjetivos).ThenInclude( x => x.IdAreaNavigation).ToListAsync();
            return await objetivos;
        }

    }
}
