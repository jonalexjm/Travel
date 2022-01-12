using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Core.Entities;
using Travel.Core.Interfaces;
using Travel.Core.Interfaces.Services;

namespace Travel.Infrastructure.Services
{
    public class AutoresHasLibroService : IAutoresHasLibroService
    {
        private readonly IUnitOfWork _unitOfWork;

        #region Constructor
        public AutoresHasLibroService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        /// <summary>
        /// Método para crear AutorHasLibro
        /// </summary>
        /// <param name="autoresHasLibro"> Objeto con la información de AutorHasLibro </param>
        /// <returns></returns>
        public async  Task CreateAutorHasLibro(AutoresHasLibro autoresHasLibro)
        {
            await _unitOfWork.AutoresHasLibroRepository.Add(autoresHasLibro);
            await _unitOfWork.SaveChangesAsync();
        }

        // <summary>
        /// Método para Obtener Autores 
        /// </summary>
        /// <param name="idLibros"> ISBN del libro a buscar AutorHasLibro </param>
        /// <returns></returns>
        public async Task<List<AutoresHasLibro>> ObtenerAutorHasLibroPorLibro(int idLibros)
        {
            return  _unitOfWork.AutoresHasLibroRepository
                                                         .GetAll()
                                                         .Where(l => l.LibrosIsbn == idLibros)
                                                         .ToList();
            //autorHasLibroPorLibro = autorHasLibroPorLibro.Where(l => l.LibrosIsbn == idLibros).ToList();
        }

        /// <summary>
        /// Método para Obtener AutorHasLibro 
        /// </summary>
        /// <param> </param>
        /// <returns></returns>
        public async  Task<List<AutoresHasLibro>> ObtenerAutorHasLibroPorLibroAll(int id)
        {
            var items = await _unitOfWork.AutoresHasLibroRepository
                                        .ObtenerAutorHasLibroPorLibroAll();

            return items.Where(l => l.LibrosIsbn == id).ToList();
            
        }
    }
}
