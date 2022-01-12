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
    public class EditorialService : IEditorialService
    {
        private readonly IUnitOfWork _unitOfWork;

        #region Constructor
        public EditorialService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        /// <summary>
        /// Método para actualizar Editorial
        /// </summary>
        /// <param name="editorial">Objeto editorial para actualizar</param>
        /// <returns> Retorna resultado de operacion true o false</returns>
        public async Task<bool> ActualizarEditorial(Editorial editorial)
        {
            var editorialResultado = await _unitOfWork.EditorialRepository.GetById(editorial.Id);
            if (editorialResultado != null)
            {
                editorialResultado.Nombre = editorial.Nombre;
                editorialResultado.Sede = editorial.Sede;
                var actualizarEditorial = await _unitOfWork.EditorialRepository.UpdateAsync(editorialResultado);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Método para crear Autor
        /// </summary>
        /// <param name="Editorial"> Objeto con la información de editorial </param>
        /// <returns></returns>
        public async Task CrearEditorial(Editorial editorial)
        {
            await _unitOfWork.EditorialRepository.Add(editorial);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Método para obtener editorial con id
        /// </summary>
        /// <param name="id"> Id property </param>
        /// <returns></returns>
        public async Task<Editorial> ObtenerEditorial(int id)
        {
            return await this._unitOfWork.EditorialRepository.GetById(id);
        }

        /// <summary>
        /// Método para consultar todos los Editoriales
        /// </summary>
        /// <param> </param>
        /// <returns> Objeto paginado con el resultado de la consulta </returns>
        public async Task<List<Editorial>> ObtenerEditoriales()
        {
            return  this._unitOfWork.EditorialRepository.GetAll().ToList();
        }

        /// <summary>
        /// Método para eliminar Editorial
        /// </summary>
        /// <param name="autor"> Objeto Editorial a eliminar </param>
        /// <returns> Retorna resutlado de operacion true</returns>
        public async Task<bool> DeleteEditorial(Editorial editorial)
        {
            await _unitOfWork.EditorialRepository.DeleteAsync(editorial);

            return true;
        }
    }
}
