using System;
using System.Threading.Tasks;
using Travel.Core.Interfaces.Repositories;

namespace Travel.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAutorRepository AutorRepository { get; }
        IEditorialRepository EditorialRepository { get; }
        IAutoresHasLibroRepository AutoresHasLibroRepository { get; }
        ILibroRepository LibroRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
