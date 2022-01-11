using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Core.Entities;

namespace Travel.Core.Interfaces.Services
{
    public interface IEditorialService
    {
        /// <summary>
        /// Método para consultar todos los Editoriales
        /// </summary>
        /// <param> </param>
        /// <returns> Objeto paginado con el resultado de la consulta </returns>
        Task<List<Editorial>> ObtenerEditoriales();

        /// <summary>
        /// Método para obtener editorial con id
        /// </summary>
        /// <param name="id"> Id property </param>
        /// <returns></returns>
        Task<Editorial> ObtenerEditorial(int id);


        /// <summary>
        /// Método para crear Autor
        /// </summary>
        /// <param name="Editorial"> Objeto con la información de editorial </param>
        /// <returns></returns>
        Task CrearEditorial(Editorial editorial);

        /// <summary>
        /// Metodo para actualizar editorial
        /// </summary>
        /// <param name="editorial"> Objeto property para actualizar </param>
        /// <returns> Retorna resutlado de operacion true o false</returns>
        Task<bool> ActualizarEditorial(Editorial editorial);
    }
}
