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
    public class AutorService : IAutorService
    {
        private readonly IUnitOfWork _unitOfWork;

        #region Constructor
        public AutorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        /// <summary>
        /// Método para consultar todos los registros de Autor
        /// </summary>
        /// <param> </param>
        /// <returns> Objeto paginado con el resultado de la consulta </returns>
        public async Task<List<Autor>> ObtenerAutores()
        {
            return  this._unitOfWork.AutorRepository.GetAll().ToList();
        }

        /// <summary>
        /// Método para crear Autor
        /// </summary>
        /// <param name="Autor"> Objeto con la información de autor </param>
        /// <returns></returns>
        public async Task CreateAutor(Autor autor)
        {
            await _unitOfWork.AutorRepository.Add(autor);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Método para obtener autor con id
        /// </summary>
        /// <param name="id"> Id property </param>
        /// <returns></returns>
        public Task<Autor> ObtenerAutor(int id)
        {
            return _unitOfWork.AutorRepository.GetById(id);
        }

        /// <summary>
        /// Método para consultar todos los registros de PropertyImage con paginación
        /// </summary>
        /// <param name="property"> Objeto property para actualizar </param>
        /// <returns> Retorna resutlado de operacion true o false</returns>
        public async Task<bool> ActualizarAutor(Autor autor)
        {
            var autorResultado = await _unitOfWork.AutorRepository.GetById(autor.Id);
            if (autorResultado != null)
            {
                autorResultado.Nombre = autor.Nombre;
                autorResultado.Apellidos = autor.Apellidos;                
                var actualizarAutor = await _unitOfWork.AutorRepository.UpdateAsync(autorResultado);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Método para eliminar Autor
        /// </summary>
        /// <param name="autor"> Objeto property a eliminar </param>
        /// <returns> Retorna resutlado de operacion true</returns>
        public async Task<bool> DeleteProperty(Autor autor)
        {
            await _unitOfWork.AutorRepository.DeleteAsync(autor);

            return true;
        }

    }
}
