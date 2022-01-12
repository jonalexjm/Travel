using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Core.Entities;
using Travel.Core.Interfaces.Repositories;
using Travel.Infrastructure.Data;

namespace Travel.Infrastructure.Repositories
{
    public class AutoresHasLibroRepository : BaseRepository<AutoresHasLibro>, IAutoresHasLibroRepository
    {
        private readonly TravelDbContext travelDbContext;
        public AutoresHasLibroRepository(TravelDbContext context) : base(context)
        {
            travelDbContext = context;
        }

        public async Task<List<AutoresHasLibro>> ObtenerAutorHasLibroPorLibroAll()
        {
            return await travelDbContext.AutoresHasLibros
                                        .Include(e => e.Autores)                                        
                                        .ToListAsync();
        }
    }
}
