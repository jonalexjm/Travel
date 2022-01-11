using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Core.Interfaces;
using Travel.Core.Interfaces.Repositories;
using Travel.Infrastructure.Data;

namespace Travel.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TravelDbContext _travelDbContext;
        public UnitOfWork(TravelDbContext travelDbContext)
        {
            _travelDbContext = travelDbContext;
        }
        public IAutorRepository AutorRepository => new AutorRepository(_travelDbContext);

        public IEditorialRepository EditorialRepository => new EditorialRepository(_travelDbContext);

        public IAutoresHasLibroRepository AutoresHasLibroRepository => new AutoresHasLibroRepository(_travelDbContext);

        public ILibroRepository LibroRepository => new LibroRepository(_travelDbContext);

        public void Dispose()
        {
            if (_travelDbContext != null)
                _travelDbContext.Dispose();
        }

        public void SaveChanges()
        {
            this._travelDbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await this._travelDbContext.SaveChangesAsync();
        }
    }
}
