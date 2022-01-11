using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Core.Entities;

namespace Travel.Core.Interfaces.Services
{
    public interface ILibroService
    {
        /// <summary>
        /// Método para consultar todos los registros de Libro
        /// </summary>
        /// <param> </param>
        /// <returns> Objeto paginado con el resultado de la consulta </returns>
        Task<List<Libro>> ObtenerLibros();

        /// <summary>
        /// Método para obtener libro con id
        /// </summary>
        /// <param name="id"> Id property </param>
        /// <returns></returns>
        Task<Libro> ObtenerLibro(int id);


        /// <summary>
        /// Método para crear Libro
        /// </summary>
        /// <param name="Libro"> Objeto con la información de libro </param>
        /// <returns></returns>
        Task CreateLibro(Libro libro);

        /// <summary>
        /// Metodo para actualizar libro
        /// </summary>
        /// <param name="libro"> Objeto property para actualizar </param>
        /// <returns> Retorna resutlado de operacion true o false</returns>
        Task<bool> ActualizarLibro(Libro libro);
    }
}
