using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Core.Entities;

namespace Travel.Core.Interfaces.Services
{
    public interface IAutorService
    {
        /// <summary>
        /// Método para consultar todos los registros de Autor
        /// </summary>
        /// <param> </param>
        /// <returns> Objeto paginado con el resultado de la consulta </returns>
        Task<List<Autor>> ObtenerAutores();

        /// <summary>
        /// Método para obtener autor con id
        /// </summary>
        /// <param name="id"> Id property </param>
        /// <returns></returns>
        Task<Autor> ObtenerAutor(int id);


        /// <summary>
        /// Método para crear Autor
        /// </summary>
        /// <param name="Autor"> Objeto con la información de autor </param>
        /// <returns></returns>
        Task CreateAutor(Autor autor);

        /// <summary>
        /// Metodo para actualizar editorial
        /// </summary>
        /// <param name="autor"> Objeto property para actualizar </param>
        /// <returns> Retorna resutlado de operacion true o false</returns>
        Task<bool> ActualizarAutor(Autor autor);
       
    }
}
