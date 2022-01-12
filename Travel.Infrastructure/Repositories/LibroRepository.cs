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
    public class LibroRepository : BaseRepository<Libro>, ILibroRepository
    {
        private readonly TravelDbContext travelDbContext;
        public LibroRepository(TravelDbContext context) : base(context)
        {
            travelDbContext = context;
        }

        public async  Task<Libro> ObtenerLibroConEditoriales(int isbn)
        {
            return await travelDbContext.Libros
                                        .Where(l => l.Isbn == isbn)
                                        .Include(e => e.EditorialesNavigation)
                                        .FirstOrDefaultAsync();
        }

        public async Task<List<Libro>> ObtenerLibrosConEditoriales()
        {
            return await travelDbContext.Libros.Include(e => e.EditorialesNavigation).ToListAsync();
        }
    }
}
