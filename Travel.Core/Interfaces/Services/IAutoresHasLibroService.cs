using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Core.Entities;

namespace Travel.Core.Interfaces.Services
{
    public interface IAutoresHasLibroService
    {
        /// <summary>
        /// Método para crear AutorHasLibro
        /// </summary>
        /// <param name="autoresHasLibro"> Objeto con la información de AutorHasLibro </param>
        /// <returns></returns>
        Task CreateAutorHasLibro(AutoresHasLibro autoresHasLibro);

        /// <summary>
        /// Método para Obtener Autores 
        /// </summary>
        /// <param name="idLibros"> ISBN del libro a buscar AutorHasLibro </param>
        /// <returns></returns>
        Task<List<AutoresHasLibro>> ObtenerAutorHasLibroPorLibro(int idLibros);

        /// <summary>
        /// Método para Obtener AutorHasLibro 
        /// </summary>
        /// <param> </param>
        /// <returns></returns>
        Task<List<AutoresHasLibro>> ObtenerAutorHasLibroPorLibroAll(int id);
    }
}
